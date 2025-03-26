using RulerHub.Shared.DataTransferObjects.Logistic.Providers;
using RulerHub.Shared.Entities.Logistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulerHub.Data.Mappers.Logistics;

public static class ProviderMapper
{
    public static ProviderDto ToProviderDto(this Provider provider)
    {
        return new ProviderDto
        {
            Code = provider.Code,
            Name = provider.Name,
            Description = provider.Description,
            //Purchases = provider.Purchases,
        };
    }

    public static Provider ToProvider(this ProviderDto provider)
    {
        return new Provider
        {
            Code = provider.Code,
            Name = provider.Name,
            Description = provider.Description,
            //Purchases = provider.Purchases,
        };
    }
}
