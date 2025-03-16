
using RulerHub.Shared.Entities.Enterprices;

namespace RulerHub.Data.Services.Enterprices.Interfaces;

public interface IEnterpriseService
{
    Task<List<Enterprice>> GetEnterprices();
}
