using DddCqrs.Crud.Domain.Aggregates;
using DddCqrs.Crud.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Application.Gateways.EventStoreRepositories
{
    public interface ICustomerEventStoreRepository : IEventStoreRepository<Customer, CustomerId>
    {

    }
}
