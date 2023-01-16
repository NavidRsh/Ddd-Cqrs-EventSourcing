using FluentValidation;

namespace DddCqrs.Crud.Application.Features.Customers.Commands
{ 
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(command => command.Id).NotNull().NotEmpty()
                .WithMessage("");
        }
    }
}