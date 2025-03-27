using RulerHub.Shared.DataTransferObjects.Logistic.Categories;
using RulerHub.Shared.Entities.Warehouses;

namespace RulerHub.Data.Mappers.Logistics;

public static class CategoryMapper
{
    public static CategoryDto ToCategoryDto(this Category category)
    {
        return new CategoryDto
        {
            Name = category.Name,
            Description = category.Description,
            //Items = provider.Items,
        };
    }

    public static Category ToCategory(this CategoryDto category)
    {
        return new Category
        {
            Name = category.Name,
            Description = category.Description,
            //Items = provider.Items,
        };
    }
}
