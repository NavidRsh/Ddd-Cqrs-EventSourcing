using MapsterMapper;
using DddCqrs.Crud.Application.Gateways.EventStoreRepositories;
using DddCqrs.Crud.Application.Services.PubSub;
using DddCqrs.Crud.Domain.Aggregates;
using DddCqrs.Crud.Domain.Common;
using DddCqrs.Crud.Domain.Events;
using DddCqrs.Crud.Domain.Interfaces;
using DddCqrs.Crud.Domain.ValueObjects;
using DddCqrs.Crud.Persistence.EventStore.Ef.Helpers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Persistence.EventStore.Ef.Data.Repositories
{
    public class CustomerEventStoreRepository : ICustomerEventStoreRepository
    {
        private readonly CrudTestEventStoreContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ITransientDomainEventPublisher _publisher;
        public CustomerEventStoreRepository(CrudTestEventStoreContext dbContext, IMapper mapper, ITransientDomainEventPublisher publisher)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _publisher = publisher;
        }

        public async Task<Customer> GetByIdAsync(CustomerId id)
        {
            try
            {
                List<EventData> eventList = await _dbContext.Events
                    .Where(a => a.EntityId == id.IdAsString()).ToListAsync();

                Customer customer = new Customer(id);
                IEventSourcingAggregate<CustomerId> aggregatePersistence = customer;

                foreach (var @event in eventList)
                {
                    var domainEvent = Deserialize<CustomerId>(@event.Type, @event.Data); 

                    aggregatePersistence.ApplyEvent(domainEvent, 0);// @event.EventNumber);
                }
                return customer;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task SaveAsync(Customer aggregate)
        {
            IEventSourcingAggregate<CustomerId> aggregatePersistence = aggregate;

            foreach (var @event in aggregatePersistence.GetUncommittedEvents())
            {
                var eventData = new EventData(
                    @event.EventId,
                    @event.AggregateId.IdAsString(),
                    @event.GetType().AssemblyQualifiedName,
                    true,
                    Serialize(@event),
                    Encoding.UTF8.GetBytes("{}"));

                await _dbContext.Events.AddAsync(eventData);
                await _dbContext.SaveChangesAsync();

                await _publisher.PublishAsync(@event);
            }
            
            aggregatePersistence.ClearUncommittedEvents();
        }
       
        private IDomainEvent<TAggregateId> Deserialize<TAggregateId>(string eventType, byte[] data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { ContractResolver = new PrivateSetterContractResolver() };
            return (IDomainEvent<TAggregateId>)JsonConvert.DeserializeObject(Encoding.UTF8.GetString(data), Type.GetType(eventType), settings);
        }

        private byte[] Serialize<TAggregateId>(IDomainEvent<TAggregateId> @event)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));
        }
    }
}
