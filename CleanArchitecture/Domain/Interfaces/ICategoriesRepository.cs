using Domain.Entities;
using Domain.Pagination;

namespace Domain.Interfaces
{
    public interface ICategoriesRepository : IRepositoryBase<Category>
    {
      Task<IEnumerable<Category>> GetCategories(CategoryParameters queryParameters);
      Task<Category> GetCategoryById(int id);
    }
}
