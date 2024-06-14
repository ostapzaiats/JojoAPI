using JojoAPI.Core.Interfaces;
using JojoAPI.Data;
using JojoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace JojoAPI.Core.Repositories
{
    public class StandRepository : GenericRepository<Stand>, IStandRepository
    {
        public StandRepository(ApiDbContext context, ILogger logger) : base(context, logger) { }

        public async Task<Stand?> GetByName(string name)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
