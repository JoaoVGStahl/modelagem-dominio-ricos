using PontoSysStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PontoSysStore.Core.Messages.CommonMessages.DomainEvents
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggreateId)
        {
            AggregateId = aggreateId;
        }
    }
}
