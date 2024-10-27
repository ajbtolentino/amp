using AMP.Core.Repository;
using AMP.Infrastructure.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Security.Claims;
using AMP.Core.Entity;

namespace AMP.Infrastructure.Repository;

public class EFUnitOfWork(DbContext dbContext, IHttpContextAccessor httpContextAccessor, IServiceProvider serviceProvider) : IUnitOfWork
{
    public IRepository<TEntity> Repository<TEntity>() where TEntity : class => serviceProvider.GetRequiredService<EFRepository<TEntity>>();

    public IDbTransaction BeginTransaction() => IsTransactionSupported ? dbContext.Database.BeginTransaction().GetDbTransaction() : null;

    public async Task CommitTransactionAsync()
    {
        if (IsTransactionSupported)
            await dbContext.Database.CurrentTransaction.CommitAsync();
    }


    public async Task RollbackTransactionAsync()
    {
        if (IsTransactionSupported) await dbContext.Database.CurrentTransaction.RollbackAsync();
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
                    entry.Entity.DateCreated = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = claims?.Value ?? string.Empty;
                    entry.Entity.DateUpdated = DateTime.Now;
                    break;
            }
        }

        await dbContext.SaveChangesAsync();
    }

    private bool IsTransactionSupported => !dbContext.Database.ProviderName.Contains("MongoDB");
}
