﻿using MassTransit;

namespace Masstransit.StateMachine.Host.Saga;

public class OrderStateInstance : SagaStateMachineInstance,ISagaVersion
{
    public Guid CorrelationId { get; set; }
    public int CurrentState { get; set; }
    public int Version { get; set; }
}