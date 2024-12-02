using eStore.Api.Entities;

namespace eStore.Api.DataTransferObjets.ProductDtos;

public class CreateProductDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
