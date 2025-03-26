using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using RulerHub.Data.Repository.Generic;
using RulerHub.Data.Services.Statistics.Interfaces;
using RulerHub.Shared.Entities.Logistic;
using RulerHub.Shared.Localization;

namespace RulerHub.Data.Services.Statistics.Implement
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IGenericRepository<Provider> _providerRepository;
        private readonly IGenericRepository<Purchase> _purchaseRepository;
        private readonly IStringLocalizer<Language> _Language;

        public StatisticsService(IGenericRepository<Provider> providerRepository, IGenericRepository<Purchase> purchaseRepository, IStringLocalizer<Language> Language)
        {
            _providerRepository = providerRepository;
            _purchaseRepository = purchaseRepository;
            _Language = Language;
        }

        public async Task<int> GetTotalProvidersAsync()
        {
            try
            {
                return await _providerRepository.GetAll().CountAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(_Language["E0010"], ex); // E0010: Error al obtener el total de proveedores.
            }
        }

        public async Task<int> GetTotalPurchasesAsync()
        {
            try
            {
                return await _purchaseRepository.GetAll().CountAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(_Language["E0011"], ex); // E0011: Error al obtener el total de compras.
            }
        }

        // Agregar más métodos según sea necesario para otras estadísticas
    }
}