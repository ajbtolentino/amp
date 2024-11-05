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
    public DbSet<Vendor> Vendors { get; }
    public DbSet<VendorType> VendorTypes { get; }
    public DbSet<VendorAccount> VendorAccounts { get; }

    //Event
    public DbSet<ContractState> ContractStates { get; }
    public DbSet<ContractPaymentState> ContractPaymentStates { get; }
    public DbSet<EventAccount> EventAccounts { get; }
    public DbSet<Event> Events { get; }
    public DbSet<EventVendorTypeBudget> EventVendorTypeBudgets { get; }
    public DbSet<EventGuest> EventGuests { get; }
    public DbSet<EventGuestInvitation> EventGuestInvitations { get; }
    public DbSet<EventGuestInvitationRsvp> EventGuestInvitationRsvps { get; }
    public DbSet<EventGuestInvitationRsvpItem> EventGuestInvitationsRsvpItems { get; }
    public DbSet<EventGuestRole> EventGuestRoles { get; }
    public DbSet<EventInvitation> EventInvitations { get; }
    public DbSet<EventType> EventTypes { get; }
    public DbSet<EventTypeRole> EventTypeRoles { get; }
    public DbSet<EventVendorContract> EventVendorContracts { get; set; }
    public DbSet<EventVendorContractState> EventVendorContractStates { get; set; }
    public DbSet<EventVendorTransaction> EventVendorTransactions { get; set; }
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

    private static void Seed(ModelBuilder modelBuilder)
    {
        SeedEventTypes(modelBuilder);
        SeedAccountTypes(modelBuilder);
        SeedTransactionTypes(modelBuilder);
        SeedVendors(modelBuilder);
        SeedProductTypes(modelBuilder);
        SeedContractStates(modelBuilder);
        SeedContractPaymentStates(modelBuilder);
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

    private static void SeedVendors(ModelBuilder modelBuilder)
    {
        var catererVendorType = new VendorType
        {
            Id = Guid.NewGuid(),
            Name = "Caterer",
            Description = "Provides food and beverage services for the wedding."
        };
        var venueVendorType =
            new VendorType
            {
                Id = Guid.NewGuid(),
                Name = "Venue",
                Description = "Location where the wedding ceremony and/or reception is held."
            };
        var floristVendorType = new VendorType
        {
            Id = Guid.NewGuid(),
            Name = "Florist",
            Description = "Supplies floral arrangements, bouquets, and centerpieces."
        };
        var photovideoVendorType = new VendorType
        {
            Id = Guid.NewGuid(),
            Name = "Photographer & Videographer",
            Description = "Captures memories through professional photography during the wedding."
        };
        var liveBandVendorType = new VendorType
        {
            Id = Guid.NewGuid(),
            Name = "Live Band",
            Description = "A musical group that performs live at the wedding reception."
        };
        modelBuilder.Entity<VendorType>().HasData(
            catererVendorType,
            venueVendorType,
            floristVendorType,
            photovideoVendorType,
            liveBandVendorType,
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

        // SeedEventVendorContractStates(modelBuilder);
    }

    private static void SeedProductTypes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductType>().HasData(
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Catering",
                Description = "Food and beverage services, including full-course meals, buffets, and bar services."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Venue",
                Description = "Locations for wedding ceremonies, receptions, and other related events."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Photography",
                Description = "Professional photography services for capturing wedding moments."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Videography",
                Description = "Video recording services to capture and document the wedding day."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Floristry",
                Description = "Floral arrangements, bouquets, and other decorative flower services."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Decor",
                Description =
                    "Decorative items and setup services, including centerpieces, lighting, and table settings."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Music & Entertainment",
                Description = "Entertainment services, including live bands, DJs, and performers."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Wedding Planning",
                Description = "Coordination and planning services to manage the entire wedding event."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Transportation",
                Description =
                    "Transportation services for the wedding party and guests, such as limousines and shuttles."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Cake & Confectionery",
                Description = "Wedding cakes, desserts, and other sweets for the reception."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Attire & Accessories",
                Description = "Wedding attire rentals or purchases, including dresses, suits, and accessories."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Hair & Makeup",
                Description = "Beauty services for the bridal party, including hairstyling and makeup."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Stationery & Invitations",
                Description =
                    "Design and printing services for wedding invitations, save-the-dates, and other stationery."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Officiant Services",
                Description = "Professional officiants to conduct the wedding ceremony."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Rentals",
                Description = "Rental of items like furniture, tableware, tents, and dance floors."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Jewelry",
                Description = "Wedding rings, bridal jewelry, and other related accessories."
            },
            new ProductType
            {
                Id = Guid.NewGuid(),
                Name = "Favors & Gifts",
                Description = "Gifts and party favors for guests."
            }
        );
    }

    private static void SeedContractStates(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContractState>().HasData(
            new ContractState
            {
                Id = Guid.NewGuid(),
                Name = "Inquiry",
                Description = "Initial inquiry stage."
            },
            new ContractState
            {
                Id = Guid.NewGuid(),
                Name = "Pending Quote",
                Description = "Waiting for a quote from the vendor."
            },
            new ContractState
            {
                Id = Guid.NewGuid(),
                Name = "Quote Received",
                Description = "Quote has been received from the vendor."
            },
            new ContractState
            {
                Id = Guid.NewGuid(),
                Name = "Negotiation",
                Description = "Negotiations are ongoing with the vendor."
            },
            new ContractState
            {
                Id = Guid.NewGuid(),
                Name = "Reserved",
                Description = "Reserved but not yet confirmed."
            },
            new ContractState
            {
                Id = Guid.NewGuid(),
                Name = "Tentative",
                Description = "Tentatively booked, awaiting confirmation."
            },
            new ContractState
            {
                Id = Guid.NewGuid(),
                Name = "Booked",
                Description = "Contract has been booked and confirmed."
            },
            new ContractState
            {
                Id = Guid.NewGuid(),
                Name = "Closed",
                Description = "Contract has been completed and closed."
            }
        );
    }

    private static void SeedContractPaymentStates(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContractPaymentState>().HasData(
            new ContractPaymentState
            {
                Id = Guid.NewGuid(),
                Name = "Deposit Pending",
                Description = "Waiting for the initial deposit to be paid."
            },
            new ContractPaymentState
            {
                Id = Guid.NewGuid(),
                Name = "Partial Payment",
                Description = "Partial payment received, remaining balance due."
            },
            new ContractPaymentState
            {
                Id = Guid.NewGuid(),
                Name = "Paid in Full",
                Description = "All payments have been made, contract is paid in full."
            },
            new ContractPaymentState
            {
                Id = Guid.NewGuid(),
                Name = "Overdue Payment",
                Description = "Payment is overdue."
            },
            new ContractPaymentState
            {
                Id = Guid.NewGuid(),
                Name = "Refund Pending",
                Description = "Refund is pending processing."
            },
            new ContractPaymentState
            {
                Id = Guid.NewGuid(),
                Name = "Refunded",
                Description = "Refund has been processed and completed."
            }
        );
    }
}