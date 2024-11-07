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
                    { new Guid("67cf0138-3e78-41d9-8aa7-7df876279419"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(400), null, "", "GCash", "" },
                    { new Guid("696769e1-0d06-4f6c-8156-5490b3a7124b"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(410), null, "", "Credit Card", "" },
                    { new Guid("a872efe7-3637-4a24-a0a9-f5e259d758df"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(390), null, "", "Cash", "" },
                    { new Guid("c0ee6a72-4d5f-443a-875c-58466f3d37b2"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(410), null, "", "Checking", "" },
                    { new Guid("de4847da-0087-42d3-8392-ecd7257e9f99"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(400), null, "", "Savings", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("069373d0-1844-4dab-a688-422b189078b0"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(280), null, "A live performance of music by one or more musicians.", "Concert", "" },
                    { new Guid("07651705-cacd-4607-bfe9-af4b1d25f977"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(280), null, "A series of events or activities celebrating a particular theme or occasion.", "Festival", "" },
                    { new Guid("0be51e0c-f8d6-494e-8f63-d46d35a7e7e9"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(260), null, "A celebration commemorating a significant milestone in a couple's relationship.", "Anniversary Celebration", "" },
                    { new Guid("0f30a7fe-1097-48a5-87e9-33f3278bb2fa"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(260), null, "A celebration of the anniversary of a person's birth.", "Birthday Party", "" },
                    { new Guid("5747076a-cf91-47df-989f-d850f125ed23"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(250), null, "An event organized by a company or business for its employees or clients.", "Corporate Event", "" },
                    { new Guid("7abdbe46-0098-4b90-bb4b-5bd5e69fe606"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(270), null, "A celebration to honor the completion of an academic program.", "Graduation Party", "" },
                    { new Guid("93b0fe2d-b1bb-488e-a681-e48ae7173c89"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(280), null, "An event organized to raise funds or awareness for a charitable cause.", "Charity Event", "" },
                    { new Guid("aa259699-66c7-4566-a8e8-15f29554d478"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(270), null, "A celebration held to honor the expectant mother and her baby.", "Baby Shower", "" },
                    { new Guid("ae14ca14-0365-4d5b-a55d-d518e1fad713"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(50), null, "A ceremony where two people are united in marriage.", "Wedding", "" },
                    { new Guid("fe3968ce-f4f2-46f1-a567-25847b78a0e2"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(290), null, "An exhibition where businesses showcase their products and services.", "Trade Show", "" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("00862258-65b9-4671-aa56-c789b7ba13f6"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8370), null, "Wedding cakes, desserts, and other sweets for the reception.", "Cake & Confectionery", "" },
                    { new Guid("07e708e0-3583-43cc-b5ce-1f3cba828401"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8350), null, "Professional photography services for capturing wedding moments.", "Photography", "" },
                    { new Guid("0b6e20a7-5ef8-44b7-8956-d2a78441d0b2"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8360), null, "Entertainment services, including live bands, DJs, and performers.", "Music & Entertainment", "" },
                    { new Guid("0dde6433-965b-409c-99e7-2243c57e2ab8"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8370), null, "Coordination and planning services to manage the entire wedding event.", "Wedding Planning", "" },
                    { new Guid("54df8687-b3bf-4021-bdbf-353837701168"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8380), null, "Design and printing services for wedding invitations, save-the-dates, and other stationery.", "Stationery & Invitations", "" },
                    { new Guid("5d8aa879-4b02-4982-a185-fb4dfbdb5335"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8360), null, "Decorative items and setup services, including centerpieces, lighting, and table settings.", "Decor", "" },
                    { new Guid("6f935cad-4216-4617-815c-914293eb0915"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8390), null, "Rental of items like furniture, tableware, tents, and dance floors.", "Rentals", "" },
                    { new Guid("74da8e0c-1a8f-4cd7-85e4-695a3cad94d0"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8380), null, "Beauty services for the bridal party, including hairstyling and makeup.", "Hair & Makeup", "" },
                    { new Guid("9dc9f4f9-6490-4d5d-82f3-351f7b249c7e"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8370), null, "Transportation services for the wedding party and guests, such as limousines and shuttles.", "Transportation", "" },
                    { new Guid("9e080ba9-d6f3-4b90-b5ea-2f731c4a5546"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8360), null, "Floral arrangements, bouquets, and other decorative flower services.", "Floristry", "" },
                    { new Guid("a7a87b48-3e92-44d0-a0b4-77b899e4c29f"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8330), null, "Food and beverage services, including full-course meals, buffets, and bar services.", "Catering", "" },
                    { new Guid("c31ce01b-5aa0-4a13-9da8-dd0d3445278f"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8350), null, "Locations for wedding ceremonies, receptions, and other related events.", "Venue", "" },
                    { new Guid("c744eb84-ff97-419d-ad2a-b517c075dcaa"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8400), null, "Gifts and party favors for guests.", "Favors & Gifts", "" },
                    { new Guid("d2dc51bf-0096-40dd-b825-bd28fab842f1"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8350), null, "Video recording services to capture and document the wedding day.", "Videography", "" },
                    { new Guid("d7bbfa89-219a-4ce8-984b-38f73ff414f7"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8380), null, "Wedding attire rentals or purchases, including dresses, suits, and accessories.", "Attire & Accessories", "" },
                    { new Guid("e16700aa-73b0-4591-86cc-a5e75463d49a"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8390), null, "Professional officiants to conduct the wedding ceremony.", "Officiant Services", "" },
                    { new Guid("e983d1cd-b3c1-4899-b8c9-6de331f1ab68"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8400), null, "Wedding rings, bridal jewelry, and other related accessories.", "Jewelry", "" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("13ec197f-aeca-4d3d-ac88-3992286628e5"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(450), null, "A general payment or debit from a user’s account, often for non-purchase activities, such as bill payments or installment payments.", "Payment", "" },
                    { new Guid("439cf117-b218-4f33-bac2-cd6de7880b4c"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(450), null, "Represents adding funds to an account, usually as a top-up or a prepayment.", "Deposit", "" },
                    { new Guid("d462db61-395c-46ab-b6cd-5455e59803a6"), "", new DateTime(2024, 11, 7, 11, 42, 35, 460, DateTimeKind.Utc).AddTicks(460), null, "Represents money returned to the user for a previous purchase, usually due to a return or an issue with the product/service.", "Refund", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0f7dd14c-94e7-4036-b544-7b73641bab2e"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8510), null, "Captures memories through professional photography during the wedding.", "Photographer", "" },
                    { new Guid("12a3c347-008d-488d-9875-c4d336e0ae7b"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8530), null, "Provides vehicles for transporting the wedding party and guests.", "Transportation", "" },
                    { new Guid("17475c86-b987-4ba9-a6c7-487424720d77"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8460), null, "Captures memories through professional photography during the wedding.", "Photographer & Videographer", "" },
                    { new Guid("1ced64f7-1b16-4522-bf5a-0fe4972b2b06"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8520), null, "Creates wedding cakes, cupcakes, and desserts for the celebration.", "Baker", "" },
                    { new Guid("2112bbd8-731c-4571-8d4e-2b15d3c0b64d"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8500), null, "Location where the wedding ceremony and/or reception is held.", "Venue", "" },
                    { new Guid("29758e12-89c6-4a7d-b8f5-b9f92b4160b9"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8470), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup Artist", "" },
                    { new Guid("2af9c85a-926d-48c4-bb18-e576996e8c66"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8520), null, "Coordinates all aspects of the wedding planning process from start to finish.", "Wedding Planner", "" },
                    { new Guid("31585b5e-1038-4ffd-a74c-85bd2e44af2f"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8490), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "" },
                    { new Guid("4476b022-a68c-4a71-b28b-a15c3d468f66"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8450), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "" },
                    { new Guid("46dd3189-e7c0-475a-b505-3a0738f5f940"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8460), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "" },
                    { new Guid("46e67c5c-442e-4d95-b7e4-ae0aee864cb9"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8540), null, "Provides professional makeup services for the bride and bridal party.", "Makeup Artist", "" },
                    { new Guid("5f37be38-426d-4ad6-b232-9bb3a445b1dd"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8550), null, "Provides a fun photo booth setup with props for guests to enjoy.", "Photo Booth", "" },
                    { new Guid("6e330c35-a815-409e-8165-cfc97c5d2aa1"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8490), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "" },
                    { new Guid("6fb75e39-3cbf-4ed3-8b5c-cc9421518aea"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8560), null, "Manages sound systems and audio equipment for the ceremony and reception.", "Sound Engineer", "" },
                    { new Guid("77539244-771a-4f8a-ad04-c017e1b7ee60"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8550), null, "Designs and prints wedding invitations, save-the-dates, and programs.", "Stationery", "" },
                    { new Guid("7c1a8a08-7aff-49f1-9ecf-d8e904ec3def"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8480), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "" },
                    { new Guid("7d60b841-e093-47be-b5d6-dbcc75e4083d"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8510), null, "Records the wedding ceremony and reception with high-quality video.", "Videographer", "" },
                    { new Guid("88d4f898-5448-49bb-bfe5-6d55b9d72c55"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8450), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "" },
                    { new Guid("a4a75fd3-8e4c-4fb4-b695-023afe22524b"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8510), null, "Provides music entertainment and emceeing for the wedding and reception.", "DJ", "" },
                    { new Guid("a986cc7e-3926-4f5f-b7b9-e5e3ce6e3965"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8460), null, "Provides food and beverage services for the wedding.", "Caterer", "" },
                    { new Guid("ac208798-76de-4091-a559-e2b4583fc820"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8480), null, "Sells wedding rings and related jewelry.", "Jeweler", "" },
                    { new Guid("aeb2e7cf-12f4-47c1-95e8-1b9afe54d3dc"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8530), null, "Styles hair for the bride, bridesmaids, and other family members.", "Hair Stylist", "" },
                    { new Guid("b193f0cb-1d05-41c9-aad4-17c27079ff9f"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8490), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "" },
                    { new Guid("bf999a0a-1afd-494c-a119-0712837bb1fd"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8530), null, "Conducts the wedding ceremony and ensures it is legally binding.", "Officiant", "" },
                    { new Guid("cb27773b-ec40-4986-8a39-7c35744538ee"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8500), null, "Hosts and coordinates the wedding program.", "Emcee", "" },
                    { new Guid("cb5840d7-0f64-4d67-b73d-16ffda21e35b"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8560), null, "Creates customized lighting plans to enhance the wedding ambiance.", "Lighting Designer", "" },
                    { new Guid("e5bd3892-5eb6-4294-ba5e-1156ed5d9be4"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8540), null, "Offers items for rent such as tables, chairs, linens, and decor.", "Rentals", "" },
                    { new Guid("e83ff3a4-ffc3-4dac-9c34-d31a161de626"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8550), null, "Ensures the safety and security of the wedding event and guests.", "Security", "" },
                    { new Guid("f595994f-672e-4e10-8ad4-553177f0297e"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8470), null, "A musical group that performs live at the wedding reception.", "Live Band", "" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountTypeId", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("9eeaf26b-7bb4-428e-b3c8-49b38c20ec0a"), "54f0f096-2892-48bd-b7df-fe1dc74995e4", new Guid("a872efe7-3637-4a24-a0a9-f5e259d758df"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8730), null, "Vendor Account", "" },
                    { new Guid("db04c174-bbe0-4af6-a672-87d73ff53c81"), "9c690120-840a-4e6a-828a-934b466aee40", new Guid("a872efe7-3637-4a24-a0a9-f5e259d758df"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9240), null, "Event Account", "" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EndDate", "EventTypeId", "Location", "Seats", "StartDate", "Title", "UpdatedBy" },
                values: new object[] { new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8880), null, "Wedding", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ae14ca14-0365-4d5b-a55d-d518e1fad713"), "Ph", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wedding", "" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Address", "ContactInformation", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy", "VendorTypeId" },
                values: new object[,]
                {
                    { new Guid("25867a12-2734-472d-9c7f-ddfa2193ea09"), "N/A", "", "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8660), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "", new Guid("7c1a8a08-7aff-49f1-9ecf-d8e904ec3def") },
                    { new Guid("2e753c51-3af4-4d2a-85f4-1815cef1a6c3"), "N/A", "", "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8680), null, "Hosts and coordinates the wedding program.", "Emcee", "", new Guid("cb27773b-ec40-4986-8a39-7c35744538ee") },
                    { new Guid("4b39ad4a-d5f0-4480-86b4-1609ca645068"), "N/A", "", "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8630), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "", new Guid("4476b022-a68c-4a71-b28b-a15c3d468f66") },
                    { new Guid("52ec4091-9678-41b0-a586-499531718bb8"), "N/A", "", "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8630), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "", new Guid("46dd3189-e7c0-475a-b505-3a0738f5f940") },
                    { new Guid("6685c600-8b2e-46f9-aabb-72c3ec121b85"), "N/A", "", "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8680), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "", new Guid("b193f0cb-1d05-41c9-aad4-17c27079ff9f") },
                    { new Guid("8189b52c-3692-4aff-9d71-5fbc163e8238"), "N/A", "", "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8650), null, "A musical group that performs live at the wedding reception.", "Strings", "", new Guid("f595994f-672e-4e10-8ad4-553177f0297e") },
                    { new Guid("83e7d021-e17d-4d5c-ae6f-261fc54fef4a"), "N/A", "", "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8660), null, "Sells wedding rings and related jewelry.", "Jeweler", "", new Guid("ac208798-76de-4091-a559-e2b4583fc820") },
                    { new Guid("94a1b1f6-95bd-4a53-8f99-6657c93c3bb7"), "N/A", "", "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8650), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup", "", new Guid("29758e12-89c6-4a7d-b8f5-b9f92b4160b9") },
                    { new Guid("b99f9e38-c951-4f61-b747-43635704ad7c"), "N/A", "", "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8670), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "", new Guid("6e330c35-a815-409e-8165-cfc97c5d2aa1") },
                    { new Guid("ba831837-8568-49f7-b27a-2fc7df7ca647"), "N/A", "", "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8670), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "", new Guid("31585b5e-1038-4ffd-a74c-85bd2e44af2f") },
                    { new Guid("d5c5500e-a4a4-4d5d-8017-c1b232e7e522"), "N/A", "", "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8640), null, "Captures memories through professional photography during the wedding.", "Photo & Video", "", new Guid("17475c86-b987-4ba9-a6c7-487424720d77") },
                    { new Guid("e6f96dc6-b200-4e5c-a44a-b85bd07b7059"), "N/A", "", "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8620), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "", new Guid("88d4f898-5448-49bb-bfe5-6d55b9d72c55") },
                    { new Guid("ef139de5-6812-4a9c-8d5d-8abdf4f3d653"), "N/A", "", "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8640), null, "Provides food and beverage services for the wedding.", "Caterer", "", new Guid("a986cc7e-3926-4f5f-b7b9-e5e3ce6e3965") }
                });

            migrationBuilder.InsertData(
                table: "EventAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "EventId", "UpdatedBy" },
                values: new object[] { new Guid("6e946b5a-2871-4695-b15f-753558feb218"), new Guid("db04c174-bbe0-4af6-a672-87d73ff53c81"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9260), null, new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "" });

            migrationBuilder.InsertData(
                table: "EventVendorContractPaymentStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("06464364-9997-45be-abd3-0620d0a12bc0"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9180), null, "A portion of the payment has been made.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Partially Paid", "" },
                    { new Guid("18f6e91e-e023-425e-a374-54b563fc28ec"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9210), null, "Payment is planned for a future date.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Scheduled", "" },
                    { new Guid("30bcb8e3-6506-4613-b9a7-d3cb0f469cdb"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9190), null, "Payment is past the due date and is overdue.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Overdue", "" },
                    { new Guid("32df8cfb-bc62-439d-b0b8-e3b56dbda17f"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9210), null, "Payment is temporarily paused or held.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Hold", "" },
                    { new Guid("572f3452-bb44-49b7-8781-d04c3b37d219"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9200), null, "Payment is under review and pending approval.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "In Review", "" },
                    { new Guid("85dd7bfb-58d3-4c33-8264-bb23fbd94aa9"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9200), null, "Payment has been returned to the payer.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Refunded", "" },
                    { new Guid("b5be3405-a3c5-4b5f-b184-c6aad01e6a10"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9200), null, "The payment was canceled.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Canceled", "" },
                    { new Guid("d5ccf453-e4ef-459e-bf3e-4b59a410736a"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9190), null, "The full payment has been received.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Completed", "" },
                    { new Guid("f2d3124e-c2d3-4927-b85d-13f3879bf628"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9180), null, "Payment is scheduled but not yet made.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Pending", "" },
                    { new Guid("fdd36c39-ae5f-4b64-ae74-96223d57bce5"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9190), null, "Payment attempt was unsuccessful.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Failed", "" }
                });

            migrationBuilder.InsertData(
                table: "EventVendorContractStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("07f085d6-caa7-4d9d-bf0a-dabd19009e49"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9090), null, "Vendor provides a detailed proposal including costs, services, and timelines.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Proposal", "" },
                    { new Guid("14fcec6b-1040-4ae3-8746-8e95e5753567"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9140), null, "Discussion of adjustments if needed during execution.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Review and Adjustments", "" },
                    { new Guid("29c71799-03c3-4b38-a501-8054beed977d"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9110), null, "Vendor reviews the contract and proposes changes or confirms terms.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Contract Review", "" },
                    { new Guid("30025398-b771-48e9-8929-d047a2fe4eee"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9140), null, "Final payment is made upon the completion of services.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Completion and Final Payment", "" },
                    { new Guid("40740243-b92c-41c7-af7f-63eedf5714a0"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9120), null, "An initial deposit is paid to secure the vendor’s services.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Deposit Paid", "" },
                    { new Guid("44506b4c-2ac5-4af9-8590-59288065f59b"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9120), null, "Vendor begins preparations for the event based on the agreed services.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Preparation and Planning", "" },
                    { new Guid("530ba3e4-30c9-49f7-8cb4-3e898ba3e27c"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9090), null, "Initial contact to check vendor availability and gather preliminary information.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Inquiry", "" },
                    { new Guid("73f36843-399a-4efa-9316-0306f2f12dab"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9110), null, "Both parties sign the contract, making it legally binding.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Signed", "" },
                    { new Guid("78d2d474-371b-4dd4-9496-7683240c4977"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9130), null, "Vendor delivers their services during the event as outlined in the contract.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Execution", "" },
                    { new Guid("ba1f6436-fd6b-4082-92c1-b3f2f2d75d99"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9100), null, "Discussion and adjustments of terms, pricing, and deliverables.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Negotiation", "" },
                    { new Guid("ca3077c1-4214-4423-bd85-eb00274d450a"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9100), null, "Internal review and approval of the final terms.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Approval", "" },
                    { new Guid("e27dc3b2-73c8-4f3a-aeb5-071d25f4470d"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9150), null, "Contract is officially closed after all deliverables are met and payments are completed.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Contract Closeout", "" },
                    { new Guid("fafaa3d4-868d-4999-ad3b-f141172386bf"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9140), null, "Event manager provides feedback on the vendor’s performance.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Feedback and Review", "" },
                    { new Guid("fbac17b9-ee55-4232-a5c4-051c3433b521"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9100), null, "Formal contract is drafted and sent to the vendor for review and signing.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Contract Sent", "" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0cbb5055-e496-4d2e-9f7c-314664cec69d"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9020), null, "A person invited to attend the wedding.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Guest", "" },
                    { new Guid("0e554623-f674-4369-8d9a-5772c672576c"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9050), null, "A key family member who may have a significant role.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Parent of the Bride", "" },
                    { new Guid("15f926f7-079d-430f-8575-ae139b55763c"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8990), null, "The groom's chief assistant during the wedding.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Best Man", "" },
                    { new Guid("292447d1-ad18-4be3-b1b8-0a5b35efd688"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9040), null, "Friends or family who stand with the bride during the ceremony.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Bridesmaids", "" },
                    { new Guid("359a4723-7b5a-4e03-9306-b96af03878ed"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8990), null, "The male participant in the wedding.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Groom", "" },
                    { new Guid("534d9868-a607-4cd4-bfa8-a5a835d7c612"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8980), null, "The female participant in the wedding.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Bride", "" },
                    { new Guid("6434a0b6-bddb-47e3-9d56-1d62d83ccc97"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9030), null, "A role representing the cord used in the ceremony.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Cord", "" },
                    { new Guid("7f613d74-481b-4ab0-90d8-f0ea6ffbddd0"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9010), null, "An additional financial supporter of the wedding.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Secondary Sponsor", "" },
                    { new Guid("a4b2fcdc-56b4-43b9-9f72-5b6bdbb5053e"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9000), null, "The bride's chief assistant during the wedding.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Maid of Honor", "" },
                    { new Guid("b4250995-802c-45e1-a00d-8762bfea192b"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9000), null, "The main financial supporter of the wedding.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Primary Sponsor", "" },
                    { new Guid("c8491153-cb93-4539-a4d7-70da270db8a2"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9030), null, "A role representing the candle holders during the ceremony.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Candles", "" },
                    { new Guid("deac1bd2-9c5d-4aff-9c8f-3bae30d98e74"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9010), null, "A young girl who scatters flower petals along the aisle.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Flower Girl", "" },
                    { new Guid("f11e5a9e-46e2-49e8-a1ec-ef48671149be"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9020), null, "A young child who carries the wedding rings during the ceremony.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Ring Bearer", "" },
                    { new Guid("f428fc80-7550-4d33-b083-95db84a68bdc"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9020), null, "A person who carries the Bible during the ceremony.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Bible Bearer", "" },
                    { new Guid("fac7f0fb-62d4-43e5-b49a-6a4ab0b1456d"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9040), null, "Friends or family who stand with the groom during the ceremony.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Groomsmen", "" },
                    { new Guid("fd5e0598-11ae-467e-b24c-10cd5c2b132b"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9050), null, "A key family member representing the groom's side.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Parent of the Groom", "" },
                    { new Guid("fd914703-407f-4047-805f-3b191ddc39f5"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(9030), null, "Individuals responsible for seating guests at the ceremony.", new Guid("659eea8c-e1c1-493b-9fd2-4075bc5efded"), "Ushers", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "UpdatedBy", "VendorId" },
                values: new object[] { new Guid("b19b0a6e-00d0-4ea8-a8d8-7ff6635f3b96"), new Guid("9eeaf26b-7bb4-428e-b3c8-49b38c20ec0a"), "", new DateTime(2024, 11, 7, 11, 42, 35, 461, DateTimeKind.Utc).AddTicks(8770), null, "", new Guid("e6f96dc6-b200-4e5c-a44a-b85bd07b7059") });

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
                name: "IX_EventVendorContractPayments_EventVendorContractId",
                table: "EventVendorContractPayments",
                column: "EventVendorContractId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorContractPayments_EventVendorContractPaymentStateId",
                table: "EventVendorContractPayments",
                column: "EventVendorContractPaymentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorContractPayments_TransactionId",
                table: "EventVendorContractPayments",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendorContractPaymentStates_EventId",
                table: "EventVendorContractPaymentStates",
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
                name: "EventTypes");
        }
    }
}
