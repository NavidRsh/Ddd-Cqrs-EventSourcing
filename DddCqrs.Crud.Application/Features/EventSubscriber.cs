namespace DddCqrs.Crud.Application.Features
{
    using DddCqrs.Crud.Application.Services.EventHandlers;
    using DddCqrs.Crud.Domain.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EventSubscriber
    {
        public static async Task HandleEnumerableAsync<TId, TEvent>(IEnumerable<IDomainEventHandler<TId, TEvent>> handlers, TEvent @event)
          where TEvent : IDomainEvent<TId>
        {
            foreach (var handler in handlers)
            {
                await handler.HandleAsync(@event);
            }
        }
    }
}
