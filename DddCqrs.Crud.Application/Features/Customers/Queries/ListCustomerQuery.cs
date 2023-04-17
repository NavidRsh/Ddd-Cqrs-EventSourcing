using DddCqrs.Crud.Application.Gateways.ReadModelRepositories.Customer;
using DddCqrs.Crud.Domain.Common;
using DddCqrs.Crud.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;


namespace DddCqrs.Crud.Application.Features.Customers.Queries
{    
    public sealed class ListCustomerQuery : IRequest<ListCustomerQueryDto>
    {
        
    }

    public sealed class ListCustomerQueryDto : ApplicationDto
    {
        public List<ListCustomerQueryDtoItem>? List { get; set; }
        public long Count { get; init; }
        public ListCustomerQueryDto(Status status, string message = "") : base(status, message)
        {

        }
    }

    public class ListCustomerQueryDtoItem
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }

}