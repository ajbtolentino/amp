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
                    EventVendorPaymentStateId = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    { new Guid("4b5101f5-f24b-4cad-8412-7d4636ce6fce"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(930), null, "", "Checking", "" },
                    { new Guid("60f9c36a-8566-491c-936c-4e110b89412c"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(920), null, "", "Savings", "" },
                    { new Guid("95667bf4-6414-49a6-a801-93d35c05b58a"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(920), null, "", "GCash", "" },
                    { new Guid("be5299c3-d72c-4b19-b825-85cd18f2428a"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(920), null, "", "Credit Card", "" },
                    { new Guid("c1a730eb-48cd-4024-b762-78706cb3e1bc"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(910), null, "", "Cash", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0b15018e-c69e-4010-ae16-0bf6a1a9fe61"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(660), null, "An event organized to raise funds or awareness for a charitable cause.", "Charity Event", "" },
                    { new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(560), null, "A ceremony where two people are united in marriage.", "Wedding", "" },
                    { new Guid("3babe4a7-280c-465f-84ad-1ada571f6f19"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(650), null, "A celebration commemorating a significant milestone in a couple's relationship.", "Anniversary Celebration", "" },
                    { new Guid("6b383fee-7cfd-4102-a80a-ab2ec7965a98"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(640), null, "A celebration of the anniversary of a person's birth.", "Birthday Party", "" },
                    { new Guid("76772781-72bb-48e5-82e7-19446cf5e089"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(670), null, "A series of events or activities celebrating a particular theme or occasion.", "Festival", "" },
                    { new Guid("a3d71513-8c9b-446a-8385-92c83af9b97a"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(670), null, "An exhibition where businesses showcase their products and services.", "Trade Show", "" },
                    { new Guid("a52746e2-eec5-43be-bfda-7793013245c5"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(660), null, "A live performance of music by one or more musicians.", "Concert", "" },
                    { new Guid("b8de7147-1772-46ef-ba3c-1d52018e0a7e"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(650), null, "A celebration to honor the completion of an academic program.", "Graduation Party", "" },
                    { new Guid("e0e076e7-83b6-40dc-95d4-2c39515dd037"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(660), null, "A celebration held to honor the expectant mother and her baby.", "Baby Shower", "" },
                    { new Guid("ffa45292-07dd-4ad7-abe9-d6ecc89b51b1"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(640), null, "An event organized by a company or business for its employees or clients.", "Corporate Event", "" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("08419f25-4058-451e-868d-2cf5a4433c18"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8900), null, "Entertainment services, including live bands, DJs, and performers.", "Music & Entertainment", "" },
                    { new Guid("2c2ea7d2-8b4a-4bdc-baf2-f84ef95612d3"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8920), null, "Design and printing services for wedding invitations, save-the-dates, and other stationery.", "Stationery & Invitations", "" },
                    { new Guid("30e1c070-4c82-4d99-89eb-df4e11a1810a"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8930), null, "Rental of items like furniture, tableware, tents, and dance floors.", "Rentals", "" },
                    { new Guid("316cb913-af5d-45ea-9090-8a1a2f1f918c"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8880), null, "Professional photography services for capturing wedding moments.", "Photography", "" },
                    { new Guid("38de4acd-278b-4499-99f7-8143288066e4"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8900), null, "Coordination and planning services to manage the entire wedding event.", "Wedding Planning", "" },
                    { new Guid("415244c9-d759-41f3-9673-bf18411d576f"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8910), null, "Transportation services for the wedding party and guests, such as limousines and shuttles.", "Transportation", "" },
                    { new Guid("43a19510-3311-4b53-b3c2-9b2d5c30f773"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8860), null, "Food and beverage services, including full-course meals, buffets, and bar services.", "Catering", "" },
                    { new Guid("4757dda7-baeb-4f0e-a262-141f58b816c2"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8910), null, "Wedding cakes, desserts, and other sweets for the reception.", "Cake & Confectionery", "" },
                    { new Guid("5202a706-eccb-4bc2-ab86-b62e48251681"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8910), null, "Wedding attire rentals or purchases, including dresses, suits, and accessories.", "Attire & Accessories", "" },
                    { new Guid("684cae83-98fe-41a1-920e-b4adf2ab778d"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8920), null, "Beauty services for the bridal party, including hairstyling and makeup.", "Hair & Makeup", "" },
                    { new Guid("7715d585-ff47-4470-9fa2-096df4bec69f"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8930), null, "Gifts and party favors for guests.", "Favors & Gifts", "" },
                    { new Guid("7f14cae2-b567-44e7-bac9-4cdc658d6fce"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8890), null, "Decorative items and setup services, including centerpieces, lighting, and table settings.", "Decor", "" },
                    { new Guid("82fb8e39-c355-4278-85c3-fb9f07c301c2"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8890), null, "Floral arrangements, bouquets, and other decorative flower services.", "Floristry", "" },
                    { new Guid("84ce7e14-5ce3-4a0f-85a9-d9666148f762"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8880), null, "Locations for wedding ceremonies, receptions, and other related events.", "Venue", "" },
                    { new Guid("a53fafe6-557f-4db7-9483-11b32e85b3fb"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8920), null, "Professional officiants to conduct the wedding ceremony.", "Officiant Services", "" },
                    { new Guid("ac190657-bcf8-42d4-9716-b1047f65d1ee"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8890), null, "Video recording services to capture and document the wedding day.", "Videography", "" },
                    { new Guid("ef3b66a8-39c8-46c7-a2b9-00bb1aa3f0ed"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8930), null, "Wedding rings, bridal jewelry, and other related accessories.", "Jewelry", "" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("670c4334-4521-4ee8-8536-ab35f04bfdf7"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(990), null, "Represents adding funds to an account, usually as a top-up or a prepayment.", "Deposit", "" },
                    { new Guid("6b0441b2-6a75-4c49-91d6-8786047f3c6c"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(980), null, "A general payment or debit from a user’s account, often for non-purchase activities, such as bill payments or installment payments.", "Payment", "" },
                    { new Guid("b982a51e-1c8a-47dc-9031-41982c3543eb"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(990), null, "Represents money returned to the user for a previous purchase, usually due to a return or an issue with the product/service.", "Refund", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("05b02e11-cf37-462a-9c10-a20af9a3565c"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9040), null, "Records the wedding ceremony and reception with high-quality video.", "Videographer", "" },
                    { new Guid("089ca5c1-4535-4d18-9d34-d4047d705e96"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9020), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "" },
                    { new Guid("141b5398-b76b-4718-86c7-3bee534dfcbf"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9000), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup Artist", "" },
                    { new Guid("447e3f42-2d62-4c68-8a12-74b38dc55cce"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9030), null, "Hosts and coordinates the wedding program.", "Emcee", "" },
                    { new Guid("4497a30a-ba2a-44fa-834c-2508a9be91f2"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8980), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "" },
                    { new Guid("5b9a60ad-50a8-4235-8871-5132055a53a6"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9050), null, "Coordinates all aspects of the wedding planning process from start to finish.", "Wedding Planner", "" },
                    { new Guid("5fc578f3-d39b-4d6d-a869-ddbcbc4ba368"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9250), null, "Creates wedding cakes, cupcakes, and desserts for the celebration.", "Baker", "" },
                    { new Guid("6a78183c-3445-4976-9a3e-8736150df024"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9530), null, "Creates customized lighting plans to enhance the wedding ambiance.", "Lighting Designer", "" },
                    { new Guid("6e21e315-e256-49ba-9285-507b14ab81d3"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8980), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "" },
                    { new Guid("72c9fd50-d375-461f-a82e-3ee24196cf40"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9520), null, "Offers items for rent such as tables, chairs, linens, and decor.", "Rentals", "" },
                    { new Guid("73be89dc-2151-4807-8d35-42374411351e"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9520), null, "Designs and prints wedding invitations, save-the-dates, and programs.", "Stationery", "" },
                    { new Guid("7998c540-1261-4d85-9ef9-e0eb704f9aa4"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9530), null, "Provides a fun photo booth setup with props for guests to enjoy.", "Photo Booth", "" },
                    { new Guid("7df5a0dc-b01f-41b4-b379-39157f6d487c"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9010), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "" },
                    { new Guid("81efcf71-f3bf-4a8e-a83b-29e9fa87e0c3"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9040), null, "Provides music entertainment and emceeing for the wedding and reception.", "DJ", "" },
                    { new Guid("86205b19-0f61-48fa-acd7-e7dc39f484f6"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9000), null, "A musical group that performs live at the wedding reception.", "Live Band", "" },
                    { new Guid("9c8f8d96-0caa-412a-a397-fe62d9b9133f"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9510), null, "Styles hair for the bride, bridesmaids, and other family members.", "Hair Stylist", "" },
                    { new Guid("9cfb5a88-ad28-4758-8f54-ff8f63c041b6"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9010), null, "Sells wedding rings and related jewelry.", "Jeweler", "" },
                    { new Guid("a1211624-c8c4-42da-a369-60d1862c9cff"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9010), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "" },
                    { new Guid("a68fc4a2-ac2b-434f-9074-e0c0023108b3"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8990), null, "Provides food and beverage services for the wedding.", "Caterer", "" },
                    { new Guid("b0becf4f-abee-45a0-9665-9c535df5b6cc"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9030), null, "Captures memories through professional photography during the wedding.", "Photographer", "" },
                    { new Guid("b34b1468-b9e5-4474-81bb-78c6674dac95"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9510), null, "Provides professional makeup services for the bride and bridal party.", "Makeup Artist", "" },
                    { new Guid("c1a73b6f-7024-4e0d-aef6-bb286278ac93"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9030), null, "Location where the wedding ceremony and/or reception is held.", "Venue", "" },
                    { new Guid("c307dffc-20ac-4eaa-a121-d142194c1db3"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9500), null, "Conducts the wedding ceremony and ensures it is legally binding.", "Officiant", "" },
                    { new Guid("cc3e0d95-e7d0-43b6-a072-2214174c7bbd"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8970), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "" },
                    { new Guid("cd3c4749-8df0-465a-8039-40ed018d2185"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9540), null, "Manages sound systems and audio equipment for the ceremony and reception.", "Sound Engineer", "" },
                    { new Guid("d71a17bb-ba1e-4a54-adb7-bb11155acd70"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(8990), null, "Captures memories through professional photography during the wedding.", "Photographer & Videographer", "" },
                    { new Guid("df8fe973-71e4-4b3c-be53-70a68ff3d268"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9020), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "" },
                    { new Guid("ead8f62a-c020-4465-bf18-fa0d2b125014"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9490), null, "Provides vehicles for transporting the wedding party and guests.", "Transportation", "" },
                    { new Guid("faf1c343-d37e-428e-9bdd-08514e38fb68"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9530), null, "Ensures the safety and security of the wedding event and guests.", "Security", "" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountTypeId", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("305a05f4-c043-4d8e-9917-a276a6a88718"), "ff557ceb-ddc0-4326-a15e-fa26cedd3807", new Guid("c1a730eb-48cd-4024-b762-78706cb3e1bc"), "", new DateTime(2024, 11, 5, 23, 25, 58, 197, DateTimeKind.Utc).AddTicks(90), null, "Event Account", "" },
                    { new Guid("7af8f630-8142-4709-b0f2-1da93a711ef3"), "947e4e31-10db-4705-940a-e697bf537f47", new Guid("c1a730eb-48cd-4024-b762-78706cb3e1bc"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9840), null, "Vendor Account", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypeRoles",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventTypeId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("32afecbf-c19d-47b5-b893-8f8651c0fa9e"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(800), null, "A role representing the candle holders during the ceremony.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Candles", "" },
                    { new Guid("34c7d65a-8509-464d-a136-760211e0df16"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(820), null, "A key family member representing the groom's side.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Parent of the Groom", "" },
                    { new Guid("394d3f12-bf0e-4427-b34d-31544deb8d97"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(780), null, "A young child who carries the wedding rings during the ceremony.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Ring Bearer", "" },
                    { new Guid("4f6e155b-8b1c-4196-87c9-17e1d19f2dea"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(810), null, "A key family member who may have a significant role.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Parent of the Bride", "" },
                    { new Guid("60ed9e69-6c02-41a6-8413-713e4b2535ae"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(790), null, "A person who carries the Bible during the ceremony.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Bible Bearer", "" },
                    { new Guid("65dd31fa-9c52-4def-ba51-6c87d42c6698"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(800), null, "Friends or family who stand with the groom during the ceremony.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Groomsmen", "" },
                    { new Guid("6aa76d8f-76f0-4a63-acfb-24804314e84b"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(770), null, "An additional financial supporter of the wedding.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Secondary Sponsor", "" },
                    { new Guid("74faa5bc-b5ea-4d5a-a7bd-7a5fa1793176"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(760), null, "The male participant in the wedding.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Groom", "" },
                    { new Guid("7b751084-3695-4736-8408-94e155821f2f"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(810), null, "Friends or family who stand with the bride during the ceremony.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Bridesmaids", "" },
                    { new Guid("813a7749-1f19-43b4-8b32-9e4867b5a28a"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(800), null, "Individuals responsible for seating guests at the ceremony.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Ushers", "" },
                    { new Guid("8fb4d062-55bf-4af4-ac56-fd630098b489"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(760), null, "The female participant in the wedding.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Bride", "" },
                    { new Guid("91e3b6ac-5c43-40e7-8d03-e352fec13af6"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(760), null, "The groom's chief assistant during the wedding.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Best Man", "" },
                    { new Guid("a77c6787-9308-43d1-89bd-7f0b94b53588"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(790), null, "A person invited to attend the wedding.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Guest", "" },
                    { new Guid("c322c326-113a-425e-a56b-6ad501657d67"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(780), null, "A young girl who scatters flower petals along the aisle.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Flower Girl", "" },
                    { new Guid("c7dc3ec8-13c4-4fba-961c-f0b99eba8e76"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(770), null, "The main financial supporter of the wedding.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Primary Sponsor", "" },
                    { new Guid("de379b29-21fa-40e0-883b-aa09cdfba497"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(790), null, "A role representing the cord used in the ceremony.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Cord", "" },
                    { new Guid("fbc4635c-6e8a-4e4a-8c88-f3638ae9454d"), "", new DateTime(2024, 11, 5, 23, 25, 58, 195, DateTimeKind.Utc).AddTicks(770), null, "The bride's chief assistant during the wedding.", new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Maid of Honor", "" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EndDate", "EventTypeId", "Location", "Seats", "StartDate", "Title", "UpdatedBy" },
                values: new object[] { new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9920), null, "Wedding", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3a31995e-e7f3-4656-932c-ff12a9a66ca5"), "Ph", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wedding", "" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Address", "ContactInformation", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy", "VendorTypeId" },
                values: new object[,]
                {
                    { new Guid("4906bd81-8e3c-4c10-91c9-3d44f224d50d"), "N/A", "", "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9730), null, "Provides food and beverage services for the wedding.", "Caterer", "", new Guid("a68fc4a2-ac2b-434f-9074-e0c0023108b3") },
                    { new Guid("539efa94-8ae5-4bac-9594-1c2580f71760"), "N/A", "", "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9800), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "", new Guid("df8fe973-71e4-4b3c-be53-70a68ff3d268") },
                    { new Guid("56a37581-eab7-41c1-a915-e891bb537f4a"), "N/A", "", "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9720), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "", new Guid("6e21e315-e256-49ba-9285-507b14ab81d3") },
                    { new Guid("6075c4ed-7a2f-41ae-82bb-db730796486a"), "N/A", "", "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9740), null, "A musical group that performs live at the wedding reception.", "Strings", "", new Guid("86205b19-0f61-48fa-acd7-e7dc39f484f6") },
                    { new Guid("7f95a5cb-b6fc-465a-9fca-cd57bac130ad"), "N/A", "", "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9720), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "", new Guid("4497a30a-ba2a-44fa-834c-2508a9be91f2") },
                    { new Guid("868cbc34-0e69-45ca-aadc-6cabf1ad25f2"), "N/A", "", "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9730), null, "Captures memories through professional photography during the wedding.", "Photo & Video", "", new Guid("d71a17bb-ba1e-4a54-adb7-bb11155acd70") },
                    { new Guid("8973fef1-772e-4ee9-8335-e09e6de84e27"), "N/A", "", "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9790), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "", new Guid("a1211624-c8c4-42da-a369-60d1862c9cff") },
                    { new Guid("90ec295d-16d5-4d1f-b8c3-b5017ee227c9"), "N/A", "", "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9800), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "", new Guid("089ca5c1-4535-4d18-9d34-d4047d705e96") },
                    { new Guid("95af34ec-7896-4d8a-85cd-e6adfcc8d52d"), "N/A", "", "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9710), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "", new Guid("cc3e0d95-e7d0-43b6-a072-2214174c7bbd") },
                    { new Guid("ac39b42b-76a3-47a3-b718-3cd653c07c39"), "N/A", "", "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9750), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "", new Guid("7df5a0dc-b01f-41b4-b379-39157f6d487c") },
                    { new Guid("b5886865-9d03-4e03-8ec2-b43b007af20c"), "N/A", "", "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9810), null, "Hosts and coordinates the wedding program.", "Emcee", "", new Guid("447e3f42-2d62-4c68-8a12-74b38dc55cce") },
                    { new Guid("ebc8cdbd-0313-4f3f-90f4-5128ee30ab27"), "N/A", "", "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9740), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup", "", new Guid("141b5398-b76b-4718-86c7-3bee534dfcbf") },
                    { new Guid("f85be3ce-c194-48d3-9f97-e789fb8fd513"), "N/A", "", "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9750), null, "Sells wedding rings and related jewelry.", "Jeweler", "", new Guid("9cfb5a88-ad28-4758-8f54-ff8f63c041b6") }
                });

            migrationBuilder.InsertData(
                table: "EventAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "EventId", "UpdatedBy" },
                values: new object[] { new Guid("be53b0e4-84d7-47bd-829e-abb9e518de32"), new Guid("305a05f4-c043-4d8e-9917-a276a6a88718"), "", new DateTime(2024, 11, 5, 23, 25, 58, 197, DateTimeKind.Utc).AddTicks(110), null, new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "" });

            migrationBuilder.InsertData(
                table: "EventVendorContractPaymentState",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("5a643a6d-05a2-40a9-adca-53ad53402e55"), "", new DateTime(2024, 11, 5, 23, 25, 58, 197, DateTimeKind.Utc).AddTicks(20), null, "Waiting for the initial deposit to be paid.", new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "Deposit Pending", "" },
                    { new Guid("5c1d9b06-9df2-4982-818a-e91c684932a8"), "", new DateTime(2024, 11, 5, 23, 25, 58, 197, DateTimeKind.Utc).AddTicks(40), null, "Payment is overdue.", new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "Overdue Payment", "" },
                    { new Guid("7e8dbcfa-d1ec-47d0-9484-3a7f125a67f8"), "", new DateTime(2024, 11, 5, 23, 25, 58, 197, DateTimeKind.Utc).AddTicks(50), null, "Refund has been processed and completed.", new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "Refunded", "" },
                    { new Guid("a2dcddbd-fb5c-4e30-a38a-fc3e4e346cdc"), "", new DateTime(2024, 11, 5, 23, 25, 58, 197, DateTimeKind.Utc).AddTicks(40), null, "All payments have been made, contract is paid in full.", new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "Paid in Full", "" },
                    { new Guid("a631a83f-788d-4c5c-8c60-768c96a80508"), "", new DateTime(2024, 11, 5, 23, 25, 58, 197, DateTimeKind.Utc).AddTicks(40), null, "Refund is pending processing.", new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "Refund Pending", "" },
                    { new Guid("a6b97aa6-1835-43d5-b5cd-47467dbde3f4"), "", new DateTime(2024, 11, 5, 23, 25, 58, 197, DateTimeKind.Utc).AddTicks(30), null, "Partial payment received, remaining balance due.", new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "Partial Payment", "" }
                });

            migrationBuilder.InsertData(
                table: "EventVendorContractStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("3728a85c-354c-47d1-a637-79c089d2aa0f"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9970), null, "Negotiations are ongoing with the vendor.", new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "Negotiation", "" },
                    { new Guid("4c185cb3-78d9-44a0-9049-649048d0fcf0"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9980), null, "Contract has been completed and closed.", new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "Closed", "" },
                    { new Guid("52fa2f7f-9524-4370-bd5e-4f0676ad1578"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9980), null, "Contract has been booked and confirmed.", new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "Booked", "" },
                    { new Guid("6b42d656-dffe-462b-876f-b135a5826591"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9960), null, "Waiting for a quote from the vendor.", new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "Pending Quote", "" },
                    { new Guid("6ee55530-c0e0-4a4c-9b05-91d3b3f664ae"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9970), null, "Reserved but not yet confirmed.", new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "Reserved", "" },
                    { new Guid("8520b608-a88b-4474-9ddd-e76fd67f6d9a"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9950), null, "Initial inquiry stage.", new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "Inquiry", "" },
                    { new Guid("b8c2886b-010b-41ce-a9dd-9b00fc1be8b0"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9960), null, "Quote has been received from the vendor.", new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "Quote Received", "" },
                    { new Guid("d4b63089-59b7-44a0-bbd4-732f2d4a04fb"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9970), null, "Tentatively booked, awaiting confirmation.", new Guid("c8e797ee-8c2a-4663-b078-6f53ee717ab3"), "Tentative", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "UpdatedBy", "VendorId" },
                values: new object[] { new Guid("e24466cc-f1ea-49cd-9493-e207da6de89f"), new Guid("7af8f630-8142-4709-b0f2-1da93a711ef3"), "", new DateTime(2024, 11, 5, 23, 25, 58, 196, DateTimeKind.Utc).AddTicks(9890), null, "", new Guid("95af34ec-7896-4d8a-85cd-e6adfcc8d52d") });

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
