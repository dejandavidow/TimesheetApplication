using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICategoriesRepository : IRepositoryBase<Category>
    {
      Task<IEnumerable<Category>> GetCategories();
      Task<Category> GetCategoryById(int id);
    }
}
