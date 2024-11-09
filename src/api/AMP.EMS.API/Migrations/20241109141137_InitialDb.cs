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
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "TEXT", nullable: false),
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
                    { new Guid("1598adb2-fb2c-4caf-b249-b905db71c49f"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(380), null, "", "Savings", "" },
                    { new Guid("20535fbb-c6ae-4f0b-91e6-fc2105746680"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(370), null, "", "Cash", "" },
                    { new Guid("3e5c8ca3-1915-45fd-9596-3354bd2be42a"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(380), null, "", "GCash", "" },
                    { new Guid("73ce86ee-39f0-4b4f-9617-d88f1b80f5a6"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(390), null, "", "Checking", "" },
                    { new Guid("bb21e56a-a4f2-412b-9d3b-3b0d55b344f9"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(390), null, "", "Credit Card", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("13d52730-9dac-476e-8304-44dd8d48a22e"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(240), null, "A celebration of the anniversary of a person's birth.", "Birthday Party", "" },
                    { new Guid("1558d5d9-4a5e-4bad-a555-c165010d36be"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(290), null, "An exhibition where businesses showcase their products and services.", "Trade Show", "" },
                    { new Guid("21141317-00c5-4959-b46c-4a46eb988883"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(250), null, "A celebration held to honor the expectant mother and her baby.", "Baby Shower", "" },
                    { new Guid("225622e3-09aa-482f-bd36-a1a6c12ce881"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(270), null, "A series of events or activities celebrating a particular theme or occasion.", "Festival", "" },
                    { new Guid("2bfb8e9c-78c1-49fd-9b1d-576f8d4bdf33"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(240), null, "A celebration commemorating a significant milestone in a couple's relationship.", "Anniversary Celebration", "" },
                    { new Guid("969736e8-361a-4b54-aa52-3971d5019f71"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(230), null, "An event organized by a company or business for its employees or clients.", "Corporate Event", "" },
                    { new Guid("a7fd6bdb-5f96-41d4-bcfd-c10062c960ab"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(160), null, "A ceremony where two people are united in marriage.", "Wedding", "" },
                    { new Guid("ab2eed80-1f5f-4cf7-9c8d-358baee62900"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(260), null, "A live performance of music by one or more musicians.", "Concert", "" },
                    { new Guid("efbccf7c-ffd3-4e20-91c8-9c5177703a8e"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(250), null, "A celebration to honor the completion of an academic program.", "Graduation Party", "" },
                    { new Guid("f256a59c-b3ec-4c9e-bb58-72bcef335a29"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(260), null, "An event organized to raise funds or awareness for a charitable cause.", "Charity Event", "" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("094c8474-9a12-4085-b249-08499d0138a3"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3520), null, "Wedding attire rentals or purchases, including dresses, suits, and accessories.", "Attire & Accessories", "" },
                    { new Guid("0d7f6b5f-0861-4e4b-a020-aef0ae80d646"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3510), null, "Entertainment services, including live bands, DJs, and performers.", "Music & Entertainment", "" },
                    { new Guid("1dd04fe9-ca4a-4c6e-8ce4-538194bbdeb1"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3500), null, "Decorative items and setup services, including centerpieces, lighting, and table settings.", "Decor", "" },
                    { new Guid("2cb1e290-c098-42fe-8df5-396b9815ba6f"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3480), null, "Locations for wedding ceremonies, receptions, and other related events.", "Venue", "" },
                    { new Guid("3bc7f6c6-846f-4727-9e55-f0bbd7d98040"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3540), null, "Wedding rings, bridal jewelry, and other related accessories.", "Jewelry", "" },
                    { new Guid("6f7155c4-7549-407f-806b-7818be495ee8"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3490), null, "Floral arrangements, bouquets, and other decorative flower services.", "Floristry", "" },
                    { new Guid("74791ac5-18ec-4002-98bd-21672477ec42"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3540), null, "Rental of items like furniture, tableware, tents, and dance floors.", "Rentals", "" },
                    { new Guid("7dd4ee8b-cf6b-403f-ad70-f2a756dd0971"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3540), null, "Professional officiants to conduct the wedding ceremony.", "Officiant Services", "" },
                    { new Guid("86d4c2dd-2e54-4178-9590-efb15f5b520a"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3510), null, "Transportation services for the wedding party and guests, such as limousines and shuttles.", "Transportation", "" },
                    { new Guid("89889d58-e70f-4fd7-a099-6d10d35fab77"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3510), null, "Coordination and planning services to manage the entire wedding event.", "Wedding Planning", "" },
                    { new Guid("8a21b067-8f23-4770-935c-77e8d0fc7a02"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3490), null, "Professional photography services for capturing wedding moments.", "Photography", "" },
                    { new Guid("9b1c388a-7c37-438a-9844-b65acffe3528"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3520), null, "Wedding cakes, desserts, and other sweets for the reception.", "Cake & Confectionery", "" },
                    { new Guid("9d57d95f-500f-40a6-b212-d041c659a1f7"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3530), null, "Beauty services for the bridal party, including hairstyling and makeup.", "Hair & Makeup", "" },
                    { new Guid("a0832d17-efe5-4c09-a2a1-b85c119a75dd"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3550), null, "Gifts and party favors for guests.", "Favors & Gifts", "" },
                    { new Guid("c0c21fa0-60de-4220-8352-7f8620725f90"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3530), null, "Design and printing services for wedding invitations, save-the-dates, and other stationery.", "Stationery & Invitations", "" },
                    { new Guid("db62a404-5c63-49dd-97df-6c23ceca565d"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3490), null, "Video recording services to capture and document the wedding day.", "Videography", "" },
                    { new Guid("f920b1f3-1851-4c2c-8cd8-59cd92d18f8d"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3450), null, "Food and beverage services, including full-course meals, buffets, and bar services.", "Catering", "" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("058c93c6-23d3-4b06-b0d4-47eb58e4dbe1"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(450), null, "Represents money returned to the user for a previous purchase, usually due to a return or an issue with the product/service.", "Refund", "" },
                    { new Guid("749d9194-ad7e-4ed5-af7d-072084ef5c9c"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(440), null, "Represents adding funds to an account, usually as a top-up or a prepayment.", "Deposit", "" },
                    { new Guid("aa35b35b-0c03-480a-b394-2d12fede75b8"), "", new DateTime(2024, 11, 9, 14, 11, 37, 578, DateTimeKind.Utc).AddTicks(440), null, "A general payment or debit from a user’s account, often for non-purchase activities, such as bill payments or installment payments.", "Payment", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0cfa29f0-d7b5-4a78-a329-94ba1b572c73"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3760), null, "Provides a fun photo booth setup with props for guests to enjoy.", "Photo Booth", "" },
                    { new Guid("175c740a-9daf-4915-83fe-476ebd558d4c"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3700), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "" },
                    { new Guid("28be6d42-d8a2-4d56-92da-7975f63429c5"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3650), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "" },
                    { new Guid("2f93df87-a126-42d0-be2b-758802e6a972"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3740), null, "Provides professional makeup services for the bride and bridal party.", "Makeup Artist", "" },
                    { new Guid("300f6fe8-d929-443e-bac7-43d65295cbde"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3750), null, "Offers items for rent such as tables, chairs, linens, and decor.", "Rentals", "" },
                    { new Guid("309e008c-5562-4c4d-b6cb-bfe952fa9262"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3730), null, "Provides vehicles for transporting the wedding party and guests.", "Transportation", "" },
                    { new Guid("60f4bafa-3321-4aee-97f3-2d4725610ca3"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3660), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "" },
                    { new Guid("6279169f-c5d4-4221-8ed1-45c0dbaac7d2"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3680), null, "Sells wedding rings and related jewelry.", "Jeweler", "" },
                    { new Guid("66527723-3f4a-4f76-b06c-6930cccb4f74"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3690), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "" },
                    { new Guid("668e3f60-72b5-4365-bd99-70dbf014baeb"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3680), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "" },
                    { new Guid("77fddc6a-8851-4737-9862-fecd8d1cdb6f"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3720), null, "Coordinates all aspects of the wedding planning process from start to finish.", "Wedding Planner", "" },
                    { new Guid("80073138-dc12-4284-988c-990bf9527438"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3640), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "" },
                    { new Guid("8f701d4a-bb62-4b54-887d-a6e5a834a189"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3700), null, "Hosts and coordinates the wedding program.", "Emcee", "" },
                    { new Guid("9def4b1c-cac9-48fe-9277-259615028f66"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3670), null, "A musical group that performs live at the wedding reception.", "Live Band", "" },
                    { new Guid("a43bd740-9a53-450b-8d34-3362e43230d5"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3740), null, "Conducts the wedding ceremony and ensures it is legally binding.", "Officiant", "" },
                    { new Guid("b19edce9-a85d-4cb5-8242-a9203d204833"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3680), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup Artist", "" },
                    { new Guid("c0e0dd66-089e-4997-9544-2d918224e11a"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3660), null, "Provides food and beverage services for the wedding.", "Caterer", "" },
                    { new Guid("c732cc59-cf23-4cef-aaed-8c11b954637c"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3760), null, "Creates customized lighting plans to enhance the wedding ambiance.", "Lighting Designer", "" },
                    { new Guid("c8307720-4994-4610-8de3-eba3139d15cd"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3740), null, "Styles hair for the bride, bridesmaids, and other family members.", "Hair Stylist", "" },
                    { new Guid("cd970576-e1a9-4aba-88d4-ffca05365a34"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3760), null, "Ensures the safety and security of the wedding event and guests.", "Security", "" },
                    { new Guid("cf1bb971-2c16-484c-a5f1-af01537e7640"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3710), null, "Records the wedding ceremony and reception with high-quality video.", "Videographer", "" },
                    { new Guid("d3c7dd8c-e305-4a2b-ba1d-34566136ee3c"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3710), null, "Location where the wedding ceremony and/or reception is held.", "Venue", "" },
                    { new Guid("d7b749f6-1c50-46ef-8e7b-0d17f1de6d7c"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3720), null, "Provides music entertainment and emceeing for the wedding and reception.", "DJ", "" },
                    { new Guid("d91e5033-0098-4c56-980e-1b589b7a9072"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3730), null, "Creates wedding cakes, cupcakes, and desserts for the celebration.", "Baker", "" },
                    { new Guid("e203179d-5af5-4f1f-91fd-30708ada90ea"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3770), null, "Manages sound systems and audio equipment for the ceremony and reception.", "Sound Engineer", "" },
                    { new Guid("e2b14a13-099c-4d4f-ad8e-09c6d4e862d0"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3670), null, "Captures memories through professional photography during the wedding.", "Photographer & Videographer", "" },
                    { new Guid("f5777ef2-f383-4d93-acae-4f5b38e59b7c"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3750), null, "Designs and prints wedding invitations, save-the-dates, and programs.", "Stationery", "" },
                    { new Guid("fccfce59-9e97-4384-91ba-872242c2e282"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3710), null, "Captures memories through professional photography during the wedding.", "Photographer", "" },
                    { new Guid("fe59058c-f866-4a8b-a7d3-a1c000ac8433"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3690), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountTypeId", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("e380bfb8-4be0-488a-b258-152df101f32a"), "d99b69cd-f396-4dbc-a893-2c34d666cff5", new Guid("20535fbb-c6ae-4f0b-91e6-fc2105746680"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4000), null, "Vendor Account", "" },
                    { new Guid("e417c7c4-2d87-4d71-8977-e56ceeb4785c"), "67183ee7-f896-41ca-b943-d0f7927d637d", new Guid("20535fbb-c6ae-4f0b-91e6-fc2105746680"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4620), null, "Event Account", "" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "ContentId", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EndDate", "EventTypeId", "Location", "Seats", "StartDate", "Title", "UpdatedBy" },
                values: new object[] { new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), null, "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4130), null, "Wedding", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a7fd6bdb-5f96-41d4-bcfd-c10062c960ab"), "Ph", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wedding", "" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Address", "ContactInformation", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy", "VendorTypeId" },
                values: new object[,]
                {
                    { new Guid("0d828522-1f9a-4e22-8709-949a7e049a34"), "N/A", "", "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3930), null, "Sells wedding rings and related jewelry.", "Jeweler", "", new Guid("6279169f-c5d4-4221-8ed1-45c0dbaac7d2") },
                    { new Guid("0e833525-08ed-4483-b014-41473b420e88"), "N/A", "", "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3940), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "", new Guid("175c740a-9daf-4915-83fe-476ebd558d4c") },
                    { new Guid("2312fe87-7c61-42fb-8126-d1a75cf0b680"), "N/A", "", "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3890), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "", new Guid("28be6d42-d8a2-4d56-92da-7975f63429c5") },
                    { new Guid("7bf1ed78-94f5-4b12-8f2e-b7bc26d339b0"), "N/A", "", "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3920), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup", "", new Guid("b19edce9-a85d-4cb5-8242-a9203d204833") },
                    { new Guid("8d8752ff-d7c3-46fc-b55b-c2313bd803d6"), "N/A", "", "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3910), null, "A musical group that performs live at the wedding reception.", "Strings", "", new Guid("9def4b1c-cac9-48fe-9277-259615028f66") },
                    { new Guid("918dab29-a364-48e0-a2e9-106d0d0401fa"), "N/A", "", "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3900), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "", new Guid("60f4bafa-3321-4aee-97f3-2d4725610ca3") },
                    { new Guid("bd027d5c-dd4d-4f18-854e-4afc68da1495"), "N/A", "", "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3910), null, "Captures memories through professional photography during the wedding.", "Photo & Video", "", new Guid("e2b14a13-099c-4d4f-ad8e-09c6d4e862d0") },
                    { new Guid("c315c79c-50f0-446c-9ca0-7733d85dc0f3"), "N/A", "", "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3900), null, "Provides food and beverage services for the wedding.", "Caterer", "", new Guid("c0e0dd66-089e-4997-9544-2d918224e11a") },
                    { new Guid("d7b58007-21ab-4863-945d-eceb3425c47c"), "N/A", "", "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3920), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "", new Guid("668e3f60-72b5-4365-bd99-70dbf014baeb") },
                    { new Guid("dacb6d40-d36f-41ca-a598-df3021cfbcdf"), "N/A", "", "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3940), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "", new Guid("66527723-3f4a-4f76-b06c-6930cccb4f74") },
                    { new Guid("e74aef4a-9ecb-4bce-af01-e69a1b330cb7"), "N/A", "", "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3880), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "", new Guid("80073138-dc12-4284-988c-990bf9527438") },
                    { new Guid("f2b6a927-4b12-4106-87ec-046d5d39ad71"), "N/A", "", "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3950), null, "Hosts and coordinates the wedding program.", "Emcee", "", new Guid("8f701d4a-bb62-4b54-887d-a6e5a834a189") },
                    { new Guid("f45213a6-425e-4959-9e51-a8e5332a4bb7"), "N/A", "", "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(3930), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "", new Guid("fe59058c-f866-4a8b-a7d3-a1c000ac8433") }
                });

            migrationBuilder.InsertData(
                table: "EventAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "EventId", "UpdatedBy" },
                values: new object[] { new Guid("f14cf5f6-0beb-44ef-aca5-2cc1d7e7b43d"), new Guid("e417c7c4-2d87-4d71-8977-e56ceeb4785c"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4650), null, new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "" });

            migrationBuilder.InsertData(
                table: "EventVendorContractPaymentStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0cdf33fc-e20e-46dc-a987-f966173f9569"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4580), null, "Payment is temporarily paused or held.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Hold", "" },
                    { new Guid("1463c2f4-7b41-436b-9181-dc607cbfb444"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4560), null, "The full payment has been received.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Completed", "" },
                    { new Guid("177da231-950d-4d21-a81a-8d99314c1f9e"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4530), null, "A portion of the payment has been made.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Partially Paid", "" },
                    { new Guid("8182f11c-fe02-4b42-a52e-55370a9fe830"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4570), null, "Payment has been returned to the payer.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Refunded", "" },
                    { new Guid("aff3e3cf-b786-4bd5-afba-c4248491fa70"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4570), null, "The payment was canceled.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Canceled", "" },
                    { new Guid("b1f2dbd4-f599-4f84-87f7-a418a0bbbde8"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4560), null, "Payment is past the due date and is overdue.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Overdue", "" },
                    { new Guid("ba6e8db4-7735-433a-9aba-da8079610f69"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4510), null, "Payment is scheduled but not yet made.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Pending", "" },
                    { new Guid("bd94921d-7476-4e63-bc2b-dc7a4d3409e5"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4560), null, "Payment attempt was unsuccessful.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Failed", "" },
                    { new Guid("dccd9ea4-c62e-4164-83a6-11f83e1b2879"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4580), null, "Payment is under review and pending approval.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "In Review", "" },
                    { new Guid("f63b682d-bb41-485a-9166-6fa32d19ca87"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4590), null, "Payment is planned for a future date.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Scheduled", "" }
                });

            migrationBuilder.InsertData(
                table: "EventVendorContractPaymentTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("08d46d3f-df17-4fe1-b09d-047714e5e72d"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4470), null, "Additional payment for exceeding performance expectations.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Bonus Payment", "" },
                    { new Guid("106aa278-36af-4c07-a3d8-5aaeb8bc6037"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4420), null, "Scheduled partial payment at specific intervals in the contract.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Installment", "" },
                    { new Guid("1b38f49f-f711-4be9-8964-5198d9d15326"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4440), null, "Payment made in advance for materials, equipment, or initial requirements.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Advance Payment", "" },
                    { new Guid("2a066769-c315-49ea-8784-e428f87f5233"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4420), null, "Payment to secure ongoing services, may or may not apply toward final balance.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Retainer", "" },
                    { new Guid("2cde0f97-a726-4a68-ab8f-853f90266d40"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4440), null, "Additional fee imposed if a payment is not made on time.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Late Fee", "" },
                    { new Guid("3174d0c2-6708-4005-a99c-cf99f30813cb"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4430), null, "Payments made upon reaching specific milestones or stages.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Progress Payment", "" },
                    { new Guid("3c95952a-b785-41b2-b9de-bd33400e15f4"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4440), null, "Fee charged for contract violations or unmet deadlines.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Penalty Payment", "" },
                    { new Guid("643c2925-6cab-469b-895c-b58c0e9885d8"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4470), null, "Additional fee for using a specific payment method.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Service Charge", "" },
                    { new Guid("67853fa5-22b1-4c61-ac1e-b046b00a3656"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4400), null, "Initial payment to secure services or confirm a booking.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Deposit", "" },
                    { new Guid("67e39413-9fbe-4786-bf56-159a7308f81e"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4460), null, "Amount returned to the client if conditions such as cancellations are met.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Refund", "" },
                    { new Guid("6fabdbfc-8423-40ea-82d0-94175d3605be"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4430), null, "Remaining balance due upon completion of the contract.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Final Payment", "" },
                    { new Guid("83538d26-58f8-4200-96b9-19c45e724795"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4470), null, "Payment held by a third party until contract terms are fulfilled.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Escrow Payment", "" },
                    { new Guid("bac0af5c-ff32-4355-920d-49c3d6258a14"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4450), null, "Fee charged if the contract is canceled after a specified date.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Cancellation Fee", "" },
                    { new Guid("bdfef515-b24c-4f99-8e1d-af681c29cba7"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4460), null, "Portion of payment withheld until contract conditions are satisfactorily fulfilled.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Holdback", "" },
                    { new Guid("f02a9434-4696-441a-9b14-e3c411c2b3d4"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4450), null, "Reduction in payment, often for early payment or promotional purposes.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Discount", "" }
                });

            migrationBuilder.InsertData(
                table: "EventVendorContractStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("249f46fc-29fa-4fab-84e9-6dfdb3f2894a"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4340), null, "Vendor delivers their services during the event as outlined in the contract.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Execution", "" },
                    { new Guid("293cfdc2-03b3-4f62-afc8-43d5f5c012b9"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4350), null, "Final payment is made upon the completion of services.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Completion and Final Payment", "" },
                    { new Guid("2de6f006-8113-400d-8cd0-12a5ba6a091a"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4330), null, "Both parties sign the contract, making it legally binding.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Signed", "" },
                    { new Guid("35d773c5-4943-45e7-892b-09010ad5d185"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4300), null, "Discussion and adjustments of terms, pricing, and deliverables.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Negotiation", "" },
                    { new Guid("4d7855f8-9d2d-4444-ab75-e56c0afba481"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4310), null, "Internal review and approval of the final terms.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Approval", "" },
                    { new Guid("5ffdf207-f5a0-4ad3-a8ae-3b94fc29006a"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4330), null, "Vendor begins preparations for the event based on the agreed services.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Preparation and Planning", "" },
                    { new Guid("601166db-2eb2-45f8-b4b8-c82280005b42"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4310), null, "Formal contract is drafted and sent to the vendor for review and signing.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Contract Sent", "" },
                    { new Guid("666f4310-b7a1-4514-b499-08c6c81920c6"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4360), null, "Contract is officially closed after all deliverables are met and payments are completed.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Contract Closeout", "" },
                    { new Guid("686332f6-99f2-4712-a629-d60f7a0255d3"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4330), null, "An initial deposit is paid to secure the vendor’s services.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Deposit Paid", "" },
                    { new Guid("8a60802e-714c-4220-b40b-230090e5ba3b"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4340), null, "Discussion of adjustments if needed during execution.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Review and Adjustments", "" },
                    { new Guid("9a5993be-9abd-40f0-93c3-40782d2f523b"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4290), null, "Initial contact to check vendor availability and gather preliminary information.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Inquiry", "" },
                    { new Guid("abe58884-d3c2-468c-b192-70bf822c220a"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4350), null, "Event manager provides feedback on the vendor’s performance.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Feedback and Review", "" },
                    { new Guid("c2ce32e7-7810-47d1-afbd-44d7fab9f17b"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4300), null, "Vendor provides a detailed proposal including costs, services, and timelines.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Proposal", "" },
                    { new Guid("fb8ea7e8-9927-4b7d-aae2-0e52bad6f831"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4320), null, "Vendor reviews the contract and proposes changes or confirms terms.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Contract Review", "" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("00233391-1a04-41b9-845c-40546f331c9e"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4190), null, "A young girl who scatters flower petals along the aisle.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Flower Girl", "" },
                    { new Guid("0a4c4df3-8058-4777-b8f6-6e472714d9fb"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4240), null, "A key family member representing the groom's side.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Parent of the Groom", "" },
                    { new Guid("2f8fe7a4-7d7f-4e5e-9e86-7ce0178c7dcf"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4180), null, "An additional financial supporter of the wedding.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Secondary Sponsor", "" },
                    { new Guid("5735431c-e786-43ef-89a9-d0906e3ebc3c"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4220), null, "Individuals responsible for seating guests at the ceremony.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Ushers", "" },
                    { new Guid("84fa2f83-e816-4cdd-91e4-69d5c41f8c38"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4230), null, "A key family member who may have a significant role.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Parent of the Bride", "" },
                    { new Guid("936c8974-ea80-400e-8b61-e316891817a9"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4170), null, "The male participant in the wedding.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Groom", "" },
                    { new Guid("97c922d5-bbc0-4fb7-a1ca-04d73df19646"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4160), null, "The female participant in the wedding.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Bride", "" },
                    { new Guid("9be53970-9a7b-4585-b7f3-0de9702366a4"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4220), null, "Friends or family who stand with the groom during the ceremony.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Groomsmen", "" },
                    { new Guid("a746ec40-e032-4c9b-815e-6b9fb55b4699"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4230), null, "Friends or family who stand with the bride during the ceremony.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Bridesmaids", "" },
                    { new Guid("ad62ace9-19ef-4a14-ba57-990d96dad05d"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4180), null, "The main financial supporter of the wedding.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Primary Sponsor", "" },
                    { new Guid("c87a9d65-269a-4768-b406-68fd03a452ec"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4210), null, "A person who carries the Bible during the ceremony.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Bible Bearer", "" },
                    { new Guid("cf6e0455-ec92-4eed-a266-8f82614f9c97"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4180), null, "The bride's chief assistant during the wedding.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Maid of Honor", "" },
                    { new Guid("da58f79f-0f8c-48ec-bba8-a27adc501cb3"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4210), null, "A role representing the cord used in the ceremony.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Cord", "" },
                    { new Guid("ef3ae8d8-592c-47c6-99b3-ab0f1bd439b5"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4210), null, "A role representing the candle holders during the ceremony.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Candles", "" },
                    { new Guid("f3d98732-acb8-4bd9-9f4a-b6e7857db407"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4200), null, "A person invited to attend the wedding.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Guest", "" },
                    { new Guid("f96330ff-4993-4bbd-b428-ae02157c696d"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4190), null, "A young child who carries the wedding rings during the ceremony.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Ring Bearer", "" },
                    { new Guid("fd657d58-fc8b-4564-8c13-5f2a9cfc9113"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4170), null, "The groom's chief assistant during the wedding.", new Guid("eb299097-bb65-42bb-8392-63917c191fb9"), "Best Man", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "UpdatedBy", "VendorId" },
                values: new object[] { new Guid("4afb77f1-c5c5-4018-8ec5-a29738962e09"), new Guid("e380bfb8-4be0-488a-b258-152df101f32a"), "", new DateTime(2024, 11, 9, 14, 11, 37, 580, DateTimeKind.Utc).AddTicks(4040), null, "", new Guid("e74aef4a-9ecb-4bce-af01-e69a1b330cb7") });

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
