using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProjectsRepository : RepositoryBase<Project>, IProjectsRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Project>> GetProjects()
        {
            var projects = await _context.Projects.Include(x => x.Member).ToListAsync();
            return projects.Adapt<IEnumerable<Project>>();
        }
    }
}
