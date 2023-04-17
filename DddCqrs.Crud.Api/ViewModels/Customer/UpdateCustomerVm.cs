using FluentValidation;
using DddCqrs.Crud.Application.CustomValidations;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Api.ViewModels.Customer
{
    public class UpdateCustomerVm
    {
        public string Id { get; set; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public DateTime DateOfBirth { get; init; }

        public string PhoneNumber { get; init; }

        public string Email { get; init; }

        public string BankAccountNumber { get; init; }
    }

    public class UpdateCustomerVmValidator : AbstractValidator<UpdateCustomerVm>
    {   
        public UpdateCustomerVmValidator(ICustomerValidations customerValidations)
        {
            RuleFor(command => command.PhoneNumber).Must(customerValidations.IsValidPhoneNumber)
                .WithMessage("Phone number is not valid!");

            RuleFor(command => command.Email).Must(customerValidations.IsValidMail)
                .WithMessage("Email is not valid!");

            RuleFor(command => command.BankAccountNumber).Must(customerValidations.IsValidBankAccount)
                .WithMessage("Bank account number is not valid!");

            RuleFor(command => command.FirstName).NotNull()
                .NotEmpty()
                .WithMessage("First name is not valid!");

            RuleFor(command => command.LastName).NotNull()
                .NotEmpty()
                .WithMessage("Last name is not valid!");

            RuleFor(command => command.DateOfBirth).NotNull()
                .NotEmpty()
                .WithMessage("Date of birth is not valid!");
            
        }

    }
}
