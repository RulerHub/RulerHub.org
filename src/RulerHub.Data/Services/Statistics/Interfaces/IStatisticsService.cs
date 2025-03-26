namespace RulerHub.Data.Services.Statistics.Interfaces
{
    public interface IStatisticsService
    {
        Task<int> GetTotalProvidersAsync();
        Task<int> GetTotalPurchasesAsync();
        // Agregar m�s m�todos seg�n sea necesario para otras estad�sticas
    }
}