namespace RaddarTestApp.Domain.Ports
{
    public interface IGenericRepository<E> : IDisposable
        where E : Entities.Base.DomainEntity
    {
        Task<E> CreateAsync(E entity);
        Task<E> UpdateAsync(E entity);
        Task DeleteAsync(E entity);
    }
}
