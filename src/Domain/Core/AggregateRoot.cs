using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public abstract class AggregateRoot: Entity
    {
        protected ICollection<DomainEvent> _domainEvents = new HashSet<DomainEvent>();
        public IEnumerable<DomainEvent> DomainEvents => _domainEvents.ToList();

    }
}
