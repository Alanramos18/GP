namespace Gp.Test.Repository.Repositories
{
    using Gp.Test.Api.DTO;
    using Gp.Test.Entity;
    using Gp.Test.Interface.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class TestRepository : BaseRepository<Personas>, ITestRepository
    {
        private readonly TestContext _dbContext;

        public TestRepository(TestContext context, IConfiguration configuration) : base(context)
        {
            _dbContext = context;
        }

        /// <inheritdoc />
        public Task<bool> CheckDuplicateAsync(string? name, string? dni, CancellationToken cancellationToken)
        {
            return _dbContext.Personas.AnyAsync(x => x.NombreCompleto.Equals(name) && x.Dni.Equals(dni), cancellationToken);
        }

        /// <inheritdoc />
        public IQueryable<Personas>? Search(SearchPersonasDTORequest filters)
        {
            var personas = from person in _dbContext.Personas
                           where (string.IsNullOrEmpty(filters.Id) || person.Id.Equals(Guid.Parse(filters.Id))) &&
                           (string.IsNullOrEmpty(filters.NombreCompleto) || person.NombreCompleto.Equals(filters.NombreCompleto)) &&
                           (string.IsNullOrEmpty(filters.Edad) || person.Edad.Equals(filters.Edad)) &&
                           (string.IsNullOrEmpty(filters.Domicilio) || person.Domicilio.Equals(filters.Domicilio)) &&
                           (string.IsNullOrEmpty(filters.Telefono) || person.Telefono.Equals(filters.Telefono)) &&
                           (string.IsNullOrEmpty(filters.Profesion) || person.Profesion.Equals(filters.Profesion))
                           select person;

            return personas;
        }
    }
}