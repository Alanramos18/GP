using Gp.Test.Entity;

namespace Gp.Test.Interface.Repositories
{
    public interface ITestRepository
    {
        ICollection<Personas>? GetAll();
    }   
}
