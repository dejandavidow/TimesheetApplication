using Domain;
using Service.DTOs;
using Service.Pagination;

namespace Service.Interfaces
{
    public interface ICategoriesService
    {
        Task<PagedList<CategoryDTO>> GetCategoriesAsync(QueryParameters parameters);
        Task CreateCategoryAsync(CategoryDTO categoryDTO);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(int id,CategoryDTO categoryDTO);
        Task<CategoryDTO> GetCategoryByIdAsync(int id);

    }
}
