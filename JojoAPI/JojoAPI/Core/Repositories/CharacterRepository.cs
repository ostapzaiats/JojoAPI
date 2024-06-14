using JojoAPI.Core.Interfaces;
using JojoAPI.Data;
using JojoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace JojoAPI.Core.Repositories
{
    public class CharacterRepository : GenericRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(ApiDbContext context, ILogger logger) : base(context, logger) { }

        public override async Task<IEnumerable<Character>> GetAll()
        {
            return await dbSet.Include(x => x.Stand).ToListAsync();
        }

        public async Task<Character?> GetByName(string name)
        {
            return await dbSet.AsNoTracking().Include(x => x.Stand).FirstOrDefaultAsync(x => x.Name == name);
        }

        public async override Task<Character?> GetById(int id)
        {
            return await dbSet.AsNoTracking().Include(x => x.Stand).FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Character?> GetByNameAndSurname(string name, string surname)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name && x.Surname == surname);
        }

        public override async Task<bool> Add(Character entity)
        {
            if (entity.Stand != null)
            {
                var standId = entity.Stand?.Id;
                entity.Stand = context.Stands.SingleOrDefault(x => x.Id == standId);
            }

            dbSet.Add(entity);
            return true;
        }
    }
}
