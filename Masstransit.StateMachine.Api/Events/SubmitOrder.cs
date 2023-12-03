using MassTransit;

namespace Masstransit.StateMachine.Api.Events;

    public interface SubmitOrder : CorrelatedBy<Guid>
    {
        Guid OrderId { get; }    
    }
