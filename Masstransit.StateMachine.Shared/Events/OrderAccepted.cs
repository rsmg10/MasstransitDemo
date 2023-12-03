using MassTransit;

namespace Masstransit.StateMachine.Shared.Events;

public interface OrderAccepted : CorrelatedBy<Guid>
{
    Guid OrderId { get; set; }
}