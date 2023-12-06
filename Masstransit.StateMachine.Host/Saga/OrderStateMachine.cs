using MassTransit;
using Masstransit.StateMachine.Shared.Events;

namespace Masstransit.StateMachine.Host.Saga;

public class OrderStateMachine : MassTransitStateMachine<OrderStateInstance>
{
    public State Submitted { get; private set; }
    public State Accepted { get; private set; }
    public Event<SubmitOrder> SubmitOrder { get; private set; }
    public Event<AcceptOrder> OrderAccepted { get; private set; }
    
    public OrderStateMachine()
    {
        Event(() => SubmitOrder, x => x.CorrelateById(x=> x.Message.OrderId));
        // Event(() => OrderAccepted, x => x.CorrelateById(context => context.Message.OrderId));
        
        InstanceState(x => x.CurrentState, Submitted, Accepted);
        Initially(
            When(SubmitOrder).Then(s =>
                {
                    Console.WriteLine("in the saga");
                })
                .RespondAsync(context =>
                {
                    var values = new SubmitOrderResponse
                        { OrderId = context.Saga.CorrelationId, Message = "Order Submitted" };
                    return context.Init<SubmitOrderResponse>(values);
                })
                // .Publish(r=>  new AcceptOrder())
                .TransitionTo(Submitted));
        
        During(Submitted, When(SubmitOrder)
            .TransitionTo(Accepted));
        // During(Submitted, When(OrderAccepted)
        //     .TransitionTo(Accepted));
 

        
        
        // During(Submitted,
        //     When(OrderAccepted)
        //         .TransitionTo(Accepted));
        
        
        // Initial(SubmitOrder);
        
    }
}
public class Order2
{
    public Order2(string message)
    {
        Message = message;
    }
    public Guid OrderId { get; set; }
    public string Message { get; set; }
}