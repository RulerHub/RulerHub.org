using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RulerHub.Data.Context;
using RulerHub.Data.Mappers.Logistics;
using RulerHub.Data.Repository.Generic;
using RulerHub.Data.Services.Logistic.Providers.Interface;
using RulerHub.Shared.DataTransferObjects.Logistic.Providers;
using RulerHub.Shared.Entities.Logistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RulerHub.Data.Services.Logistic.Providers.Implements;

public class ProviderService(IGenericRepository<Provider> repository) : IProviderService
{
    private readonly IGenericRepository<Provider> _repository = repository;

    public async Task<ProviderDto?> CreateAsync(ProviderDto model)
    {
        try
        {
            var entity = model.ToProvider();
            var query = await _repository.Create(entity);
            if (query.Id != 0)
            {
                return query.ToProviderDto();
            }
            else
            {
                throw new TaskCanceledException("Error al crear");
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.ToString());
            throw ex;
        }
    }

    public Task<ProviderDto?> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProviderDto>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProviderDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProviderDto?> UpdateAsync(int id, ProviderDto model)
    {
        throw new NotImplementedException();
    }
}
