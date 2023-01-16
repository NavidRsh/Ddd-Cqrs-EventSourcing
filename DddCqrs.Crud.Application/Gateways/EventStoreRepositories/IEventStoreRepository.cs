using DddCqrs.Crud.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Application.Gateways.EventStoreRepositories
{
    public interface IEventStoreRepository<TAggregate, TAggregateId>
        where TAggregate : IAggregate<TAggregateId>
    {
        Task<TAggregate> GetByIdAsync(TAggregateId id);

        Task SaveAsync(TAggregate aggregate);
    }
}
