using ShoppingNow.core.Contracts;

namespace ShoppingNow.Infrastructure.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    public async Task BeginTransaction() => await _context.Database.BeginTransactionAsync();


    public async Task CommitTransaction() => await _context.Database.CommitTransactionAsync();


    public async Task RollbackTransaction() => await _context.Database.RollbackTransactionAsync();


    public async Task SaveChange() => await _context.SaveChangesAsync();

}