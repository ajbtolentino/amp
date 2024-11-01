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
            .HasMany(_ => _.EventInvitations)
            .WithOne(_ => _.Event)
            .HasForeignKey(_ => _.EventId)
            .HasPrincipalKey(_ => _.Id);
        
        modelBuilder.Entity<Event>()
            .HasMany(_ => _.EventGuests)
            .WithOne(_ => _.Event)
            .HasForeignKey(_ => _.EventId)
            .HasPrincipalKey(_ => _.Id);
        
        modelBuilder.Entity<Event>()
            .HasMany(_ => _.EventBudgets)
            .WithOne(_ => _.Event)
            .HasForeignKey(_ => _.EventId)
            .HasPrincipalKey(_ => _.Id);
        
        modelBuilder.Entity<Event>()
            .HasMany(_ => _.EventVendors)
            .WithOne(_ => _.Event)
            .HasForeignKey(_ => _.EventId)
            .HasPrincipalKey(_ => _.Id);
        
        modelBuilder.Entity<Event>()
            .HasMany(_ => _.Roles)
            .WithOne(_ => _.Event)
            .HasForeignKey(_ => _.EventId)
            .HasPrincipalKey(_ => _.Id);

        modelBuilder.Entity<Guest>()
            .HasMany(_ => _.EventGuests)
            .WithOne(_ => _.Guest)
            .HasForeignKey(_ => _.GuestId)
            .HasPrincipalKey(_ => _.Id);
        
        modelBuilder.Entity<EventGuest>()
            .HasMany(_ => _.EventGuestRoles)
            .WithOne(_ => _.EventGuest)
            .HasForeignKey(_ => _.EventGuestId)
            .HasPrincipalKey(_ => _.Id);
        
        modelBuilder.Entity<EventGuest>()
            .HasMany(_ => _.EventGuestInvitations)
            .WithOne(_ => _.EventGuest)
            .HasForeignKey(_ => _.EventGuestId)
            .HasPrincipalKey(_ => _.Id);
        
        modelBuilder.Entity<EventInvitation>()
            .HasMany(_ => _.EventGuestInvitations)
            .WithOne(_ => _.EventInvitation)
            .HasForeignKey(_ => _.EventInvitationId)
            .HasPrincipalKey(_ => _.Id);
        
        modelBuilder.Entity<EventGuestInvitation>()
            .HasMany(_ => _.EventGuestInvitationRsvps)
            .WithOne(_ => _.EventGuestInvitation)
            .HasForeignKey(_ => _.EventGuestInvitationId)
            .HasPrincipalKey(_ => _.Id);
        
        modelBuilder.Entity<EventGuestInvitationRsvp>()
            .HasMany(_ => _.EventGuestInvitationRsvpItems)
            .WithOne(_ => _.EventGuestInvitationRsvp)
            .HasForeignKey(_ => _.EventGuestInvitationRsvpId)
            .HasPrincipalKey(_ => _.Id);
        
        modelBuilder.Entity<Vendor>()
            .HasMany(_ => _.EventVendors)
            .WithOne(_ => _.Vendor)
            .HasForeignKey(_ => _.VendorId)
            .HasPrincipalKey(_ => _.Id);
        
        modelBuilder.Entity<AccountType>()
            .HasMany(_ => _.Accounts)
            .WithOne(_ => _.AccountType)
            .HasForeignKey(_ => _.AccountTypeId)
            .HasPrincipalKey(_ => _.Id);
        
        modelBuilder.Entity<EventType>()
            .HasMany(_ => _.Events)
            .WithOne(_ => _.EventType)
            .HasForeignKey(_ => _.EventTypeId)
            .HasPrincipalKey(_ => _.Id);
        
        modelBuilder.Entity<TransactionType>()
            .HasMany(_ => _.Transactions)
            .WithOne(_ => _.TransactionType)
            .HasForeignKey(_ => _.TransactionTypeId)
            .HasPrincipalKey(_ => _.Id);

        modelBuilder.Entity<Account>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<AccountType>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Event>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<EventBudget>()
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
        
        modelBuilder.Entity<EventGuestInvitationRsvpItem>()
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
        
        modelBuilder.Entity<EventVendor>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Guest>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Role>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Transaction>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<TransactionType>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Vendor>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        Seed(modelBuilder);
    }

    public DbSet<Account> Accounts { get; private set; }
    public DbSet<AccountType> AccountsTypes { get; private set; }
    public DbSet<Event> Events { get; private set; }
    public DbSet<EventBudget> EventBudgets { get; private set; }
    public DbSet<EventGuest> EventGuests { get; private set; }
    public DbSet<EventGuestInvitation> EventGuestInvitations { get; private set; }
    public DbSet<EventGuestInvitationRsvp> EventGuestInvitationRsvps { get; private set; }
    public DbSet<EventGuestInvitationRsvpItem> EventGuestInvitationsRsvpItems { get; private set; }
    public DbSet<EventGuestRole> EventGuestRoles { get; private set; }
    public DbSet<EventInvitation> EventInvitations { get; private set; }
    public DbSet<EventType> EventTypes { get; private set; }
    public DbSet<EventVendor> EventVendors { get; private set; }
    public DbSet<Guest> Guests { get; private set; }
    public DbSet<Role> Roles { get; private set; }
    public DbSet<Transaction> Transactions { get; private set; }
    public DbSet<TransactionType> TransactionTypes { get; private set; }
    public DbSet<Vendor> Vendors { get; private set; }

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

    private static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventType>().HasData(
            new EventType() { Id = Guid.NewGuid(), Name = "Wedding" }
        );

        modelBuilder.Entity<AccountType>().HasData(
            new AccountType() { Id = Guid.NewGuid(), Name = "Cash" },
            new AccountType() { Id = Guid.NewGuid(), Name = "Savings" },
            new AccountType() { Id = Guid.NewGuid(), Name = "Credit Card" },
            new AccountType() { Id = Guid.NewGuid(), Name = "Checking" }
        );

        modelBuilder.Entity<TransactionType>().HasData(
            new TransactionType() { Id = Guid.NewGuid(), Name = "Income" },
            new TransactionType() { Id = Guid.NewGuid(), Name = "Expense" }
        );
    }
}
