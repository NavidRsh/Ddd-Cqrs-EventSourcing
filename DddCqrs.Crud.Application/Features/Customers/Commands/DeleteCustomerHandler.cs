using DddCqrs.Crud.Application.Gateways.EventStoreRepositories;
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
    public sealed class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerDto>
    {
        private readonly ITransientDomainEventSubscriber _subscriber;
        private readonly IEnumerable<IDomainEventHandler<CustomerId, CustomerDeletedEvent>> _customerDeletedEventHandlers;
        private readonly ICustomerEventStoreRepository _customerEventStoreRepository;
        public DeleteCustomerHandler(ITransientDomainEventSubscriber subscriber,
                                     IEnumerable<IDomainEventHandler<CustomerId, CustomerDeletedEvent>> customerDeletedEventHandlers,
                                     ICustomerEventStoreRepository customerEventStoreRepository)
        {
            _subscriber = subscriber;
            _customerDeletedEventHandlers = customerDeletedEventHandlers;
            _customerEventStoreRepository = customerEventStoreRepository;
        }

        public async Task<DeleteCustomerDto> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = await _customerEventStoreRepository.GetByIdAsync(new CustomerId(command.Id.ToString()));

            _subscriber.Subscribe<CustomerDeletedEvent>(async @event =>
            {
                await EventSubscriber.HandleEnumerableAsync(_customerDeletedEventHandlers, @event);
            });

            customer.Delete();

            await _customerEventStoreRepository.SaveAsync(customer);

            return new DeleteCustomerDto(Status.Ok, "");
        }
    }
}