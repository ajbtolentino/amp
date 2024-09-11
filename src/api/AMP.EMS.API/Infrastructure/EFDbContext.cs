using System;
using AMP.Core.Entity;
using AMP.EMS.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Infrastructure;

public class EMSDbContext : DbContext
{
    public EMSDbContext(DbContextOptions<EMSDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Event>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }

    public DbSet<Event> Events { get; private set; }

    public TEntity Add<TEntity, TID>(TEntity entity) where TEntity : class, IEntity<TID>
    {
        var result = this.Set<TEntity>().Add(entity);
        return result.Entity;
    }

    public void Delete<TEntity, TID>(TID id) where TEntity : class, IEntity<TID>
    {
        var entity = this.Set<TEntity>().Find(id);
        this.Set<TEntity>().Remove(entity);
    }

    public TEntity Get<TEntity, TID>(TID id) where TEntity : class, IEntity<TID>
    {
        if (id is null) throw new NullReferenceException(nameof(id));

        return this.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> GetAll<TEntity, TID>() where TEntity : class, IEntity<TID>
    {
        return this.Set<TEntity>();
    }

    public bool Save()
    {
        return this.SaveChanges() > 0;
    }

    public TEntity Update<TEntity, TID>(TEntity entity) where TEntity : class, IEntity<TID>
    {
        return this.Set<TEntity>().Update(entity).Entity;
    }
}
