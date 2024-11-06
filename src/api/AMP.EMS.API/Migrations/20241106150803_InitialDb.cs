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
                name: "EventVendorContractPaymentState",
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
                    table.PrimaryKey("PK_EventVendorContractPaymentState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventVendorContractPaymentState_Events_EventId",
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
                    EventVendorContractStateId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventVendorContractPaymentStateId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVendorContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventVendorContracts_EventVendorContractPaymentState_EventVendorContractPaymentStateId",
                        column: x => x.EventVendorContractPaymentStateId,
                        principalTable: "EventVendorContractPaymentState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "AccountTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("37ec77c7-e2d3-4e52-85ab-c0f68faaa61e"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6240), null, "", "Checking", "" },
                    { new Guid("3e272327-3c04-47d4-a421-8bcce138c8d8"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6220), null, "", "Cash", "" },
                    { new Guid("6e452f94-f5aa-4d59-a2b0-9306f098555e"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6240), null, "", "Credit Card", "" },
                    { new Guid("8ecc048d-8b40-4873-af0b-9dd911b292c7"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6240), null, "", "Savings", "" },
                    { new Guid("fbf7574c-629d-435d-94f7-f49913f67c1a"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6230), null, "", "GCash", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("011a6f73-1bc8-4a5d-bf67-8ff4d37a3fea"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6110), null, "An event organized by a company or business for its employees or clients.", "Corporate Event", "" },
                    { new Guid("1efec157-4a09-46b0-93b8-586373297569"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6120), null, "A celebration commemorating a significant milestone in a couple's relationship.", "Anniversary Celebration", "" },
                    { new Guid("2fec3324-cd83-44aa-b8d6-5478ec2bf24b"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6110), null, "A celebration of the anniversary of a person's birth.", "Birthday Party", "" },
                    { new Guid("454ff548-ed76-4d99-bdac-b196dec39622"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6140), null, "A series of events or activities celebrating a particular theme or occasion.", "Festival", "" },
                    { new Guid("758f47e9-b7c2-4298-a768-c48a65973292"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6130), null, "An event organized to raise funds or awareness for a charitable cause.", "Charity Event", "" },
                    { new Guid("97a7efd1-e428-4996-a80f-5f4ce9514d14"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6140), null, "An exhibition where businesses showcase their products and services.", "Trade Show", "" },
                    { new Guid("ad10fd4d-ad14-4877-876a-3a8092abea76"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6130), null, "A live performance of music by one or more musicians.", "Concert", "" },
                    { new Guid("bb58d68b-26fe-4d5d-8015-d41dea405914"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6120), null, "A celebration to honor the completion of an academic program.", "Graduation Party", "" },
                    { new Guid("c39f50c5-90a2-46c8-92ca-3c9631016277"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6120), null, "A celebration held to honor the expectant mother and her baby.", "Baby Shower", "" },
                    { new Guid("ece6572c-3d92-4efe-a42f-14f78cba1b4c"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6050), null, "A ceremony where two people are united in marriage.", "Wedding", "" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("09cf4998-69b8-44bb-b5a0-7ff5cd920423"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3350), null, "Wedding cakes, desserts, and other sweets for the reception.", "Cake & Confectionery", "" },
                    { new Guid("0ad3cc6d-a63b-4dbd-a503-edb6842bec37"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3360), null, "Professional officiants to conduct the wedding ceremony.", "Officiant Services", "" },
                    { new Guid("0dc59c71-aece-47e9-832a-d766cf57e732"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3340), null, "Decorative items and setup services, including centerpieces, lighting, and table settings.", "Decor", "" },
                    { new Guid("1805ddaa-38b1-4661-bca8-89c0885aa6ef"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3340), null, "Coordination and planning services to manage the entire wedding event.", "Wedding Planning", "" },
                    { new Guid("2b76d2e9-69c3-4490-b8d9-662e3b19adc9"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3380), null, "Gifts and party favors for guests.", "Favors & Gifts", "" },
                    { new Guid("34952766-c64d-41f7-885c-99c4931eef3e"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3350), null, "Transportation services for the wedding party and guests, such as limousines and shuttles.", "Transportation", "" },
                    { new Guid("34b7cea4-5d9b-4096-bcf3-95a4ae6b1ed0"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3330), null, "Video recording services to capture and document the wedding day.", "Videography", "" },
                    { new Guid("52581775-dfdb-453a-b35c-ab140aa7d16c"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3370), null, "Rental of items like furniture, tableware, tents, and dance floors.", "Rentals", "" },
                    { new Guid("59c9bb63-ccb8-4925-aad0-f53c183c2c78"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3310), null, "Food and beverage services, including full-course meals, buffets, and bar services.", "Catering", "" },
                    { new Guid("71ad1250-1230-43f1-a83f-f369b6e7ca6f"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3320), null, "Locations for wedding ceremonies, receptions, and other related events.", "Venue", "" },
                    { new Guid("82253fc4-1abd-4090-9d9e-ecbae8cd4e0b"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3360), null, "Design and printing services for wedding invitations, save-the-dates, and other stationery.", "Stationery & Invitations", "" },
                    { new Guid("87465b17-0b47-44df-85e1-1046a668d5a9"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3360), null, "Beauty services for the bridal party, including hairstyling and makeup.", "Hair & Makeup", "" },
                    { new Guid("8e3d7646-3c33-44ed-be0c-f460dfaeae74"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3330), null, "Floral arrangements, bouquets, and other decorative flower services.", "Floristry", "" },
                    { new Guid("a5b62787-b898-48ad-bdae-2901c1ac151e"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3330), null, "Professional photography services for capturing wedding moments.", "Photography", "" },
                    { new Guid("af97030c-272f-4779-ae6d-2b61a65bc863"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3370), null, "Wedding rings, bridal jewelry, and other related accessories.", "Jewelry", "" },
                    { new Guid("b969e5b0-d980-4479-a1ab-119ba688fc43"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3340), null, "Entertainment services, including live bands, DJs, and performers.", "Music & Entertainment", "" },
                    { new Guid("bfea5b43-8cec-49b3-8599-ca4130142e70"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3350), null, "Wedding attire rentals or purchases, including dresses, suits, and accessories.", "Attire & Accessories", "" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("189cc01f-1bd9-47e1-8be3-501e9de6d585"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6280), null, "Represents adding funds to an account, usually as a top-up or a prepayment.", "Deposit", "" },
                    { new Guid("7eb9cf21-48e6-4519-9823-d16f1caaaac2"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6290), null, "Represents money returned to the user for a previous purchase, usually due to a return or an issue with the product/service.", "Refund", "" },
                    { new Guid("cc84258b-4f37-4be0-aceb-d073094f3723"), "", new DateTime(2024, 11, 6, 15, 8, 3, 511, DateTimeKind.Utc).AddTicks(6280), null, "A general payment or debit from a user’s account, often for non-purchase activities, such as bill payments or installment payments.", "Payment", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1589a775-a1c9-4f2b-9eec-bb61b413b444"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3490), null, "Conducts the wedding ceremony and ensures it is legally binding.", "Officiant", "" },
                    { new Guid("19752ed9-fa8a-4f56-8117-f33d9efe816b"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3500), null, "Styles hair for the bride, bridesmaids, and other family members.", "Hair Stylist", "" },
                    { new Guid("23cfc6a8-7cb7-4a20-97a9-c10ae3ce88d6"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3520), null, "Ensures the safety and security of the wedding event and guests.", "Security", "" },
                    { new Guid("39a9b752-8109-479d-a971-d39cd488e257"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3440), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup Artist", "" },
                    { new Guid("418b6e96-a70b-4d05-8e45-08ab01bb8077"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3520), null, "Manages sound systems and audio equipment for the ceremony and reception.", "Sound Engineer", "" },
                    { new Guid("49ff4985-d30d-47c9-87b1-9c85ebe79961"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3490), null, "Creates wedding cakes, cupcakes, and desserts for the celebration.", "Baker", "" },
                    { new Guid("5165d054-5dec-467c-b618-feb993ff4f14"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3510), null, "Provides a fun photo booth setup with props for guests to enjoy.", "Photo Booth", "" },
                    { new Guid("51ae28e4-e2d0-44d0-8170-90fcc54e20e2"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3510), null, "Offers items for rent such as tables, chairs, linens, and decor.", "Rentals", "" },
                    { new Guid("5b812c6a-5e30-4dc8-a3d1-a625860d196a"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3470), null, "Records the wedding ceremony and reception with high-quality video.", "Videographer", "" },
                    { new Guid("5c8954ae-65a5-4b14-b2ee-42634d48b2f0"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3440), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "" },
                    { new Guid("5ccce4f4-91db-43ef-9134-3bdca2a3e7d3"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3490), null, "Provides vehicles for transporting the wedding party and guests.", "Transportation", "" },
                    { new Guid("6164e55c-4bf4-4f7f-9a5f-5509d84f4046"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3420), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "" },
                    { new Guid("6b1e9b96-98ee-4b65-a591-6221df95c4f4"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3480), null, "Coordinates all aspects of the wedding planning process from start to finish.", "Wedding Planner", "" },
                    { new Guid("6f246120-8522-4ad8-b308-dbf39801604c"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3430), null, "Captures memories through professional photography during the wedding.", "Photographer & Videographer", "" },
                    { new Guid("7031fbc0-5efc-401f-b38f-3719703de161"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3460), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "" },
                    { new Guid("7054cfa5-9a47-413d-83a0-89b1911b811e"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3500), null, "Provides professional makeup services for the bride and bridal party.", "Makeup Artist", "" },
                    { new Guid("75d1cf60-d140-420b-ba2b-40788e705cfa"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3520), null, "Creates customized lighting plans to enhance the wedding ambiance.", "Lighting Designer", "" },
                    { new Guid("866841d1-89f0-45a8-84aa-12c37302110f"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3440), null, "A musical group that performs live at the wedding reception.", "Live Band", "" },
                    { new Guid("869549c2-914a-4fa8-8496-67256106d19b"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3460), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "" },
                    { new Guid("87d60d1d-c073-4373-818e-f3d57b8e635d"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3450), null, "Sells wedding rings and related jewelry.", "Jeweler", "" },
                    { new Guid("8f351ec6-9438-44c3-bac7-b290fa6450e8"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3420), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "" },
                    { new Guid("90b0ddff-0f05-47d9-ad7d-941f9a541efe"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3460), null, "Hosts and coordinates the wedding program.", "Emcee", "" },
                    { new Guid("9e775d04-47ce-4422-a70c-c2e6f84a7808"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3450), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "" },
                    { new Guid("b282998d-fd89-44c3-ab54-5aaabe8ce5d1"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3480), null, "Provides music entertainment and emceeing for the wedding and reception.", "DJ", "" },
                    { new Guid("db97c0b1-21f2-414a-8453-b6aba638ec0f"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3470), null, "Captures memories through professional photography during the wedding.", "Photographer", "" },
                    { new Guid("e51403e9-40fd-4eec-8252-e63d4fea1068"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3430), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "" },
                    { new Guid("e77590c5-47bb-4280-bfb5-28fe31ef1d12"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3470), null, "Location where the wedding ceremony and/or reception is held.", "Venue", "" },
                    { new Guid("e9d460a2-738e-40d9-beb8-5e0318f2a637"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3430), null, "Provides food and beverage services for the wedding.", "Caterer", "" },
                    { new Guid("f24a07f6-8589-4442-a2e5-bb53bff7ede6"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3510), null, "Designs and prints wedding invitations, save-the-dates, and programs.", "Stationery", "" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountTypeId", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("5bcceecd-bb53-4cb9-8e60-918a3ad304d8"), "cad37ebb-9b41-482b-8701-03688568ed24", new Guid("3e272327-3c04-47d4-a421-8bcce138c8d8"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3720), null, "Vendor Account", "" },
                    { new Guid("e33572da-54f6-4d9c-93c5-c1467d73d80d"), "6de7af2b-cf30-4cf3-9e7f-f20f9fe436b3", new Guid("3e272327-3c04-47d4-a421-8bcce138c8d8"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3990), null, "Event Account", "" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EndDate", "EventTypeId", "Location", "Seats", "StartDate", "Title", "UpdatedBy" },
                values: new object[] { new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3780), null, "Wedding", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ece6572c-3d92-4efe-a42f-14f78cba1b4c"), "Ph", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wedding", "" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Address", "ContactInformation", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy", "VendorTypeId" },
                values: new object[,]
                {
                    { new Guid("0dba9a51-ad96-4b14-aef4-bab0a224aab1"), "N/A", "", "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3680), null, "Hosts and coordinates the wedding program.", "Emcee", "", new Guid("90b0ddff-0f05-47d9-ad7d-941f9a541efe") },
                    { new Guid("167a0583-ee94-4e6c-8388-a68b3a1d346e"), "N/A", "", "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3590), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "", new Guid("8f351ec6-9438-44c3-bac7-b290fa6450e8") },
                    { new Guid("376a54f3-5407-46c8-965c-01c7b500b8c0"), "N/A", "", "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3580), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "", new Guid("6164e55c-4bf4-4f7f-9a5f-5509d84f4046") },
                    { new Guid("5aae6725-0061-4794-833d-c599d14a1b2b"), "N/A", "", "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3650), null, "A musical group that performs live at the wedding reception.", "Strings", "", new Guid("866841d1-89f0-45a8-84aa-12c37302110f") },
                    { new Guid("64142c84-fa91-42f6-9aa7-bb23f72a1974"), "N/A", "", "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3600), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "", new Guid("e51403e9-40fd-4eec-8252-e63d4fea1068") },
                    { new Guid("892a31ea-3943-40ea-9527-93d87bc3e61d"), "N/A", "", "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3660), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "", new Guid("5c8954ae-65a5-4b14-b2ee-42634d48b2f0") },
                    { new Guid("9f8d86bd-3867-4dea-a903-1c265e79d33c"), "N/A", "", "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3670), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "", new Guid("9e775d04-47ce-4422-a70c-c2e6f84a7808") },
                    { new Guid("9ffef654-d864-4d16-b8b0-9cf941fdd732"), "N/A", "", "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3680), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "", new Guid("7031fbc0-5efc-401f-b38f-3719703de161") },
                    { new Guid("af0ddcd8-f403-461e-94dd-52f1fa5dc924"), "N/A", "", "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3670), null, "Sells wedding rings and related jewelry.", "Jeweler", "", new Guid("87d60d1d-c073-4373-818e-f3d57b8e635d") },
                    { new Guid("b52414f3-0f7b-4bf4-9390-51b784de58f6"), "N/A", "", "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3600), null, "Provides food and beverage services for the wedding.", "Caterer", "", new Guid("e9d460a2-738e-40d9-beb8-5e0318f2a637") },
                    { new Guid("ea935641-a447-4589-840d-c09d51b4eba8"), "N/A", "", "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3600), null, "Captures memories through professional photography during the wedding.", "Photo & Video", "", new Guid("6f246120-8522-4ad8-b308-dbf39801604c") },
                    { new Guid("fac0e951-f173-4685-9fcd-355069cef98f"), "N/A", "", "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3680), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "", new Guid("869549c2-914a-4fa8-8496-67256106d19b") },
                    { new Guid("fd0d943b-ab9f-4efb-919b-9d70e7da2be5"), "N/A", "", "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3660), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup", "", new Guid("39a9b752-8109-479d-a971-d39cd488e257") }
                });

            migrationBuilder.InsertData(
                table: "EventAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "EventId", "UpdatedBy" },
                values: new object[] { new Guid("9ac58092-a6f4-457b-aff3-cb9ed7826ac3"), new Guid("e33572da-54f6-4d9c-93c5-c1467d73d80d"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(4010), null, new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "" });

            migrationBuilder.InsertData(
                table: "EventVendorContractPaymentState",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("3aa5361d-41f9-41d5-ac3b-5d917db12029"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3960), null, "Payment is overdue.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Overdue Payment", "" },
                    { new Guid("83145820-e9de-42f3-b468-069622e89184"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3970), null, "Refund has been processed and completed.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Refunded", "" },
                    { new Guid("a0d21065-6b66-4a70-9873-e10d7c89a6dc"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3960), null, "Refund is pending processing.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Refund Pending", "" },
                    { new Guid("ac667552-ca86-46b6-93ed-889f27523db4"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3950), null, "Waiting for the initial deposit to be paid.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Deposit Pending", "" },
                    { new Guid("c671aae5-704f-4f06-ba0c-489fd5726fe7"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3950), null, "Partial payment received, remaining balance due.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Partial Payment", "" },
                    { new Guid("d5f14890-b4dc-448d-8904-5ae54d1c2aeb"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3960), null, "All payments have been made, contract is paid in full.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Paid in Full", "" }
                });

            migrationBuilder.InsertData(
                table: "EventVendorContractStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2dc955c9-7c73-4c2c-ae45-4e006267d133"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3910), null, "Reserved but not yet confirmed.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Reserved", "" },
                    { new Guid("2ef8c7ef-e07a-44be-b8e4-12d0b978be7e"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3910), null, "Quote has been received from the vendor.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Quote Received", "" },
                    { new Guid("3113a60d-150f-4ab9-b08b-1113b1140f1f"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3920), null, "Tentatively booked, awaiting confirmation.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Tentative", "" },
                    { new Guid("33473d2c-d212-44de-a929-eceec1d421d0"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3900), null, "Initial inquiry stage.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Inquiry", "" },
                    { new Guid("59d6369c-fb5d-4ef4-9489-88aa1e90f00a"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3930), null, "Contract has been completed and closed.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Closed", "" },
                    { new Guid("bdd36b97-04cf-4e7d-8c0b-9bac322c19dc"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3920), null, "Contract has been booked and confirmed.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Booked", "" },
                    { new Guid("c619c388-e801-4d04-9c12-deb32784d544"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3900), null, "Waiting for a quote from the vendor.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Pending Quote", "" },
                    { new Guid("c8e8774c-7560-47c9-bca5-f2ae263f6049"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3910), null, "Negotiations are ongoing with the vendor.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Negotiation", "" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("146b01c9-18d2-4010-ac5f-147a04d8fbf8"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3860), null, "Friends or family who stand with the bride during the ceremony.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Bridesmaids", "" },
                    { new Guid("15892117-1c68-473a-af32-06c86412a171"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3810), null, "The male participant in the wedding.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Groom", "" },
                    { new Guid("21889917-84a9-478b-8548-3a9e4f39a2b4"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3820), null, "The bride's chief assistant during the wedding.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Maid of Honor", "" },
                    { new Guid("3bca0d1a-db7b-4f5c-b80f-1176cd0c5b5b"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3830), null, "An additional financial supporter of the wedding.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Secondary Sponsor", "" },
                    { new Guid("472ae49a-0734-4c18-a07e-d019a7ab084e"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3830), null, "A young child who carries the wedding rings during the ceremony.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Ring Bearer", "" },
                    { new Guid("4c77671e-a9c2-44fe-91a4-222fcfa2ffcc"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3820), null, "The main financial supporter of the wedding.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Primary Sponsor", "" },
                    { new Guid("53ca6266-d74e-45ca-bd85-af12bb58f8ec"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3860), null, "Friends or family who stand with the groom during the ceremony.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Groomsmen", "" },
                    { new Guid("55512cc9-2820-4dde-8b77-6bb209a8fbb6"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3830), null, "A young girl who scatters flower petals along the aisle.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Flower Girl", "" },
                    { new Guid("5dda5254-afaa-448b-8be7-8a27f094e935"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3860), null, "A key family member who may have a significant role.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Parent of the Bride", "" },
                    { new Guid("60debef8-ca06-45af-be34-9d4241538e6b"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3850), null, "A role representing the candle holders during the ceremony.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Candles", "" },
                    { new Guid("8068b564-bcf2-4e23-94ef-a0eb496221c6"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3840), null, "A person who carries the Bible during the ceremony.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Bible Bearer", "" },
                    { new Guid("b4f214b6-d63a-4217-871c-2034066b721a"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3810), null, "The groom's chief assistant during the wedding.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Best Man", "" },
                    { new Guid("cd1383a4-1d5a-49dd-9c82-d276cfa03c59"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3850), null, "Individuals responsible for seating guests at the ceremony.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Ushers", "" },
                    { new Guid("e02e9a97-96c0-4ee4-9269-1b21275856c1"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3840), null, "A person invited to attend the wedding.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Guest", "" },
                    { new Guid("ed2467fd-b876-4254-a1bd-6f244c7a7767"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3810), null, "The female participant in the wedding.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Bride", "" },
                    { new Guid("f30bc4d2-01c6-4b8b-bc9a-4a637afeab85"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3840), null, "A role representing the cord used in the ceremony.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Cord", "" },
                    { new Guid("fce707ca-48d9-4c8d-8fcd-2e1e9fbf0e69"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3870), null, "A key family member representing the groom's side.", new Guid("14d36c6d-2a04-4e91-bdff-e8508c787c97"), "Parent of the Groom", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "UpdatedBy", "VendorId" },
                values: new object[] { new Guid("e9d7214c-9141-4b6d-a522-6b8ab5d9c3bd"), new Guid("5bcceecd-bb53-4cb9-8e60-918a3ad304d8"), "", new DateTime(2024, 11, 6, 15, 8, 3, 513, DateTimeKind.Utc).AddTicks(3750), null, "", new Guid("376a54f3-5407-46c8-965c-01c7b500b8c0") });

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
                name: "IX_EventVendorContractPaymentState_EventId",
                table: "EventVendorContractPaymentState",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorContracts_EventId",
                table: "EventVendorContracts",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorContracts_EventVendorContractPaymentStateId",
                table: "EventVendorContracts",
                column: "EventVendorContractPaymentStateId");

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
                name: "EventVendorContractPaymentState");

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
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "EventTypes");
        }
    }
}
