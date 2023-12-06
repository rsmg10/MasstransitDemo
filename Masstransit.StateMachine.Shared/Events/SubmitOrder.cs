using MassTransit;

namespace Masstransit.StateMachine.Shared.Events;

    public class SubmitOrder : CorrelatedBy<Guid>
    {
        public Guid OrderId { get; set; }
        public Guid CorrelationId { get; set;}
    }
    public class SubmitOrderResponse : CorrelatedBy<Guid>
    {
        public SubmitOrderResponse()
        {
            
        }
        // public SubmitOrderResponse(Guid contextCorrelationId, string message)
        // {
        //     OrderId = contextCorrelationId;
        //     Message = message;
        // }

        public Guid OrderId { get; set; }
        public string Message { get; set; }
        public Guid CorrelationId { get; set;}
    }
