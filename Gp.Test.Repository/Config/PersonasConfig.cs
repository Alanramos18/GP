using Gp.Test.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gp.Test.Repository.Config
{
    public class PersonasConfig
    {
        public PersonasConfig(EntityTypeBuilder<Personas> entityBuilder)
        {
            entityBuilder.HasKey(x => new { x.Id });
            entityBuilder.Property(x => x.NombreCompleto);
            entityBuilder.Property(x => x.Edad);
            entityBuilder.Property(x => x.Domicilio);
            entityBuilder.Property(x => x.Telefono);
            entityBuilder.Property(x => x.Profesion);
        }
    }
}
