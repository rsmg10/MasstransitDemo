namespace Masstransit.StateMachine.Host.Events;

public interface OrderAccepted
{
    Guid OrderId { get; set; }
}