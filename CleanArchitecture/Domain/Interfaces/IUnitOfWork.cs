namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoriesRepository CategoryRepository { get; }
        IClientsRepository ClientsRepository { get; }
        Task SaveChanges();
    }
}
