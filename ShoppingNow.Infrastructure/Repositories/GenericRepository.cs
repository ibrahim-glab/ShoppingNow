using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ShoppingNow.core.Contracts;

namespace ShoppingNow.Infrastructure.Repositories;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T>
    where T : class
{
    private readonly AppDbContext _context = context;

    public async Task Add(T entity)
    {
        try
        {
            await _context.Set<T>().AddAsync(entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task<bool> Delete(object id)
    {
        try
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity is null)
                return false;
            
            _context.Set<T>().Remove(entity);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public void Update(T entity)
    {
        try
        {
            _context.Set<T>().Update(entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }

    public async Task<IEnumerable<T>> GetAll(bool tracking = false)
    {
       return tracking ? await _context.Set<T>().ToListAsync() : await _context.Set<T>().AsNoTracking().ToListAsync();
    }

   

    public async Task<T?> GetById(object id, bool tracking = false)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetByCondition(Expression<Func<T, bool>> condition,bool tracking =false)
    {
        var query = tracking ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
        query = query.Where(condition);
        return await query.ToListAsync();
    }

    public async Task<List<object>> GetByCondition(Expression<Func<T, bool>> condition, Expression<Func<T, object>> select,
        bool tracking = false)
    {
        var query = tracking ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
        query = query.Where(condition);

        return await query.Select(select).ToListAsync();
    }
    
    
}