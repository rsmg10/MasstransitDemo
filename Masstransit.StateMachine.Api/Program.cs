using MassTransit;
using Masstransit.StateMachine.Api.Consumers;
using Masstransit.StateMachine.Api.Events;
using Masstransit.StateMachine.Api.Saga;
using StateMachineSample.StateMachine.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var messageBrokerQueueSettings = builder.Configuration.GetSection("MessageBroker:QueueSettings").Get<MessageBrokerQueueSettings>(); 
var messageBrokerPersistenceSettings = builder.Configuration.GetSection("MessageBroker:StateMachinePersistence").Get<MessageBrokerPersistenceSettings>(); 

// Add services to the container.
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<OrderSubmittedConsumer>();
    x.AddRequestClient<OrderSubmittedConsumer>();
    x.AddConsumer<OrderAcceptedConsumer>();
    x.AddRequestClient<OrderAcceptedConsumer>();
    // x.AddSagaStateMachine<OrderStateMachine, OrderStateInstance>();
    x.AddSagaStateMachine<OrderStateMachine, OrderStateInstance>() .InMemoryRepository();
    //     .MongoDbRepository(r =>
    // {
    //     r.Connection = messageBrokerPersistenceSettings.Connection;
    //     r.DatabaseName = messageBrokerPersistenceSettings.DatabaseName;
    //     r.CollectionName = messageBrokerPersistenceSettings.CollectionName;
    // });
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(messageBrokerQueueSettings.HostName, messageBrokerQueueSettings.VirtualHost, h =>
        {
            h.Username(messageBrokerQueueSettings.UserName);
            h.Password(messageBrokerQueueSettings.Password);
        });
                
        cfg.ConfigureEndpoints(context);
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();