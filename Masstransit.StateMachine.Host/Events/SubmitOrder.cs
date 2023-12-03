namespace Masstransit.StateMachine.Host.Events;

    public interface SubmitOrder
    {
        Guid OrderId { get; }    
    }
