using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ICategoriesRepository? _categoryRepository;
        private readonly IClientsRepository? _clientsRepository;
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context=context;
        }
        public ICategoriesRepository CategoryRepository
        {
            get
            {
                if( _categoryRepository == null )
                {
                    return new CategoriesRepository(_context);
                }
                return _categoryRepository;
            }
        }
        public IClientsRepository ClientsRepository
        {
            get
            {
                if (_clientsRepository == null)
                {
                    return new ClientsRepository(_context);
                }
                return _clientsRepository;
            }
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
