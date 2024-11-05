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
                name: "AccountsTypes",
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
                    table.PrimaryKey("PK_AccountsTypes", x => x.Id);
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
                        name: "FK_Accounts_AccountsTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountsTypes",
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
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    MaxGuests = table.Column<int>(type: "INTEGER", nullable: false),
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
                    MaxGuests = table.Column<int>(type: "INTEGER", nullable: false),
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
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Html = table.Column<string>(type: "TEXT", nullable: false),
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
                        name: "FK_EventInvitations_Events_EventId",
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
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
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
                    MaxGuests = table.Column<int>(type: "INTEGER", nullable: false),
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
                    EventVendorContractStateId = table.Column<Guid>(type: "TEXT", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "AccountsTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("11da9125-45ba-443d-8620-750e230e1d3b"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2880), null, "", "Credit Card", "" },
                    { new Guid("3675aff8-6e78-452f-b0b9-ac5b13c274e8"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2880), null, "", "Savings", "" },
                    { new Guid("91defe2d-e4f2-48b0-bf5f-56b9e6399bbd"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2870), null, "", "Cash", "" },
                    { new Guid("a9a9f5ad-9c23-4958-a1e1-f89a1e72ee6c"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2870), null, "", "GCash", "" },
                    { new Guid("dadb84da-560c-4b5e-ba86-0ace19259169"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2880), null, "", "Checking", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2127eb36-fa82-431e-bc74-244ef505ba2d"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2670), null, "A live performance of music by one or more musicians.", "Concert", "" },
                    { new Guid("245d423b-3358-4bae-ad05-cfde1c393b1c"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2680), null, "An exhibition where businesses showcase their products and services.", "Trade Show", "" },
                    { new Guid("5470a3e5-9689-4e54-952c-93828c60594b"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2650), null, "A celebration commemorating a significant milestone in a couple's relationship.", "Anniversary Celebration", "" },
                    { new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2570), null, "A ceremony where two people are united in marriage.", "Wedding", "" },
                    { new Guid("5d5161cf-0dbb-434d-8840-1758078b935d"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2650), null, "An event organized by a company or business for its employees or clients.", "Corporate Event", "" },
                    { new Guid("6dc18c4b-d3fe-4c66-8c94-e966b13ee8c8"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2660), null, "A celebration to honor the completion of an academic program.", "Graduation Party", "" },
                    { new Guid("7263a0c2-8d0a-46b3-a4e4-4ce01c033f7d"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2660), null, "A celebration held to honor the expectant mother and her baby.", "Baby Shower", "" },
                    { new Guid("7643cb54-ac9a-400d-abce-283817f194c6"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2650), null, "A celebration of the anniversary of a person's birth.", "Birthday Party", "" },
                    { new Guid("917ab3c9-a7ec-4e8d-ab46-76ce520bdd30"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2670), null, "A series of events or activities celebrating a particular theme or occasion.", "Festival", "" },
                    { new Guid("e3e26fb8-4e1f-4627-a580-85707c2a265d"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2670), null, "An event organized to raise funds or awareness for a charitable cause.", "Charity Event", "" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("01d147f0-9769-45da-88ef-922c5ab7e234"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1960), null, "Rental of items like furniture, tableware, tents, and dance floors.", "Rentals", "" },
                    { new Guid("146c743e-71b9-4325-8478-486e6ff39832"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1910), null, "Food and beverage services, including full-course meals, buffets, and bar services.", "Catering", "" },
                    { new Guid("27dfc974-f19b-4296-ab66-659316653b3b"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1970), null, "Gifts and party favors for guests.", "Favors & Gifts", "" },
                    { new Guid("2ac5c2d2-3ced-4feb-b232-bfba08105ad3"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1970), null, "Wedding rings, bridal jewelry, and other related accessories.", "Jewelry", "" },
                    { new Guid("40e816f8-d1b0-4bca-9f47-da61407afe94"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1960), null, "Professional officiants to conduct the wedding ceremony.", "Officiant Services", "" },
                    { new Guid("43cd0150-307a-4cd4-b9d4-696050d61811"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1930), null, "Floral arrangements, bouquets, and other decorative flower services.", "Floristry", "" },
                    { new Guid("46b70372-7284-4f8c-892a-3315b1904ae8"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1930), null, "Video recording services to capture and document the wedding day.", "Videography", "" },
                    { new Guid("54322633-466e-4017-8087-8d45f5cfa9f7"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1950), null, "Wedding attire rentals or purchases, including dresses, suits, and accessories.", "Attire & Accessories", "" },
                    { new Guid("7f801627-fcf0-42ed-8914-3eeb7906afd6"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1920), null, "Professional photography services for capturing wedding moments.", "Photography", "" },
                    { new Guid("802b0aac-5a95-480e-bccb-bc25301b6e77"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1930), null, "Decorative items and setup services, including centerpieces, lighting, and table settings.", "Decor", "" },
                    { new Guid("87f99f88-1e1d-44a9-afbc-b872b0f5b173"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1920), null, "Locations for wedding ceremonies, receptions, and other related events.", "Venue", "" },
                    { new Guid("cec7473a-18ae-450f-b03f-5e3026420370"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1950), null, "Beauty services for the bridal party, including hairstyling and makeup.", "Hair & Makeup", "" },
                    { new Guid("da486461-d2b0-42a7-a250-2ff438ebfe74"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1960), null, "Design and printing services for wedding invitations, save-the-dates, and other stationery.", "Stationery & Invitations", "" },
                    { new Guid("e94da569-c211-4ce1-8aae-c11a807d7ac0"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1940), null, "Transportation services for the wedding party and guests, such as limousines and shuttles.", "Transportation", "" },
                    { new Guid("ea83681a-96f8-4da1-8931-17e33ef3cbdd"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1940), null, "Coordination and planning services to manage the entire wedding event.", "Wedding Planning", "" },
                    { new Guid("eb05b2f8-61dc-4d1d-a723-4e81978b4b5e"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1940), null, "Entertainment services, including live bands, DJs, and performers.", "Music & Entertainment", "" },
                    { new Guid("f403f511-0c53-4782-ab40-613191b3fa7c"), "", new DateTime(2024, 11, 5, 17, 20, 24, 720, DateTimeKind.Utc).AddTicks(1950), null, "Wedding cakes, desserts, and other sweets for the reception.", "Cake & Confectionery", "" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1a05ea18-849c-4cd8-8f64-03855efef8f6"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2910), null, "Represents money returned to the user for a previous purchase, usually due to a return or an issue with the product/service.", "Refund", "" },
                    { new Guid("5282484f-a027-43cf-9e08-083f54dac409"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2910), null, "A general payment or debit from a user’s account, often for non-purchase activities, such as bill payments or installment payments.", "Payment", "" },
                    { new Guid("b1628ee9-8507-4927-a781-9260a4c14c59"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2910), null, "Represents adding funds to an account, usually as a top-up or a prepayment.", "Deposit", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("092e00b4-b27f-4a8f-8339-37f64743198a"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2940), null, "A musical group that performs live at the wedding reception.", "Live Band", "" },
                    { new Guid("10b64b30-4934-4b3c-940f-ea077e32c78f"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(3020), null, "Ensures the safety and security of the wedding event and guests.", "Security", "" },
                    { new Guid("206d24a6-468b-4cc4-a727-509639b60b77"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2920), null, "Provides food and beverage services for the wedding.", "Caterer", "" },
                    { new Guid("22b434c1-1a0a-4bb0-a0ea-26706d2384c5"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(3020), null, "Creates customized lighting plans to enhance the wedding ambiance.", "Lighting Designer", "" },
                    { new Guid("39d2322b-6a3f-4a9f-be6b-82e321b16f2a"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(3000), null, "Conducts the wedding ceremony and ensures it is legally binding.", "Officiant", "" },
                    { new Guid("3a70e7d2-4ac6-41af-acf0-a141be9b2091"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2930), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "" },
                    { new Guid("3c177f6e-dd76-49ec-a791-befde9763283"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2970), null, "Captures memories through professional photography during the wedding.", "Photographer", "" },
                    { new Guid("406f0dfe-596a-45b9-aea8-28b16fef4085"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2930), null, "Location where the wedding ceremony and/or reception is held.", "Venue", "" },
                    { new Guid("4100e596-f3de-4f63-bf4f-1b90596d44b3"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(3010), null, "Offers items for rent such as tables, chairs, linens, and decor.", "Rentals", "" },
                    { new Guid("71a1b0a5-cc67-4ce9-ab29-7b35f64465b3"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(3010), null, "Provides a fun photo booth setup with props for guests to enjoy.", "Photo Booth", "" },
                    { new Guid("72b454d2-f76a-4c74-afd9-7396fd9778df"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(3000), null, "Provides professional makeup services for the bride and bridal party.", "Makeup Artist", "" },
                    { new Guid("8747dc59-5d1f-4f10-bc49-99ce7a916c62"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(3000), null, "Styles hair for the bride, bridesmaids, and other family members.", "Hair Stylist", "" },
                    { new Guid("9ed85546-ad00-4de9-a23d-69f162b6b46a"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2980), null, "Provides music entertainment and emceeing for the wedding and reception.", "DJ", "" },
                    { new Guid("c1935865-0b30-4221-87f0-9b8d307be39c"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2990), null, "Provides vehicles for transporting the wedding party and guests.", "Transportation", "" },
                    { new Guid("c6185270-e0e6-4aca-a64a-e0a7e877901b"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2970), null, "Records the wedding ceremony and reception with high-quality video.", "Videographer", "" },
                    { new Guid("cf14b1ec-490c-4f4f-b8c1-ff852a9fd6d1"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2980), null, "A musical group that performs live at the wedding reception.", "Live Band", "" },
                    { new Guid("d412d881-73b6-489e-ac96-8d822e274c64"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2990), null, "Creates wedding cakes, cupcakes, and desserts for the celebration.", "Baker", "" },
                    { new Guid("edfd73f7-efd6-4a14-ac30-a3e8668c171c"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2980), null, "Coordinates all aspects of the wedding planning process from start to finish.", "Wedding Planner", "" },
                    { new Guid("f7ae357c-ffbd-45d0-88db-e8979228f236"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(3020), null, "Manages sound systems and audio equipment for the ceremony and reception.", "Sound Engineer", "" },
                    { new Guid("f94aae9e-7cd3-4f12-8e5e-9e8f6f875b7f"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2940), null, "Captures memories through professional photography during the wedding.", "Photographer & Videographer", "" },
                    { new Guid("fa62ce12-cd06-4797-b2a5-a4eff049ed07"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(3010), null, "Designs and prints wedding invitations, save-the-dates, and programs.", "Stationery", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypeRoles",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventTypeId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("00494024-60bb-47a9-9a97-8a1dbbf6d9c8"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2820), null, "Individuals responsible for seating guests at the ceremony.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Ushers", "" },
                    { new Guid("0db382a5-7473-4ffa-9d04-50f6b09cc0ed"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2840), null, "A key family member who may have a significant role.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Parent of the Bride", "" },
                    { new Guid("1111bace-c383-436a-b190-e59eda40c978"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2790), null, "The bride's chief assistant during the wedding.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Maid of Honor", "" },
                    { new Guid("1782f8aa-a7ff-4603-9dc5-638371e13dc2"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2800), null, "An additional financial supporter of the wedding.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Secondary Sponsor", "" },
                    { new Guid("1add36e9-b46c-4661-8b51-10d337d656ec"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2810), null, "A young child who carries the wedding rings during the ceremony.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Ring Bearer", "" },
                    { new Guid("42ce80dd-b3b0-47d8-b036-d0f1c14cfbec"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2830), null, "Friends or family who stand with the bride during the ceremony.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Bridesmaids", "" },
                    { new Guid("439185de-4660-4748-94a2-9f11d042974b"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2780), null, "The female participant in the wedding.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Bride", "" },
                    { new Guid("45e119c5-28ea-4b1e-a60c-49e5b516ca00"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2790), null, "The groom's chief assistant during the wedding.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Best Man", "" },
                    { new Guid("6961b0c2-6272-4138-bd00-76c7d94f742f"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2800), null, "The main financial supporter of the wedding.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Primary Sponsor", "" },
                    { new Guid("6e813d6c-4f90-46e3-843e-bd39c36c69e0"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2820), null, "A role representing the candle holders during the ceremony.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Candles", "" },
                    { new Guid("711026e4-4de2-4ab5-b156-05f527b7940b"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2810), null, "A person who carries the Bible during the ceremony.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Bible Bearer", "" },
                    { new Guid("83e6b50a-8664-470d-b469-1fda7baf3dad"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2830), null, "Friends or family who stand with the groom during the ceremony.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Groomsmen", "" },
                    { new Guid("a23c68c4-9d6d-4099-bfef-fb084bf8eac9"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2780), null, "The male participant in the wedding.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Groom", "" },
                    { new Guid("c2b63036-dee0-47b1-b082-6b7e3e175ace"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2800), null, "A young girl who scatters flower petals along the aisle.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Flower Girl", "" },
                    { new Guid("cbb5268a-c851-4168-93e8-de50a0415cbc"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2840), null, "A key family member representing the groom's side.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Parent of the Groom", "" },
                    { new Guid("d6300bc8-f89a-44d7-aff4-de6581645db3"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2820), null, "A role representing the cord used in the ceremony.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Cord", "" },
                    { new Guid("e38df745-9035-4c4a-9d52-3ba96dbc63f9"), "", new DateTime(2024, 11, 5, 17, 20, 24, 718, DateTimeKind.Utc).AddTicks(2810), null, "A person invited to attend the wedding.", new Guid("5bda49fd-bcae-42fe-ba40-4f2516465150"), "Guest", "" }
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
                name: "IX_EventInvitations_EventId",
                table: "EventInvitations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTypeRoles_EventTypeId",
                table: "EventTypeRoles",
                column: "EventTypeId");

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
                name: "EventVendorContracts");

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
                name: "EventVendorContractStates");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "EventGuestInvitations");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropTable(
                name: "VendorTypes");

            migrationBuilder.DropTable(
                name: "EventGuests");

            migrationBuilder.DropTable(
                name: "EventInvitations");

            migrationBuilder.DropTable(
                name: "AccountsTypes");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "EventTypes");
        }
    }
}
