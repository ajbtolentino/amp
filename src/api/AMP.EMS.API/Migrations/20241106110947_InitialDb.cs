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
                    { new Guid("07e1291a-b670-4ba4-9e84-9871e5449e6a"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4920), null, "", "Checking", "" },
                    { new Guid("5f3f9a0a-3c68-481f-8aba-c0d801711b20"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4910), null, "", "Credit Card", "" },
                    { new Guid("6b0797fe-a680-4d28-91a4-94f0ae869bf3"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4900), null, "", "GCash", "" },
                    { new Guid("b4db4c1a-43ef-4fa2-9fe4-3d4739b28e4a"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4910), null, "", "Savings", "" },
                    { new Guid("f04ee2e8-3b62-4423-9b99-22f68d21016d"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4900), null, "", "Cash", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2db98350-2916-414f-a894-4205fbf6053d"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4800), null, "A celebration commemorating a significant milestone in a couple's relationship.", "Anniversary Celebration", "" },
                    { new Guid("3b4e0090-b064-484e-bb8a-436ae0109fbb"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4790), null, "An event organized by a company or business for its employees or clients.", "Corporate Event", "" },
                    { new Guid("404364c1-bb43-41fb-abb3-e16c9238b749"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4820), null, "An exhibition where businesses showcase their products and services.", "Trade Show", "" },
                    { new Guid("57df092f-17ef-4e90-bbfa-25ffd847f151"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4790), null, "A celebration of the anniversary of a person's birth.", "Birthday Party", "" },
                    { new Guid("92fc11a0-88d6-4fc8-b2cc-feced4040527"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4800), null, "A celebration to honor the completion of an academic program.", "Graduation Party", "" },
                    { new Guid("b61e9c09-7c23-4cb5-a6ea-209f3399117d"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4810), null, "A live performance of music by one or more musicians.", "Concert", "" },
                    { new Guid("c08c0a9a-d6b2-4006-b8df-6fd679b44683"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4730), null, "A ceremony where two people are united in marriage.", "Wedding", "" },
                    { new Guid("da931f60-904e-45f2-af03-2cb747fb90e1"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4820), null, "A series of events or activities celebrating a particular theme or occasion.", "Festival", "" },
                    { new Guid("dd208f78-cb6b-4e84-b54d-6f3cf3a3ea9c"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4810), null, "An event organized to raise funds or awareness for a charitable cause.", "Charity Event", "" },
                    { new Guid("eef80111-3ef1-43c8-a6eb-130f76abb28f"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4810), null, "A celebration held to honor the expectant mother and her baby.", "Baby Shower", "" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0e3f239c-d6ea-4579-9546-f14946994c8a"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2670), null, "Design and printing services for wedding invitations, save-the-dates, and other stationery.", "Stationery & Invitations", "" },
                    { new Guid("0ef71f7d-b378-4af0-bea4-62e4f2e6524a"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2670), null, "Professional officiants to conduct the wedding ceremony.", "Officiant Services", "" },
                    { new Guid("14e3266a-db1f-4c5f-aea6-7d7e78318671"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2640), null, "Floral arrangements, bouquets, and other decorative flower services.", "Floristry", "" },
                    { new Guid("175ffd7b-ef06-428b-9012-a28f50de1e2b"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2630), null, "Locations for wedding ceremonies, receptions, and other related events.", "Venue", "" },
                    { new Guid("1e23e131-b418-40b6-8448-e70a51193f4c"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2680), null, "Rental of items like furniture, tableware, tents, and dance floors.", "Rentals", "" },
                    { new Guid("2163d3a8-69e0-4c42-b2b3-d66578cf7ffa"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2650), null, "Coordination and planning services to manage the entire wedding event.", "Wedding Planning", "" },
                    { new Guid("36901cb0-9d2a-4cbe-abf3-76e60ca5b8f9"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2650), null, "Transportation services for the wedding party and guests, such as limousines and shuttles.", "Transportation", "" },
                    { new Guid("4c6e6e69-9d87-4563-a8ec-3cd1fe088c40"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2680), null, "Wedding rings, bridal jewelry, and other related accessories.", "Jewelry", "" },
                    { new Guid("6f2f51f6-9b5a-48ea-84c0-bfe24f099fad"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2660), null, "Wedding attire rentals or purchases, including dresses, suits, and accessories.", "Attire & Accessories", "" },
                    { new Guid("93fbcd79-aabe-4cc2-a74b-31963585ccb0"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2680), null, "Gifts and party favors for guests.", "Favors & Gifts", "" },
                    { new Guid("a8fdd0ed-ed87-4732-afc3-deba6c98b216"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2630), null, "Professional photography services for capturing wedding moments.", "Photography", "" },
                    { new Guid("b198e7f5-2981-4987-a18c-04942569178c"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2630), null, "Video recording services to capture and document the wedding day.", "Videography", "" },
                    { new Guid("b817df44-e981-4468-b69e-3d533ecaef1e"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2640), null, "Decorative items and setup services, including centerpieces, lighting, and table settings.", "Decor", "" },
                    { new Guid("c9f7afb6-08d5-47d7-8948-3af5ab0fb26f"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2620), null, "Food and beverage services, including full-course meals, buffets, and bar services.", "Catering", "" },
                    { new Guid("cada1168-d67e-45c0-8685-94ee0ad06f88"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2660), null, "Beauty services for the bridal party, including hairstyling and makeup.", "Hair & Makeup", "" },
                    { new Guid("dd39dc88-7a2a-4e48-8ccf-62a3ad91673f"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2640), null, "Entertainment services, including live bands, DJs, and performers.", "Music & Entertainment", "" },
                    { new Guid("ed75967a-2262-483b-8bae-409d036259e2"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2660), null, "Wedding cakes, desserts, and other sweets for the reception.", "Cake & Confectionery", "" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("9d410d46-bccd-4dcd-acde-d38b6bd5c5d8"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4950), null, "A general payment or debit from a user’s account, often for non-purchase activities, such as bill payments or installment payments.", "Payment", "" },
                    { new Guid("c49fd8df-5bcd-4db2-a590-511be4ebef81"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4960), null, "Represents adding funds to an account, usually as a top-up or a prepayment.", "Deposit", "" },
                    { new Guid("cc131b1e-852a-49da-92e1-71ac75230726"), "", new DateTime(2024, 11, 6, 11, 9, 46, 950, DateTimeKind.Utc).AddTicks(4960), null, "Represents money returned to the user for a previous purchase, usually due to a return or an issue with the product/service.", "Refund", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("057a2ea9-e0c0-400e-83ad-a08a2ea474c1"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2780), null, "Hosts and coordinates the wedding program.", "Emcee", "" },
                    { new Guid("06789e1d-96ec-4214-ace7-9d67cce9652f"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2790), null, "Location where the wedding ceremony and/or reception is held.", "Venue", "" },
                    { new Guid("0addebed-3d70-4e49-b61d-ca10ca44817c"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2730), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "" },
                    { new Guid("101b7aa6-7fe8-442d-8f0e-a556e87a3aa0"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2770), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "" },
                    { new Guid("198fef30-ec9d-4c56-a89d-25797b8c4c5e"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2800), null, "Coordinates all aspects of the wedding planning process from start to finish.", "Wedding Planner", "" },
                    { new Guid("2685db96-92c9-461f-88f7-4af20449b6c1"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2820), null, "Offers items for rent such as tables, chairs, linens, and decor.", "Rentals", "" },
                    { new Guid("44930831-3a7e-47f2-a499-5ff2f0d86632"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2750), null, "Provides food and beverage services for the wedding.", "Caterer", "" },
                    { new Guid("5702b648-193b-49b2-b098-a499bc4fd73b"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2750), null, "Captures memories through professional photography during the wedding.", "Photographer & Videographer", "" },
                    { new Guid("5e5de48f-b8a2-4b18-bfd2-d2180f475d3d"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2760), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup Artist", "" },
                    { new Guid("65925415-984c-4898-9f81-727c1f089b07"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2820), null, "Styles hair for the bride, bridesmaids, and other family members.", "Hair Stylist", "" },
                    { new Guid("6b4963d1-4261-4415-afb1-5e4186e72a36"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2830), null, "Designs and prints wedding invitations, save-the-dates, and programs.", "Stationery", "" },
                    { new Guid("75c84ce3-a3ee-4e87-bd98-a39292a1075e"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2840), null, "Ensures the safety and security of the wedding event and guests.", "Security", "" },
                    { new Guid("827bcb6b-b094-4597-9385-d8f4078a6482"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2840), null, "Manages sound systems and audio equipment for the ceremony and reception.", "Sound Engineer", "" },
                    { new Guid("8b9d814a-08cd-4135-81dd-fcb9c5c35f79"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2770), null, "Sells wedding rings and related jewelry.", "Jeweler", "" },
                    { new Guid("8d627700-d9b2-4eb7-b2c6-e9dc1d83d2e6"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2800), null, "Provides music entertainment and emceeing for the wedding and reception.", "DJ", "" },
                    { new Guid("8d6eb40b-05a3-4c2e-828a-b71ff1677eb7"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2820), null, "Provides professional makeup services for the bride and bridal party.", "Makeup Artist", "" },
                    { new Guid("8fe08549-6fcc-4aaa-8e50-ebbd2ee873c9"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2810), null, "Provides vehicles for transporting the wedding party and guests.", "Transportation", "" },
                    { new Guid("95e90cc5-f4cf-4ebc-919e-3048b5042367"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2800), null, "Creates wedding cakes, cupcakes, and desserts for the celebration.", "Baker", "" },
                    { new Guid("a0f0ddbf-f6bf-4546-8f87-36df76f07429"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2780), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "" },
                    { new Guid("a9fdda25-0936-46bc-8c44-052cf40f786c"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2810), null, "Conducts the wedding ceremony and ensures it is legally binding.", "Officiant", "" },
                    { new Guid("af8e87b7-1332-4907-ba55-3dedd06631b6"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2740), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "" },
                    { new Guid("bb12bcdc-f89c-4847-a942-c1d001dfebd7"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2830), null, "Provides a fun photo booth setup with props for guests to enjoy.", "Photo Booth", "" },
                    { new Guid("c626b299-e8b0-4b4c-b9b6-0fd5ffcc6f06"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2740), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "" },
                    { new Guid("cae8cdf1-077f-4a74-9824-fb60dd5d4402"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2760), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "" },
                    { new Guid("dae957e7-7c1f-4956-8954-88b693d38cb6"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2840), null, "Creates customized lighting plans to enhance the wedding ambiance.", "Lighting Designer", "" },
                    { new Guid("df77c71c-8d66-4d2b-b98b-6625b48faedc"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2770), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "" },
                    { new Guid("e5f9b305-dffe-46e1-b288-c753b67d6694"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2760), null, "A musical group that performs live at the wedding reception.", "Live Band", "" },
                    { new Guid("e6e1f8df-58ac-4b00-a3da-dfaa6d16c053"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2790), null, "Records the wedding ceremony and reception with high-quality video.", "Videographer", "" },
                    { new Guid("ee9c28db-45de-4256-a861-82365430eb5f"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2790), null, "Captures memories through professional photography during the wedding.", "Photographer", "" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountTypeId", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2feba8df-234d-428c-86b6-cf1061c09f80"), "2ff73eea-48e2-430c-955a-959d296563e4", new Guid("f04ee2e8-3b62-4423-9b99-22f68d21016d"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3290), null, "Event Account", "" },
                    { new Guid("857e18dc-9d19-4aae-b51b-22dc71c62390"), "ebab313b-62b1-4d87-9607-aec0db74696e", new Guid("f04ee2e8-3b62-4423-9b99-22f68d21016d"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3000), null, "Vendor Account", "" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EndDate", "EventTypeId", "Location", "Seats", "StartDate", "Title", "UpdatedBy" },
                values: new object[] { new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3070), null, "Wedding", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c08c0a9a-d6b2-4006-b8df-6fd679b44683"), "Ph", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wedding", "" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Address", "ContactInformation", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy", "VendorTypeId" },
                values: new object[,]
                {
                    { new Guid("3b96b041-2103-4310-9b6b-0fe002067416"), "N/A", "", "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2940), null, "Captures memories through professional photography during the wedding.", "Photo & Video", "", new Guid("5702b648-193b-49b2-b098-a499bc4fd73b") },
                    { new Guid("4e88c11c-4d5f-4c41-8474-45e18ae83703"), "N/A", "", "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2950), null, "Sells wedding rings and related jewelry.", "Jeweler", "", new Guid("8b9d814a-08cd-4135-81dd-fcb9c5c35f79") },
                    { new Guid("5a72ae0b-0e56-4a54-827e-2b21a6f100f9"), "N/A", "", "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2970), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "", new Guid("a0f0ddbf-f6bf-4546-8f87-36df76f07429") },
                    { new Guid("5b44396b-d12c-43d3-97a3-d5eb5e2dff14"), "N/A", "", "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2930), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "", new Guid("af8e87b7-1332-4907-ba55-3dedd06631b6") },
                    { new Guid("670dd042-05f9-4f1e-8c84-9e129852a1d5"), "N/A", "", "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2920), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "", new Guid("0addebed-3d70-4e49-b61d-ca10ca44817c") },
                    { new Guid("67a1317c-50e0-417d-aa8f-4f1ab2bd952f"), "N/A", "", "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2970), null, "Hosts and coordinates the wedding program.", "Emcee", "", new Guid("057a2ea9-e0c0-400e-83ad-a08a2ea474c1") },
                    { new Guid("aebba88d-f17e-4140-9c44-f14bc0dce87b"), "N/A", "", "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2930), null, "Provides food and beverage services for the wedding.", "Caterer", "", new Guid("44930831-3a7e-47f2-a499-5ff2f0d86632") },
                    { new Guid("b57fe9ba-a51f-4ff8-b3ed-105c84bc1d00"), "N/A", "", "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2950), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup", "", new Guid("5e5de48f-b8a2-4b18-bfd2-d2180f475d3d") },
                    { new Guid("bd978627-1514-4284-9557-7a59947667a4"), "N/A", "", "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2960), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "", new Guid("101b7aa6-7fe8-442d-8f0e-a556e87a3aa0") },
                    { new Guid("cc7353fe-8fd5-428a-bdf8-f0d9b4fd9d8e"), "N/A", "", "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2920), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "", new Guid("c626b299-e8b0-4b4c-b9b6-0fd5ffcc6f06") },
                    { new Guid("ecefae58-76ad-4db3-b3fa-9b94181019c3"), "N/A", "", "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2940), null, "A musical group that performs live at the wedding reception.", "Strings", "", new Guid("e5f9b305-dffe-46e1-b288-c753b67d6694") },
                    { new Guid("f1086525-f6e0-4866-862d-ce20fad50ce7"), "N/A", "", "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2960), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "", new Guid("df77c71c-8d66-4d2b-b98b-6625b48faedc") },
                    { new Guid("f6e3987e-ad9f-497b-8499-88d341c9eff7"), "N/A", "", "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(2950), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "", new Guid("cae8cdf1-077f-4a74-9824-fb60dd5d4402") }
                });

            migrationBuilder.InsertData(
                table: "EventAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "EventId", "UpdatedBy" },
                values: new object[] { new Guid("4b9126e3-2b4c-4a1d-ad0e-981d26b3fac3"), new Guid("2feba8df-234d-428c-86b6-cf1061c09f80"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3310), null, new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "" });

            migrationBuilder.InsertData(
                table: "EventVendorContractPaymentState",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0dab70ce-6975-4971-8b41-23c79a750a85"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3250), null, "Payment is overdue.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Overdue Payment", "" },
                    { new Guid("44546681-6280-4bd9-8467-8afeccbfe1d2"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3240), null, "Waiting for the initial deposit to be paid.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Deposit Pending", "" },
                    { new Guid("8b0ffa60-9421-426d-bd36-8af6ae428fb2"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3250), null, "All payments have been made, contract is paid in full.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Paid in Full", "" },
                    { new Guid("906eb283-a43f-41c5-b415-5d012b0e795b"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3260), null, "Refund has been processed and completed.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Refunded", "" },
                    { new Guid("f60e75b9-9f3e-4900-a80b-c4133dc9da8f"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3250), null, "Partial payment received, remaining balance due.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Partial Payment", "" },
                    { new Guid("f9efb7ea-7958-47a0-b393-99bbff219beb"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3260), null, "Refund is pending processing.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Refund Pending", "" }
                });

            migrationBuilder.InsertData(
                table: "EventVendorContractStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("059cef22-b130-4901-9088-f40495c5df50"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3200), null, "Waiting for a quote from the vendor.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Pending Quote", "" },
                    { new Guid("1eb61ef0-32cb-41c6-af97-bcccbbd04aa6"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3200), null, "Quote has been received from the vendor.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Quote Received", "" },
                    { new Guid("60c22f16-9793-4d8b-b92a-c0a07dc66053"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3220), null, "Contract has been booked and confirmed.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Booked", "" },
                    { new Guid("6c114ad3-07a7-40eb-9284-ebe5afd63756"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3210), null, "Negotiations are ongoing with the vendor.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Negotiation", "" },
                    { new Guid("852e798d-7690-4d17-9b69-d61040164d2a"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3190), null, "Initial inquiry stage.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Inquiry", "" },
                    { new Guid("ea2bc5a1-1319-43e2-89d0-6ae90e598a91"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3220), null, "Contract has been completed and closed.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Closed", "" },
                    { new Guid("eabe52bd-60b5-4272-bfd6-9c1e7aa59bb6"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3210), null, "Tentatively booked, awaiting confirmation.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Tentative", "" },
                    { new Guid("f3da1b8d-b402-44bf-bef6-0b586c45bda8"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3210), null, "Reserved but not yet confirmed.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Reserved", "" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("04f77d78-5cda-469c-849b-3e342efc995e"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3140), null, "A role representing the cord used in the ceremony.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Cord", "" },
                    { new Guid("05238d99-9b81-4f75-804a-b309cc0c7810"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3140), null, "A role representing the candle holders during the ceremony.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Candles", "" },
                    { new Guid("054318bf-c95c-4b5e-a14d-3202082bac79"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3150), null, "Friends or family who stand with the groom during the ceremony.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Groomsmen", "" },
                    { new Guid("1c1d5e30-045b-42fe-860b-877d1b2f2afd"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3160), null, "Friends or family who stand with the bride during the ceremony.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Bridesmaids", "" },
                    { new Guid("26886b64-1290-467a-b72a-b5db25f32d65"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3100), null, "The female participant in the wedding.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Bride", "" },
                    { new Guid("38b0c53c-8320-48e4-bedb-74e4f6218eed"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3130), null, "A young child who carries the wedding rings during the ceremony.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Ring Bearer", "" },
                    { new Guid("3f6990b8-26ca-4f3c-af90-811a535bdc88"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3110), null, "The male participant in the wedding.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Groom", "" },
                    { new Guid("427888ae-1857-48d2-bf35-f14d6009db2c"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3150), null, "Individuals responsible for seating guests at the ceremony.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Ushers", "" },
                    { new Guid("773e2d6f-1f91-48e7-93dd-5c7438834b69"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3140), null, "A person who carries the Bible during the ceremony.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Bible Bearer", "" },
                    { new Guid("8130dce9-ea03-4fcb-a51f-9188e84d10dc"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3170), null, "A key family member representing the groom's side.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Parent of the Groom", "" },
                    { new Guid("85863402-db5d-4885-8302-1fc452056c50"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3130), null, "A person invited to attend the wedding.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Guest", "" },
                    { new Guid("a324b79c-fdf1-4394-a396-07b18fb8fab8"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3120), null, "The main financial supporter of the wedding.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Primary Sponsor", "" },
                    { new Guid("aafee7b7-f9c2-4e77-8020-7c73b1fa9ce6"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3110), null, "The bride's chief assistant during the wedding.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Maid of Honor", "" },
                    { new Guid("be7e0cca-b1b2-4a46-b5e6-27fb85e32a43"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3120), null, "An additional financial supporter of the wedding.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Secondary Sponsor", "" },
                    { new Guid("c57544fe-7f41-48e6-bca9-6031b3b71a4c"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3160), null, "A key family member who may have a significant role.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Parent of the Bride", "" },
                    { new Guid("ce417024-35c8-4d99-9f73-cbdca9bc0fd2"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3120), null, "A young girl who scatters flower petals along the aisle.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Flower Girl", "" },
                    { new Guid("f250caa1-6092-4af8-a71d-8a35268cc89d"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3110), null, "The groom's chief assistant during the wedding.", new Guid("564bd367-ff68-4b5e-a5b6-e695b884b7ff"), "Best Man", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "UpdatedBy", "VendorId" },
                values: new object[] { new Guid("68d21a7b-6ebf-453d-9408-788b139a357d"), new Guid("857e18dc-9d19-4aae-b51b-22dc71c62390"), "", new DateTime(2024, 11, 6, 11, 9, 46, 952, DateTimeKind.Utc).AddTicks(3040), null, "", new Guid("670dd042-05f9-4f1e-8c84-9e129852a1d5") });

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
