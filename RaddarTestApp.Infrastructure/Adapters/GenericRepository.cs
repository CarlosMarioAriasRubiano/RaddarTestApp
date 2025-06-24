using RaddarTestApp.Domain.Ports;
using RaddarTestApp.Infrastructure.Context;

namespace RaddarTestApp.Infrastructure.Adapters
{
    public class GenericRepository<E>(PersistenceContext context) : IGenericRepository<E>
        where E : Domain.Entities.Base.DomainEntity
    {
        private readonly PersistenceContext _context = context;

        public async Task<E> CreateAsync(E entity)
        {
            _context.Set<E>().Add(entity);
            await CommitAsync();
            return entity;
        }

        public async Task DeleteAsync(E entity)
        {
            _context.Set<E>().Remove(entity);
            await CommitAsync().ConfigureAwait(false);
        }

        public async Task<E> UpdateAsync(E entity)
        {
            _context.Set<E>().Update(entity);
            await CommitAsync();
            return entity;
        }

        public async Task CommitAsync()
        {
            _context.ChangeTracker.DetectChanges();

            await _context.CommitAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
