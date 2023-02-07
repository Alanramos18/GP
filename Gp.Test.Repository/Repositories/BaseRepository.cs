using Gp.Test.Entity;
using Gp.Test.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gp.Test.Repository.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private readonly TestContext _context;
        internal DbSet<T>? _dbSet;

        protected BaseRepository(TestContext chatContext)
        {
            _context = chatContext;
            this._dbSet = (_context as DbContext)?.Set<T>();
        }

        /// <inheritdoc />
        public IQueryable<T>? GetAll()
        {
            return _context.Set<T>();
        }

        /// <inheritdoc />
        public virtual async Task<T> GetByIdAsync(Guid entityId, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FindAsync(new object[] { entityId }, cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
        }

        /// <inheritdoc />
        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        /// <inheritdoc />
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                await (_context as DbContext).SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
