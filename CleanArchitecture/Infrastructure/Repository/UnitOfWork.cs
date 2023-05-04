using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ICategoryRepository? _categoryRepository;
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context=context;
        }
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if( _categoryRepository == null )
                {
                    return new CategoryRepository(_context);
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
