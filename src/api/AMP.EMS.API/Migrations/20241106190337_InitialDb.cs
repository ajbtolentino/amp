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
                    EventVendorContractStateId = table.Column<Guid>(type: "TEXT", nullable: true),
                    EventVendorContractPaymentStateId = table.Column<Guid>(type: "TEXT", nullable: true),
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
                        principalColumn: "Id");
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
                    { new Guid("24942542-7aaa-49df-b97a-569c98df1aba"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(750), null, "", "Credit Card", "" },
                    { new Guid("42720c94-07ec-4901-b14c-8173f869a3f7"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(750), null, "", "Checking", "" },
                    { new Guid("65edd900-f9fd-49a5-bc20-0e41f38632d7"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(750), null, "", "Savings", "" },
                    { new Guid("c8d7e776-acbb-4b1d-80df-4dd888fb87b3"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(740), null, "", "Cash", "" },
                    { new Guid("ff262531-fa1f-4eec-992e-19fb7ada6616"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(740), null, "", "GCash", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("183bf5ad-c3ca-457d-adbc-40955196204b"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(640), null, "A celebration of the anniversary of a person's birth.", "Birthday Party", "" },
                    { new Guid("36ae1366-8f70-498f-a770-98c02570788e"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(660), null, "An event organized to raise funds or awareness for a charitable cause.", "Charity Event", "" },
                    { new Guid("4a0cbda5-fd39-4938-a67b-e3bcce3591e0"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(650), null, "A celebration held to honor the expectant mother and her baby.", "Baby Shower", "" },
                    { new Guid("5d3aeb1f-df53-4615-90c5-43b1560513b1"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(660), null, "A live performance of music by one or more musicians.", "Concert", "" },
                    { new Guid("6054ef8f-bd58-41e5-a4e4-4efe93a0feb3"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(650), null, "A celebration to honor the completion of an academic program.", "Graduation Party", "" },
                    { new Guid("711c66e3-44f4-492c-a303-c0e441f0bf07"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(660), null, "A series of events or activities celebrating a particular theme or occasion.", "Festival", "" },
                    { new Guid("7201311b-e463-491a-ad5e-ad0aa765fcad"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(670), null, "An exhibition where businesses showcase their products and services.", "Trade Show", "" },
                    { new Guid("79c16dc1-a94b-4c68-8bcb-bec04c440f77"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(640), null, "A celebration commemorating a significant milestone in a couple's relationship.", "Anniversary Celebration", "" },
                    { new Guid("aa26c480-40e1-4435-9339-5ba09de27abd"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(630), null, "An event organized by a company or business for its employees or clients.", "Corporate Event", "" },
                    { new Guid("f7c6c362-90ad-475f-bd0e-854c83d55870"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(580), null, "A ceremony where two people are united in marriage.", "Wedding", "" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("029334aa-e87c-4ea3-8914-7f58f204b913"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7570), null, "Transportation services for the wedding party and guests, such as limousines and shuttles.", "Transportation", "" },
                    { new Guid("131b721e-913a-4689-86fc-032c7653c5b3"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7550), null, "Video recording services to capture and document the wedding day.", "Videography", "" },
                    { new Guid("1d1c3f60-16e3-48a9-836f-36fa9ac7f368"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7560), null, "Decorative items and setup services, including centerpieces, lighting, and table settings.", "Decor", "" },
                    { new Guid("370b8c67-a068-40a8-ad9a-12a8f4930121"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7590), null, "Wedding rings, bridal jewelry, and other related accessories.", "Jewelry", "" },
                    { new Guid("3a94507a-2019-47fa-94af-ade237a1813b"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7570), null, "Wedding cakes, desserts, and other sweets for the reception.", "Cake & Confectionery", "" },
                    { new Guid("3d89eed8-de2a-410c-9186-60bae382e187"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7550), null, "Floral arrangements, bouquets, and other decorative flower services.", "Floristry", "" },
                    { new Guid("4dd8ed37-a4bd-46a3-9ced-0930c3b7a395"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7570), null, "Wedding attire rentals or purchases, including dresses, suits, and accessories.", "Attire & Accessories", "" },
                    { new Guid("587e6750-6106-4e63-9e8c-7855955776a2"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7540), null, "Locations for wedding ceremonies, receptions, and other related events.", "Venue", "" },
                    { new Guid("5b344922-2272-4aad-b7bf-746cff87cddd"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7560), null, "Coordination and planning services to manage the entire wedding event.", "Wedding Planning", "" },
                    { new Guid("83051d11-3f92-4b22-b1f1-4d66b8698423"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7590), null, "Rental of items like furniture, tableware, tents, and dance floors.", "Rentals", "" },
                    { new Guid("8b3e8901-29f4-4486-a849-f82543c812d2"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7580), null, "Beauty services for the bridal party, including hairstyling and makeup.", "Hair & Makeup", "" },
                    { new Guid("a52aac78-9294-41bc-b96f-6868f51edb72"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7580), null, "Design and printing services for wedding invitations, save-the-dates, and other stationery.", "Stationery & Invitations", "" },
                    { new Guid("ab8025d4-5b5d-4cad-9ef3-1574b50323fa"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7550), null, "Professional photography services for capturing wedding moments.", "Photography", "" },
                    { new Guid("ad54812b-f71e-4d14-bcbc-c3a7d9020f96"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7560), null, "Entertainment services, including live bands, DJs, and performers.", "Music & Entertainment", "" },
                    { new Guid("bdf497e7-8cdb-47fe-9ebf-f700427091f4"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7530), null, "Food and beverage services, including full-course meals, buffets, and bar services.", "Catering", "" },
                    { new Guid("cc748d21-f978-4332-90eb-b4607ebe713a"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7590), null, "Professional officiants to conduct the wedding ceremony.", "Officiant Services", "" },
                    { new Guid("d8bd39c7-cd95-4b40-8c5f-91ca0cc5c1be"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7600), null, "Gifts and party favors for guests.", "Favors & Gifts", "" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("18d56995-5908-403a-ab43-f75d4c9bc775"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(810), null, "Represents money returned to the user for a previous purchase, usually due to a return or an issue with the product/service.", "Refund", "" },
                    { new Guid("3961e5ba-7230-40a1-812c-2bf91780e3b3"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(810), null, "Represents adding funds to an account, usually as a top-up or a prepayment.", "Deposit", "" },
                    { new Guid("d56e836e-be51-4976-b07d-1d80b2b56bd2"), "", new DateTime(2024, 11, 6, 19, 3, 37, 681, DateTimeKind.Utc).AddTicks(800), null, "A general payment or debit from a user’s account, often for non-purchase activities, such as bill payments or installment payments.", "Payment", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0215f011-ddb4-46e0-904e-5e520f3a170b"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7730), null, "Designs and prints wedding invitations, save-the-dates, and programs.", "Stationery", "" },
                    { new Guid("05dd88de-960e-42e6-af2c-9ba614369833"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7650), null, "A musical group that performs live at the wedding reception.", "Live Band", "" },
                    { new Guid("0c2b6903-955a-40be-8323-90a2653197ca"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7660), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "" },
                    { new Guid("0f19a7bf-d67b-4d06-86ed-db782c61a12e"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7650), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "" },
                    { new Guid("17665b12-d967-4cf3-9a02-80ca603e0936"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7670), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "" },
                    { new Guid("242eb61a-ceb1-4944-b6cb-dbc3b2d7e7ec"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7720), null, "Conducts the wedding ceremony and ensures it is legally binding.", "Officiant", "" },
                    { new Guid("25522887-25ec-4f2f-bfbf-433e97000a1b"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7670), null, "Hosts and coordinates the wedding program.", "Emcee", "" },
                    { new Guid("3ca5bbbc-32d0-4d7f-ad8d-fe2d007296ba"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7640), null, "Provides food and beverage services for the wedding.", "Caterer", "" },
                    { new Guid("4f9f72b4-e242-4a9a-857a-78467b5ab2bd"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7750), null, "Creates customized lighting plans to enhance the wedding ambiance.", "Lighting Designer", "" },
                    { new Guid("508ee3db-f119-410f-ad66-20c9150535e2"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7640), null, "Captures memories through professional photography during the wedding.", "Photographer & Videographer", "" },
                    { new Guid("5fe77510-e4a4-457c-aae1-250f9887eee2"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7680), null, "Location where the wedding ceremony and/or reception is held.", "Venue", "" },
                    { new Guid("63ed16d6-67a7-413b-b55f-a88693444886"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7750), null, "Manages sound systems and audio equipment for the ceremony and reception.", "Sound Engineer", "" },
                    { new Guid("65d40493-0478-409e-99f6-b8904942b642"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7730), null, "Provides professional makeup services for the bride and bridal party.", "Makeup Artist", "" },
                    { new Guid("7c0285eb-57d8-41dc-8c3b-7e2093ec7532"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7650), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup Artist", "" },
                    { new Guid("7d334885-a8ed-4fa1-917c-7c46740cb58d"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7700), null, "Captures memories through professional photography during the wedding.", "Photographer", "" },
                    { new Guid("85e14ff5-7905-497f-af12-92e0cdd9032f"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7620), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "" },
                    { new Guid("86b63700-3a45-47cf-985a-ce065310e9ed"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7740), null, "Provides a fun photo booth setup with props for guests to enjoy.", "Photo Booth", "" },
                    { new Guid("8750de2c-1151-448b-be69-fed4898d5cc7"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7730), null, "Offers items for rent such as tables, chairs, linens, and decor.", "Rentals", "" },
                    { new Guid("89d88aad-dfbc-41b4-aa8d-186bc19481e5"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7660), null, "Sells wedding rings and related jewelry.", "Jeweler", "" },
                    { new Guid("921fb57d-df79-4184-822e-f144d9928514"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7740), null, "Ensures the safety and security of the wedding event and guests.", "Security", "" },
                    { new Guid("95a48777-4e64-4d59-b96f-a0eba4df43c5"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7710), null, "Creates wedding cakes, cupcakes, and desserts for the celebration.", "Baker", "" },
                    { new Guid("96725c6a-2732-4cea-90e8-0c3731c3fd94"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7720), null, "Styles hair for the bride, bridesmaids, and other family members.", "Hair Stylist", "" },
                    { new Guid("97b5dd40-f540-40d1-bfa2-66d4dede9ac5"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7630), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "" },
                    { new Guid("a0a206f6-0b33-4ac1-acc7-2ce5de4403f7"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7720), null, "Provides vehicles for transporting the wedding party and guests.", "Transportation", "" },
                    { new Guid("b68ee99f-0313-4002-9f0a-ff20edd378f2"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7660), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "" },
                    { new Guid("b96aef48-211e-4b09-801b-3c71c35667ae"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7700), null, "Provides music entertainment and emceeing for the wedding and reception.", "DJ", "" },
                    { new Guid("ebdd7825-f0e2-4451-bc33-196b2d9f75bd"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7700), null, "Records the wedding ceremony and reception with high-quality video.", "Videographer", "" },
                    { new Guid("f4828f75-1eb9-407a-86ce-1e643cb902c9"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7710), null, "Coordinates all aspects of the wedding planning process from start to finish.", "Wedding Planner", "" },
                    { new Guid("f821501d-cb36-4dfd-b8b8-daad3ebc42d9"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7630), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountTypeId", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("35d2acaa-2f90-42ce-bee9-bc4c16e2d2bf"), "51035d7e-291a-4d22-b9f0-04506a30bc0c", new Guid("c8d7e776-acbb-4b1d-80df-4dd888fb87b3"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8190), null, "Event Account", "" },
                    { new Guid("9c32a87a-6527-4f55-ac3e-e4d78e3bf031"), "9c02578b-0b7e-46ef-a4f9-66596bce6762", new Guid("c8d7e776-acbb-4b1d-80df-4dd888fb87b3"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7900), null, "Vendor Account", "" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EndDate", "EventTypeId", "Location", "Seats", "StartDate", "Title", "UpdatedBy" },
                values: new object[] { new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7970), null, "Wedding", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f7c6c362-90ad-475f-bd0e-854c83d55870"), "Ph", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wedding", "" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Address", "ContactInformation", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy", "VendorTypeId" },
                values: new object[,]
                {
                    { new Guid("006fd6a8-19fd-4075-bb82-80549f154e5e"), "N/A", "", "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7820), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "", new Guid("97b5dd40-f540-40d1-bfa2-66d4dede9ac5") },
                    { new Guid("13557d96-26fe-4b8a-bfe3-e7a6c2e645bd"), "N/A", "", "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7820), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "", new Guid("f821501d-cb36-4dfd-b8b8-daad3ebc42d9") },
                    { new Guid("23449a6f-418d-4651-84d8-72116167bfed"), "N/A", "", "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7840), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup", "", new Guid("7c0285eb-57d8-41dc-8c3b-7e2093ec7532") },
                    { new Guid("2662bdea-cb67-45bb-93f2-caa6c117f97b"), "N/A", "", "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7850), null, "Sells wedding rings and related jewelry.", "Jeweler", "", new Guid("89d88aad-dfbc-41b4-aa8d-186bc19481e5") },
                    { new Guid("5413447f-8438-4d77-8f60-2101731bc13b"), "N/A", "", "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7840), null, "A musical group that performs live at the wedding reception.", "Strings", "", new Guid("05dd88de-960e-42e6-af2c-9ba614369833") },
                    { new Guid("5afe4043-aad0-4bbb-9a41-eb6cc9331f86"), "N/A", "", "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7850), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "", new Guid("0f19a7bf-d67b-4d06-86ed-db782c61a12e") },
                    { new Guid("71617f5e-54c0-4749-81ad-b7e0323bdb17"), "N/A", "", "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7860), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "", new Guid("0c2b6903-955a-40be-8323-90a2653197ca") },
                    { new Guid("7c49b5d1-fa13-43e1-b68a-3f25864064db"), "N/A", "", "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7830), null, "Provides food and beverage services for the wedding.", "Caterer", "", new Guid("3ca5bbbc-32d0-4d7f-ad8d-fe2d007296ba") },
                    { new Guid("ad3ca28b-f710-4b46-9a1e-f1f188cac358"), "N/A", "", "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7860), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "", new Guid("17665b12-d967-4cf3-9a02-80ca603e0936") },
                    { new Guid("c618cca2-fc8e-4a58-832e-8ddc1287ae29"), "N/A", "", "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7810), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "", new Guid("85e14ff5-7905-497f-af12-92e0cdd9032f") },
                    { new Guid("d7edf160-588d-4e7d-83de-2c1f67658c4b"), "N/A", "", "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7830), null, "Captures memories through professional photography during the wedding.", "Photo & Video", "", new Guid("508ee3db-f119-410f-ad66-20c9150535e2") },
                    { new Guid("f2c6d454-07d6-4c62-8b2f-bb09ac307830"), "N/A", "", "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7850), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "", new Guid("b68ee99f-0313-4002-9f0a-ff20edd378f2") },
                    { new Guid("f806f849-4d64-4652-bcef-1d828896bd7a"), "N/A", "", "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7870), null, "Hosts and coordinates the wedding program.", "Emcee", "", new Guid("25522887-25ec-4f2f-bfbf-433e97000a1b") }
                });

            migrationBuilder.InsertData(
                table: "EventAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "EventId", "UpdatedBy" },
                values: new object[] { new Guid("b14d741e-0235-4c67-8427-c223e085961e"), new Guid("35d2acaa-2f90-42ce-bee9-bc4c16e2d2bf"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8210), null, new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "" });

            migrationBuilder.InsertData(
                table: "EventVendorContractPaymentState",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("258c66f0-ebc1-4db2-8eca-2f56c4be545e"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8150), null, "Refund is pending processing.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Refund Pending", "" },
                    { new Guid("48ba786e-2259-4f9c-baf2-75f40f2ff34f"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8140), null, "All payments have been made, contract is paid in full.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Paid in Full", "" },
                    { new Guid("50eb29c9-2ae2-43fd-8349-c33a90d67985"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8150), null, "Refund has been processed and completed.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Refunded", "" },
                    { new Guid("62103302-c8af-474c-9829-4535246ea8de"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8150), null, "Payment is overdue.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Overdue Payment", "" },
                    { new Guid("79dba2a1-6bcd-45a7-b08a-9d184ee456bb"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8140), null, "Partial payment received, remaining balance due.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Partial Payment", "" },
                    { new Guid("94c0f886-9d0e-4d73-84b0-5733222dd42a"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8130), null, "Waiting for the initial deposit to be paid.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Deposit Pending", "" }
                });

            migrationBuilder.InsertData(
                table: "EventVendorContractStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("06259499-dc3d-4200-bb25-db4365bbd2bf"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8080), null, "Initial inquiry stage.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Inquiry", "" },
                    { new Guid("0a921687-4ff9-480c-b396-98d6675c1ab3"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8090), null, "Quote has been received from the vendor.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Quote Received", "" },
                    { new Guid("2a2e96c6-32ac-4f21-bb80-a96de656fe10"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8110), null, "Tentatively booked, awaiting confirmation.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Tentative", "" },
                    { new Guid("2a7604f4-24eb-44b9-be95-923b6fcacb76"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8100), null, "Reserved but not yet confirmed.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Reserved", "" },
                    { new Guid("7ec31d87-276e-41e2-9c62-0229c7589277"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8100), null, "Negotiations are ongoing with the vendor.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Negotiation", "" },
                    { new Guid("a2209a96-afeb-4ba5-88cc-f33623acee7f"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8090), null, "Waiting for a quote from the vendor.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Pending Quote", "" },
                    { new Guid("e166af46-0fb4-450f-9ddd-d45f3d6a3609"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8110), null, "Contract has been completed and closed.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Closed", "" },
                    { new Guid("ea394113-327f-42c2-bc28-c42759562f10"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8110), null, "Contract has been booked and confirmed.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Booked", "" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("12f8381a-e544-408c-bbde-2a70f4d76922"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8000), null, "The groom's chief assistant during the wedding.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Best Man", "" },
                    { new Guid("200fda0f-1595-4e6b-aba4-0dc10e0fe5ff"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8030), null, "A person who carries the Bible during the ceremony.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Bible Bearer", "" },
                    { new Guid("29206ed1-da08-43d2-8e28-2cc91acd8d4b"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8050), null, "A key family member who may have a significant role.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Parent of the Bride", "" },
                    { new Guid("3b5ef963-f882-4f39-ab10-d08be7fc3b08"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8010), null, "The main financial supporter of the wedding.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Primary Sponsor", "" },
                    { new Guid("3ba5ddcb-be28-49d6-995b-b83b546ed73a"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8020), null, "A young girl who scatters flower petals along the aisle.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Flower Girl", "" },
                    { new Guid("57d29754-80d5-4a15-822e-f7abadf945d9"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8030), null, "A person invited to attend the wedding.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Guest", "" },
                    { new Guid("65066089-4699-4b9e-ad87-d60c55e61d84"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8050), null, "Friends or family who stand with the groom during the ceremony.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Groomsmen", "" },
                    { new Guid("6f150c4b-6332-4940-8b25-cb712aaa127c"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8040), null, "A role representing the candle holders during the ceremony.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Candles", "" },
                    { new Guid("8d10c669-ad01-4c40-b7c6-aa88def5684f"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8000), null, "The male participant in the wedding.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Groom", "" },
                    { new Guid("8d21fb20-b114-4f2b-b356-0ebff9cfd631"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7990), null, "The female participant in the wedding.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Bride", "" },
                    { new Guid("a57a3392-a2f2-4054-abbe-0becf445a0c4"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8030), null, "A role representing the cord used in the ceremony.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Cord", "" },
                    { new Guid("ac61a7f7-11ba-493f-984f-5e28c56a67d4"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8010), null, "An additional financial supporter of the wedding.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Secondary Sponsor", "" },
                    { new Guid("b6fa2863-f662-4764-8ab3-a3a9d166b98d"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8060), null, "A key family member representing the groom's side.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Parent of the Groom", "" },
                    { new Guid("d4739baa-4862-485a-ad51-f11e57d43c2f"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8050), null, "Friends or family who stand with the bride during the ceremony.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Bridesmaids", "" },
                    { new Guid("e5e53174-f0bf-4712-86c8-5b327b07e617"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8010), null, "The bride's chief assistant during the wedding.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Maid of Honor", "" },
                    { new Guid("ece31ae7-c125-4b63-8ce2-7c69fb40ec3c"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8020), null, "A young child who carries the wedding rings during the ceremony.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Ring Bearer", "" },
                    { new Guid("ffae5178-7d4b-45df-84dc-da8f92c80a66"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(8040), null, "Individuals responsible for seating guests at the ceremony.", new Guid("69ab9653-c631-4634-b4b6-a629f8615212"), "Ushers", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "UpdatedBy", "VendorId" },
                values: new object[] { new Guid("9af1d76c-b9ac-4d93-b544-5408db653f62"), new Guid("9c32a87a-6527-4f55-ac3e-e4d78e3bf031"), "", new DateTime(2024, 11, 6, 19, 3, 37, 682, DateTimeKind.Utc).AddTicks(7940), null, "", new Guid("c618cca2-fc8e-4a58-832e-8ddc1287ae29") });

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
