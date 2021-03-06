using System;
using System.Collections.Generic;
using System.Text;

namespace PontoSysStore.Core.Messages
{
    public abstract class Message
    {
        public string MessageType { get; set; }
        public Guid AggregateId { get; set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
