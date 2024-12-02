using eStore.Api.DataTransferObjets.CategoryDtos;
using eStore.Api.Entities;

namespace eStore.Api.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category model)
    {
        return new CategoryDto
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            CreateDate = model.CreateDate,
        };
    }
        public static Category ToCategoryFromCreateDto(this CreateCategoryDto create)
    {
        return new Category
        {
            Name = create.Name!,
            Description = create.Description,
        };
    }
    }
}
