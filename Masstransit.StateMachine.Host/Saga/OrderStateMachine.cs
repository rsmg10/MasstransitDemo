using MassTransit;
using Masstransit.StateMachine.Host.Events;

namespace Masstransit.StateMachine.Host;

public class OrderStateMachine : MassTransitStateMachine<OrderStateInstance>
{
    public State Submitted { get; private set; }
    public State Accepted { get; private set; }
    public Event<SubmitOrder> SubmitOrder { get; private set; }
    public Event<OrderAccepted> OrderAccepted { get; private set; }
    
    public OrderStateMachine()
    {
        Event(() => SubmitOrder, x => x.CorrelateById(context => context.Message.OrderId));
        Event(() => OrderAccepted, x => x.CorrelateById(context => context.Message.OrderId));
        
        Initially(
            When(SubmitOrder)
                .TransitionTo(Submitted));

        During(Submitted,
            When(OrderAccepted)
                .TransitionTo(Accepted));
        
        
        InstanceState(x => x.CurrentState, Submitted, Accepted);
        // Initial(SubmitOrder);
        
    }
}