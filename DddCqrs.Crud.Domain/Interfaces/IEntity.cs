namespace DddCqrs.Crud.Domain.Interfaces
{
    public interface IEntity<out TKey> where TKey : struct
    {
        TKey Id { get; }
    }
}