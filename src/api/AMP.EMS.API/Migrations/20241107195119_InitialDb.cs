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
                    { new Guid("02c2d02a-76e8-43da-ba18-9d57ecf1e430"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9830), null, "", "GCash", "" },
                    { new Guid("6575126a-c505-44c6-8f29-d8022eda3fbe"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9840), null, "", "Checking", "" },
                    { new Guid("da5ae9cc-8681-4856-b317-aab6c9990ef0"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9840), null, "", "Credit Card", "" },
                    { new Guid("e7548a0e-5604-4b0b-bead-d1f575f1d251"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9830), null, "", "Cash", "" },
                    { new Guid("eb7696d9-9c95-4d48-b4ef-fa7beda42d5f"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9840), null, "", "Savings", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("18a5a33f-71b3-419a-8cfc-db072515bc9a"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9750), null, "A series of events or activities celebrating a particular theme or occasion.", "Festival", "" },
                    { new Guid("3f7aa500-ff92-4bc3-8335-570da9a3832d"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9720), null, "A celebration of the anniversary of a person's birth.", "Birthday Party", "" },
                    { new Guid("80449857-4280-4d0d-b6f0-fb7e4b552a8a"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9730), null, "A celebration commemorating a significant milestone in a couple's relationship.", "Anniversary Celebration", "" },
                    { new Guid("c8747cfd-f45d-4940-9482-b82ad6432db6"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9750), null, "An exhibition where businesses showcase their products and services.", "Trade Show", "" },
                    { new Guid("d3adfb2f-fa2f-45f2-9cfd-dbdc50a66bde"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9660), null, "A ceremony where two people are united in marriage.", "Wedding", "" },
                    { new Guid("df717ede-1079-4881-94fa-c477857fc159"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9740), null, "An event organized to raise funds or awareness for a charitable cause.", "Charity Event", "" },
                    { new Guid("ef7623e0-63ec-4546-8cef-78855edbeedc"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9720), null, "An event organized by a company or business for its employees or clients.", "Corporate Event", "" },
                    { new Guid("f0377a23-04ce-43f0-856c-92e844e93f49"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9740), null, "A celebration held to honor the expectant mother and her baby.", "Baby Shower", "" },
                    { new Guid("fc2ac4aa-09c5-4aef-88a1-504fca4b4ca2"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9730), null, "A celebration to honor the completion of an academic program.", "Graduation Party", "" },
                    { new Guid("ff5aa940-106d-4d1e-9e13-f5df25640402"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9740), null, "A live performance of music by one or more musicians.", "Concert", "" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1bfd0478-8af8-499c-9fe0-e0d9b126cd0f"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7270), null, "Beauty services for the bridal party, including hairstyling and makeup.", "Hair & Makeup", "" },
                    { new Guid("1dd30444-1068-4aa4-8e83-83ff44fcc0a4"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7280), null, "Rental of items like furniture, tableware, tents, and dance floors.", "Rentals", "" },
                    { new Guid("2467b2e3-e51a-4366-af9a-607359a8fc81"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7220), null, "Food and beverage services, including full-course meals, buffets, and bar services.", "Catering", "" },
                    { new Guid("335e2dc2-876a-40cd-aaf8-96251fd628e7"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7240), null, "Video recording services to capture and document the wedding day.", "Videography", "" },
                    { new Guid("3e01cd5e-8ad4-4a37-98c5-be0bc7cb36b1"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7240), null, "Professional photography services for capturing wedding moments.", "Photography", "" },
                    { new Guid("3e39d3b9-dfc6-4f77-9096-3c1d0e7f1e70"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7280), null, "Professional officiants to conduct the wedding ceremony.", "Officiant Services", "" },
                    { new Guid("5e9c962f-a290-44fc-b0b9-d12aa30d2faa"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7250), null, "Decorative items and setup services, including centerpieces, lighting, and table settings.", "Decor", "" },
                    { new Guid("6501f614-8849-4c64-a14d-caa1e16b73ab"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7260), null, "Coordination and planning services to manage the entire wedding event.", "Wedding Planning", "" },
                    { new Guid("80509428-cf14-45a4-a0ba-ac14d3d467f0"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7230), null, "Locations for wedding ceremonies, receptions, and other related events.", "Venue", "" },
                    { new Guid("81a4ec09-a494-4a26-80a3-6d4c722e9f1d"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7290), null, "Gifts and party favors for guests.", "Favors & Gifts", "" },
                    { new Guid("a00bd6c8-6b36-4bb5-b34a-c83724e512ce"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7260), null, "Wedding cakes, desserts, and other sweets for the reception.", "Cake & Confectionery", "" },
                    { new Guid("a8c9006d-e891-4146-8cb4-b0731b32bd58"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7280), null, "Design and printing services for wedding invitations, save-the-dates, and other stationery.", "Stationery & Invitations", "" },
                    { new Guid("af0f9759-3dd0-45b9-9ce9-cfa53812d1fe"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7290), null, "Wedding rings, bridal jewelry, and other related accessories.", "Jewelry", "" },
                    { new Guid("af921f18-5f5e-45ae-bdc5-b0af0d3ae285"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7260), null, "Transportation services for the wedding party and guests, such as limousines and shuttles.", "Transportation", "" },
                    { new Guid("be2d0043-5d99-4ade-9823-a8170d4a1ced"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7250), null, "Entertainment services, including live bands, DJs, and performers.", "Music & Entertainment", "" },
                    { new Guid("d321d65a-46de-4a94-bfaf-85e8043ff175"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7270), null, "Wedding attire rentals or purchases, including dresses, suits, and accessories.", "Attire & Accessories", "" },
                    { new Guid("fe63c49e-ff54-47e7-95c5-6414b3b676e3"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7250), null, "Floral arrangements, bouquets, and other decorative flower services.", "Floristry", "" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("96151338-8ec5-4804-b9af-6a0604fda0a6"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9890), null, "A general payment or debit from a user’s account, often for non-purchase activities, such as bill payments or installment payments.", "Payment", "" },
                    { new Guid("c1000e1d-80b5-440f-899d-eaf164538706"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9890), null, "Represents money returned to the user for a previous purchase, usually due to a return or an issue with the product/service.", "Refund", "" },
                    { new Guid("f7d7e125-36d0-498b-b5c1-6882064663c6"), "", new DateTime(2024, 11, 7, 19, 51, 19, 320, DateTimeKind.Utc).AddTicks(9890), null, "Represents adding funds to an account, usually as a top-up or a prepayment.", "Deposit", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0a096e94-f958-4453-9c23-1147af6bf5ba"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7430), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "" },
                    { new Guid("0d9ee999-759f-4a1e-8eed-fcd051a8ef35"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7470), null, "Conducts the wedding ceremony and ensures it is legally binding.", "Officiant", "" },
                    { new Guid("101d8fa6-d055-4b8a-ba7d-d563e7b80373"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7420), null, "Sells wedding rings and related jewelry.", "Jeweler", "" },
                    { new Guid("221ea1a3-968e-4d64-874d-719fbd9fa134"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7420), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "" },
                    { new Guid("2f64b110-3b55-468f-b282-6c00aff5e258"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7400), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup Artist", "" },
                    { new Guid("30712589-5d16-47c9-a2ba-315b2c67539b"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7460), null, "Coordinates all aspects of the wedding planning process from start to finish.", "Wedding Planner", "" },
                    { new Guid("36014349-753a-45b4-b8d2-0990e0d6b148"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7430), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "" },
                    { new Guid("3e42a7fd-97ad-409c-9d5d-e6a99094c7ca"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7460), null, "Provides vehicles for transporting the wedding party and guests.", "Transportation", "" },
                    { new Guid("625c59c6-c4dd-41bc-a64a-449885a8e37c"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7490), null, "Creates customized lighting plans to enhance the wedding ambiance.", "Lighting Designer", "" },
                    { new Guid("648828a4-ad6d-48f1-9509-1ce9ec3403da"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7480), null, "Offers items for rent such as tables, chairs, linens, and decor.", "Rentals", "" },
                    { new Guid("6da54672-49c7-4afb-b35b-4b8d8e7dbcfb"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7470), null, "Styles hair for the bride, bridesmaids, and other family members.", "Hair Stylist", "" },
                    { new Guid("717bd8a1-1a83-4b61-b9c9-53f9c75a155a"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7380), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "" },
                    { new Guid("77a87c8b-7c52-40c0-841f-24315e1bf454"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7480), null, "Designs and prints wedding invitations, save-the-dates, and programs.", "Stationery", "" },
                    { new Guid("7b05d1e4-6911-4df6-8043-1f6afa8d9ade"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7380), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "" },
                    { new Guid("86d96ce3-b4b9-484c-ad44-ae384077f7ff"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7340), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "" },
                    { new Guid("8972100a-77b2-4ae3-bdec-ece2ca416612"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7500), null, "Manages sound systems and audio equipment for the ceremony and reception.", "Sound Engineer", "" },
                    { new Guid("98e75f59-7449-43cc-9c67-cd8973132957"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7430), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "" },
                    { new Guid("a040ebc8-9e85-4efd-b54f-49fb02c867ac"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7440), null, "Hosts and coordinates the wedding program.", "Emcee", "" },
                    { new Guid("a17bbc92-3f39-43d2-91bb-217e1d989926"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7490), null, "Ensures the safety and security of the wedding event and guests.", "Security", "" },
                    { new Guid("af31b3fd-960e-46a2-8fa6-28f8ff3df84c"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7470), null, "Provides professional makeup services for the bride and bridal party.", "Makeup Artist", "" },
                    { new Guid("b3b0c166-7be2-445b-9ac9-9c58cbd54673"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7380), null, "Provides food and beverage services for the wedding.", "Caterer", "" },
                    { new Guid("cd4d6744-7d04-4b7a-89ba-5dda863f36f0"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7390), null, "Captures memories through professional photography during the wedding.", "Photographer & Videographer", "" },
                    { new Guid("d77c2ef6-fa06-44ea-95f3-b928e780621d"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7390), null, "A musical group that performs live at the wedding reception.", "Live Band", "" },
                    { new Guid("dd4b5583-c5dc-43b4-a229-7425db816aea"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7460), null, "Creates wedding cakes, cupcakes, and desserts for the celebration.", "Baker", "" },
                    { new Guid("e16211f8-137b-416b-af75-d80bebefc5cb"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7450), null, "Records the wedding ceremony and reception with high-quality video.", "Videographer", "" },
                    { new Guid("e9939fec-7320-4052-8e6c-005a68913cc4"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7450), null, "Provides music entertainment and emceeing for the wedding and reception.", "DJ", "" },
                    { new Guid("ea0a6d4d-2844-4160-a61f-0ed58e66e470"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7440), null, "Captures memories through professional photography during the wedding.", "Photographer", "" },
                    { new Guid("f2163e24-fe68-4a23-91c5-2670acd18ef1"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7440), null, "Location where the wedding ceremony and/or reception is held.", "Venue", "" },
                    { new Guid("fb523ca5-917d-4143-a213-27810006dc2e"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7490), null, "Provides a fun photo booth setup with props for guests to enjoy.", "Photo Booth", "" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountTypeId", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("96612049-fc71-46c6-9d36-1759016f4449"), "88cd5471-040f-4830-bb53-20e8817c0e0e", new Guid("e7548a0e-5604-4b0b-bead-d1f575f1d251"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7660), null, "Vendor Account", "" },
                    { new Guid("c4aa123b-b790-4a98-948c-494b820be054"), "faef333b-b4c5-432c-af30-c4c6c28a63a7", new Guid("e7548a0e-5604-4b0b-bead-d1f575f1d251"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(8100), null, "Event Account", "" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EndDate", "EventTypeId", "Location", "Seats", "StartDate", "Title", "UpdatedBy" },
                values: new object[] { new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7730), null, "Wedding", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d3adfb2f-fa2f-45f2-9cfd-dbdc50a66bde"), "Ph", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wedding", "" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Address", "ContactInformation", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy", "VendorTypeId" },
                values: new object[,]
                {
                    { new Guid("02a7f71b-6844-4fe0-a3ab-dee8ab0e6f57"), "N/A", "", "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7620), null, "Hosts and coordinates the wedding program.", "Emcee", "", new Guid("a040ebc8-9e85-4efd-b54f-49fb02c867ac") },
                    { new Guid("08d80482-46f1-41f9-88e2-853ea99b23e5"), "N/A", "", "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7580), null, "A musical group that performs live at the wedding reception.", "Strings", "", new Guid("d77c2ef6-fa06-44ea-95f3-b928e780621d") },
                    { new Guid("11e75d78-a75a-4c41-96f5-2689ae11832d"), "N/A", "", "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7620), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "", new Guid("98e75f59-7449-43cc-9c67-cd8973132957") },
                    { new Guid("1a09dab2-527e-4724-9142-541a46a83c6b"), "N/A", "", "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7580), null, "Captures memories through professional photography during the wedding.", "Photo & Video", "", new Guid("cd4d6744-7d04-4b7a-89ba-5dda863f36f0") },
                    { new Guid("1e202fc4-058d-4c2a-9922-47a5894e04f0"), "N/A", "", "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7610), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "", new Guid("36014349-753a-45b4-b8d2-0990e0d6b148") },
                    { new Guid("25a05686-8c3e-44c6-bcae-d5a4ff1f1144"), "N/A", "", "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7560), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "", new Guid("86d96ce3-b4b9-484c-ad44-ae384077f7ff") },
                    { new Guid("32c86d47-6379-41ce-b5a9-71c470ec1467"), "N/A", "", "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7570), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "", new Guid("717bd8a1-1a83-4b61-b9c9-53f9c75a155a") },
                    { new Guid("57cbc5a6-f079-4a6c-aa24-6f26f8349183"), "N/A", "", "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7570), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "", new Guid("7b05d1e4-6911-4df6-8043-1f6afa8d9ade") },
                    { new Guid("7306042a-c7e0-4591-96b9-bc779933231e"), "N/A", "", "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7600), null, "Sells wedding rings and related jewelry.", "Jeweler", "", new Guid("101d8fa6-d055-4b8a-ba7d-d563e7b80373") },
                    { new Guid("7a81a78f-1b0a-4a86-bee5-2ed665c1d303"), "N/A", "", "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7570), null, "Provides food and beverage services for the wedding.", "Caterer", "", new Guid("b3b0c166-7be2-445b-9ac9-9c58cbd54673") },
                    { new Guid("875c9c8c-a422-462a-8878-2691a648e43b"), "N/A", "", "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7600), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "", new Guid("0a096e94-f958-4453-9c23-1147af6bf5ba") },
                    { new Guid("e37fe827-363a-4190-8f81-bcfcbd758b1a"), "N/A", "", "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7590), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup", "", new Guid("2f64b110-3b55-468f-b282-6c00aff5e258") },
                    { new Guid("e75e4782-6966-4daf-b145-2146be104a8e"), "N/A", "", "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7590), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "", new Guid("221ea1a3-968e-4d64-874d-719fbd9fa134") }
                });

            migrationBuilder.InsertData(
                table: "EventAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "EventId", "UpdatedBy" },
                values: new object[] { new Guid("2f842409-de8e-42be-87fa-ed5b3e6e737a"), new Guid("c4aa123b-b790-4a98-948c-494b820be054"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(8120), null, new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "" });

            migrationBuilder.InsertData(
                table: "EventVendorContractPaymentStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("191a19f6-57dc-4419-be51-2f8168f26ba3"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(8060), null, "Payment has been returned to the payer.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Refunded", "" },
                    { new Guid("200e7846-b70b-4a70-ab11-adf90a9cb58f"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(8050), null, "Payment attempt was unsuccessful.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Failed", "" },
                    { new Guid("25ed580c-47ef-4de9-929e-4d674c146fc8"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(8040), null, "The full payment has been received.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Completed", "" },
                    { new Guid("45f928ee-c39a-4e50-a087-21ce9139e800"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(8040), null, "Payment is scheduled but not yet made.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Pending", "" },
                    { new Guid("4774bf14-ae9d-45e8-b9a4-bf9c6d777a28"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(8050), null, "Payment is past the due date and is overdue.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Overdue", "" },
                    { new Guid("4cb5b62d-b175-4d69-91b4-e5ab4eaa9b4f"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(8040), null, "A portion of the payment has been made.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Partially Paid", "" },
                    { new Guid("56c27634-6de4-49ba-8b56-9c718cb6d514"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(8060), null, "The payment was canceled.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Canceled", "" },
                    { new Guid("6c19dfca-795a-4828-bc92-f43b6a974b65"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(8060), null, "Payment is under review and pending approval.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "In Review", "" },
                    { new Guid("76abee1f-7475-449b-87ef-1e39c941f31f"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(8070), null, "Payment is temporarily paused or held.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Hold", "" },
                    { new Guid("a9c11404-c6c0-4bd1-b5d1-ba3be1a10d5f"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(8070), null, "Payment is planned for a future date.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Scheduled", "" }
                });

            migrationBuilder.InsertData(
                table: "EventVendorContractPaymentTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2db8a1ba-ed8c-447a-aca5-49337d103631"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7990), null, "Additional fee for using a specific payment method.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Service Charge", "" },
                    { new Guid("34c35488-c8dc-4136-917a-a253ffaee0d9"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7990), null, "Portion of payment withheld until contract conditions are satisfactorily fulfilled.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Holdback", "" },
                    { new Guid("4e138d82-16df-48fb-89a3-29514dc997e3"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7950), null, "Payment to secure ongoing services, may or may not apply toward final balance.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Retainer", "" },
                    { new Guid("6ca51fd0-589a-48a2-bf10-5b46bc8b030b"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7950), null, "Initial payment to secure services or confirm a booking.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Deposit", "" },
                    { new Guid("7b06dd7b-3d17-4201-9b03-842b2ebf8a85"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7980), null, "Additional fee imposed if a payment is not made on time.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Late Fee", "" },
                    { new Guid("8dd2b670-5ad8-4636-bb35-19d4a362c5e4"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7980), null, "Fee charged if the contract is canceled after a specified date.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Cancellation Fee", "" },
                    { new Guid("90728c90-5f45-49c6-a3f4-117b87b3df00"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7980), null, "Reduction in payment, often for early payment or promotional purposes.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Discount", "" },
                    { new Guid("9ad432d6-747a-4917-8616-532535e30d5c"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7960), null, "Remaining balance due upon completion of the contract.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Final Payment", "" },
                    { new Guid("ad2709b4-efb0-4eb0-b87a-d0c17162a02c"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(8000), null, "Additional payment for exceeding performance expectations.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Bonus Payment", "" },
                    { new Guid("c19d3638-ed92-4ae5-9e66-d2b766a11924"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7960), null, "Payments made upon reaching specific milestones or stages.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Progress Payment", "" },
                    { new Guid("c1c6d5f0-b7ce-494a-99b0-7d4352ba35d8"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7960), null, "Scheduled partial payment at specific intervals in the contract.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Installment", "" },
                    { new Guid("d317f47c-fdb2-4295-bc79-1810f338d55f"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7990), null, "Amount returned to the client if conditions such as cancellations are met.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Refund", "" },
                    { new Guid("f07fbaf0-885f-4ac1-9607-83a8f408fca9"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(8000), null, "Payment held by a third party until contract terms are fulfilled.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Escrow Payment", "" },
                    { new Guid("f7a16003-db42-4059-b5a8-9a326502a5f9"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7970), null, "Fee charged for contract violations or unmet deadlines.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Penalty Payment", "" },
                    { new Guid("fa9f7de7-7a3b-4474-be34-58fa7644d600"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7970), null, "Payment made in advance for materials, equipment, or initial requirements.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Advance Payment", "" }
                });

            migrationBuilder.InsertData(
                table: "EventVendorContractStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("226f8261-c2df-4fef-9e0c-29710b0f39f2"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7870), null, "Vendor reviews the contract and proposes changes or confirms terms.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Contract Review", "" },
                    { new Guid("2bdb9b0c-85d2-42c0-b9e0-8aa1f2bafa56"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7910), null, "Final payment is made upon the completion of services.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Completion and Final Payment", "" },
                    { new Guid("341fbfe2-c939-4af6-ac83-3bccc0c0c4f0"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7880), null, "An initial deposit is paid to secure the vendor’s services.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Deposit Paid", "" },
                    { new Guid("345e3186-b051-4b98-9141-4e47756c8a0a"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7860), null, "Discussion and adjustments of terms, pricing, and deliverables.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Negotiation", "" },
                    { new Guid("4b783a3d-edd1-43ff-9a4c-7fa018ea3f9f"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7900), null, "Vendor delivers their services during the event as outlined in the contract.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Execution", "" },
                    { new Guid("4fe22a7e-99dc-4083-8cbf-f735ae990c74"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7880), null, "Both parties sign the contract, making it legally binding.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Signed", "" },
                    { new Guid("5073ed7b-6126-47f9-b2f8-083c0b8e21f3"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7910), null, "Discussion of adjustments if needed during execution.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Review and Adjustments", "" },
                    { new Guid("73e5d306-5cdc-4c05-bdc4-f6f8c489c6fd"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7870), null, "Formal contract is drafted and sent to the vendor for review and signing.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Contract Sent", "" },
                    { new Guid("7b6d4346-a2af-4209-8624-474e25802cc3"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7870), null, "Internal review and approval of the final terms.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Approval", "" },
                    { new Guid("aaf543e9-b441-4415-9fbe-56d4043f5b0d"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7850), null, "Initial contact to check vendor availability and gather preliminary information.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Inquiry", "" },
                    { new Guid("b4faa093-ba4d-4804-a4d4-088851b860ba"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7900), null, "Vendor begins preparations for the event based on the agreed services.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Preparation and Planning", "" },
                    { new Guid("ba6fab0e-91d8-4f1a-873c-74427c5e0892"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7860), null, "Vendor provides a detailed proposal including costs, services, and timelines.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Proposal", "" },
                    { new Guid("d466cb2b-430d-44e8-8be9-47d0e189d1d6"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7920), null, "Event manager provides feedback on the vendor’s performance.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Feedback and Review", "" },
                    { new Guid("ec2d1901-fff0-4d49-aef6-5d2118bb294f"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7920), null, "Contract is officially closed after all deliverables are met and payments are completed.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Contract Closeout", "" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0f41c599-7264-452d-ba73-cd2f9d466d80"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7780), null, "An additional financial supporter of the wedding.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Secondary Sponsor", "" },
                    { new Guid("15d6359a-2aec-4817-85c7-1649cf4ef420"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7790), null, "A young child who carries the wedding rings during the ceremony.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Ring Bearer", "" },
                    { new Guid("1a9ad0f6-f49c-470d-a0d8-67bdbbf71c98"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7810), null, "Friends or family who stand with the bride during the ceremony.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Bridesmaids", "" },
                    { new Guid("223df872-e2fd-49b8-8cfe-aa3b2f0cf672"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7800), null, "A role representing the candle holders during the ceremony.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Candles", "" },
                    { new Guid("2b3b07f7-bcba-4233-b2bd-90ff1f5e1759"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7760), null, "The female participant in the wedding.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Bride", "" },
                    { new Guid("3fc5d3a6-a855-4ee0-a533-0e0ad24c5536"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7800), null, "A role representing the cord used in the ceremony.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Cord", "" },
                    { new Guid("4ba89be3-94ef-481c-bc86-a726f795d1f4"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7820), null, "A key family member representing the groom's side.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Parent of the Groom", "" },
                    { new Guid("59dadf54-a345-47ad-910f-71f33e7e27dd"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7770), null, "The groom's chief assistant during the wedding.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Best Man", "" },
                    { new Guid("809c3548-fd92-4966-9697-2a498810442b"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7810), null, "Individuals responsible for seating guests at the ceremony.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Ushers", "" },
                    { new Guid("9effb615-db36-4f4d-b732-2904d8a9cec2"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7810), null, "Friends or family who stand with the groom during the ceremony.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Groomsmen", "" },
                    { new Guid("a9590d6c-054b-46f4-b360-2b80cb64b715"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7820), null, "A key family member who may have a significant role.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Parent of the Bride", "" },
                    { new Guid("be5fca5c-2294-4976-8cc8-a670f5cf8f5a"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7790), null, "A person who carries the Bible during the ceremony.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Bible Bearer", "" },
                    { new Guid("d16b1aba-1a6a-40fb-88db-12b97afdd722"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7760), null, "The male participant in the wedding.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Groom", "" },
                    { new Guid("dbe01ebd-3462-4df1-a989-2c75a402732e"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7770), null, "The bride's chief assistant during the wedding.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Maid of Honor", "" },
                    { new Guid("de50926e-f919-4d13-bb5b-d629a5a806f5"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7780), null, "A young girl who scatters flower petals along the aisle.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Flower Girl", "" },
                    { new Guid("deec1693-5790-4740-b917-32cef75c1b7d"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7790), null, "A person invited to attend the wedding.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Guest", "" },
                    { new Guid("fef68e4b-3591-434e-b66a-e5b76e0ce9de"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7770), null, "The main financial supporter of the wedding.", new Guid("617ffe67-4cf4-4869-8908-24469d2e74fe"), "Primary Sponsor", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "UpdatedBy", "VendorId" },
                values: new object[] { new Guid("8507a092-ec74-4e2a-a3c9-d85999c81884"), new Guid("96612049-fc71-46c6-9d36-1759016f4449"), "", new DateTime(2024, 11, 7, 19, 51, 19, 322, DateTimeKind.Utc).AddTicks(7690), null, "", new Guid("25a05686-8c3e-44c6-bcae-d5a4ff1f1144") });

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
                name: "EventTypes");
        }
    }
}
