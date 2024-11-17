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
    public DbSet<EventTask> EventTasks { get; set; }
    public DbSet<EventVendorTypeBudget> EventVendorTypeBudgets { get; set; }
    public DbSet<GuestInvitation> GuestInvitations { get; set; }
    public DbSet<GuestInvitationRsvp> GuestInvitationRsvps { get; set; }
    public DbSet<GuestInvitationRsvpItem> GuestInvitationsRsvpItems { get; set; }
    public DbSet<GuestRole> GuestRoles { get; set; }
    public DbSet<Invitation> Invitations { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
    public DbSet<EventTypeRole> EventTypeRoles { get; set; }
    public DbSet<VendorContract> VendorContracts { get; set; }
    public DbSet<VendorContractState> VendorContractStates { get; set; }
    public DbSet<VendorContractPayment> VendorContractPayments { get; set; }
    public DbSet<VendorContractPaymentType> VendorContractPaymentTypes { get; set; }
    public DbSet<VendorContractPaymentState> VendorContractPaymentStates { get; set; }
    public DbSet<EventVendorTransaction> EventVendorTransactions { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Role> Roles { get; set; }

    public DbSet<SeatGroup> SeatGroups { get; set; }
    public DbSet<SeatGroupAttendee> SeatGroupAttendees { get; set; }
    public DbSet<Timeline> Timelines { get; set; }

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

    private void ConfigureRelationships(ModelBuilder modelBuilder)
    {
        var entityTypes = typeof(EmsDbContext).GetProperties().Where(_ => _.PropertyType.IsGenericType)
            .Select(_ => _.PropertyType.GenericTypeArguments[0]).ToList();

        Console.WriteLine($"Found {entityTypes.Count()} entities");

        foreach (var entityType in entityTypes)
        {
            // Configure HasMany relationships
            var collectionProperties = entityType.GetProperties();

            Console.WriteLine(
                $"Configuring Relationships for {entityType.Name} with {collectionProperties.Count()} properties");

            foreach (var collectionProperty in collectionProperties)
            {
                if (collectionProperty.PropertyType.Name != typeof(ICollection<>).Name) continue;
                if (collectionProperty.Name == nameof(Account.DebitTransactions) ||
                    collectionProperty.Name == nameof(Account.CreditTransactions)) continue;

                Console.WriteLine(
                    $"-Configuring {entityType.Name}.{collectionProperty.Name}...");

                var targetEntityType = collectionProperty.PropertyType.GetGenericArguments()[0];

                // Assuming that the foreign key is named as <TargetEntityName>Id
                var foreignKeyName = $"{entityType.Name}Id";

                Console.WriteLine($"-Target Collection Entity {targetEntityType.Name}...");

                var foreignKeyProperty = targetEntityType.GetProperty(foreignKeyName);

                Console.WriteLine($"-Found {foreignKeyProperty.Name} foreign key in {targetEntityType.Name}");

                if (foreignKeyProperty != null && foreignKeyProperty.PropertyType == typeof(Guid))
                {
                    // Configure HasMany relationship
                    modelBuilder.Entity(entityType)
                        .HasMany(targetEntityType.Name + "s")
                        .WithOne(entityType.Name)
                        .HasForeignKey(foreignKeyName)
                        .OnDelete(DeleteBehavior.Restrict); // General case

                    Console.WriteLine($"-Done configuring {entityType.Name} HasMany {foreignKeyProperty.Name}...");
                }
            }

            // Configure HasOne relationships
            var referenceProperties = entityType.GetProperties()
                .Where(p => p.PropertyType.IsClass && p.PropertyType != typeof(string) &&
                            !p.PropertyType.IsGenericType);

            foreach (var referenceProperty in referenceProperties)
            {
                var targetEntityType = referenceProperty.PropertyType;

                Console.WriteLine(
                    $"-Configuring {entityType.Name}.{referenceProperty.Name}...");

                // Assuming the foreign key property is named as <TargetEntityName>Id
                var foreignKeyName = $"{targetEntityType.Name}Id";
                var foreignKeyProperty = entityType.GetProperty(foreignKeyName);

                Console.WriteLine($"-Configuring {entityType.Name} HasOne {foreignKeyName}");

                if (foreignKeyProperty != null && foreignKeyProperty.PropertyType == typeof(Guid) &&
                    targetEntityType.GetProperties().Any(_ => _.Name == referenceProperty.Name + "Id"))
                {
                    // Configure HasOne relationship
                    modelBuilder.Entity(entityType)
                        .HasOne(referenceProperty.Name)
                        .WithOne(targetEntityType.Name)
                        .HasForeignKey(foreignKeyName)
                        .OnDelete(DeleteBehavior.Restrict); // Set delete behavior as needed

                    Console.WriteLine($"-Done configuring {referenceProperty.Name} HasOne {targetEntityType.Name}...");
                }
            }

            // Configure Primary Key
            var primaryKeyProperty = entityType.GetProperties()
                .FirstOrDefault(p => p.Name == $"{entityType.Name}Id" && p.PropertyType == typeof(Guid));

            if (primaryKeyProperty != null)
                modelBuilder.Entity(entityType)
                    .HasKey(primaryKeyProperty.Name); // Set the primary key


            Console.WriteLine(
                $"Finished configuring {entityType.Name}...");
        }

        //Configure Account->Transaction relationships
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