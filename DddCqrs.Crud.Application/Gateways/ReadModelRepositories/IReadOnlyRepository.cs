using DddCqrs.Crud.Application.Features.Customers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Application.Gateways.ReadModelRepositories
{
    public interface IReadOnlyRepository<T>
    {
        Task<List<ListCustomerQueryDtoItem>> FindAllAsync();

        ValueTask<T> GetByIdAsync(string id);
    }
}
