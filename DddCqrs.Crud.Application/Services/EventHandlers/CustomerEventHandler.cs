using DddCqrs.Crud.Application.Gateways.ReadModelRepositories.Customer;
using DddCqrs.Crud.Domain.Events;
using DddCqrs.Crud.Domain.ValueObjects;
using DddCqrs.Crud.ReadDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Application.Services.EventHandlers
{
    public class CustomerEventHandler : IDomainEventHandler<CustomerId, CustomerCreatedEvent>,
        IDomainEventHandler<CustomerId, CustomerUpdatedEvent>,
        IDomainEventHandler<CustomerId, CustomerDeletedEvent>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerEventHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task HandleAsync(CustomerCreatedEvent @event)
        {
            await _customerRepository.InsertAsync(CustomerReadEntity.Create(@event.CustomerId.IdAsString(), 
                @event.Firstname, @event.Lastname, @event.DateOfBirth, @event.PhoneNumber, @event.Email, @event.BankAccountNumber));
        }

        public async Task HandleAsync(CustomerUpdatedEvent @event)
        {
            var customer = await _customerRepository.GetByIdAsync(@event.CustomerId.IdAsString());

            customer.Update(@event.Firstname, @event.Lastname, @event.PhoneNumber, @event.DateOfBirth,
                @event.Email, @event.BankAccountNumber);

            await _customerRepository.UpdateAsync(customer); 
        }

        public async Task HandleAsync(CustomerDeletedEvent @event)
        {
            var customer = await _customerRepository.GetByIdAsync(@event.CustomerId.IdAsString());

            await _customerRepository.Delete(customer);
        }
    }
}
