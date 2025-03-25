using RulerHub.Shared.Entities.Logistic;


namespace RulerHub.Data.Services.Logistic.Providers.Interface;

public interface IProviderService
{
    Task<List<Provider>> GetAsync();
    Task<Provider?> GetByIdAsync(int id);
    Task<Provider?> CreateAsync(Provider model);
    Task<Provider?> UpdateAsync(int id, Provider model);
    Task<Provider?> DeleteAsync(int id);
}
