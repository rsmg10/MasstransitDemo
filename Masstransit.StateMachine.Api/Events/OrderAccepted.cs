using MassTransit;

namespace Masstransit.StateMachine.Api.Events;

public interface OrderAccepted : CorrelatedBy<Guid>
{
    Guid OrderId { get; set; }
}