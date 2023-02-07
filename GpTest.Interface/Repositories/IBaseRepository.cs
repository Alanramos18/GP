namespace Gp.Test.Interface.Repositories
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        ///     Get All entities.
        /// </summary>
        IQueryable<T>? GetAll();

        /// <summary>
        ///     Gets the specific entity.
        /// </summary>
        /// <param name="entityId">Id of the entity</param>
        /// <param name="cancellationToken">Cancellation Transaction Token</param>
        /// <returns></returns>
        Task<T> GetByIdAsync(Guid entityId, CancellationToken cancellationToken);

        /// <summary>
        ///     Adds the specific entity.
        /// </summary>
        /// <param name="entity">Entity to be added</param>
        /// <param name="cancellationToken">Cancellation Transaction Token</param>
        Task AddAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        ///     Updates an entity.
        /// </summary>
        /// <param name="entity">Entity to be updated</param>
        void Update(T entity);

        /// <summary>
        ///     Saves whatever entities have been added to the unit of work.
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="cancellationToken">Cancellation Transaction Token</param>
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }   
}
