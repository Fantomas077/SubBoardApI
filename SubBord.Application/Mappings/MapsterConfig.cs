using Mapster;
using SubBoard.Application.Dtos.Category;
using SubBoard.Application.Dtos.Subscription;
using SubBoard.Domain.Entities;

namespace SubBoard.Application.Mappings
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            // Category mappings
            TypeAdapterConfig<Category, CategoryDto>.NewConfig();
            TypeAdapterConfig<CreateCategoryDto, Category>.NewConfig();
            TypeAdapterConfig<UpdateCategoryDto, Category>.NewConfig();

            // Subscription mappings
            TypeAdapterConfig<Subscription, SubscriptionDto>
                .NewConfig()
                .Map(dest => dest.CategoryName, src => src.Category.Name);

            TypeAdapterConfig<CreateSubscriptionDto, Subscription>.NewConfig();
            TypeAdapterConfig<UpdateSubscriptionDto, Subscription>.NewConfig();
        }
    }
}
