using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Domain.Core
{
    public abstract class DomainEvent : INotification
    {
        public EventType EventId { get; set; }
    }

    public enum EventType
    {
        Internal,
        External
    }
}
