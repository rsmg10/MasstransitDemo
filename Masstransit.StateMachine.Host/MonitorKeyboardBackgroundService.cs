using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Masstransit.StateMachine.Host;

public class MonitorKeyboardBackgroundService : BackgroundService
{
    private readonly ILogger<MonitorKeyboardBackgroundService> _logger;

    public MonitorKeyboardBackgroundService(ILogger<MonitorKeyboardBackgroundService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (! stoppingToken.IsCancellationRequested)
        {
            await Task.Yield();

            var keyPressed = Console.ReadKey();

            if (keyPressed.Key != ConsoleKey.Escape)
            {
                _logger.LogInformation("Pressed Key {KeyPressed}", keyPressed.Key.ToString());
            }

            await Task.Delay(200);
        }
        
    }
}