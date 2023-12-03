using MassTransit;
using Masstransit.StateMachine.Api.Events;

namespace Masstransit.StateMachine.Api.Saga;

public class OrderStateMachine : MassTransitStateMachine<OrderStateInstance>
{
    public State Submitted { get; private set; }
    public State Accepted { get; private set; }
    public Event<SubmitOrder> SubmitOrder { get; private set; }
    // public Event<OrderAccepted> OrderAccepted { get; private set; }
    
    public OrderStateMachine()
    {
        Event(() => SubmitOrder, x => x.CorrelateById(x=> x.Message.OrderId));
        // Event(() => OrderAccepted, x => x.CorrelateById(context => context.Message.OrderId));
        
        InstanceState(x => x.CurrentState, Submitted, Accepted);
        Initially(
            When(SubmitOrder)
                .TransitionTo(Submitted));
        //
        // During(Submitted,
        //     When(OrderAccepted)
        //         .TransitionTo(Accepted));
        
        
        // Initial(SubmitOrder);
        
    }
}