using System.Linq.Expressions;

namespace ShoppingNow.core.Contracts;

public interface IGenericRepository<T> where T : class
{
    public Task Add(T entity);
    public Task<bool> Delete(object id);
    public void Update(T entity);
    public Task<IEnumerable<T>> GetAll(bool tracking = false);
    public Task<T?> GetById(object id , bool tracking = false);
    public Task<List<T>> GetByCondition(Expression<Func<T, bool>> condition , bool tracking =false) ;
    public Task<List<object>> GetByCondition(Expression<Func<T, bool>> condition , Expression<Func<T,object>> select , bool tracking =false ) ;
}