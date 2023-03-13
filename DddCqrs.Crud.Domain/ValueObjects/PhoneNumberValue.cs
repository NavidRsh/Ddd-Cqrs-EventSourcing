using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Domain.ValueObjects
{
    public record PhoneNumberValue
    {
        private const int MinLengthAttribute = 7; 

        private PhoneNumberValue(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
        public static PhoneNumberValue? Create(string phoneNumber)
        {
            if (phoneNumber.Length < 7)
                return null; 

            return new PhoneNumberValue(phoneNumber); 
        }
        public string PhoneNumber { get; }
    }
}
