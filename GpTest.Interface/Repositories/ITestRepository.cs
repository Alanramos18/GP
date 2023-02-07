using Gp.Test.Api.DTO;
using Gp.Test.Entity;

namespace Gp.Test.Interface.Repositories
{
    public interface ITestRepository : IBaseRepository<Personas>
    {
        /// <summary>
        ///     Check if email/dni combination is unique.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dni"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> CheckDuplicateAsync(string? name, string? dni, CancellationToken cancellationToken);

        /// <summary>
        ///     Returns a list of personas filtered.
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        IQueryable<Personas>? Search(SearchPersonasDTORequest filters);
    }
}
