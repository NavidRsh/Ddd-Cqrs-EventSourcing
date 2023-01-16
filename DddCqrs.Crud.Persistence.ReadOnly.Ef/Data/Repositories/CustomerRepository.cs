using DddCqrs.Crud.Application.Gateways.ReadModelRepositories.Customer;
using DddCqrs.Crud.Domain.Common;
using DddCqrs.Crud.ReadDomain.Entities;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Persistence.ReadDomain.Ef.Data.Repositories
{
    public class CustomerRepository : CustomerReadOnlyRepository, ICustomerRepository
    {
        public CustomerRepository(CrudTestReadDomainContext dbContext): base(dbContext)
        {

        }

        public async Task InsertAsync(CustomerReadEntity entity)
        {
            await _dbContext.Customers.AddAsync(entity);

            await _dbContext.SaveChangesAsync(); 
        }

        public async Task UpdateAsync(CustomerReadEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified; 

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(CustomerReadEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();
        }
    }
}
