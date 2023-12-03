using MassTransit;

namespace Masstransit.StateMachine.Shared.Saga;

public class OrderStateInstance : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public int CurrentState { get; set; }
}