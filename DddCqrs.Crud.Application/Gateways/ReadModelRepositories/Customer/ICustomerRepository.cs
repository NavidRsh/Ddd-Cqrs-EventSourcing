using DddCqrs.Crud.ReadDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Application.Gateways.ReadModelRepositories.Customer
{
    public interface ICustomerRepository : IRepository<CustomerReadEntity>
    {

    }
}
