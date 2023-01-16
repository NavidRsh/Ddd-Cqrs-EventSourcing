namespace DddCqrs.Crud.Domain.Events
{
    using DddCqrs.Crud.Domain.Common;
    using DddCqrs.Crud.Domain.Interfaces;
    using DddCqrs.Crud.Domain.ValueObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CustomerDeletedEvent : DomainEventBase<CustomerId>
    {
        CustomerDeletedEvent()
        {
        }

        internal CustomerDeletedEvent(CustomerId aggregateId) : base(aggregateId)
        {
            CustomerId = aggregateId;
        }

        private CustomerDeletedEvent(CustomerId aggregateId, long aggregateVersion) : base(aggregateId, aggregateVersion)
        {
            CustomerId = aggregateId;
        }

        public CustomerId CustomerId { get; private set; }

        public override IDomainEvent<CustomerId> WithAggregate(CustomerId aggregateId, long aggregateVersion)
        {
            return new CustomerDeletedEvent(aggregateId, aggregateVersion);
        }
    }
}
