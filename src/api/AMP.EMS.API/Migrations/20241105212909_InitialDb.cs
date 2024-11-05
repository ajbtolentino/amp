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
                name: "ContractPaymentStates",
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
                    table.PrimaryKey("PK_ContractPaymentStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractStates",
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
                    table.PrimaryKey("PK_ContractStates", x => x.Id);
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
                table: "AccountsTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("7ee3a5d1-206e-4143-ab6d-cee70f13e4e5"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4880), null, "", "Savings", "" },
                    { new Guid("a24c01ec-169c-4182-b9e6-b702b7c1f94b"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4880), null, "", "Credit Card", "" },
                    { new Guid("af4e2d10-e663-469c-82f3-898bd09934a7"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4880), null, "", "Checking", "" },
                    { new Guid("bd4e2a73-45cd-4f44-b1a3-eff9ad7307b9"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4870), null, "", "Cash", "" },
                    { new Guid("ebd2931e-06e4-44b4-931e-4eff0c9b685c"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4870), null, "", "GCash", "" }
                });

            migrationBuilder.InsertData(
                table: "ContractPaymentStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("00ea0773-e6da-4577-a715-526c97277dd7"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4570), null, "All payments have been made, contract is paid in full.", "Paid in Full", "" },
                    { new Guid("011c62c9-d6a5-4e68-bdac-717359767fff"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4560), null, "Partial payment received, remaining balance due.", "Partial Payment", "" },
                    { new Guid("6166488b-6b8a-4bd1-af23-1e2ba7538795"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4580), null, "Refund has been processed and completed.", "Refunded", "" },
                    { new Guid("bf4449ca-a25d-4209-b9bf-874630e930ac"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4560), null, "Waiting for the initial deposit to be paid.", "Deposit Pending", "" },
                    { new Guid("ea279acd-3b5d-4193-95f7-a44ac5205157"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4570), null, "Payment is overdue.", "Overdue Payment", "" },
                    { new Guid("efd55666-9caa-475a-b9f7-9732c692c0d6"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4570), null, "Refund is pending processing.", "Refund Pending", "" }
                });

            migrationBuilder.InsertData(
                table: "ContractStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("04541eb5-285b-4a90-992d-4ff62fc2f7c9"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4510), null, "Negotiations are ongoing with the vendor.", "Negotiation", "" },
                    { new Guid("12cc7c65-38ef-496d-836c-6498fa220d10"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4520), null, "Tentatively booked, awaiting confirmation.", "Tentative", "" },
                    { new Guid("3dc3e657-3700-4174-be81-ddd781a074f9"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4500), null, "Initial inquiry stage.", "Inquiry", "" },
                    { new Guid("505c3244-21d2-486a-ae91-180ba6c27230"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4520), null, "Contract has been booked and confirmed.", "Booked", "" },
                    { new Guid("66443c91-20fa-4247-9e44-12d06b82c8b3"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4530), null, "Contract has been completed and closed.", "Closed", "" },
                    { new Guid("84e40bef-5e31-4217-8a4a-dbc0705fa05e"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4520), null, "Reserved but not yet confirmed.", "Reserved", "" },
                    { new Guid("9b55a5f3-1e90-4b4c-a82e-21449bdd7cb2"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4510), null, "Quote has been received from the vendor.", "Quote Received", "" },
                    { new Guid("b86ea67c-a270-4a18-bdf3-ebca49cbf6a1"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4500), null, "Waiting for a quote from the vendor.", "Pending Quote", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4500), null, "A ceremony where two people are united in marriage.", "Wedding", "" },
                    { new Guid("39e5a4ee-af8f-45b1-ba2d-96fe07e5b7ca"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4580), null, "An event organized by a company or business for its employees or clients.", "Corporate Event", "" },
                    { new Guid("4392d287-da52-42b8-a03b-24afd33ee236"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4600), null, "A live performance of music by one or more musicians.", "Concert", "" },
                    { new Guid("480ae673-3e79-4826-9863-376fdbb6c5f4"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4600), null, "A series of events or activities celebrating a particular theme or occasion.", "Festival", "" },
                    { new Guid("9aa602d5-654a-4e54-be30-900cdb962135"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4600), null, "An event organized to raise funds or awareness for a charitable cause.", "Charity Event", "" },
                    { new Guid("d689e4b3-4b15-42c5-864e-3c46aa17db4b"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4610), null, "An exhibition where businesses showcase their products and services.", "Trade Show", "" },
                    { new Guid("db91abd5-cfd8-483a-a36f-92789aa0df08"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4590), null, "A celebration held to honor the expectant mother and her baby.", "Baby Shower", "" },
                    { new Guid("de014baf-7922-41eb-8970-d87cf2869130"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4580), null, "A celebration of the anniversary of a person's birth.", "Birthday Party", "" },
                    { new Guid("ecc5140e-a19f-4d54-83f6-432590bdadaa"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4590), null, "A celebration to honor the completion of an academic program.", "Graduation Party", "" },
                    { new Guid("fed5c2e4-ffec-4b68-a194-68810ae7186a"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4580), null, "A celebration commemorating a significant milestone in a couple's relationship.", "Anniversary Celebration", "" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("00479b55-5583-44e7-8881-e60c3f14be50"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4370), null, "Floral arrangements, bouquets, and other decorative flower services.", "Floristry", "" },
                    { new Guid("0e273a68-1b22-4340-8167-d3f5814c9422"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4370), null, "Decorative items and setup services, including centerpieces, lighting, and table settings.", "Decor", "" },
                    { new Guid("1e5d7f00-27c7-4f9e-8b3e-80f3435ec3f3"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4380), null, "Entertainment services, including live bands, DJs, and performers.", "Music & Entertainment", "" },
                    { new Guid("2a6a2406-6b71-439f-bb52-ab887f807228"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4390), null, "Transportation services for the wedding party and guests, such as limousines and shuttles.", "Transportation", "" },
                    { new Guid("2b761532-be96-44e2-967e-9d72e7b07c36"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4390), null, "Wedding cakes, desserts, and other sweets for the reception.", "Cake & Confectionery", "" },
                    { new Guid("34468869-32d0-4d8b-81e7-b73c1386d4a7"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4400), null, "Professional officiants to conduct the wedding ceremony.", "Officiant Services", "" },
                    { new Guid("531a46c7-db36-4eaf-99ea-2193748a8a57"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4410), null, "Rental of items like furniture, tableware, tents, and dance floors.", "Rentals", "" },
                    { new Guid("5695b21a-eabd-4729-97dd-ef6ef780ac71"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4360), null, "Professional photography services for capturing wedding moments.", "Photography", "" },
                    { new Guid("93f4f64b-4822-40a7-af1e-90a79fb7860f"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4420), null, "Gifts and party favors for guests.", "Favors & Gifts", "" },
                    { new Guid("a020a32f-8819-49a6-b293-d533a0b55b7e"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4360), null, "Locations for wedding ceremonies, receptions, and other related events.", "Venue", "" },
                    { new Guid("a37556a3-a358-4987-a5ef-3bbf3c3f7fcb"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4390), null, "Wedding attire rentals or purchases, including dresses, suits, and accessories.", "Attire & Accessories", "" },
                    { new Guid("ae932676-96f0-4763-8ec8-e4b5ccc75825"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4370), null, "Video recording services to capture and document the wedding day.", "Videography", "" },
                    { new Guid("b6bea698-b360-44fb-b239-2031fff2e39e"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4400), null, "Design and printing services for wedding invitations, save-the-dates, and other stationery.", "Stationery & Invitations", "" },
                    { new Guid("bde2817a-9b46-4916-b723-642010c1e607"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4410), null, "Wedding rings, bridal jewelry, and other related accessories.", "Jewelry", "" },
                    { new Guid("e2b9b9e6-2ee3-4b12-b0ae-d7ebd6cfb8cf"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4320), null, "Food and beverage services, including full-course meals, buffets, and bar services.", "Catering", "" },
                    { new Guid("e2f54237-526b-4427-bbb7-5d369ef0493d"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4400), null, "Beauty services for the bridal party, including hairstyling and makeup.", "Hair & Makeup", "" },
                    { new Guid("ea017363-768a-4d63-bb1c-1cf8a8849557"), "", new DateTime(2024, 11, 5, 21, 29, 8, 987, DateTimeKind.Utc).AddTicks(4380), null, "Coordination and planning services to manage the entire wedding event.", "Wedding Planning", "" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("61c781ab-ac50-4f8a-b863-6f7aef6aa8ec"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4920), null, "Represents money returned to the user for a previous purchase, usually due to a return or an issue with the product/service.", "Refund", "" },
                    { new Guid("670ac479-4655-4b07-8283-9549cc0b17ad"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4910), null, "A general payment or debit from a user’s account, often for non-purchase activities, such as bill payments or installment payments.", "Payment", "" },
                    { new Guid("ee883adf-959b-4d2d-a064-35336974a749"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4910), null, "Represents adding funds to an account, usually as a top-up or a prepayment.", "Deposit", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("033ee5e0-b649-420e-aaa1-dcc4c0b5be26"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(5020), null, "Creates customized lighting plans to enhance the wedding ambiance.", "Lighting Designer", "" },
                    { new Guid("1e7e5dab-b324-4146-b941-8133797da812"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4980), null, "Creates wedding cakes, cupcakes, and desserts for the celebration.", "Baker", "" },
                    { new Guid("1e986823-312c-4ccb-9b06-e511a242271c"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4960), null, "Captures memories through professional photography during the wedding.", "Photographer", "" },
                    { new Guid("1ea4d4f0-1e11-46f0-8125-44d6a408c5d6"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4940), null, "Captures memories through professional photography during the wedding.", "Photographer & Videographer", "" },
                    { new Guid("1f34446c-c021-4b60-b249-2ddc495f15a1"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(5000), null, "Provides professional makeup services for the bride and bridal party.", "Makeup Artist", "" },
                    { new Guid("365b6f43-6429-495e-8b69-a26356d10453"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4950), null, "A musical group that performs live at the wedding reception.", "Live Band", "" },
                    { new Guid("591b0bef-3b2e-4972-bba3-1459c17cdc6b"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4990), null, "Styles hair for the bride, bridesmaids, and other family members.", "Hair Stylist", "" },
                    { new Guid("5e610d14-b1eb-460f-b1e8-faa72ae26975"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(5000), null, "Offers items for rent such as tables, chairs, linens, and decor.", "Rentals", "" },
                    { new Guid("72802a4e-22cc-48a0-a432-6221122b7277"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4940), null, "Location where the wedding ceremony and/or reception is held.", "Venue", "" },
                    { new Guid("735c2a0d-a42f-42fa-8a16-a52fc53af5ed"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4970), null, "Provides music entertainment and emceeing for the wedding and reception.", "DJ", "" },
                    { new Guid("773f5ff4-f4d0-4d1b-8453-a3c7f8732775"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4990), null, "Conducts the wedding ceremony and ensures it is legally binding.", "Officiant", "" },
                    { new Guid("a213b2e8-73c9-495d-b44e-06e3b1d3a450"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(5000), null, "Designs and prints wedding invitations, save-the-dates, and programs.", "Stationery", "" },
                    { new Guid("a2f8d3d7-eb7e-4abf-b817-d155aba88853"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4940), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "" },
                    { new Guid("b63f8579-a044-43ec-9c73-72532b4552b9"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(5010), null, "Ensures the safety and security of the wedding event and guests.", "Security", "" },
                    { new Guid("b6bf912d-fe3c-44b6-a5fd-f164807abd3d"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4990), null, "Provides vehicles for transporting the wedding party and guests.", "Transportation", "" },
                    { new Guid("b7854150-6952-404b-9fde-5c8d3717060c"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4980), null, "Coordinates all aspects of the wedding planning process from start to finish.", "Wedding Planner", "" },
                    { new Guid("bc9f4eb0-f25a-43dc-b06c-af806b1a3512"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4930), null, "Provides food and beverage services for the wedding.", "Caterer", "" },
                    { new Guid("ca007dd1-1098-4efb-af92-f80254eac6d2"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4970), null, "Records the wedding ceremony and reception with high-quality video.", "Videographer", "" },
                    { new Guid("ed663f2f-744c-4603-adc0-5c022e0b01b2"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4970), null, "A musical group that performs live at the wedding reception.", "Live Band", "" },
                    { new Guid("ef4cf873-68b7-4d45-8476-edc5fcd30ddb"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(5020), null, "Manages sound systems and audio equipment for the ceremony and reception.", "Sound Engineer", "" },
                    { new Guid("f10ca6f1-d6b3-457f-908c-e5f8e5334beb"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(5010), null, "Provides a fun photo booth setup with props for guests to enjoy.", "Photo Booth", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypeRoles",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventTypeId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("20987270-80ac-4bd1-9d12-da8cd90f87f8"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4800), null, "A person invited to attend the wedding.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Guest", "" },
                    { new Guid("364ab53d-4bae-4e68-8b1f-297c8d248867"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4780), null, "The groom's chief assistant during the wedding.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Best Man", "" },
                    { new Guid("4b477684-e95c-4783-b11c-57cecdc56e09"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4820), null, "Individuals responsible for seating guests at the ceremony.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Ushers", "" },
                    { new Guid("5d0eee78-d748-4af4-8309-c53b43a89d9c"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4820), null, "Friends or family who stand with the groom during the ceremony.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Groomsmen", "" },
                    { new Guid("5d14c0b9-54e8-4602-a00a-dd5865f45432"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4810), null, "A role representing the candle holders during the ceremony.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Candles", "" },
                    { new Guid("5f0766de-abcf-4459-9ae4-5b19227179d1"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4800), null, "A young child who carries the wedding rings during the ceremony.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Ring Bearer", "" },
                    { new Guid("61819fcf-0e6e-4f44-81d0-2d2ff608e243"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4830), null, "A key family member who may have a significant role.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Parent of the Bride", "" },
                    { new Guid("622fdd34-71ff-4d7c-a267-7bd796a8d56c"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4770), null, "The female participant in the wedding.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Bride", "" },
                    { new Guid("62dfe5fe-ee4a-4d9b-a28e-59a108299da4"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4790), null, "An additional financial supporter of the wedding.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Secondary Sponsor", "" },
                    { new Guid("71e18aea-e76f-49c7-aa2e-aaa64dd72909"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4810), null, "A person who carries the Bible during the ceremony.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Bible Bearer", "" },
                    { new Guid("89783de1-76d1-4bb1-9c9c-1ede068b9786"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4810), null, "A role representing the cord used in the ceremony.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Cord", "" },
                    { new Guid("8c653471-6e66-4278-aeb4-ea747734d0bd"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4800), null, "A young girl who scatters flower petals along the aisle.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Flower Girl", "" },
                    { new Guid("956832c4-7580-45f1-a1b3-e2f014b5db4b"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4780), null, "The bride's chief assistant during the wedding.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Maid of Honor", "" },
                    { new Guid("afef0455-5453-4095-8d4b-509a5c2be4b8"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4830), null, "A key family member representing the groom's side.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Parent of the Groom", "" },
                    { new Guid("c9f3a0c9-65dc-46b3-954b-487835068cc2"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4820), null, "Friends or family who stand with the bride during the ceremony.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Bridesmaids", "" },
                    { new Guid("ce0d7ca1-1b5d-4609-ac40-b0ddc87a7d5f"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4780), null, "The male participant in the wedding.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Groom", "" },
                    { new Guid("e1755e64-b827-4af9-85ce-137ba4032086"), "", new DateTime(2024, 11, 5, 21, 29, 8, 985, DateTimeKind.Utc).AddTicks(4790), null, "The main financial supporter of the wedding.", new Guid("27f46b64-84ec-4ca5-95a1-7a87e7e61c11"), "Primary Sponsor", "" }
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
                name: "ContractPaymentStates");

            migrationBuilder.DropTable(
                name: "ContractStates");

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
