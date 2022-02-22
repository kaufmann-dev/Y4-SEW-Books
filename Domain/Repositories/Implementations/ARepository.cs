using System.Linq.Expressions;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;

namespace Domain.Repositories.Implementations; 

public abstract class ARepository<TEntity> : IRepository<TEntity> where TEntity : class {
    protected TestDbContext _dbContext;
    protected DbSet<TEntity> _table;

    public ARepository(TestDbContext dbContext) {
        _dbContext = dbContext;
        _table = _dbContext.Set<TEntity>();
    }

    public async Task CreateAsync(TEntity entity) {
        _table.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity) {
        _table.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity) {
        _table.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<TEntity?> ReadAsync(int id)
        => await _table.FindAsync(id);

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter)
        => await _table.Where(filter).ToListAsync();

    public async Task<List<TEntity>> ReadAllAsync(int start, int count)
        => await _table.Skip(start).Take(count).ToListAsync();
}