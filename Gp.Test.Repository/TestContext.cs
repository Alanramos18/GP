using Gp.Test.Entity;
using Gp.Test.Repository.Config;
using Microsoft.EntityFrameworkCore;

namespace Gp.Test.Repository
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new PersonasConfig(builder.Entity<Personas>());
        }

        public DbSet<Personas> Personas { get; set; } = default!;
    }
}
