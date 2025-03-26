using RulerHub.Shared.DataTransferObjects.Logistic.Providers;

namespace RulerHub.Data.Services.Logistic.Providers.Interface;

public interface IProviderService
{
    Task<List<ProviderDto>> GetAsync();
    Task<ProviderDto?> GetByIdAsync(int id);
    Task<ProviderDto?> CreateAsync(ProviderDto model);
    Task<ProviderDto?> UpdateAsync(int id, ProviderDto model);
    Task<ProviderDto?> DeleteAsync(int id);
}
