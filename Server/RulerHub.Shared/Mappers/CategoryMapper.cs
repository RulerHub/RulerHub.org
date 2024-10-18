
using RulerHub.Shared.DataTransferObjects.Category;
using RulerHub.Shared.DbModels;

namespace RulerHub.Shared.Mappers;

public static class CategoryMapper
{
    public static CategoryDto ToCategoryDto(this CategoryModel cat)
    {
        return new CategoryDto
        {
            Id = cat.Id,
            Name = cat.Name,
            Description = cat.Description,
            Items = cat.Items.Select(i => i.ToItemDto()).ToList(),
        };
    }
    public static CategoryModel ToCategoryFromCreateDto(this CreateCategoryDto create)
    {
        return new CategoryModel
        {
            Name = create.Name,
            Description = create.Description!,
        };
    }
}
