using DddCqrs.Crud.Application.Gateways.ReadModelRepositories.Customer;
using DddCqrs.Crud.Domain.Aggregates;
using DddCqrs.Crud.Domain.Enums;
using DddCqrs.Crud.Domain.ValueObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Application.Features.Customers.Queries
{
    public sealed class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerQueryDto>
    {

        private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;
        public GetCustomerQueryHandler(ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            _customerReadOnlyRepository = customerReadOnlyRepository;
        }
        public async Task<GetCustomerQueryDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerReadOnlyRepository
                .GetByIdAsync(new CustomerId(request.Id).ToString());

            return new GetCustomerQueryDto(Status.Ok)
            {
                Id = customer.Id,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                BankAccountNumber = customer.BankAccountNumber,
                Email = customer.Email,
                DateOfBirth = customer.DateOfBirth,
                PhoneNumber = customer.PhoneNumber
            };
        }
    }
}