// See https://aka.ms/new-console-template for more information

using MassTransit;
using Masstransit.StateMachine.Host;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder();

builder.Services.AddHostedService<MonitorKeyboardBackgroundService>();

builder.Services.AddMassTransit(x =>
{
    x.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

app.Run();

Console.WriteLine("Hello, World!");