namespace JojoAPI.Core.Interfaces
{
    public interface IUnitOfWork
    {
        ICharacterRepository Characters { get; }
        IStandRepository Stands { get; }
        Task CompleteAsync();
    }
}
