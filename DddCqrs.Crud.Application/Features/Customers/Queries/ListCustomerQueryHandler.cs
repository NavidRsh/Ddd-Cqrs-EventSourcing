using DddCqrs.Crud.Application.Gateways.ReadModelRepositories.Customer;
using DddCqrs.Crud.Domain.Enums;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Application.Features.Customers.Queries
{
    public sealed class ListCustomerQueryHandler : IRequestHandler<ListCustomerQuery, ListCustomerQueryDto>
    {

        private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;
        public ListCustomerQueryHandler(ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            _customerReadOnlyRepository = customerReadOnlyRepository;
        }
        public async Task<ListCustomerQueryDto> Handle(ListCustomerQuery request, CancellationToken cancellationToken)
        {
            List<ListCustomerQueryDtoItem> list = await _customerReadOnlyRepository.FindAllAsync();

            return new ListCustomerQueryDto(Status.Ok)
            {
                List = list, 
                Count = list.Count
            };
        }
    }
}