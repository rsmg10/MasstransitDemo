using MassTransit;

namespace Masstransit.StateMachine.Shared.Events;

    public interface SubmitOrder : CorrelatedBy<Guid>
    {
        Guid OrderId { get; }    
    }
