namespace Masstransit.StateMachine.Shared.Settings;

public class MessageBrokerPersistenceSettings
{
    public string Connection { get; set; }
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }
}