using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ICategoriesRepository? _categoryRepository;
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
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
