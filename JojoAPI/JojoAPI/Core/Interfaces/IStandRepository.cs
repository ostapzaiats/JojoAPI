using JojoAPI.Model;

namespace JojoAPI.Core.Interfaces
{
    public interface IStandRepository : IGenericRepository<Stand>
    {
        Task<Stand?> GetByName(string name);
    }
}
