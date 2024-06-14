using JojoAPI.Core.Interfaces;
using JojoAPI.Core.Repositories;

namespace JojoAPI.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiDbContext context;
        private readonly ILogger logger;

        public ICharacterRepository Characters { get; private set; }
        public IStandRepository Stands { get; private set; }

        public UnitOfWork(ApiDbContext context, ILoggerFactory loggerFactory)
        {
            this.context = context;
            this.logger = loggerFactory.CreateLogger("logs");

            Characters = new CharacterRepository(context, logger);
            Stands = new StandRepository(context, logger);
        }
        
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
