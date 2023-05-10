using Domain.Entities;
using Domain.Interfaces;
using Domain.Pagination;
using Mapster;
using Service.DTOs;
using Service.Interfaces;
using Service.Pagination;

namespace Service.Implementations
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = categoryDTO.Adapt<Category>();
            _unitOfWork.CategoryRepository.Create(category);
            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetCategoryById(id);
            _unitOfWork.CategoryRepository.Delete(category);
            await _unitOfWork.SaveChanges();
        }

        public async Task<PagedList<CategoryDTO>> GetCategoriesAsync(CategoryParameters parameters)
        {
           var categories = await _unitOfWork.CategoryRepository.GetCategories(parameters);
           var dtos =  categories.Adapt<IEnumerable<CategoryDTO>>();
           return PagedList<CategoryDTO>.ToPagedList(dtos,parameters.PageNumber,parameters.PageSize);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetCategoryById(id);
            return category.Adapt<CategoryDTO>();
        }

        public async Task UpdateCategoryAsync(int id, CategoryDTO categoryDTO)
        {
            var category = await  _unitOfWork.CategoryRepository.GetCategoryById(id);
            categoryDTO.Adapt(category);
            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.SaveChanges();
        }
    }
}
