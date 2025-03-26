namespace RulerHub.Data.Services.Statistics.Interfaces
{
    public interface IStatisticsService
    {
        Task<int> GetTotalProvidersAsync();
        Task<int> GetTotalPurchasesAsync();
        // Agregar más métodos según sea necesario para otras estadísticas
    }
}