
namespace Gp.EndPoint.Repository.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Gp.EndPoint.Entity;

    public class EndPointConfig
    {
        public EndPointConfig(EntityTypeBuilder<EndPoint> entityBuilder)
        {
            entityBuilder.HasKey(x => new { x.Id});
            entityBuilder.Property(x => x.UrlNamePrepaga).IsRequired();
            entityBuilder.Property(x => x.UrlNameCredito);
            entityBuilder.Property(x => x.Id_EntidadPrepaga).IsRequired();
            entityBuilder.Property(x => x.Id_EntidadCredito);
            entityBuilder.Property(x => x.Entorno);
        }
    }
}
