using DddCqrs.Crud.Application.Exceptions;
using DddCqrs.Crud.Application.Gateways.EventStoreRepositories;
using DddCqrs.Crud.Application.Gateways.ReadModelRepositories.Customer;
using DddCqrs.Crud.Application.Services.EventHandlers;
using DddCqrs.Crud.Application.Services.PubSub;
using DddCqrs.Crud.Domain.Enums;
using DddCqrs.Crud.Domain.Events;
using DddCqrs.Crud.Domain.ValueObjects;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Application.Features.Customers.Commands
{
    public sealed class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerDto>
    {
        private readonly ITransientDomainEventSubscriber _subscriber;
        private readonly IEnumerable<IDomainEventHandler<CustomerId, CustomerUpdatedEvent>> _customerUpdatedEventHandlers;
        private readonly ICustomerEventStoreRepository _customerEventStoreRepository;
        private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;
        public UpdateCustomerHandler(IEnumerable<IDomainEventHandler<CustomerId, CustomerUpdatedEvent>> customerUpdatedEventHandlers, 
            ICustomerEventStoreRepository customerEventStoreRepository, 
            ITransientDomainEventSubscriber subscriber, 
            ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            _customerUpdatedEventHandlers = customerUpdatedEventHandlers;
            _customerEventStoreRepository = customerEventStoreRepository;
            _subscriber = subscriber;
            _customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public async Task<UpdateCustomerDto> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customerId = new CustomerId(command.Id.ToString()); 
            
            if (await _customerReadOnlyRepository.AnyDuplicateEmailAsync(command.Email, customerId.ToString()))
            {
                throw new DuplicateEmailException();
            }

            if (await _customerReadOnlyRepository.AnyDuplicateIdentityAsync(command.FirstName, command.LastName,
                command.DateOfBirth, customerId.ToString()))
            {
                throw new DuplicateEmailException();
            }

            var customer = await _customerEventStoreRepository.GetByIdAsync(customerId);

            _subscriber.Subscribe<CustomerUpdatedEvent>(async @event =>
            {
                await EventSubscriber.HandleEnumerableAsync(_customerUpdatedEventHandlers, @event);
            });

            customer.Update(command.FirstName, command.LastName, command.PhoneNumber, 
                command.DateOfBirth, command.Email, command.BankAccountNumber);

            await _customerEventStoreRepository.SaveAsync(customer);

            return new UpdateCustomerDto(Status.Ok, "");
        }
    }
}