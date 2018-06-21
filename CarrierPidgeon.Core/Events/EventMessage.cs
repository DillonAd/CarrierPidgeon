namespace CarrierPidgeon.Core.Events
{
    public class EventMessage
    {
        public object Content { get; set; }

        public EventMessage() { }

        public EventMessage(object content)
        {
            Content = content;
        }
    }
}
