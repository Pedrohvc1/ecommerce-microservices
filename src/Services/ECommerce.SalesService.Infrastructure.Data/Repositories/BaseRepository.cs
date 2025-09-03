using ECommerce.SalesService.Domain.Core.Interfaces.Repositories;
using ECommerce.SalesService.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.SalesService.Infrastructure.Data.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
{
    protected readonly SalesServiceDbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    protected BaseRepository(SalesServiceDbContext context)
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

    public virtual void Remove(TEntity entity)
        => DbSet.Remove(entity);

    public virtual async Task SaveChangesAsync()
        => await Context.SaveChangesAsync();
}