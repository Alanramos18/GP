namespace Gp.EndPoint.Repository
{
    using APAR.Client;
    using Gp.EndPoint.Entity;
    using Gp.EndPoint.Interface.Repositories;
    using Gp.EndPoint.Repository.Context;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EndPointRepository : IEndPointRepository
    {
        IConfiguration configuration;
     
        private readonly EndPointContext _dbContext;

        public EndPointRepository(EndPointContext context, IConfiguration configuration)
        {
            _dbContext = context;
            this.configuration = configuration;
        }
      
        public async Task<EndPoint> AddAsync(EndPoint endPoint)
        {
            try
            {
                _dbContext.endPoints.Add(endPoint);
                await _dbContext.SaveChangesAsync();
                return endPoint;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<int> DeleteAsync(EndPoint endPoint)
        {
            try
            {
                _dbContext.endPoints.Remove(endPoint);
                await _dbContext.SaveChangesAsync();
                return endPoint.Id != default(Guid) ? int.Parse(endPoint.Id.ToString()) : 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICollection<EndPoint>? GetAllEndPoint(List<Func<EndPoint, bool>> endPointFiltros)
        {
            var endPointsList = default(IEnumerable<EndPoint>?);   
            foreach (var endPoint in endPointFiltros)
            {
                endPointsList = _dbContext.endPoints.Where(endPoint).Where(endPoint => endPoint.Entorno == configuration.GetSection("ambiente").Value);
            }

            return endPointsList?.ToList().Count > 0 ? endPointsList.ToList() : _dbContext.endPoints.ToList();
        }

        public ICollection<Gp.EndPoint.Entity.Entidades>? GetAllEntidades()
        {
            string endPoint_ = configuration.GetSection("urlAPAR").Value;
            APARClient client = new APARClient(new Uri(endPoint_));
            ObtenerToken.configuration = configuration;
            var entidades = client.Entidades.GetEntidades(Token: ObtenerToken.Token);
            return entidades.Select(i => ToEntidad(i)).ToList();
        }

        private Gp.EndPoint.Entity.Entidades ToEntidad(APAR.Client.Models.EntidadDTO entidad)
        {
            return new Gp.EndPoint.Entity.Entidades
            {
                IdEntidad = entidad.IdEntidad,
                Descripcion = entidad.Descripcion
            };
        }
    }
}