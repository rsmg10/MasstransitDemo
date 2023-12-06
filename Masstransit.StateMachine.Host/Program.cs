using MassTransit;
using Masstransit.StateMachine.Host.Consumers;
using Masstransit.StateMachine.Host.Saga;
using Microsoft.Extensions.Hosting;


Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<OrderSubmittedConsumer>();
            x.AddRequestClient<OrderSubmittedConsumer>();
            x.AddConsumer<OrderAcceptedConsumer>();
            x.AddRequestClient<OrderAcceptedConsumer>();
            x.AddSagaStateMachine<OrderStateMachine, OrderStateInstance>()
                .InMemoryRepository();
            //     .MongoDbRepository(r =>
            // {
            //     r.Connection = messageBrokerPersistenceSettings.Connection;
            //     r.DatabaseName = messageBrokerPersistenceSettings.DatabaseName;
            //     r.CollectionName = messageBrokerPersistenceSettings.CollectionName;
            // });
            
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                cfg.ConfigureEndpoints(context);
            });
            
            services.AddMassTransitHostedService();
        });
    }).Build().Run();