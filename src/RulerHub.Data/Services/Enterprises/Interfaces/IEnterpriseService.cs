﻿using RulerHub.Shared.Entities.Enterprises;

namespace RulerHub.Data.Services.Enterprises.Interfaces;

public interface IEnterpriseService
{
    Task<List<Enterprise>> GetEnterprises();
    Task<Enterprise> GetEnterprise();
    Task<Enterprise?> GetEnterpriseById(int id);
    Task<Enterprise> CreateEnterprise(Enterprise enterprise);
    Task<Enterprise?> UpdateEnterprise(Enterprise enterprise);
    Task<bool> DeleteEnterprise(int id);
}
