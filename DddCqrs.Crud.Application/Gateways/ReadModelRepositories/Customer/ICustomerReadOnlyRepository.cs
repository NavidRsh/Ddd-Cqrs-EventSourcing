using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DddCqrs.Crud.ReadDomain.Entities; 

namespace DddCqrs.Crud.Application.Gateways.ReadModelRepositories.Customer
{
    public interface ICustomerReadOnlyRepository : IReadOnlyRepository<CustomerReadEntity>
    {
        Task<bool> AnyDuplicateEmailAsync(string email, string id);

        Task<bool> AnyDuplicateIdentityAsync(string firstName, string lastName,
            DateTime dateOfBirth, string id);
    }
}
