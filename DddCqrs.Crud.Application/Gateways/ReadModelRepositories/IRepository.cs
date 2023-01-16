using DddCqrs.Crud.ReadDomain.Common;
using DddCqrs.Crud.ReadDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Application.Gateways.ReadModelRepositories
{
    public interface IRepository<T> : IReadOnlyRepository<T>
        where T : IReadEntity
    {
        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task Delete(T entity); 
    }
}
