using eStore.Api.DataTransferObjets.CategoryDtos;
using eStore.Api.Entities;

namespace eStore.Api.DataTransferObjets.ProductDtos;

public class ProductDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public CategoryDto? Category { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
