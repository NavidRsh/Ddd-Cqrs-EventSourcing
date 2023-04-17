using DddCqrs.Crud.Domain.Common;
using DddCqrs.Crud.Domain.Enums;
using MediatR;
using System;

namespace DddCqrs.Crud.Application.Features.Customers.Commands
{

    public sealed class AddCustomerCommand : IRequest<AddCustomerDto>
    {
        public string FirstName { get; init; } 

        public string LastName { get; init; }

        public DateTime DateOfBirth { get; init; }

        public string PhoneNumber { get; init; }

        public string Email { get; init; }

        public string BankAccountNumber { get; init; }
    }

    public sealed class AddCustomerDto : ApplicationDto
    {
        public Guid Id { get; init; }

        public AddCustomerDto(Status status, string message = null) : base(status, message)
        {
        }
    }

}