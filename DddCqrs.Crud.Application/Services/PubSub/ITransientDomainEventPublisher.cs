using System.Threading.Tasks;

namespace DddCqrs.Crud.Application.Services.PubSub
{
    public interface ITransientDomainEventPublisher
    {
        Task PublishAsync<T>(T publishedEvent);
    }
}