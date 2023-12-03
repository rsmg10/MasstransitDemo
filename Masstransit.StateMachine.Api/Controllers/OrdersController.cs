using MassTransit;
using Masstransit.StateMachine.Api.Events;
using Microsoft.AspNetCore.Mvc;

namespace Masstransit.StateMachine.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IRequestClient<SubmitOrder> _submitOrderClient;

    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(ILogger<OrdersController> logger, IRequestClient<SubmitOrder> submitOrderClient, IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _submitOrderClient = submitOrderClient;
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost(Name = "SubmitOrder")]
    public async Task<IActionResult> SubmitOrder()
    {
        await _publishEndpoint.Publish<SubmitOrder>(new
        {
            OrderId = Guid.NewGuid()
        });
    //
    // var order = await _submitOrderClient.Create(new
    //     {
    //         OrderId = Guid.NewGuid()
    //     }).GetResponse<SubmitOrder>();
    //     
        return Ok();    
    }
}