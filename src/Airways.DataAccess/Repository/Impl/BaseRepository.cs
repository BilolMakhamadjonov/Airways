﻿using Airways.Core.Common;
using Airways.Core.Exceptions;
using Airways.DataAccess.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Airways.DataAccess.Repository.Impl;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DatabaseContext Context;
    protected readonly DbSet<TEntity> DbSet;

    protected BaseRepository(DatabaseContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var addedEntity = (await DbSet.AddAsync(entity)).Entity;
        await Context.SaveChangesAsync();

        return addedEntity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        var removedEntity = DbSet.Remove(entity).Entity;
        await Context.SaveChangesAsync();

        return removedEntity;
    }

    public IEnumerable<TEntity> GetAllAsEnumurable()
    {
        return DbSet.AsEnumerable();
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.Where(predicate).ToListAsync();
    }
    public IQueryable<TEntity> GetAll() =>
        DbSet.AsQueryable();

    public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await DbSet.Where(predicate).FirstOrDefaultAsync();

        if (entity == null) throw new ResourceNotFound(typeof(TEntity));

        return await DbSet.Where(predicate).FirstOrDefaultAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task<List<TEntity>?> GetAllAsync()
    {
        try
        {
            var result = await DbSet.ToListAsync();
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}