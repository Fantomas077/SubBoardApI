using Mapster;
using SubBoard.Application.Dtos.Category;
using SubBoard.Application.Repositories.IRepositories;
using SubBoard.Domain.Entities;
using SubBoard.Infrastructure.Repositories;

namespace SubBoard.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _rep;

        public CategoryService(ICategoryRepository rep)
        {
            _rep = rep;
        }

        public async Task AddAsync(CreateCategoryDto dto)
        {
            var category = dto.Adapt<Category>();
            await _rep.AddAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _rep.GetByIdAsync(id);
            if (category == null)
                throw new Exception("Not found");

            await _rep.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _rep.GetAllAsync();
            return categories.Adapt<IEnumerable<CategoryDto>>();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _rep.GetByIdAsync(id);
            if (category == null)
                throw new Exception("Not found");

            return category.Adapt<CategoryDto>();
        }

        public async Task UpdateAsync(UpdateCategoryDto dto)
        {
            var category = await _rep.GetByIdAsync(dto.Id);
            if (category == null)
                throw new Exception("Not found");

            dto.Adapt(category);
            await _rep.UpdateAsync(category);
        }
    }
}
