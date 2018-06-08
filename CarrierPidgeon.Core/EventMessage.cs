using System;
using System.Collections.Generic;
using System.Text;

namespace CarrierPidgeon.Core
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
