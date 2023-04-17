using DddCqrs.Crud.Domain.Common;
using DddCqrs.Crud.Domain.Enums;
using MediatR;
using System;

namespace DddCqrs.Crud.Application.Features.Customers.Commands
{
    public sealed class UpdateCustomerCommand : IRequest<UpdateCustomerDto>
    {
        public string Id { get; init; }

        public string FirstName { get; init; } = null!;

        public string LastName { get; init; } = null!;

        public DateTime DateOfBirth { get; init; }

        public string PhoneNumber { get; init; }

        public string Email { get; init; }

        public string BankAccountNumber { get; init; }
    }

    public sealed class UpdateCustomerDto : ApplicationDto
    {
        public UpdateCustomerDto(Status status, string message = null) : base(status, message)
        {
        }
    }

}