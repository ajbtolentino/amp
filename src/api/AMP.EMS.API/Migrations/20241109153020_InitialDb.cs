using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AMP.EMS.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    HtmlContent = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    NickName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    AccountTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    EventTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ContentId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Seats = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTypeRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypeRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventTypeRoles_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    ContactInformation = table.Column<string>(type: "TEXT", nullable: false),
                    VendorTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendors_VendorTypes_VendorTypeId",
                        column: x => x.VendorTypeId,
                        principalTable: "VendorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DebitAccountId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreditAccountId = table.Column<Guid>(type: "TEXT", nullable: true),
                    TransactionTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "TEXT", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_CreditAccountId",
                        column: x => x.CreditAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_DebitAccountId",
                        column: x => x.DebitAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventAccounts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventAccounts_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventGuests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GuestId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Seats = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGuests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventGuests_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventGuests_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventInvitations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ContentId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    RsvpDeadline = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventInvitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventInvitations_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventInvitations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventVendorContractPaymentStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVendorContractPaymentStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventVendorContractPaymentStates_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventVendorContractPaymentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVendorContractPaymentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventVendorContractPaymentTypes_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventVendorContractStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVendorContractStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventVendorContractStates_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventVendorTypeBudgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VendorTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVendorTypeBudgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventVendorTypeBudgets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventVendorTypeBudgets_VendorTypes_VendorTypeId",
                        column: x => x.VendorTypeId,
                        principalTable: "VendorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    VendorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorAccounts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorAccounts_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventVendorTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VendorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TransactionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVendorTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventVendorTransactions_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventVendorTransactions_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventVendorTransactions_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventGuestInvitations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventGuestId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventInvitationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Seats = table.Column<int>(type: "INTEGER", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGuestInvitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventGuestInvitations_EventGuests_EventGuestId",
                        column: x => x.EventGuestId,
                        principalTable: "EventGuests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventGuestInvitations_EventInvitations_EventInvitationId",
                        column: x => x.EventInvitationId,
                        principalTable: "EventInvitations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventVendorContracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VendorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventVendorContractStateId = table.Column<Guid>(type: "TEXT", nullable: true),
                    EventVendorContractPaymentStateId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVendorContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventVendorContracts_EventVendorContractStates_EventVendorContractStateId",
                        column: x => x.EventVendorContractStateId,
                        principalTable: "EventVendorContractStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventVendorContracts_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventVendorContracts_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventGuestRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventGuestId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGuestRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventGuestRoles_EventGuests_EventGuestId",
                        column: x => x.EventGuestId,
                        principalTable: "EventGuests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventGuestRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventGuestInvitationRsvps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventGuestInvitationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Response = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGuestInvitationRsvps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventGuestInvitationRsvps_EventGuestInvitations_EventGuestInvitationId",
                        column: x => x.EventGuestInvitationId,
                        principalTable: "EventGuestInvitations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventVendorContractPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventVendorContractId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventVendorContractPaymentStateId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventVendorContractPaymentTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TransactionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DueAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVendorContractPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventVendorContractPayments_EventVendorContractPaymentStates_EventVendorContractPaymentStateId",
                        column: x => x.EventVendorContractPaymentStateId,
                        principalTable: "EventVendorContractPaymentStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventVendorContractPayments_EventVendorContractPaymentTypes_EventVendorContractPaymentTypeId",
                        column: x => x.EventVendorContractPaymentTypeId,
                        principalTable: "EventVendorContractPaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventVendorContractPayments_EventVendorContracts_EventVendorContractId",
                        column: x => x.EventVendorContractId,
                        principalTable: "EventVendorContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventVendorContractPayments_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventGuestInvitationsRsvpItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventGuestInvitationRsvpId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGuestInvitationsRsvpItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventGuestInvitationsRsvpItems_EventGuestInvitationRsvps_EventGuestInvitationRsvpId",
                        column: x => x.EventGuestInvitationRsvpId,
                        principalTable: "EventGuestInvitationRsvps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("02d081e8-bb1a-4d6d-aa16-c29e72e7c973"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2320), null, "", "Cash", "" },
                    { new Guid("500819d8-4552-4703-828b-4cf8dcaaad91"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2340), null, "", "Checking", "" },
                    { new Guid("b06fcff7-ce4a-457b-870f-b364dd8aaab9"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2330), null, "", "Savings", "" },
                    { new Guid("f7b8d330-ca51-4211-80ba-ab6acc90f044"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2330), null, "", "GCash", "" },
                    { new Guid("fd9c4fad-94fd-45fd-a6d2-f5997e43f5a3"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2330), null, "", "Credit Card", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("36e7e0e3-3bfb-4125-8fe3-08bec8b84e3a"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2210), null, "A celebration held to honor the expectant mother and her baby.", "Baby Shower", "" },
                    { new Guid("5e5c644a-d32b-40a4-9819-1842065d48a5"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2220), null, "An exhibition where businesses showcase their products and services.", "Trade Show", "" },
                    { new Guid("6ae85560-d130-4de0-8226-b56c988530ab"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2190), null, "A celebration of the anniversary of a person's birth.", "Birthday Party", "" },
                    { new Guid("925dd43f-3882-4125-9065-851013d6d1d8"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2220), null, "A series of events or activities celebrating a particular theme or occasion.", "Festival", "" },
                    { new Guid("a102afd5-615a-40cc-94e1-90bf771036a5"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2210), null, "An event organized to raise funds or awareness for a charitable cause.", "Charity Event", "" },
                    { new Guid("a3590b8b-45c5-4f98-8142-f64413f0eb67"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2200), null, "A celebration commemorating a significant milestone in a couple's relationship.", "Anniversary Celebration", "" },
                    { new Guid("a4c59226-8865-471b-b724-0ec7e818deed"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2210), null, "A live performance of music by one or more musicians.", "Concert", "" },
                    { new Guid("b109f167-bf15-4038-b523-bea1921cb8d6"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2200), null, "A celebration to honor the completion of an academic program.", "Graduation Party", "" },
                    { new Guid("b3a07ce2-b81f-4f5c-86a8-be40b98d2cd4"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2190), null, "An event organized by a company or business for its employees or clients.", "Corporate Event", "" },
                    { new Guid("ec954559-ef9d-4a75-85ba-541b4cb3227e"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2130), null, "A ceremony where two people are united in marriage.", "Wedding", "" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1222a76d-3c60-42ca-9271-5b58539bf12a"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2410), null, "Coordination and planning services to manage the entire wedding event.", "Wedding Planning", "" },
                    { new Guid("17dafb61-e27a-4640-afd5-db90cbbb5df4"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2390), null, "Video recording services to capture and document the wedding day.", "Videography", "" },
                    { new Guid("2dbb13fc-45d3-42de-97b3-d2c980b011a2"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2430), null, "Wedding cakes, desserts, and other sweets for the reception.", "Cake & Confectionery", "" },
                    { new Guid("2e9f6496-d993-4bdb-95f2-cd5d2e54025c"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2430), null, "Wedding attire rentals or purchases, including dresses, suits, and accessories.", "Attire & Accessories", "" },
                    { new Guid("30e1ad85-a0aa-455a-b34d-4a4859317e70"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2400), null, "Entertainment services, including live bands, DJs, and performers.", "Music & Entertainment", "" },
                    { new Guid("46a726a5-4472-448e-8417-4694a0ae2c6a"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2450), null, "Wedding rings, bridal jewelry, and other related accessories.", "Jewelry", "" },
                    { new Guid("490cdf27-bdb6-4dc0-8936-a1430d938662"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2390), null, "Professional photography services for capturing wedding moments.", "Photography", "" },
                    { new Guid("5c0f2309-6a1d-4ba2-9c21-a476de55ea5e"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2440), null, "Professional officiants to conduct the wedding ceremony.", "Officiant Services", "" },
                    { new Guid("5dcce45c-9fb3-4c7f-beff-25750f05ffba"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2450), null, "Gifts and party favors for guests.", "Favors & Gifts", "" },
                    { new Guid("69ac64d3-d622-4dbd-9674-2b084e574773"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2450), null, "Rental of items like furniture, tableware, tents, and dance floors.", "Rentals", "" },
                    { new Guid("865fe6ac-de8f-4c51-a46c-83c7966a247f"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2440), null, "Design and printing services for wedding invitations, save-the-dates, and other stationery.", "Stationery & Invitations", "" },
                    { new Guid("8dfceb97-5500-4e49-ac9e-18f285d766d2"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2440), null, "Beauty services for the bridal party, including hairstyling and makeup.", "Hair & Makeup", "" },
                    { new Guid("9b45f19b-75a3-438f-a99a-41daaa84c040"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2380), null, "Locations for wedding ceremonies, receptions, and other related events.", "Venue", "" },
                    { new Guid("9f05938b-bb2d-4f52-81ff-8883737c10d7"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2360), null, "Food and beverage services, including full-course meals, buffets, and bar services.", "Catering", "" },
                    { new Guid("d4e2377d-fc20-4e77-ac43-83bccd0bdfaa"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2410), null, "Transportation services for the wedding party and guests, such as limousines and shuttles.", "Transportation", "" },
                    { new Guid("d8e1ccdc-bb70-4759-9a2b-da627187317d"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2400), null, "Decorative items and setup services, including centerpieces, lighting, and table settings.", "Decor", "" },
                    { new Guid("e7a06360-f78d-41cc-8665-61bf0a7b10a1"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2390), null, "Floral arrangements, bouquets, and other decorative flower services.", "Floristry", "" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("4d6bc72d-c559-4f27-94ec-b097313251b2"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2390), null, "Represents money returned to the user for a previous purchase, usually due to a return or an issue with the product/service.", "Refund", "" },
                    { new Guid("4deb0b73-fd0d-4e82-9999-4d9b91918b4c"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2380), null, "A general payment or debit from a user’s account, often for non-purchase activities, such as bill payments or installment payments.", "Payment", "" },
                    { new Guid("8ab0a935-a7ca-482e-a552-092ff2eb6c8a"), "", new DateTime(2024, 11, 9, 15, 30, 20, 142, DateTimeKind.Utc).AddTicks(2380), null, "Represents adding funds to an account, usually as a top-up or a prepayment.", "Deposit", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0d8c1ec9-4771-4e65-ad0a-2c7bd8db58e0"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2560), null, "Location where the wedding ceremony and/or reception is held.", "Venue", "" },
                    { new Guid("18db66c2-191c-4e34-abf1-f97166dc14f8"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2530), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup Artist", "" },
                    { new Guid("1b691a15-8ca4-4990-91ba-c28600242258"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2570), null, "Captures memories through professional photography during the wedding.", "Photographer", "" },
                    { new Guid("2a2b893f-4a33-4066-bd06-a6594a2f4586"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2610), null, "Ensures the safety and security of the wedding event and guests.", "Security", "" },
                    { new Guid("3273144b-df11-419e-8ace-c27e8074e8c9"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2520), null, "Provides food and beverage services for the wedding.", "Caterer", "" },
                    { new Guid("3e340924-cde0-478f-9ebc-03bf6e0b0cf9"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2510), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "" },
                    { new Guid("4ed3ccea-e270-4c58-b7d3-8ae8cda3e076"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2540), null, "Sells wedding rings and related jewelry.", "Jeweler", "" },
                    { new Guid("5a0ea860-b775-4282-baaf-5d26532ff52a"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2530), null, "A musical group that performs live at the wedding reception.", "Live Band", "" },
                    { new Guid("6186f92c-e2fc-4f8f-8ae3-550f2cbf44cc"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2600), null, "Designs and prints wedding invitations, save-the-dates, and programs.", "Stationery", "" },
                    { new Guid("65e6db8d-8873-4241-9e2a-f8252ff7438e"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2610), null, "Provides a fun photo booth setup with props for guests to enjoy.", "Photo Booth", "" },
                    { new Guid("75152bd9-427d-4b31-962b-ab54482b249b"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2550), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "" },
                    { new Guid("77111b23-bc88-4e61-9a3b-b6a292959010"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2600), null, "Offers items for rent such as tables, chairs, linens, and decor.", "Rentals", "" },
                    { new Guid("7719d4ac-ed43-41f7-8b7b-d8205c802c88"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2590), null, "Styles hair for the bride, bridesmaids, and other family members.", "Hair Stylist", "" },
                    { new Guid("7f54b86b-5a5e-4360-bc6c-e0a982966c45"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2580), null, "Provides vehicles for transporting the wedding party and guests.", "Transportation", "" },
                    { new Guid("8fb658d2-8e63-41b4-aa97-0dc284366f9a"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2580), null, "Creates wedding cakes, cupcakes, and desserts for the celebration.", "Baker", "" },
                    { new Guid("99ca769f-74fe-4cd1-becd-7bfd6f85d731"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2570), null, "Provides music entertainment and emceeing for the wedding and reception.", "DJ", "" },
                    { new Guid("9b77c305-74bd-450d-b12c-c0e3305c4053"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2600), null, "Provides professional makeup services for the bride and bridal party.", "Makeup Artist", "" },
                    { new Guid("a27fbe9d-f9ec-472b-b276-ca838ad9fe65"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2500), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "" },
                    { new Guid("aed438e7-0a34-44b6-bf33-2aad08a05d1b"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2560), null, "Hosts and coordinates the wedding program.", "Emcee", "" },
                    { new Guid("babe111c-6c11-4bdf-9390-e981db0e915a"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2550), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "" },
                    { new Guid("c9d1021d-a2e6-4e33-96cd-b1ba4d972ae2"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2620), null, "Creates customized lighting plans to enhance the wedding ambiance.", "Lighting Designer", "" },
                    { new Guid("de9d7680-e3fe-47b5-ba6b-edd80af592f0"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2570), null, "Records the wedding ceremony and reception with high-quality video.", "Videographer", "" },
                    { new Guid("debf0d5c-3642-4fa7-90bd-f2a848ef7f87"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2580), null, "Coordinates all aspects of the wedding planning process from start to finish.", "Wedding Planner", "" },
                    { new Guid("dfad9764-6276-45d1-ac3d-2f1f66940ba5"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2590), null, "Conducts the wedding ceremony and ensures it is legally binding.", "Officiant", "" },
                    { new Guid("e6ae9ba0-77c4-41bd-888f-43c8ba3e9784"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2520), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "" },
                    { new Guid("e8b91b23-7f3a-4b8e-bfa8-8ac04b298382"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2620), null, "Manages sound systems and audio equipment for the ceremony and reception.", "Sound Engineer", "" },
                    { new Guid("eca44e40-a748-4372-80ab-aed8b57e4fcd"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2530), null, "Captures memories through professional photography during the wedding.", "Photographer & Videographer", "" },
                    { new Guid("f2e88535-0d18-4186-97cd-e0e1a8c8ccde"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2540), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "" },
                    { new Guid("fd7ac64f-1326-47c7-bf47-64b448441620"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2550), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountTypeId", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("323293f2-8fc9-4570-aee8-5fdd39881351"), "4eda7bdb-2f07-4bfa-86f9-3ac97e64957b", new Guid("02d081e8-bb1a-4d6d-aa16-c29e72e7c973"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3320), null, "Event Account", "" },
                    { new Guid("81d5c823-5d94-40c5-9530-8cd2d2787776"), "816b5f34-768d-49a6-a522-0f825e97bbaf", new Guid("02d081e8-bb1a-4d6d-aa16-c29e72e7c973"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2790), null, "Vendor Account", "" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "ContentId", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EndDate", "EventTypeId", "Location", "Seats", "StartDate", "Title", "UpdatedBy" },
                values: new object[] { new Guid("6623411d-8e17-4101-b429-fae571b1caae"), null, "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2910), null, "Wedding", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ec954559-ef9d-4a75-85ba-541b4cb3227e"), "Ph", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wedding", "" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Address", "ContactInformation", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy", "VendorTypeId" },
                values: new object[,]
                {
                    { new Guid("06e62faa-ff9f-4893-b904-ec854385d33e"), "N/A", "", "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2730), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "", new Guid("f2e88535-0d18-4186-97cd-e0e1a8c8ccde") },
                    { new Guid("0fcc1cdf-d4cf-4e88-a22b-1f5419606e7f"), "N/A", "", "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2730), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup", "", new Guid("18db66c2-191c-4e34-abf1-f97166dc14f8") },
                    { new Guid("115fe38b-6a9b-403b-8a08-63bd73e3cf51"), "N/A", "", "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2750), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "", new Guid("75152bd9-427d-4b31-962b-ab54482b249b") },
                    { new Guid("12e0c13d-d4df-4466-bc80-1d57f7e5c53b"), "N/A", "", "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2700), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "", new Guid("3e340924-cde0-478f-9ebc-03bf6e0b0cf9") },
                    { new Guid("44861575-9bc4-4fb2-9b56-51be2e8bef02"), "N/A", "", "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2720), null, "Captures memories through professional photography during the wedding.", "Photo & Video", "", new Guid("eca44e40-a748-4372-80ab-aed8b57e4fcd") },
                    { new Guid("55725585-220d-43ea-8245-f4b75f6e19e4"), "N/A", "", "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2760), null, "Hosts and coordinates the wedding program.", "Emcee", "", new Guid("aed438e7-0a34-44b6-bf33-2aad08a05d1b") },
                    { new Guid("72266823-efa2-4149-a265-01d811bc1cea"), "N/A", "", "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2710), null, "Provides food and beverage services for the wedding.", "Caterer", "", new Guid("3273144b-df11-419e-8ace-c27e8074e8c9") },
                    { new Guid("81b97a70-6dc3-4081-80d5-9e5c85916d13"), "N/A", "", "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2710), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "", new Guid("e6ae9ba0-77c4-41bd-888f-43c8ba3e9784") },
                    { new Guid("b4f5ce8f-d59a-4a7c-a7a5-d174ae8d4464"), "N/A", "", "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2720), null, "A musical group that performs live at the wedding reception.", "Strings", "", new Guid("5a0ea860-b775-4282-baaf-5d26532ff52a") },
                    { new Guid("c1d49297-f566-46ec-bd4a-bc6df6625ed1"), "N/A", "", "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2740), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "", new Guid("fd7ac64f-1326-47c7-bf47-64b448441620") },
                    { new Guid("cc905377-0e04-45fa-8df7-6c0b5c41233d"), "N/A", "", "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2700), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "", new Guid("a27fbe9d-f9ec-472b-b276-ca838ad9fe65") },
                    { new Guid("e5f6171a-4a2b-44d1-98c5-8ae8773a9bef"), "N/A", "", "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2740), null, "Sells wedding rings and related jewelry.", "Jeweler", "", new Guid("4ed3ccea-e270-4c58-b7d3-8ae8cda3e076") },
                    { new Guid("f1aaccae-ac18-40bb-a6ee-5059ff2fcc45"), "N/A", "", "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2750), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "", new Guid("babe111c-6c11-4bdf-9390-e981db0e915a") }
                });

            migrationBuilder.InsertData(
                table: "EventAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "EventId", "UpdatedBy" },
                values: new object[] { new Guid("3421cd47-528e-4925-a3f3-8e8a2cdda4b1"), new Guid("323293f2-8fc9-4570-aee8-5fdd39881351"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3340), null, new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "" });

            migrationBuilder.InsertData(
                table: "EventVendorContractPaymentStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0b1c8174-24b4-4fed-8f58-94a304cbb1b3"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3300), null, "Payment is planned for a future date.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Scheduled", "" },
                    { new Guid("1483b413-c2b5-4746-a172-4fe7bd3f095f"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3270), null, "A portion of the payment has been made.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Partially Paid", "" },
                    { new Guid("1883b151-47f9-460f-a4b5-9f1a3a05c3e7"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3290), null, "Payment is under review and pending approval.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "In Review", "" },
                    { new Guid("26bd2530-b8b2-4076-813d-8cbf00c30044"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3280), null, "Payment is past the due date and is overdue.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Overdue", "" },
                    { new Guid("45df8de5-abf7-46e1-88d5-f4b8a5e38fd5"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3290), null, "Payment is temporarily paused or held.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Hold", "" },
                    { new Guid("67b78b67-fb98-4e59-97d8-66f8cdc0079a"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3270), null, "The full payment has been received.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Completed", "" },
                    { new Guid("87cadc08-82f2-45e1-9c83-df7a1a7f3106"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3280), null, "Payment has been returned to the payer.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Refunded", "" },
                    { new Guid("97da28b7-b283-4903-9ffa-af09a00cc9f1"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3290), null, "The payment was canceled.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Canceled", "" },
                    { new Guid("cc6dd2b7-dc15-4cea-bafd-5db09317e3df"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3260), null, "Payment is scheduled but not yet made.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Pending", "" },
                    { new Guid("edf4e442-66f6-4fea-9722-42e50bbf70ce"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3280), null, "Payment attempt was unsuccessful.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Failed", "" }
                });

            migrationBuilder.InsertData(
                table: "EventVendorContractPaymentTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0d03a578-60db-49ab-aa66-0319aa422c5a"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3230), null, "Additional payment for exceeding performance expectations.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Bonus Payment", "" },
                    { new Guid("1820fbd2-29ef-40c6-ae92-19c988f18899"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3220), null, "Portion of payment withheld until contract conditions are satisfactorily fulfilled.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Holdback", "" },
                    { new Guid("2617743d-e9e6-4fbb-b5c5-d085e95bb377"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3230), null, "Payment held by a third party until contract terms are fulfilled.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Escrow Payment", "" },
                    { new Guid("2c28ac1e-98c5-41c2-9db8-8981ffcff974"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3200), null, "Additional fee imposed if a payment is not made on time.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Late Fee", "" },
                    { new Guid("4bf7b765-6f9c-4bb7-9f4a-aad389c9b707"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3190), null, "Remaining balance due upon completion of the contract.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Final Payment", "" },
                    { new Guid("55646e27-1718-408a-9aa8-0b3db6065bc3"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3170), null, "Initial payment to secure services or confirm a booking.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Deposit", "" },
                    { new Guid("670b35a7-8cef-4ca4-ada2-cda0af578aaf"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3210), null, "Fee charged if the contract is canceled after a specified date.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Cancellation Fee", "" },
                    { new Guid("70bc6289-b6a8-4fad-beb4-479d075e0a21"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3200), null, "Fee charged for contract violations or unmet deadlines.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Penalty Payment", "" },
                    { new Guid("774d0d05-4692-440e-a24a-293173409535"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3210), null, "Reduction in payment, often for early payment or promotional purposes.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Discount", "" },
                    { new Guid("8dc6201a-34db-43d2-b5a4-60a737732db5"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3190), null, "Payments made upon reaching specific milestones or stages.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Progress Payment", "" },
                    { new Guid("a257f1f6-7265-4445-9146-4316c11c1c84"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3180), null, "Scheduled partial payment at specific intervals in the contract.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Installment", "" },
                    { new Guid("ad7ec30b-997e-43c8-91e3-0cb69cbb4037"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3180), null, "Payment to secure ongoing services, may or may not apply toward final balance.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Retainer", "" },
                    { new Guid("b54d7b24-b632-46e8-9461-740c34ce1f37"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3230), null, "Additional fee for using a specific payment method.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Service Charge", "" },
                    { new Guid("c428ff6c-3e06-4e79-b191-6a98bb4de6c5"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3210), null, "Amount returned to the client if conditions such as cancellations are met.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Refund", "" },
                    { new Guid("f6b15557-24ff-45ee-a592-15a711c02b71"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3200), null, "Payment made in advance for materials, equipment, or initial requirements.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Advance Payment", "" }
                });

            migrationBuilder.InsertData(
                table: "EventVendorContractStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("00c404b5-bcd0-4d60-bcc8-0432072d140c"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3100), null, "Internal review and approval of the final terms.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Approval", "" },
                    { new Guid("05d7adca-dd53-4181-93f7-b185026dab95"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3110), null, "Both parties sign the contract, making it legally binding.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Signed", "" },
                    { new Guid("2538ed42-b4f6-45aa-8c79-5d02d4f4edd7"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3120), null, "Vendor begins preparations for the event based on the agreed services.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Preparation and Planning", "" },
                    { new Guid("43df2865-db1a-4c7c-b076-03ae0e60fbca"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3110), null, "An initial deposit is paid to secure the vendor’s services.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Deposit Paid", "" },
                    { new Guid("8ae2f7fc-e178-4304-b8c9-ebf2cf39b0aa"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3120), null, "Discussion of adjustments if needed during execution.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Review and Adjustments", "" },
                    { new Guid("96b9fa12-ff67-4577-b70f-94f916a922be"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3140), null, "Contract is officially closed after all deliverables are met and payments are completed.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Contract Closeout", "" },
                    { new Guid("a1c41846-7dcf-4c05-8f02-8cfccf67982b"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3130), null, "Final payment is made upon the completion of services.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Completion and Final Payment", "" },
                    { new Guid("af252ff1-bfce-4a81-a9f3-805c9cedbeac"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3120), null, "Vendor delivers their services during the event as outlined in the contract.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Execution", "" },
                    { new Guid("cf080be2-8f02-4c58-b5b1-cf7e0bf7ae35"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3110), null, "Vendor reviews the contract and proposes changes or confirms terms.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Contract Review", "" },
                    { new Guid("d529b4ab-337d-43bd-9ed5-15292771fac1"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3090), null, "Discussion and adjustments of terms, pricing, and deliverables.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Negotiation", "" },
                    { new Guid("d7b8c4c3-9177-45ed-a06c-e741c51ded3f"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3100), null, "Formal contract is drafted and sent to the vendor for review and signing.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Contract Sent", "" },
                    { new Guid("d9612655-5153-4f7c-94b2-16def6adadcb"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3080), null, "Initial contact to check vendor availability and gather preliminary information.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Inquiry", "" },
                    { new Guid("e7b29691-c947-4213-b5f7-d11bac553287"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3090), null, "Vendor provides a detailed proposal including costs, services, and timelines.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Proposal", "" },
                    { new Guid("f3586ed3-6fa7-4c41-b12a-a8546d482a25"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3130), null, "Event manager provides feedback on the vendor’s performance.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Feedback and Review", "" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("02ad38ba-a83c-4255-a760-e02a5c568132"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2940), null, "The female participant in the wedding.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Bride", "" },
                    { new Guid("0583cc20-5eb4-4c7e-913f-89903203df32"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2990), null, "The bride's chief assistant during the wedding.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Maid of Honor", "" },
                    { new Guid("07845c72-b5d4-49d8-aded-36553feb2850"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3040), null, "Friends or family who stand with the bride during the ceremony.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Bridesmaids", "" },
                    { new Guid("11ea0a44-8de6-49a3-af97-3d85e52b562e"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3010), null, "A person invited to attend the wedding.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Guest", "" },
                    { new Guid("33c7dccb-23f0-4fee-a08f-b672c3c18984"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3030), null, "Individuals responsible for seating guests at the ceremony.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Ushers", "" },
                    { new Guid("542ff4f6-35fa-4581-8e92-8b7df30eda9b"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3000), null, "The main financial supporter of the wedding.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Primary Sponsor", "" },
                    { new Guid("6c9514c1-29f8-4140-b8e7-90cc9fdf1d60"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3000), null, "An additional financial supporter of the wedding.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Secondary Sponsor", "" },
                    { new Guid("8d259d94-1345-4af2-8937-b143294f178c"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3020), null, "A person who carries the Bible during the ceremony.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Bible Bearer", "" },
                    { new Guid("b18e23fb-ae02-45db-8f5c-db332d6f5627"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3010), null, "A young child who carries the wedding rings during the ceremony.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Ring Bearer", "" },
                    { new Guid("bf5abf23-ed6d-4d0e-b704-6dee7a5a1820"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2950), null, "The male participant in the wedding.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Groom", "" },
                    { new Guid("c0b98d13-c20d-4710-8c63-36d44e71a9e8"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3010), null, "A young girl who scatters flower petals along the aisle.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Flower Girl", "" },
                    { new Guid("cfc12038-32e2-4bc8-ad65-356214c2e55e"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3030), null, "A role representing the candle holders during the ceremony.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Candles", "" },
                    { new Guid("d142ede2-fee7-4fca-90fa-d0fafe9b069a"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3030), null, "Friends or family who stand with the groom during the ceremony.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Groomsmen", "" },
                    { new Guid("e7f49fad-b351-4981-beb1-2f890a0cc59f"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2990), null, "The groom's chief assistant during the wedding.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Best Man", "" },
                    { new Guid("eb00a127-74b7-4156-8933-6e41cb179ed4"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3040), null, "A key family member who may have a significant role.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Parent of the Bride", "" },
                    { new Guid("ed809762-9918-4bc0-8a85-1ade09926b8e"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3050), null, "A key family member representing the groom's side.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Parent of the Groom", "" },
                    { new Guid("f76c592a-bf05-4695-a793-dc9196c1669f"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(3020), null, "A role representing the cord used in the ceremony.", new Guid("6623411d-8e17-4101-b429-fae571b1caae"), "Cord", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "UpdatedBy", "VendorId" },
                values: new object[,]
                {
                    { new Guid("21bda1a6-c48c-4669-880c-8586c209f301"), new Guid("81d5c823-5d94-40c5-9530-8cd2d2787776"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2860), null, "", new Guid("e5f6171a-4a2b-44d1-98c5-8ae8773a9bef") },
                    { new Guid("3a280f49-0286-4ec7-a1bb-701704cd12f7"), new Guid("81d5c823-5d94-40c5-9530-8cd2d2787776"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2850), null, "", new Guid("44861575-9bc4-4fb2-9b56-51be2e8bef02") },
                    { new Guid("6747238c-78ee-45ff-8518-6b907d6af0f5"), new Guid("81d5c823-5d94-40c5-9530-8cd2d2787776"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2880), null, "", new Guid("55725585-220d-43ea-8245-f4b75f6e19e4") },
                    { new Guid("72b85905-bbbf-47dc-b51e-54f394cb9c22"), new Guid("81d5c823-5d94-40c5-9530-8cd2d2787776"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2830), null, "", new Guid("cc905377-0e04-45fa-8df7-6c0b5c41233d") },
                    { new Guid("7a0c0d50-91d0-41bc-b718-a58d680b525c"), new Guid("81d5c823-5d94-40c5-9530-8cd2d2787776"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2840), null, "", new Guid("81b97a70-6dc3-4081-80d5-9e5c85916d13") },
                    { new Guid("86658d5e-f17a-49bd-824f-a76ad264373a"), new Guid("81d5c823-5d94-40c5-9530-8cd2d2787776"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2870), null, "", new Guid("115fe38b-6a9b-403b-8a08-63bd73e3cf51") },
                    { new Guid("88f6f0b4-4ba9-4ff8-b123-e27e375b3907"), new Guid("81d5c823-5d94-40c5-9530-8cd2d2787776"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2840), null, "", new Guid("12e0c13d-d4df-4466-bc80-1d57f7e5c53b") },
                    { new Guid("aabc5c04-063d-4111-be95-6150687c886f"), new Guid("81d5c823-5d94-40c5-9530-8cd2d2787776"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2860), null, "", new Guid("06e62faa-ff9f-4893-b904-ec854385d33e") },
                    { new Guid("b56eac0a-b6bb-4122-a5b4-72824ff3b643"), new Guid("81d5c823-5d94-40c5-9530-8cd2d2787776"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2850), null, "", new Guid("b4f5ce8f-d59a-4a7c-a7a5-d174ae8d4464") },
                    { new Guid("d9df98e5-91e2-40d6-82ae-99077f4e683a"), new Guid("81d5c823-5d94-40c5-9530-8cd2d2787776"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2870), null, "", new Guid("c1d49297-f566-46ec-bd4a-bc6df6625ed1") },
                    { new Guid("df605743-7503-43a4-b6ee-c5ca6432164f"), new Guid("81d5c823-5d94-40c5-9530-8cd2d2787776"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2870), null, "", new Guid("f1aaccae-ac18-40bb-a6ee-5059ff2fcc45") },
                    { new Guid("e0952eb4-67c3-4fc2-864b-1c963ab0b333"), new Guid("81d5c823-5d94-40c5-9530-8cd2d2787776"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2860), null, "", new Guid("0fcc1cdf-d4cf-4e88-a22b-1f5419606e7f") },
                    { new Guid("f3545455-1807-4210-8bac-772be83761c4"), new Guid("81d5c823-5d94-40c5-9530-8cd2d2787776"), "", new DateTime(2024, 11, 9, 15, 30, 20, 144, DateTimeKind.Utc).AddTicks(2850), null, "", new Guid("72266823-efa2-4149-a265-01d811bc1cea") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAccounts_AccountId",
                table: "EventAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAccounts_EventId",
                table: "EventAccounts",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventGuestInvitationRsvps_EventGuestInvitationId",
                table: "EventGuestInvitationRsvps",
                column: "EventGuestInvitationId");

            migrationBuilder.CreateIndex(
                name: "IX_EventGuestInvitations_EventGuestId",
                table: "EventGuestInvitations",
                column: "EventGuestId");

            migrationBuilder.CreateIndex(
                name: "IX_EventGuestInvitations_EventInvitationId",
                table: "EventGuestInvitations",
                column: "EventInvitationId");

            migrationBuilder.CreateIndex(
                name: "IX_EventGuestInvitationsRsvpItems_EventGuestInvitationRsvpId",
                table: "EventGuestInvitationsRsvpItems",
                column: "EventGuestInvitationRsvpId");

            migrationBuilder.CreateIndex(
                name: "IX_EventGuestRoles_EventGuestId",
                table: "EventGuestRoles",
                column: "EventGuestId");

            migrationBuilder.CreateIndex(
                name: "IX_EventGuestRoles_RoleId",
                table: "EventGuestRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EventGuests_EventId",
                table: "EventGuests",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventGuests_GuestId",
                table: "EventGuests",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_EventInvitations_ContentId",
                table: "EventInvitations",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_EventInvitations_EventId",
                table: "EventInvitations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ContentId",
                table: "Events",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTypeRoles_EventTypeId",
                table: "EventTypeRoles",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorContractPayments_EventVendorContractId",
                table: "EventVendorContractPayments",
                column: "EventVendorContractId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorContractPayments_EventVendorContractPaymentStateId",
                table: "EventVendorContractPayments",
                column: "EventVendorContractPaymentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorContractPayments_EventVendorContractPaymentTypeId",
                table: "EventVendorContractPayments",
                column: "EventVendorContractPaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorContractPayments_TransactionId",
                table: "EventVendorContractPayments",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorContractPaymentStates_EventId",
                table: "EventVendorContractPaymentStates",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorContractPaymentTypes_EventId",
                table: "EventVendorContractPaymentTypes",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorContracts_EventId",
                table: "EventVendorContracts",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorContracts_EventVendorContractStateId",
                table: "EventVendorContracts",
                column: "EventVendorContractStateId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorContracts_VendorId",
                table: "EventVendorContracts",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorContractStates_EventId",
                table: "EventVendorContractStates",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorTransactions_EventId",
                table: "EventVendorTransactions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorTransactions_TransactionId",
                table: "EventVendorTransactions",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorTransactions_VendorId",
                table: "EventVendorTransactions",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorTypeBudgets_EventId",
                table: "EventVendorTypeBudgets",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorTypeBudgets_VendorTypeId",
                table: "EventVendorTypeBudgets",
                column: "VendorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_EventId",
                table: "Roles",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CreditAccountId",
                table: "Transactions",
                column: "CreditAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DebitAccountId",
                table: "Transactions",
                column: "DebitAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorAccounts_AccountId",
                table: "VendorAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorAccounts_VendorId",
                table: "VendorAccounts",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_VendorTypeId",
                table: "Vendors",
                column: "VendorTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventAccounts");

            migrationBuilder.DropTable(
                name: "EventGuestInvitationsRsvpItems");

            migrationBuilder.DropTable(
                name: "EventGuestRoles");

            migrationBuilder.DropTable(
                name: "EventTypeRoles");

            migrationBuilder.DropTable(
                name: "EventVendorContractPayments");

            migrationBuilder.DropTable(
                name: "EventVendorTransactions");

            migrationBuilder.DropTable(
                name: "EventVendorTypeBudgets");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "VendorAccounts");

            migrationBuilder.DropTable(
                name: "EventGuestInvitationRsvps");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "EventVendorContractPaymentStates");

            migrationBuilder.DropTable(
                name: "EventVendorContractPaymentTypes");

            migrationBuilder.DropTable(
                name: "EventVendorContracts");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "EventGuestInvitations");

            migrationBuilder.DropTable(
                name: "EventVendorContractStates");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropTable(
                name: "EventGuests");

            migrationBuilder.DropTable(
                name: "EventInvitations");

            migrationBuilder.DropTable(
                name: "VendorTypes");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "EventTypes");
        }
    }
}
