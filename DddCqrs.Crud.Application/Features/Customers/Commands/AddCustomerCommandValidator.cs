using FluentValidation;
using DddCqrs.Crud.Application.CustomValidations;

namespace DddCqrs.Crud.Application.Features.Customers.Commands
{
    public class AddCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerCommandValidator(ICustomerValidations customerValidations)
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