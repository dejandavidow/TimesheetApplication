using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProjectsRepository : IRepositoryBase<Project>
    {
        Task<IEnumerable<Project>> GetProjects();
    }
}
