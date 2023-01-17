using DddCqrs.Crud.Application.Gateways.EventStoreRepositories;
using DddCqrs.Crud.Application.Services.EventHandlers;
using DddCqrs.Crud.Application.Services.PubSub;
using DddCqrs.Crud.Domain.Aggregates;
using DddCqrs.Crud.Domain.Enums;
using DddCqrs.Crud.Domain.Events;
using DddCqrs.Crud.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using DddCqrs.Crud.Application.Gateways.ReadModelRepositories.Customer;
using DddCqrs.Crud.Application.Exceptions;
using DddCqrs.Crud.Domain.ValueObjects;

namespace DddCqrs.Crud.Application.Features.Customers.Commands
{
    public sealed class AddCustomerHandler : IRequestHandler<AddCustomerCommand, AddCustomerDto>
    {
        private readonly ITransientDomainEventSubscriber _subscriber;
        private readonly IEnumerable<IDomainEventHandler<CustomerId, CustomerCreatedEvent>> _customerCreatedEventHandlers;
        private readonly ICustomerEventStoreRepository _customerEventStoreRepository;
        private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;
        public AddCustomerHandler(ITransientDomainEventSubscriber subscriber,
                                  IEnumerable<IDomainEventHandler<CustomerId, CustomerCreatedEvent>> customerCreatedEventHandlers,
                                  ICustomerEventStoreRepository customerEventStoreRepository,
                                  ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            _subscriber = subscriber;
            _customerCreatedEventHandlers = customerCreatedEventHandlers;
            _customerEventStoreRepository = customerEventStoreRepository;
            _customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public async Task<AddCustomerDto> Handle(AddCustomerCommand command, CancellationToken cancellationToken)
        {
            if (await _customerReadOnlyRepository.AnyDuplicateEmailAsync(command.Email, ""))
            {
                throw new DuplicateEmailException(); 
            }

            if (await _customerReadOnlyRepository.AnyDuplicateIdentityAsync(command.FirstName, command.LastName,
                command.DateOfBirth, ""))
            {
                throw new DuplicateEmailException();
            }

            var customer = new Customer(CustomerId.NewCustomerId(), command.FirstName, 
                command.LastName, command.PhoneNumber, command.DateOfBirth, command.Email, command.BankAccountNumber);

            _subscriber.Subscribe<CustomerCreatedEvent>(async @event =>            
            {
                await EventSubscriber.HandleEnumerableAsync(_customerCreatedEventHandlers, @event);
            });

            await _customerEventStoreRepository.SaveAsync(customer);

            return new AddCustomerDto(Status.Ok, "")
            {
                Id = customer.Id.Id
            };
        }       
    }
}