using eStore.Api.DataTransferObjets.ProductDtos;
using eStore.Api.Entities;

namespace eStore.Api.DataTransferObjets.CategoryDtos;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public List<ProductDto> Products { get; set; } = [];
}
