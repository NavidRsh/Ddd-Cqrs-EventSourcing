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

    public class CustomerCreatedEvent: DomainEventBase<CustomerId>
    {
        CustomerCreatedEvent()
        {
        }

        internal CustomerCreatedEvent(CustomerId aggregateId, long aggregateVersion, string firstName, string lastName,
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
        public string Lastname { get; }
        public DateTime DateOfBirth { get; }
        public PhoneNumberValue PhoneNumber { get; }
        public string Email { get; }
        public string BankAccountNumber { get; }        

        public override IDomainEvent<CustomerId> WithAggregate(CustomerId aggregateId, long aggregateVersion)
        {
            return new CustomerCreatedEvent(aggregateId, aggregateVersion, Firstname, Lastname, PhoneNumber, DateOfBirth, Email, BankAccountNumber);
        }
    }
}
