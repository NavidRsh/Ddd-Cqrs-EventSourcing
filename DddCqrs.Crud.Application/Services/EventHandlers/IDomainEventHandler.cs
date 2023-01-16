using DddCqrs.Crud.Domain.Interfaces;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Application.Services.EventHandlers
{
    public interface IDomainEventHandler<TAggregateId, TEvent>
        where TEvent: IDomainEvent<TAggregateId>
    {
        Task HandleAsync(TEvent @event);
    }
}
