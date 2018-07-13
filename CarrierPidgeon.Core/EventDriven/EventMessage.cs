namespace CarrierPidgeon.Core.EventDriven
{
    public class EventMessage : IEntity
    {
        public object Content { get; set; }

        public EventMessage() { }

        public EventMessage(object content)
        {
            Content = content;
        }
    }
}
