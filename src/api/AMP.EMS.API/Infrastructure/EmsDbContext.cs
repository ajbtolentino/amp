using AMP.Core.Entity;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Infrastructure;

/// <summary>
///     EMS Database Context
/// </summary>
public class EmsDbContext(DbContextOptions<EmsDbContext> options) : DbContext(options)
{
    //Catalog
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<VendorType> VendorTypes { get; set; }
    public DbSet<VendorAccount> VendorAccounts { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    //Content
    public DbSet<Content> Contents { get; set; }

    //Event
    public DbSet<EventAccount> EventAccounts { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventVendorTypeBudget> EventVendorTypeBudgets { get; set; }
    public DbSet<GuestInvitation> GuestInvitations { get; set; }
    public DbSet<GuestInvitationRsvp> GuestInvitationRsvps { get; set; }
    public DbSet<GuestInvitationRsvpItem> GuestInvitationsRsvpItems { get; set; }
    public DbSet<GuestRole> GuestRoles { get; set; }
    public DbSet<Invitation> Invitations { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
    public DbSet<EventTypeRole> EventTypeRoles { get; set; }
    public DbSet<EventVendorContract> EventVendorContracts { get; set; }
    public DbSet<EventVendorContractState> EventVendorContractStates { get; set; }
    public DbSet<EventVendorContractPayment> EventVendorContractPayments { get; set; }
    public DbSet<EventVendorContractPaymentType> EventVendorContractPaymentTypes { get; set; }
    public DbSet<EventVendorContractPaymentState> EventVendorContractPaymentStates { get; set; }
    public DbSet<EventVendorTransaction> EventVendorTransactions { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Role> Roles { get; set; }

    //Payment
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountType> AccountTypes { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionType> TransactionTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureRelationships(modelBuilder);

        ConfigurePrimaryKeys(modelBuilder);
    }

    public void ConfigureRelationships(ModelBuilder modelBuilder)
    {
        var entityTypes = typeof(EmsDbContext).Assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.BaseType == typeof(object));

        foreach (var entityType in entityTypes)
        {
            // Configure HasMany relationships
            var collectionProperties = entityType.GetProperties()
                .Where(p => p.PropertyType.IsGenericType &&
                            p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>));

            foreach (var collectionProperty in collectionProperties)
            {
                var targetEntityType = collectionProperty.PropertyType.GetGenericArguments()[0];

                // Assuming that the foreign key is named as <TargetEntityName>Id
                var foreignKeyName = $"{targetEntityType.Name}Id";
                var foreignKeyProperty = entityType.GetProperty(foreignKeyName);

                if (foreignKeyProperty != null && foreignKeyProperty.PropertyType == typeof(Guid))
                {
                    // Configure HasMany relationship
                    var hasManyMethod = modelBuilder.Entity(entityType)
                        .HasMany(collectionProperty.Name);

                    hasManyMethod.WithOne(targetEntityType.Name + "s")
                        .HasForeignKey(foreignKeyName)
                        .OnDelete(DeleteBehavior.Restrict); // General case
                }
            }

            // Configure HasOne relationships
            var referenceProperties = entityType.GetProperties()
                .Where(p => p.PropertyType.IsClass && p.PropertyType != typeof(string) &&
                            !p.PropertyType.IsGenericType);

            foreach (var referenceProperty in referenceProperties)
            {
                var targetEntityType = referenceProperty.PropertyType;

                // Assuming the foreign key property is named as <TargetEntityName>Id
                var foreignKeyName = $"{targetEntityType.Name}Id";
                var foreignKeyProperty = entityType.GetProperty(foreignKeyName);

                if (foreignKeyProperty != null && foreignKeyProperty.PropertyType == typeof(Guid))
                {
                    // Configure HasOne relationship
                    var hasOneMethod = modelBuilder.Entity(entityType)
                        .HasOne(referenceProperty.Name)
                        .WithMany(targetEntityType.Name + "s")
                        .HasForeignKey(foreignKeyName)
                        .OnDelete(DeleteBehavior.Restrict); // Set delete behavior as needed
                }
            }

            // Configure Primary Key
            var primaryKeyProperty = entityType.GetProperties()
                .FirstOrDefault(p => p.Name == $"{entityType.Name}Id" && p.PropertyType == typeof(Guid));

            if (primaryKeyProperty != null)
                modelBuilder.Entity(entityType)
                    .HasKey(primaryKeyProperty.Name); // Set the primary key
        }

        // Configure Account -> Transaction relationships
        modelBuilder.Entity<Account>()
            .HasMany(a => a.CreditTransactions)
            .WithOne(t => t.CreditAccount)
            .HasForeignKey(t => t.CreditAccountId)
            .OnDelete(DeleteBehavior.Restrict); // Set delete behavior as needed

        modelBuilder.Entity<Account>()
            .HasMany(a => a.DebitTransactions)
            .WithOne(t => t.DebitAccount)
            .HasForeignKey(t => t.DebitAccountId)
            .OnDelete(DeleteBehavior.Restrict); // Set delete behavior as needed
    }


    private static void ConfigurePrimaryKeys(ModelBuilder modelBuilder)
    {
        // Apply a convention to automatically set Guid IDs as primary keys with ValueGeneratedOnAdd
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            // Check if the entity inherits from BaseEntity<Guid>
            if (!entityType.ClrType.IsSubclassOf(typeof(BaseEntity<Guid>))) continue;

            // Configure the primary key
            modelBuilder.Entity(entityType.ClrType)
                .HasKey(nameof(BaseEntity<Guid>.Id));

            // Configure ValueGeneratedOnAdd for the Guid Id
            modelBuilder.Entity(entityType.ClrType)
                .Property(nameof(BaseEntity<Guid>.Id))
                .ValueGeneratedOnAdd();
        }
    }


    public TEntity Add<TEntity, TID>(TEntity entity) where TEntity : class, IEntity<TID>
    {
        var result = Set<TEntity>().Add(entity);
        return result.Entity;
    }

    public void Delete<TEntity, TID>(TID id) where TEntity : class, IEntity<TID>
    {
        var entity = Set<TEntity>().Find(id);

        if (entity != null) Set<TEntity>().Remove(entity);
    }

    public TEntity Get<TEntity, TID>(TID id) where TEntity : class, IEntity<TID>
    {
        if (id is null) throw new NullReferenceException(nameof(id));

        return Set<TEntity>().Find(id)!;
    }

    public IEnumerable<TEntity> GetAll<TEntity, TID>() where TEntity : class, IEntity<TID>
    {
        return Set<TEntity>();
    }

    public bool Save()
    {
        return SaveChanges() > 0;
    }

    public TEntity Update<TEntity, TID>(TEntity entity) where TEntity : class, IEntity<TID>
    {
        return Set<TEntity>().Update(entity).Entity;
    }
}