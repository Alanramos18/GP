namespace Gp.Test.Repository
{
    using Gp.Test.Entity;
    using Gp.Test.Interface.Repositories;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;

    public class TestRepository : ITestRepository
    {
        IConfiguration configuration;
        private readonly TestContext _dbContext;
     
        public TestRepository(TestContext context, IConfiguration configuration)
        {
            _dbContext = context;
            this.configuration = configuration;
        }

        ICollection<Personas>? ITestRepository.GetAll()
        {
            return _dbContext.Personas.ToList();
        }
    }
}