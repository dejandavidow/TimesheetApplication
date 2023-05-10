using Domain.Entities;
using Domain.Interfaces;
using Domain.Pagination;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CategoriesRepository : RepositoryBase<Category>, ICategoriesRepository
    {  
        public CategoriesRepository(ApplicationDbContext context) : base (context) { }

        public  async Task<IEnumerable<Category>> GetCategories(CategoryParameters parameters)
        {
            if (String.IsNullOrWhiteSpace(parameters.Name))
            return await FindAll().ToListAsync();
            return await FindByCondtition(x => x.Name.ToLower().Contains(parameters.Name.Trim().ToLower())).ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
           return await FindByCondtition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
