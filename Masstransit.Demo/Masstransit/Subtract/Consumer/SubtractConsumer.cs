using MassTransit;
using Masstransit.Demo.Masstransit.Subtract.Messages;

namespace Masstransit.Demo.Masstransit.Subtract.Consumer;

public class SubtractConsumer : IConsumer<SubtractMessage>
{
    public Task Consume(ConsumeContext<SubtractMessage> context)
    {
        var messageSecond = context.Message.First - context.Message.Second;
        
        context.Respond(new SubtractMessageResponse()
        {
            Subtracted = messageSecond
        });
        return Task.CompletedTask;
    }
    
}

class SubtractConsumerDefinition : ConsumerDefinition<SubtractConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<SubtractConsumer> consumerConfigurator)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;
        
        base.ConfigureConsumer(endpointConfigurator, consumerConfigurator);
    }

 
}