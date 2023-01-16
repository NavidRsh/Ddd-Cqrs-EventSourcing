namespace DddCqrs.Crud.Domain.Aggregates
{
    using DddCqrs.Crud.Domain.Common;
    using DddCqrs.Crud.Domain.Events;
    using DddCqrs.Crud.Domain.ValueObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Customer : AggregateBase<CustomerId>
    {
        public Customer()
        {

        }
        public Customer(CustomerId customerId)
        {
            Id = new CustomerId(customerId.Id.ToString());
        }
        public Customer(CustomerId customerId, string firstname, string lastname, ulong phoneNumber, DateTime dateOfBirth, string email, string bankAccountNumber)
        {
            if (customerId == null)
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            if (string.IsNullOrEmpty(firstname))
            {
                throw new ArgumentNullException("First Name should not be empty!"); 
            }

            if (string.IsNullOrEmpty(lastname))
            {
                throw new ArgumentException("Last Name should not be empty!"); 
            }

            RaiseEvent(new CustomerCreatedEvent(customerId, Version, firstname, lastname, phoneNumber, dateOfBirth, email, bankAccountNumber));
        }

        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        /// <summary>
        /// I chose ulong over varchar since ulong takes 8 bytes 
        /// but varchar takes 1 for each character plus two for overhead 
        /// (usually phone numbers should be stored as string since there is 
        /// formatting and some non-numeral characters but here storage takes priority)
        /// </summary>
        public ulong PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string BankAccountNumber { get; private set; }

        public bool Activated { get; private set; }

        public void Update(string firstname, string lastname, ulong phoneNumber, DateTime dateOfBirth, string email, string bankAccountNumber)
        {
            RaiseEvent(new CustomerUpdatedEvent(Id, Version, firstname, lastname, phoneNumber, 
                dateOfBirth, email, bankAccountNumber));
        }

        public void Delete()
        {
            RaiseEvent(new CustomerDeletedEvent(Id));
        }

        public void Apply(CustomerCreatedEvent ev)
        {
            Id = ev.AggregateId;
            Firstname = ev.Firstname;
            Lastname = ev.Lastname;
            Email = ev.Email;
            PhoneNumber = ev.PhoneNumber;
            BankAccountNumber = ev.BankAccountNumber;
            DateOfBirth = ev.DateOfBirth;
        }

        public void Apply(CustomerUpdatedEvent ev)
        {
            Firstname = ev.Firstname;
            Lastname = ev.Lastname;
            Email = ev.Email;
            PhoneNumber = ev.PhoneNumber;
            BankAccountNumber = ev.BankAccountNumber;
            DateOfBirth = ev.DateOfBirth;
        }

        public void Apply(CustomerDeletedEvent ev)
        {
            Activated = false;
        }
    }
}
