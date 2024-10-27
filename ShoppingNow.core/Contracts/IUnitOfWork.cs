using System.Data.Common;

namespace ShoppingNow.core.Contracts;

public interface IUnitOfWork
{


    public Task BeginTransaction();
    public Task CommitTransaction();
    public Task RollbackTransaction();
    public Task SaveChange();

}