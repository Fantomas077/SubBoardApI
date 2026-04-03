using Mapster;
using SubBoard.Application.Dtos.Category;
using SubBoard.Domain.Entities;

namespace SubBoard.Application.Mappings
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Category, CategoryDto>.NewConfig();
            TypeAdapterConfig<CreateCategoryDto, Category>.NewConfig();
            TypeAdapterConfig<UpdateCategoryDto, Category>.NewConfig();
        }
    }

}
