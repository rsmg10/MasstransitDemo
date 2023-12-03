using MassTransit;

namespace Masstransit.StateMachine.Host;

public class OrderStateInstance : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public int CurrentState { get; set; }
}