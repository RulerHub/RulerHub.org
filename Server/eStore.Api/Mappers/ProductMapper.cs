using eStore.Api.DataTransferObjets.ProductDtos;
using eStore.Api.Entities;

namespace eStore.Api.Mappers;

public static class ProductMapper
{
    public static ProductDto ToProductDto(this Product model)
    {
        return new ProductDto
        {
            Id = model.Id,
            Code = model.Code,
            Name = model.Name,
            Description = model.Description,
        };
    }
    public static Product ToProductFromCreateDto(this CreateProductDto create)
    {
        return new Product
        {
            Code = create.Code,
            Name = create.Name!,
            Description = create.Description,

        };
    }
}
