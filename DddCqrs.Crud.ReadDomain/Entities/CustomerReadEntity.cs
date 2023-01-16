using DddCqrs.Crud.ReadDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.ReadDomain.Entities
{
    public class CustomerReadEntity : IReadEntity
    {
        private CustomerReadEntity(string id, string firstname, string lastname, DateTime dateOfBirth, ulong phoneNumber, string email, string bankAccountNumber)
        {
            Id = id; 
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }

        public CustomerReadEntity()
        {

        }

        public static CustomerReadEntity Create(string id, string firstname, string lastname, DateTime dateOfBirth, ulong phoneNumber, string email, string bankAccountNumber)
        {
            return new CustomerReadEntity(id, firstname, lastname, dateOfBirth, phoneNumber, email, bankAccountNumber); 
        }
        public void Update(string firstname, string lastname, ulong phoneNumber, DateTime dateOfBirth, string email, string bankAccountNumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Email = email;
            BankAccountNumber = bankAccountNumber; 
        }

        public string Id { get; }

        public string Firstname { get; private set; }
        public string Lastname { get; private set;  }
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



    }
}
