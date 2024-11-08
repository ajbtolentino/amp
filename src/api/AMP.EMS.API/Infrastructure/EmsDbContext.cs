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
    private static List<AccountType> _accountTypes;

    private static List<EventType> _eventTypes;

    //Catalog
    public DbSet<Vendor> Vendors { get; }
    public DbSet<VendorType> VendorTypes { get; }
    public DbSet<VendorAccount> VendorAccounts { get; }

    //Content
    public DbSet<Content> Contents { get; }

    //Event
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
    public DbSet<EventVendorContractPayment> EventVendorContractPayments { get; set; }
    public DbSet<EventVendorContractPaymentType> EventVendorContractPaymentTypes { get; set; }
    public DbSet<EventVendorContractPaymentState> EventVendorContractPaymentStates { get; set; }
    public DbSet<EventVendorTransaction> EventVendorTransactions { get; set; }
    public DbSet<Guest> Guests { get; }
    public DbSet<Role> Roles { get; }

    //Payment
    public DbSet<Account> Accounts { get; }
    public DbSet<AccountType> AccountTypes { get; }
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
        SeedProductTypes(modelBuilder);
        SeedVendors(modelBuilder);
        SeedEvents(modelBuilder);
    }

    private static void SeedEventTypes(ModelBuilder modelBuilder)
    {
        _eventTypes = new List<EventType>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Wedding",
                Description = "A ceremony where two people are united in marriage."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Corporate Event",
                Description = "An event organized by a company or business for its employees or clients."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Birthday Party",
                Description = "A celebration of the anniversary of a person's birth."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Anniversary Celebration",
                Description = "A celebration commemorating a significant milestone in a couple's relationship."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Graduation Party",
                Description = "A celebration to honor the completion of an academic program."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Baby Shower",
                Description = "A celebration held to honor the expectant mother and her baby."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Charity Event",
                Description = "An event organized to raise funds or awareness for a charitable cause."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Concert",
                Description = "A live performance of music by one or more musicians."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Festival",
                Description = "A series of events or activities celebrating a particular theme or occasion."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Trade Show",
                Description = "An exhibition where businesses showcase their products and services."
            }
        };

        modelBuilder.Entity<EventType>().HasData(_eventTypes);
    }

    private static void SeedAccountTypes(ModelBuilder modelBuilder)
    {
        _accountTypes = new List<AccountType>
        {
            new() { Id = Guid.NewGuid(), Name = "Cash" },
            new() { Id = Guid.NewGuid(), Name = "GCash" },
            new() { Id = Guid.NewGuid(), Name = "Savings" },
            new() { Id = Guid.NewGuid(), Name = "Credit Card" },
            new() { Id = Guid.NewGuid(), Name = "Checking" }
        };
        modelBuilder.Entity<AccountType>().HasData(_accountTypes);
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
        var vendorTypes = new List<VendorType>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Church",
                Description = "A venue for hosting wedding ceremonies, typically in a religious setting."
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Reception Venue",
                Description = "A venue for hosting post-ceremony receptions or gatherings."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Lights & Sounds",
                Description = "Manages lights, sound systems and audio equipment for the ceremony and reception."
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Caterer",
                Description = "Provides food and beverage services for the wedding."
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Photographer & Videographer",
                Description = "Captures memories through professional photography during the wedding."
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Live Band",
                Description = "A musical group that performs live at the wedding reception."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Hair & Makeup Artist",
                Description = "Provides professional makeup services for the bride and bridal party."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Florist",
                Description = "Supplies floral arrangements, bouquets, and centerpieces."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Jeweler",
                Description = "Sells wedding rings and related jewelry."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Wedding Coordinator",
                Description = "Organizes wedding activities and ensures event flows smoothly."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Mobile Bar",
                Description = "Provides mobile bar services for cocktail hours and receptions."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Souvenirs",
                Description = "Offers keepsakes or favors for wedding guests."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Emcee",
                Description = "Hosts and coordinates the wedding program."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Venue",
                Description = "Location where the wedding ceremony and/or reception is held."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Photographer",
                Description = "Captures memories through professional photography during the wedding."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Videographer",
                Description = "Records the wedding ceremony and reception with high-quality video."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "DJ",
                Description = "Provides music entertainment and emceeing for the wedding and reception."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Wedding Planner",
                Description = "Coordinates all aspects of the wedding planning process from start to finish."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Baker",
                Description = "Creates wedding cakes, cupcakes, and desserts for the celebration."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Transportation",
                Description = "Provides vehicles for transporting the wedding party and guests."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Officiant",
                Description = "Conducts the wedding ceremony and ensures it is legally binding."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Hair Stylist",
                Description = "Styles hair for the bride, bridesmaids, and other family members."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Makeup Artist",
                Description = "Provides professional makeup services for the bride and bridal party."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Rentals",
                Description = "Offers items for rent such as tables, chairs, linens, and decor."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Stationery",
                Description = "Designs and prints wedding invitations, save-the-dates, and programs."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Photo Booth",
                Description = "Provides a fun photo booth setup with props for guests to enjoy."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Security",
                Description = "Ensures the safety and security of the wedding event and guests."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Lighting Designer",
                Description = "Creates customized lighting plans to enhance the wedding ambiance."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Sound Engineer",
                Description = "Manages sound systems and audio equipment for the ceremony and reception."
            }
        };

        modelBuilder.Entity<VendorType>().HasData(vendorTypes);

        var vendors = new List<Vendor>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Church",
                Description = vendorTypes[0].Description,
                Address = "N/A",
                VendorTypeId = vendorTypes[0].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Reception Venue",
                Description = vendorTypes[1].Description,
                Address = "N/A",
                VendorTypeId = vendorTypes[1].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Lights & Sounds",
                Description = vendorTypes[2].Description,
                Address = "N/A",
                VendorTypeId = vendorTypes[2].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Caterer",
                Description = vendorTypes[3].Description,
                Address = "N/A",
                VendorTypeId = vendorTypes[3].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Photo & Video",
                Description = vendorTypes[4].Description,
                Address = "N/A",
                VendorTypeId = vendorTypes[4].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Strings",
                Description = vendorTypes[5].Description,
                Address = "N/A",
                VendorTypeId = vendorTypes[5].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Hair & Makeup",
                Description = vendorTypes[6].Description,
                Address = "N/A",
                VendorTypeId = vendorTypes[6].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Florist",
                Description = vendorTypes[7].Description,
                Address = "N/A",
                VendorTypeId = vendorTypes[7].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Jeweler",
                Description = vendorTypes[8].Description,
                Address = "N/A",
                VendorTypeId = vendorTypes[8].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Wedding Coordinator",
                Description = vendorTypes[9].Description,
                Address = "N/A",
                VendorTypeId = vendorTypes[9].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Mobile Bar",
                Description = vendorTypes[10].Description,
                Address = "N/A",
                VendorTypeId = vendorTypes[10].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Souvenirs",
                Description = vendorTypes[11].Description,
                Address = "N/A",
                VendorTypeId = vendorTypes[11].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Emcee",
                Description = vendorTypes[12].Description,
                Address = "N/A",
                VendorTypeId = vendorTypes[12].Id
            }
        };

        modelBuilder.Entity<Vendor>().HasData(vendors);

        var account = new Account
        {
            Id = Guid.NewGuid(),
            Name = "Vendor Account",
            AccountNumber = Guid.NewGuid().ToString(),
            AccountTypeId = _accountTypes[0].Id
        };

        modelBuilder.Entity<Account>().HasData(account);

        var vendorAccounts = new List<VendorAccount>
        {
            new()
            {
                Id = Guid.NewGuid(),
                VendorId = vendors[0].Id,
                AccountId = account.Id
            }
        };

        modelBuilder.Entity<VendorAccount>().HasData(vendorAccounts);
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

    private static void SeedEvents(ModelBuilder modelBuilder)
    {
        var @event = new Event
        {
            Id = Guid.NewGuid(),
            Title = "Wedding",
            EventTypeId = _eventTypes[0].Id,
            Description = "Wedding",
            Location = "Ph"
        };

        modelBuilder.Entity<Event>().HasData(@event);

        var roles = new List<Role>
        {
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Bride",
                Description = "The female participant in the wedding."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Groom",
                Description = "The male participant in the wedding."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Best Man",
                Description = "The groom's chief assistant during the wedding."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Maid of Honor",
                Description = "The bride's chief assistant during the wedding."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Primary Sponsor",
                Description = "The main financial supporter of the wedding."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Secondary Sponsor",
                Description = "An additional financial supporter of the wedding."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Flower Girl",
                Description = "A young girl who scatters flower petals along the aisle."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Ring Bearer",
                Description = "A young child who carries the wedding rings during the ceremony."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Guest",
                Description = "A person invited to attend the wedding."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Bible Bearer",
                Description = "A person who carries the Bible during the ceremony."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Cord",
                Description = "A role representing the cord used in the ceremony."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Candles",
                Description = "A role representing the candle holders during the ceremony."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Ushers",
                Description = "Individuals responsible for seating guests at the ceremony."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Groomsmen",
                Description = "Friends or family who stand with the groom during the ceremony."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Bridesmaids",
                Description = "Friends or family who stand with the bride during the ceremony."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Parent of the Bride",
                Description = "A key family member who may have a significant role."
            },
            new()
            {
                EventId = @event.Id,
                Id = Guid.NewGuid(), Name = "Parent of the Groom",
                Description = "A key family member representing the groom's side."
            }
        };

        modelBuilder.Entity<Role>().HasData(roles);

        var eventVendorContractState = new List<EventVendorContractState>
        {
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Inquiry",
                Description = "Initial contact to check vendor availability and gather preliminary information."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Proposal",
                Description = "Vendor provides a detailed proposal including costs, services, and timelines."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Negotiation",
                Description = "Discussion and adjustments of terms, pricing, and deliverables."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Approval",
                Description = "Internal review and approval of the final terms."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Contract Sent",
                Description = "Formal contract is drafted and sent to the vendor for review and signing."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Contract Review",
                Description = "Vendor reviews the contract and proposes changes or confirms terms."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Signed",
                Description = "Both parties sign the contract, making it legally binding."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Deposit Paid",
                Description = "An initial deposit is paid to secure the vendor’s services."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Preparation and Planning",
                Description = "Vendor begins preparations for the event based on the agreed services."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Execution",
                Description = "Vendor delivers their services during the event as outlined in the contract."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Review and Adjustments",
                Description = "Discussion of adjustments if needed during execution."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Completion and Final Payment",
                Description = "Final payment is made upon the completion of services."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Feedback and Review",
                Description = "Event manager provides feedback on the vendor’s performance."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Contract Closeout",
                Description = "Contract is officially closed after all deliverables are met and payments are completed."
            }
        };

        modelBuilder.Entity<EventVendorContractState>().HasData(eventVendorContractState);

        var eventVendorContractPaymentTypes = new List<EventVendorContractPaymentType>
        {
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Deposit",
                Description = "Initial payment to secure services or confirm a booking."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Retainer",
                Description = "Payment to secure ongoing services, may or may not apply toward final balance."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Installment",
                Description = "Scheduled partial payment at specific intervals in the contract."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Progress Payment",
                Description = "Payments made upon reaching specific milestones or stages."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Final Payment",
                Description = "Remaining balance due upon completion of the contract."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Advance Payment",
                Description = "Payment made in advance for materials, equipment, or initial requirements."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Penalty Payment",
                Description = "Fee charged for contract violations or unmet deadlines."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Late Fee",
                Description = "Additional fee imposed if a payment is not made on time."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Cancellation Fee",
                Description = "Fee charged if the contract is canceled after a specified date."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Discount",
                Description = "Reduction in payment, often for early payment or promotional purposes."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Refund",
                Description = "Amount returned to the client if conditions such as cancellations are met."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Holdback",
                Description = "Portion of payment withheld until contract conditions are satisfactorily fulfilled."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Service Charge",
                Description = "Additional fee for using a specific payment method."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Escrow Payment",
                Description = "Payment held by a third party until contract terms are fulfilled."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Bonus Payment",
                Description = "Additional payment for exceeding performance expectations."
            }
        };

        modelBuilder.Entity<EventVendorContractPaymentType>().HasData(eventVendorContractPaymentTypes);

        var eventVendorContractPaymentStates = new List<EventVendorContractPaymentState>
        {
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Pending",
                Description = "Payment is scheduled but not yet made."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Partially Paid",
                Description = "A portion of the payment has been made."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Completed",
                Description = "The full payment has been received."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Overdue",
                Description = "Payment is past the due date and is overdue."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Failed",
                Description = "Payment attempt was unsuccessful."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Refunded",
                Description = "Payment has been returned to the payer."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Canceled",
                Description = "The payment was canceled."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "In Review",
                Description = "Payment is under review and pending approval."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Hold",
                Description = "Payment is temporarily paused or held."
            },
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                Name = "Scheduled",
                Description = "Payment is planned for a future date."
            }
        };

        modelBuilder.Entity<EventVendorContractPaymentState>().HasData(eventVendorContractPaymentStates);

        var account = new Account
        {
            Id = Guid.NewGuid(),
            Name = "Event Account",
            AccountNumber = Guid.NewGuid().ToString(),
            AccountTypeId = _accountTypes[0].Id
        };

        modelBuilder.Entity<Account>().HasData(account);

        var eventAccounts = new List<EventAccount>
        {
            new()
            {
                Id = Guid.NewGuid(),
                EventId = @event.Id,
                AccountId = account.Id
            }
        };

        modelBuilder.Entity<EventAccount>().HasData(eventAccounts);
    }
}