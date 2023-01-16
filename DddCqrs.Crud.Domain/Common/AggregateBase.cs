using DddCqrs.Crud.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Domain.Common
{
    public class AggregateBase<TId> : IAggregate<TId>, IEventSourcingAggregate<TId>
    {
        public const long NewAggregateVersion = -1;

        private readonly ICollection<IDomainEvent<TId>> _uncommittedEvents = new LinkedList<IDomainEvent<TId>>();
        public TId Id { get; protected set; }

        private long _version = NewAggregateVersion;
        public long Version => _version;

        void IEventSourcingAggregate<TId>.ApplyEvent(IDomainEvent<TId> @event, long version)
        {
            if (!_uncommittedEvents.Any(x => Equals(x.EventId, @event.EventId)))
            {
                ((dynamic)this).Apply((dynamic)@event);
                _version = version;
            }
        }

        void IEventSourcingAggregate<TId>.ClearUncommittedEvents()
        {
            _uncommittedEvents.Clear();
        }

        IEnumerable<IDomainEvent<TId>> IEventSourcingAggregate<TId>.GetUncommittedEvents()
        {
            return _uncommittedEvents.AsEnumerable();
        }

        protected void RaiseEvent<TEvent>(TEvent @event)
            where TEvent : DomainEventBase<TId>
        {
            IDomainEvent<TId> eventWithAggregate = @event.WithAggregate(
                Equals(Id, default(TId)) ? @event.AggregateId : Id,
                _version);

            ((IEventSourcingAggregate<TId>)this).ApplyEvent(eventWithAggregate, _version + 1);
            _uncommittedEvents.Add(eventWithAggregate);
        }
    }
}
