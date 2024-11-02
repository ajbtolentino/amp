using AMP.Core.Entity;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Infrastructure;

/// <summary>
///     EMS Database Context
/// </summary>
public class EMSDbContext(DbContextOptions<EMSDbContext> options) : DbContext(options)
{
    //Catalog
    public DbSet<Vendor> Vendors { get; }
    public DbSet<VendorType> VendorTypes { get; }
    public DbSet<VendorAccount> VendorAccounts { get; }

    //Event
    public DbSet<EventAccount> EventAccounts { get; }
    public DbSet<Event> Events { get; }
    public DbSet<EventVendorTypeBudget> EventBudgets { get; }
    public DbSet<EventGuest> EventGuests { get; }
    public DbSet<EventGuestInvitation> EventGuestInvitations { get; }
    public DbSet<EventGuestInvitationRsvp> EventGuestInvitationRsvps { get; }
    public DbSet<EventGuestInvitationRsvpItem> EventGuestInvitationsRsvpItems { get; }
    public DbSet<EventGuestRole> EventGuestRoles { get; }
    public DbSet<EventInvitation> EventInvitations { get; }
    public DbSet<EventType> EventTypes { get; }
    public DbSet<EventTypeRole> EventTypeRoles { get; }
    public DbSet<EventVendor> EventVendors { get; }
    public DbSet<EventVendorStatus> EventVendorStatus { get; }
    public DbSet<Guest> Guests { get; }
    public DbSet<Role> Roles { get; }

    //Payment
    public DbSet<Account> Accounts { get; }
    public DbSet<AccountType> AccountsTypes { get; }
    public DbSet<Transaction> Transactions { get; }
    public DbSet<TransactionType> TransactionTypes { get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureRelationships(modelBuilder);

        ConfigurePrimaryKeys(modelBuilder);

        Seed(modelBuilder);
    }

    public void ConfigureRelationships(ModelBuilder modelBuilder)
    {
        var entityTypes = typeof(EMSDbContext).Assembly.GetTypes()
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
                        .OnDelete(DeleteBehavior.Cascade); // General case
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
                        .OnDelete(DeleteBehavior.Cascade); // Set delete behavior as needed
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
            .OnDelete(DeleteBehavior.Cascade); // Set delete behavior as needed

        modelBuilder.Entity<Account>()
            .HasMany(a => a.DebitTransactions)
            .WithOne(t => t.DebitAccount)
            .HasForeignKey(t => t.DebitAccountId)
            .OnDelete(DeleteBehavior.Cascade); // Set delete behavior as needed
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

    private static void Seed(ModelBuilder modelBuilder)
    {
        SeedEventTypes(modelBuilder);
        SeedAccountTypes(modelBuilder);
        SeedTransactionTypes(modelBuilder);
        SeedEventVendorStatus(modelBuilder);
        SeedVendorTypes(modelBuilder);
    }

    private static void SeedEventTypes(ModelBuilder modelBuilder)
    {
        var weddingEventType = new EventType
        {
            Id = Guid.NewGuid(),
            Name = "Wedding",
            Description = "A ceremony where two people are united in marriage."
        };

        modelBuilder.Entity<EventType>().HasData(
            weddingEventType
            ,
            new EventType
            {
                Id = Guid.NewGuid(),
                Name = "Corporate Event",
                Description = "An event organized by a company or business for its employees or clients."
            },
            new EventType
            {
                Id = Guid.NewGuid(),
                Name = "Birthday Party",
                Description = "A celebration of the anniversary of a person's birth."
            },
            new EventType
            {
                Id = Guid.NewGuid(),
                Name = "Anniversary Celebration",
                Description = "A celebration commemorating a significant milestone in a couple's relationship."
            },
            new EventType
            {
                Id = Guid.NewGuid(),
                Name = "Graduation Party",
                Description = "A celebration to honor the completion of an academic program."
            },
            new EventType
            {
                Id = Guid.NewGuid(),
                Name = "Baby Shower",
                Description = "A celebration held to honor the expectant mother and her baby."
            },
            new EventType
            {
                Id = Guid.NewGuid(),
                Name = "Charity Event",
                Description = "An event organized to raise funds or awareness for a charitable cause."
            },
            new EventType
            {
                Id = Guid.NewGuid(),
                Name = "Concert",
                Description = "A live performance of music by one or more musicians."
            },
            new EventType
            {
                Id = Guid.NewGuid(),
                Name = "Festival",
                Description = "A series of events or activities celebrating a particular theme or occasion."
            },
            new EventType
            {
                Id = Guid.NewGuid(),
                Name = "Trade Show",
                Description = "An exhibition where businesses showcase their products and services."
            });

        modelBuilder.Entity<EventTypeRole>().HasData(
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Bride",
                Description = "The female participant in the wedding."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Groom",
                Description = "The male participant in the wedding."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Best Man",
                Description = "The groom's chief assistant during the wedding."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Maid of Honor",
                Description = "The bride's chief assistant during the wedding."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Primary Sponsor",
                Description = "The main financial supporter of the wedding."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Secondary Sponsor",
                Description = "An additional financial supporter of the wedding."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Flower Girl",
                Description = "A young girl who scatters flower petals along the aisle."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Ring Bearer",
                Description = "A young child who carries the wedding rings during the ceremony."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Guest",
                Description = "A person invited to attend the wedding."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Bible Bearer",
                Description = "A person who carries the Bible during the ceremony."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Cord",
                Description = "A role representing the cord used in the ceremony."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Candles",
                Description = "A role representing the candle holders during the ceremony."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Ushers",
                Description = "Individuals responsible for seating guests at the ceremony."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Groomsmen",
                Description = "Friends or family who stand with the groom during the ceremony."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Bridesmaids",
                Description = "Friends or family who stand with the bride during the ceremony."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Parent of the Bride",
                Description = "A key family member who may have a significant role."
            },
            new EventTypeRole
            {
                Id = Guid.NewGuid(), EventTypeId = weddingEventType.Id, Name = "Parent of the Groom",
                Description = "A key family member representing the groom's side."
            }
        );
    }

    private static void SeedAccountTypes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountType>().HasData(
            new AccountType { Id = Guid.NewGuid(), Name = "Cash" },
            new AccountType { Id = Guid.NewGuid(), Name = "GCash" },
            new AccountType { Id = Guid.NewGuid(), Name = "Savings" },
            new AccountType { Id = Guid.NewGuid(), Name = "Credit Card" },
            new AccountType { Id = Guid.NewGuid(), Name = "Checking" }
        );
    }

    private static void SeedTransactionTypes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TransactionType>().HasData(
            new TransactionType
            {
                Id = Guid.NewGuid(), Name = "Payment",
                Description =
                    "A general payment or debit from a user’s account, often for non-purchase activities, such as bill payments or installment payments."
            },
            new TransactionType
            {
                Id = Guid.NewGuid(), Name = "Deposit",
                Description = "Represents adding funds to an account, usually as a top-up or a prepayment."
            },
            new TransactionType
            {
                Id = Guid.NewGuid(), Name = "Refund",
                Description =
                    "Represents money returned to the user for a previous purchase, usually due to a return or an issue with the product/service."
            }
        );
    }

    private static void SeedEventVendorStatus(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventVendorStatus>().HasData(
            new EventVendorStatus
            {
                Id = Guid.NewGuid(),
                Name = "Pending",
                Description = "The vendor has been identified but the booking has not yet been finalized."
            },
            new EventVendorStatus
            {
                Id = Guid.NewGuid(),
                Name = "Confirmed",
                Description = "The vendor has been officially booked for the event."
            },
            new EventVendorStatus
            {
                Id = Guid.NewGuid(),
                Name = "Reserved",
                Description = "The vendor is on hold for the event while waiting for confirmation."
            },
            new EventVendorStatus
            {
                Id = Guid.NewGuid(),
                Name = "Cancelled",
                Description = "The vendor was booked but has been removed from the event."
            },
            new EventVendorStatus
            {
                Id = Guid.NewGuid(),
                Name = "Declined",
                Description = "The vendor has formally declined the offer to provide services."
            },
            new EventVendorStatus
            {
                Id = Guid.NewGuid(),
                Name = "Completed",
                Description = "The vendor has fulfilled their obligations, and the event has occurred."
            },
            new EventVendorStatus
            {
                Id = Guid.NewGuid(),
                Name = "In Progress",
                Description = "The vendor is actively working on preparations for the event."
            },
            new EventVendorStatus
            {
                Id = Guid.NewGuid(),
                Name = "Wishlist",
                Description = "The vendor is of interest for potential future events."
            },
            new EventVendorStatus
            {
                Id = Guid.NewGuid(),
                Name = "Feedback Needed",
                Description = "The vendor's performance is under review, and feedback is required."
            },
            new EventVendorStatus
            {
                Id = Guid.NewGuid(),
                Name = "On Hold",
                Description = "The vendor's status is temporarily suspended due to ongoing discussions."
            });
    }

    private static void SeedVendorTypes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VendorType>().HasData(
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Caterer",
                Description = "Provides food and beverage services for the wedding."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Florist",
                Description = "Supplies floral arrangements, bouquets, and centerpieces."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Photographer",
                Description = "Captures memories through professional photography during the wedding."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Videographer",
                Description = "Records the wedding ceremony and reception with high-quality video."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "DJ",
                Description = "Provides music entertainment and emceeing for the wedding and reception."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Live Band",
                Description = "A musical group that performs live at the wedding reception."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Wedding Planner",
                Description = "Coordinates all aspects of the wedding planning process from start to finish."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Venue",
                Description = "Location where the wedding ceremony and/or reception is held."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Baker",
                Description = "Creates wedding cakes, cupcakes, and desserts for the celebration."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Transportation",
                Description = "Provides vehicles for transporting the wedding party and guests."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Officiant",
                Description = "Conducts the wedding ceremony and ensures it is legally binding."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Hair Stylist",
                Description = "Styles hair for the bride, bridesmaids, and other family members."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Makeup Artist",
                Description = "Provides professional makeup services for the bride and bridal party."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Rentals",
                Description = "Offers items for rent such as tables, chairs, linens, and decor."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Stationery",
                Description = "Designs and prints wedding invitations, save-the-dates, and programs."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Photo Booth",
                Description = "Provides a fun photo booth setup with props for guests to enjoy."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Security",
                Description = "Ensures the safety and security of the wedding event and guests."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Lighting Designer",
                Description = "Creates customized lighting plans to enhance the wedding ambiance."
            },
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Sound Engineer",
                Description = "Manages sound systems and audio equipment for the ceremony and reception."
            }
        );
    }
}