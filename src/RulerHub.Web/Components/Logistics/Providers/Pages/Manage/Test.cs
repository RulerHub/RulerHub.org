using Microsoft.AspNetCore.Components;
using RulerHub.Data.Repository.Logistic.Providers.Interfaces;
using RulerHub.Shared.Entities.Logistic;

namespace RulerHub.Web.Components.Logistics.Providers.Pages.Manage;

public class Test
{
    [Inject]
    IProviderRepository? ProviderRepository { get; set; }

    public IQueryable<Provider>? providers;

    public void GetProvider()
    {
        providers = ProviderRepository.GetAll();
    }
}
