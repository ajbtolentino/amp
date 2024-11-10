using System.Data;
using System.Security.Claims;
using AMP.Core.Entity;
using AMP.Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace AMP.Infrastructure.Repository;

public class EFUnitOfWork(
    DbContext dbContext,
    IHttpContextAccessor httpContextAccessor,
    IServiceProvider serviceProvider) : IUnitOfWork
{
    public IRepository<TEntity> Set<TEntity>() where TEntity : class
    {
        return serviceProvider.GetRequiredService<EFRepository<TEntity>>();
    }

    public IDbTransaction BeginTransaction()
    {
        return dbContext.Database.BeginTransaction().GetDbTransaction();
    }

    public async Task CommitTransactionAsync()
    {
        await dbContext.Database.CurrentTransaction.CommitAsync();
    }


    public async Task RollbackTransactionAsync()
    {
        await dbContext.Database.CurrentTransaction.RollbackAsync();
    }

    public async Task SaveChangesAsync()
    {
        foreach (var entry in dbContext.ChangeTracker.Entries<IAuditableEntity>())
        {
            var claims = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = claims?.Value ?? string.Empty;
                    entry.Entity.DateCreated = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = claims?.Value ?? string.Empty;
                    entry.Entity.DateUpdated = DateTime.UtcNow;
                    break;
            }
        }

        await dbContext.SaveChangesAsync();
    }
}