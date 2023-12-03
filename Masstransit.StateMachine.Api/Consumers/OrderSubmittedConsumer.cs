using MassTransit;
using Masstransit.StateMachine.Api.Events;

namespace Masstransit.StateMachine.Api.Consumers;

public class OrderSubmittedConsumer : IConsumer<SubmitOrder>
{
    public Task Consume(ConsumeContext<SubmitOrder> context)
    {
        Console.WriteLine($"Order {context.Message.OrderId} submitted");
        return Task.CompletedTask;
    }
}