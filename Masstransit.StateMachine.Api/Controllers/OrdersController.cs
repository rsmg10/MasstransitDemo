using MassTransit;
using Masstransit.StateMachine.Shared.Events;
using Microsoft.AspNetCore.Mvc;

namespace Masstransit.StateMachine.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IRequestClient<SubmitOrder> _submitOrderClient;

    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IRequestClient<SubmitOrder> _requestClient;
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(ILogger<OrdersController> logger, IRequestClient<SubmitOrder> submitOrderClient, IPublishEndpoint publishEndpoint, IRequestClient<SubmitOrder> requestClient)
    {
        _logger = logger;
        _submitOrderClient = submitOrderClient;
        _publishEndpoint = publishEndpoint;
        _requestClient = requestClient;
    }

    [HttpPost(Name = "SubmitOrder")]
    public async Task<IActionResult> SubmitOrder()
    {
        var values = new SubmitOrder() { OrderId = Guid.NewGuid(), CorrelationId = Guid.NewGuid() };
        // await _publishEndpoint.Publish<SubmitOrder>(values);


        Console.WriteLine("about to create order");
    var order = await _requestClient.Create(values).GetResponse<SubmitOrderResponse>();
        
     Console.WriteLine(order.Message.Message);
        return Ok();    
    }
}