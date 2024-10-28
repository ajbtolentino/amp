using AMP.Core.Entity;
using AMP.EMS.API.Core.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace AMP.EMS.API.Infrastructure;

/// <summary>
/// EMS Database Context
/// </summary>
public class EMSDbContext(DbContextOptions<EMSDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Event>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<EventGuest>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<EventGuestInvitation>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<EventGuestInvitationRsvp>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<EventGuestRole>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<EventInvitation>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<EventType>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Guest>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }

    public DbSet<Event> Events { get; private set; }
    public DbSet<EventGuest> EventGuests { get; private set; }
    public DbSet<EventGuestRole> EventGuestRoles { get; private set; }
    public DbSet<EventGuestInvitation> EventGuestInvitations { get; private set; }
    public DbSet<EventGuestInvitationRsvp> EventGuestInvitationsRsvps { get; private set; }
    public DbSet<EventInvitation> EventInvitations { get; private set; }
    public DbSet<EventType> EventTypes { get; private set; }
    public DbSet<Guest> Guests { get; private set; }

    public TEntity Add<TEntity, TID>(TEntity entity) where TEntity : class, IEntity<TID>
    {
        var result = this.Set<TEntity>().Add(entity);
        return result.Entity;
    }

    public void Delete<TEntity, TID>(TID id) where TEntity : class, IEntity<TID>
    {
        var entity = this.Set<TEntity>().Find(id);

        if (entity != null) this.Set<TEntity>().Remove(entity);
    }

    public TEntity Get<TEntity, TID>(TID id) where TEntity : class, IEntity<TID>
    {
        if (id is null) throw new NullReferenceException(nameof(id));

        return this.Set<TEntity>().Find(id)!;
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
