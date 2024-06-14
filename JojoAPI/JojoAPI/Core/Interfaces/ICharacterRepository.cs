using JojoAPI.Model;

namespace JojoAPI.Core.Interfaces
{
    public interface ICharacterRepository : IGenericRepository<Character>
    {
        Task<Character?> GetByName(string name);
        Task<Character?> GetByNameAndSurname(string name, string surname);
    }
}
