using MassTransit;
using Masstransit.Demo.Masstransit.Add.Messages;
using Masstransit.Demo.Masstransit.Subtract.Messages;
using Microsoft.AspNetCore.Mvc; 

namespace Masstransit.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculateController : ControllerBase
{
 

    private readonly IRequestClient<AddMessage> _requestClient;

    public CalculateController(IRequestClient<AddMessage> requestClient)
    {
        _requestClient = requestClient;
    }

    [HttpGet(Name = "AddNumbers")]
    public async Task<IActionResult> AddNumbers(double first, double second)
    {
        var create = _requestClient.Create(new AddMessage
        {
            First = first,
            Second = second
        });
        var sum = await create.GetResponse<SubtractMessageResponse>();
        
        return Ok(sum.Message);
    }
}