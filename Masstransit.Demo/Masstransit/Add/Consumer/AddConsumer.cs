using MassTransit;
using Masstransit.Demo.Masstransit.Subtract.Messages;
using AddMessage = Masstransit.Demo.Masstransit.Add.Messages.AddMessage;

namespace Masstransit.Demo.Masstransit.Add.Consumer;

public class AddConsumer : IConsumer<AddMessage>
{
    private readonly IBus _bus;

    public AddConsumer(IBus bus)
    {
        _bus = bus;
    }
    public Task Consume(ConsumeContext<AddMessage> context)
    {
        var messageSecond = context.Message.First + context.Message.Second;
        var subtractMessage = new SubtractMessage()
        {
            First = messageSecond,
            Second = context.Message.Second
        };
        // var s = context.Send<SubtractMessageResponse>(subtractMessage);
        var res = context.CreateRequestClient<SubtractMessage>(_bus).Create(subtractMessage).GetResponse<SubtractMessageResponse>().ConfigureAwait(false).GetAwaiter().GetResult();
        context.Respond(res.Message);
        // context.Respond(new SubtractMessageResponse()
        // {
        //     Subtracted = messageSecond
        // });
        return Task.CompletedTask;
    }
}