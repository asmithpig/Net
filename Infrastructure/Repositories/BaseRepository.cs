using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T: class
{
    protected readonly EShopDbContext _context;

    public BaseRepository(EShopDbContext context)
    {
        _context = context;
    }

    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<int> Insert(T entity)
    {
        _context.Set<T>().Add(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteById(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        return 0;
    }
}