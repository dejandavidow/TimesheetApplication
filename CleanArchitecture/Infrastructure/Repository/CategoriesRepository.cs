using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Service.Pagination;

namespace Infrastructure.Repository
{
    public class CategoriesRepository : RepositoryBase<Category>, ICategoriesRepository
    {  
        public CategoriesRepository(ApplicationDbContext context) : base (context) { }

        public  async Task<IEnumerable<Category>> GetCategories()
        {
            return  await FindAll().ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
           return await FindByCondtition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
