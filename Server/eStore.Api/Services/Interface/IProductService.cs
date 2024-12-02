using eStore.Api.DataTransferObjets.ProductDtos;
using eStore.Api.Entities;

namespace eStore.Api.Services.Interface;

public interface IProductService
{
    Task<List<Product>> GetAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product?> CreateAsync(Product model);
    Task<Product?> UpdateAsync(int id, UpdateProductDto model);
    Task<Product> DeleteAsync(int id);
}
