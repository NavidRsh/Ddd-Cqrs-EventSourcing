using DddCqrs.Crud.Application.Features.Customers.Queries;
using DddCqrs.Crud.Application.Gateways.ReadModelRepositories.Customer;
using DddCqrs.Crud.ReadDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Persistence.ReadDomain.Ef.Data.Repositories
{
    public class CustomerReadOnlyRepository : ICustomerReadOnlyRepository
    {
        protected readonly CrudTestReadDomainContext _dbContext;
        public CustomerReadOnlyRepository(CrudTestReadDomainContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ListCustomerQueryDtoItem>> FindAllAsync()
        {
            return await _dbContext.Customers.Select(a => new ListCustomerQueryDtoItem() { 
                Id = a.Id,
                Firstname = a.Firstname,
                Lastname = a.Lastname,
                Email = a.Email,
                PhoneNumber = a.PhoneNumber,
                BankAccountNumber = a.BankAccountNumber,
                DateOfBirth = a.DateOfBirth
            }).ToListAsync(); 
        }

        public async ValueTask<CustomerReadEntity> GetByIdAsync(string id)
        {
            return await _dbContext.Customers.FindAsync(id); 
        }

        public async Task<bool> AnyDuplicateEmailAsync(string email, string id)
        {
            return await _dbContext.Customers.AnyAsync(a => a.Email == email && a.Id != id); 
        }

        public async Task<bool> AnyDuplicateIdentityAsync(string firstName, string lastName,
            DateTime dateOfBirth, string id)
        {
            return await _dbContext.Customers.AnyAsync(a => a.Firstname == firstName && a.Lastname == lastName &&
            a.DateOfBirth.Date == dateOfBirth.Date && a.Id != id); 
        }
    }
}
