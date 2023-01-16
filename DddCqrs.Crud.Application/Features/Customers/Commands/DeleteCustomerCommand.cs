using DddCqrs.Crud.Domain.Common;
using DddCqrs.Crud.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;

namespace DddCqrs.Crud.Application.Features.Customers.Commands
{
    public sealed class DeleteCustomerCommand : IRequest<DeleteCustomerDto>
    {
        public string Id { get; init; }
    }

    public sealed class DeleteCustomerDto : ApplicationDto
    {
        public DeleteCustomerDto(Status status, string message = null) : base(status, message)
        {
        }
    }
}
