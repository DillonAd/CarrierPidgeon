namespace CarrierPidgeon.Core.Notifications
{
    public class Notification
    {
        public string ModuleName { get; }
        public string EventName { get; }
        public string Message { get; }

        public Notification(string moduleName, string eventName, string message)
        {
            ModuleName = moduleName;
            EventName = eventName;
            Message = message;
        }
    }
}