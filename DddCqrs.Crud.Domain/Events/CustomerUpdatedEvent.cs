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

    public class CustomerUpdatedEvent : DomainEventBase<CustomerId>
    {
        CustomerUpdatedEvent()
        {
        }

        internal CustomerUpdatedEvent(CustomerId aggregateId, long aggregateVersion, string firstName, string lastName,
            PhoneNumberValue phoneNumber, DateTime dateOfBirth, string email, string bankAccountNumber) : base(aggregateId)
        {
            CustomerId = aggregateId;
            Firstname = firstName;
            Lastname = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            BankAccountNumber = bankAccountNumber;
        }

        public CustomerId CustomerId { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public PhoneNumberValue PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string BankAccountNumber { get; private set; }

        public override IDomainEvent<CustomerId> WithAggregate(CustomerId aggregateId, long aggregateVersion)
        {
            return new CustomerUpdatedEvent(aggregateId, aggregateVersion, Firstname, Lastname, PhoneNumber, DateOfBirth, Email, BankAccountNumber);
        }
    }
}
