using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.StockService.Domain.Core.Interfaces.Repositories;
using ECommerce.StockService.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.StockService.Infrastructure.Data.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
{
    protected readonly StockServiceDbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    protected BaseRepository(StockServiceDbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
        => await DbSet.FindAsync(id);

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        => await DbSet.ToListAsync();

    public virtual async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await SaveChangesAsync();
    }

    public virtual void Update(TEntity entity)
        => DbSet.Update(entity);

    public virtual void Remove(TEntity entity)
        => DbSet.Remove(entity);

    public virtual async Task SaveChangesAsync()
        => await Context.SaveChangesAsync();
}