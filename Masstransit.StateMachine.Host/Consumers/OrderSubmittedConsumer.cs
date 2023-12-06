using MassTransit;
using Masstransit.StateMachine.Shared.Events;

namespace Masstransit.StateMachine.Host.Consumers;

public class OrderSubmittedConsumer : IConsumer<SubmitOrder>
{
    public Task Consume(ConsumeContext<SubmitOrder> context)
    {
        Console.WriteLine($"Order {context.Message.OrderId} submitted");
        return Task.CompletedTask;
    }
}