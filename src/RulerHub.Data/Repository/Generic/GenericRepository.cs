﻿using System.Linq.Expressions;
using RulerHub.Data.Context;

namespace RulerHub.Data.Repository.Generic;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T> Create(T entity)
    {
        try
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            throw;
        }
    }

    public async Task<bool> Delete(T entity)
    {
        try
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = (filter == null) ?
            _context.Set<T>() :
            _context.Set<T>().Where(filter);
        return query;
    }

    public async Task<bool> Update(T entity)
    {
        try
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }
}
