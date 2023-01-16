using DddCqrs.Crud.Application.Gateways.ReadModelRepositories.Customer;
using DddCqrs.Crud.Domain.Common;
using DddCqrs.Crud.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;


namespace DddCqrs.Crud.Application.Features.Customers.Queries
{    
    public sealed class GetCustomerQuery : IRequest<GetCustomerQueryDto>
    {
        public string Id { get; set; }
    }

    public sealed class GetCustomerQueryDto : ApplicationDto
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public GetCustomerQueryDto(Status status, string message = "") : base(status, message)
        {

        }
    }

}