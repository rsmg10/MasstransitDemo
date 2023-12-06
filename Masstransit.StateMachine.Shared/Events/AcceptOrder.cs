using MassTransit;

namespace Masstransit.StateMachine.Shared.Events;

public class AcceptOrder : CorrelatedBy<Guid>
{
    public Guid OrderId { get; set; }
    public Guid CorrelationId { get; }
}