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
                    { new Guid("50a42ede-ccdb-411d-9989-f3166ba46b73"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(4100), null, "", "GCash", "" },
                    { new Guid("62b4e545-17dc-4672-bfad-fde684666c30"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(4120), null, "", "Savings", "" },
                    { new Guid("9182808a-7936-406e-9e4e-d792a315303a"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(4120), null, "", "Credit Card", "" },
                    { new Guid("a9ea64db-bd2b-438a-b32c-6cb660a27398"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(4130), null, "", "Checking", "" },
                    { new Guid("b5345c60-faa9-4e2a-974b-1fbd622ac827"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(4100), null, "", "Cash", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("4c07de1e-4e9a-4317-af4d-cf1d9db89269"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(3980), null, "An event organized by a company or business for its employees or clients.", "Corporate Event", "" },
                    { new Guid("64229d93-8694-443d-870a-41cac87c5db7"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(3920), null, "A ceremony where two people are united in marriage.", "Wedding", "" },
                    { new Guid("71b272a9-bd70-419f-9f84-afe31464427b"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(4000), null, "A live performance of music by one or more musicians.", "Concert", "" },
                    { new Guid("83f1b1bc-4b1a-4f8f-b94a-229c164724b1"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(4010), null, "An exhibition where businesses showcase their products and services.", "Trade Show", "" },
                    { new Guid("8bc2b403-4354-458d-8b51-4b95d5bfb6f1"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(4000), null, "A celebration held to honor the expectant mother and her baby.", "Baby Shower", "" },
                    { new Guid("8e0e2ccc-a12e-4780-93f7-25169bf9c280"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(4010), null, "A series of events or activities celebrating a particular theme or occasion.", "Festival", "" },
                    { new Guid("8e221298-cf3f-44a1-9abc-7eab79129315"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(4000), null, "An event organized to raise funds or awareness for a charitable cause.", "Charity Event", "" },
                    { new Guid("9e4a95ee-3f34-4c3a-a059-d0fc338f2765"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(3990), null, "A celebration commemorating a significant milestone in a couple's relationship.", "Anniversary Celebration", "" },
                    { new Guid("c4d2d153-54eb-4fcb-9ab6-b78507ba1666"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(3980), null, "A celebration of the anniversary of a person's birth.", "Birthday Party", "" },
                    { new Guid("d47754ce-6401-4b4a-8c8d-ae28915450e4"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(3990), null, "A celebration to honor the completion of an academic program.", "Graduation Party", "" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("03056b51-2bac-4a04-b864-3449af1aa4e9"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2570), null, "Wedding rings, bridal jewelry, and other related accessories.", "Jewelry", "" },
                    { new Guid("05467e34-feaf-4dba-abee-c3bd0db171b8"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2480), null, "Professional photography services for capturing wedding moments.", "Photography", "" },
                    { new Guid("1ea77ceb-e781-463d-a6f7-c51841757cf4"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2550), null, "Wedding cakes, desserts, and other sweets for the reception.", "Cake & Confectionery", "" },
                    { new Guid("3a07a700-23e2-4166-ae93-f0fe1998372b"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2530), null, "Floral arrangements, bouquets, and other decorative flower services.", "Floristry", "" },
                    { new Guid("4173ee13-7717-40ad-9689-e4848ce62258"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2540), null, "Entertainment services, including live bands, DJs, and performers.", "Music & Entertainment", "" },
                    { new Guid("475b26c6-3fe7-4c56-a02d-9fe159cd249e"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2540), null, "Decorative items and setup services, including centerpieces, lighting, and table settings.", "Decor", "" },
                    { new Guid("689bec72-02b4-418d-b89d-d0f737fa2bc4"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2540), null, "Coordination and planning services to manage the entire wedding event.", "Wedding Planning", "" },
                    { new Guid("a3a44274-06f7-4241-9452-8a0cf21bdf9e"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2580), null, "Gifts and party favors for guests.", "Favors & Gifts", "" },
                    { new Guid("a973714b-78ac-4f64-b5da-97087112bf9f"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2560), null, "Design and printing services for wedding invitations, save-the-dates, and other stationery.", "Stationery & Invitations", "" },
                    { new Guid("adfcc4c0-5af4-4b32-a6e7-d84ed2f7d2f0"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2550), null, "Transportation services for the wedding party and guests, such as limousines and shuttles.", "Transportation", "" },
                    { new Guid("ba0c41b0-bd0f-4014-a960-3c5430cda5b4"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2570), null, "Professional officiants to conduct the wedding ceremony.", "Officiant Services", "" },
                    { new Guid("baf679de-a335-4083-bc4b-2028d7233afa"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2490), null, "Video recording services to capture and document the wedding day.", "Videography", "" },
                    { new Guid("cf8da7c0-8ae7-4f5c-a2d9-fee1ea485089"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2570), null, "Rental of items like furniture, tableware, tents, and dance floors.", "Rentals", "" },
                    { new Guid("d0fd78ad-6d2f-49c1-ad86-f49067e67b95"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2550), null, "Wedding attire rentals or purchases, including dresses, suits, and accessories.", "Attire & Accessories", "" },
                    { new Guid("e3ce3750-0b41-4716-8c89-3421ceb71561"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2560), null, "Beauty services for the bridal party, including hairstyling and makeup.", "Hair & Makeup", "" },
                    { new Guid("fb49ee45-58e7-40a2-a869-0e23f517879e"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2470), null, "Food and beverage services, including full-course meals, buffets, and bar services.", "Catering", "" },
                    { new Guid("ff611ebd-58c9-4c08-91f2-e1f2620f1341"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2480), null, "Locations for wedding ceremonies, receptions, and other related events.", "Venue", "" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0d20690a-b6c1-4cfd-b2e7-c818042e27e9"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(4170), null, "A general payment or debit from a user’s account, often for non-purchase activities, such as bill payments or installment payments.", "Payment", "" },
                    { new Guid("36018348-32dc-4e0b-bab9-f00c79574ae0"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(4180), null, "Represents money returned to the user for a previous purchase, usually due to a return or an issue with the product/service.", "Refund", "" },
                    { new Guid("bcc65aef-3dad-4451-a716-a6e768aa1b1d"), "", new DateTime(2024, 11, 8, 18, 45, 34, 956, DateTimeKind.Utc).AddTicks(4180), null, "Represents adding funds to an account, usually as a top-up or a prepayment.", "Deposit", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("241cfc5a-81c2-4730-96b8-69a33e03b33e"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2700), null, "Conducts the wedding ceremony and ensures it is legally binding.", "Officiant", "" },
                    { new Guid("3d5474ad-d92a-4c64-b41f-9d2758b24a92"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2700), null, "Provides vehicles for transporting the wedding party and guests.", "Transportation", "" },
                    { new Guid("40049ab5-b5b5-459b-bd4d-ee77a33d4ae2"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2630), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "" },
                    { new Guid("565294f9-3a35-40b5-9fb4-3c8a259a84db"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2700), null, "Creates wedding cakes, cupcakes, and desserts for the celebration.", "Baker", "" },
                    { new Guid("5c4b6256-94c2-4d0a-a42a-c6ceec133f1b"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2740), null, "Manages sound systems and audio equipment for the ceremony and reception.", "Sound Engineer", "" },
                    { new Guid("614d45ab-e8bf-4129-9db6-a1b41fc0032b"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2710), null, "Styles hair for the bride, bridesmaids, and other family members.", "Hair Stylist", "" },
                    { new Guid("6cd5efaa-36e4-48b6-b69a-161ed09cf75f"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2720), null, "Offers items for rent such as tables, chairs, linens, and decor.", "Rentals", "" },
                    { new Guid("808cdb2e-bfda-4ae9-9d99-a65b98f8f758"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2630), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "" },
                    { new Guid("8308e436-a3ed-4f9d-a2d2-367e4eb61564"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2730), null, "Ensures the safety and security of the wedding event and guests.", "Security", "" },
                    { new Guid("8756fd31-51ab-425e-a13b-665c6f4008fa"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2630), null, "Provides food and beverage services for the wedding.", "Caterer", "" },
                    { new Guid("93d3f6d7-a359-4bc9-bab6-cc0477558a1e"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2650), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup Artist", "" },
                    { new Guid("96dfecbc-da9e-4451-ad89-cfa93c15298b"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2710), null, "Provides professional makeup services for the bride and bridal party.", "Makeup Artist", "" },
                    { new Guid("9843ca25-bc43-46ac-8415-2da0c67f53d8"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2660), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "" },
                    { new Guid("9d61c438-84b1-4a10-b19c-8d62d653dc34"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2650), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "" },
                    { new Guid("9d7f339e-dd7d-48cf-b19d-d53bcfd31407"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2680), null, "Captures memories through professional photography during the wedding.", "Photographer", "" },
                    { new Guid("adb633c8-5f8e-4c94-92bc-ea989ab3a304"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2690), null, "Coordinates all aspects of the wedding planning process from start to finish.", "Wedding Planner", "" },
                    { new Guid("ae157b4c-b9cd-408a-9619-4feeae4d2c92"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2720), null, "Designs and prints wedding invitations, save-the-dates, and programs.", "Stationery", "" },
                    { new Guid("aebb1be9-e070-481e-a412-ec6284decee6"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2620), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "" },
                    { new Guid("b8a49169-0f0e-47de-9b0e-69de9eabd6c9"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2730), null, "Creates customized lighting plans to enhance the wedding ambiance.", "Lighting Designer", "" },
                    { new Guid("b9d53c3a-beb6-4b3d-b3d8-513b44d61097"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2670), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "" },
                    { new Guid("bd670dd6-a06a-439f-93c7-f16bc1ac331c"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2650), null, "Sells wedding rings and related jewelry.", "Jeweler", "" },
                    { new Guid("c8aae960-1235-492a-95ee-6e09d293c018"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2690), null, "Provides music entertainment and emceeing for the wedding and reception.", "DJ", "" },
                    { new Guid("deff0ef2-d1d0-4af9-8fd1-36d1e2306f7f"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2720), null, "Provides a fun photo booth setup with props for guests to enjoy.", "Photo Booth", "" },
                    { new Guid("e50b9f48-e3ad-4ffe-87fc-2b14cd9c0818"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2640), null, "Captures memories through professional photography during the wedding.", "Photographer & Videographer", "" },
                    { new Guid("e53d45cf-1fb9-4638-8aa1-439005d85f27"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2680), null, "Records the wedding ceremony and reception with high-quality video.", "Videographer", "" },
                    { new Guid("ebcc6289-1897-4e27-8176-5b536286a6db"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2670), null, "Location where the wedding ceremony and/or reception is held.", "Venue", "" },
                    { new Guid("ec6efa36-63ce-4515-ba51-f934b1dfe724"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2660), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "" },
                    { new Guid("f518e614-430a-4fdf-b0e0-72701ce7fbb6"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2670), null, "Hosts and coordinates the wedding program.", "Emcee", "" },
                    { new Guid("fd892fee-18e0-40c3-988b-4d1f216e2161"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2640), null, "A musical group that performs live at the wedding reception.", "Live Band", "" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountTypeId", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("8f0966ce-8e83-4f63-8973-fb9499aef978"), "1686a518-9239-48eb-a9f5-2e6e3cc1ebc7", new Guid("b5345c60-faa9-4e2a-974b-1fbd622ac827"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2900), null, "Vendor Account", "" },
                    { new Guid("ee8b3667-0e5c-44e0-8722-8e4333ae645a"), "7b67d6cb-3f48-4b83-9afc-f37634f4e3f6", new Guid("b5345c60-faa9-4e2a-974b-1fbd622ac827"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3360), null, "Event Account", "" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "ContentId", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EndDate", "EventTypeId", "Location", "Seats", "StartDate", "Title", "UpdatedBy" },
                values: new object[] { new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), null, "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2960), null, "Wedding", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("64229d93-8694-443d-870a-41cac87c5db7"), "Ph", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wedding", "" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Address", "ContactInformation", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy", "VendorTypeId" },
                values: new object[,]
                {
                    { new Guid("0bc20e4b-a22d-4ea6-8fac-a9420c8a8cdb"), "N/A", "", "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2840), null, "Provides professional makeup services for the bride and bridal party.", "Hair & Makeup", "", new Guid("93d3f6d7-a359-4bc9-bab6-cc0477558a1e") },
                    { new Guid("48a51c41-0df8-437b-a6d1-f364c4f3975c"), "N/A", "", "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2820), null, "Provides food and beverage services for the wedding.", "Caterer", "", new Guid("8756fd31-51ab-425e-a13b-665c6f4008fa") },
                    { new Guid("4a6b29b8-e593-46ee-a4ad-e29963c78a44"), "N/A", "", "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2810), null, "Manages lights, sound systems and audio equipment for the ceremony and reception.", "Lights & Sounds", "", new Guid("808cdb2e-bfda-4ae9-9d99-a65b98f8f758") },
                    { new Guid("68c328d5-eba6-4a75-b6b9-68d54d652a3d"), "N/A", "", "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2840), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "", new Guid("9d61c438-84b1-4a10-b19c-8d62d653dc34") },
                    { new Guid("7775ae3c-9745-4ff7-8363-6376e1669765"), "N/A", "", "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2830), null, "A musical group that performs live at the wedding reception.", "Strings", "", new Guid("fd892fee-18e0-40c3-988b-4d1f216e2161") },
                    { new Guid("841f511a-9804-456b-9716-f2641bddf293"), "N/A", "", "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2840), null, "Sells wedding rings and related jewelry.", "Jeweler", "", new Guid("bd670dd6-a06a-439f-93c7-f16bc1ac331c") },
                    { new Guid("a260b4b4-0952-409c-84bd-688d7f3b907a"), "N/A", "", "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2860), null, "Offers keepsakes or favors for wedding guests.", "Souvenirs", "", new Guid("b9d53c3a-beb6-4b3d-b3d8-513b44d61097") },
                    { new Guid("a299160f-4f8f-49a4-8d4e-b983a2d6e3eb"), "N/A", "", "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2810), null, "A venue for hosting post-ceremony receptions or gatherings.", "Reception Venue", "", new Guid("40049ab5-b5b5-459b-bd4d-ee77a33d4ae2") },
                    { new Guid("b86c13b6-6f8b-4bd5-8e61-dba3c8528501"), "N/A", "", "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2800), null, "A venue for hosting wedding ceremonies, typically in a religious setting.", "Church", "", new Guid("aebb1be9-e070-481e-a412-ec6284decee6") },
                    { new Guid("c14f26ec-72ee-4dba-9bca-c5aff1c702a6"), "N/A", "", "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2820), null, "Captures memories through professional photography during the wedding.", "Photo & Video", "", new Guid("e50b9f48-e3ad-4ffe-87fc-2b14cd9c0818") },
                    { new Guid("c67144fc-1471-409b-8b88-3b4da9df2e3b"), "N/A", "", "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2860), null, "Hosts and coordinates the wedding program.", "Emcee", "", new Guid("f518e614-430a-4fdf-b0e0-72701ce7fbb6") },
                    { new Guid("cb1b9cc9-15d5-4317-94c9-2147330d59c1"), "N/A", "", "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2850), null, "Organizes wedding activities and ensures event flows smoothly.", "Wedding Coordinator", "", new Guid("9843ca25-bc43-46ac-8415-2da0c67f53d8") },
                    { new Guid("f89a0899-56f9-4ea0-93fc-2da8056bb9f4"), "N/A", "", "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2850), null, "Provides mobile bar services for cocktail hours and receptions.", "Mobile Bar", "", new Guid("ec6efa36-63ce-4515-ba51-f934b1dfe724") }
                });

            migrationBuilder.InsertData(
                table: "EventAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "EventId", "UpdatedBy" },
                values: new object[] { new Guid("fa008d1c-3c6d-4e82-bcc3-81e041b1f3d4"), new Guid("ee8b3667-0e5c-44e0-8722-8e4333ae645a"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3380), null, new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "" });

            migrationBuilder.InsertData(
                table: "EventVendorContractPaymentStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("017acef6-ccf5-4cb1-9d36-796197648307"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3310), null, "Payment is past the due date and is overdue.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Overdue", "" },
                    { new Guid("059904e1-c5f8-423e-b6d9-cd7a73454f8a"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3320), null, "The payment was canceled.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Canceled", "" },
                    { new Guid("0ee9cd7c-e6b3-40bf-a2f6-01de8e710f51"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3310), null, "Payment attempt was unsuccessful.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Failed", "" },
                    { new Guid("2d9679b8-69b3-40cc-b419-05197f06a105"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3330), null, "Payment is temporarily paused or held.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Hold", "" },
                    { new Guid("333f422d-28c1-4595-808c-f1e5580235cb"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3290), null, "Payment is scheduled but not yet made.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Pending", "" },
                    { new Guid("40b34fe2-482c-491f-a1a6-da749e27a2ac"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3300), null, "A portion of the payment has been made.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Partially Paid", "" },
                    { new Guid("727476d6-2094-4009-9363-3753efbedda4"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3300), null, "The full payment has been received.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Completed", "" },
                    { new Guid("78a4771e-4f6d-44c7-afdb-cafab88f4ccc"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3330), null, "Payment is planned for a future date.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Scheduled", "" },
                    { new Guid("c70ec182-2e71-4a0f-9275-55a16eb8838a"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3320), null, "Payment is under review and pending approval.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "In Review", "" },
                    { new Guid("f2101014-1aac-4144-9634-eb133e7bebe9"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3310), null, "Payment has been returned to the payer.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Refunded", "" }
                });

            migrationBuilder.InsertData(
                table: "EventVendorContractPaymentTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("098347af-7813-4c79-b0b5-6db0f409af0a"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3210), null, "Payments made upon reaching specific milestones or stages.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Progress Payment", "" },
                    { new Guid("23dcddb4-61c4-460a-afe5-5e2ee0225e1e"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3230), null, "Fee charged if the contract is canceled after a specified date.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Cancellation Fee", "" },
                    { new Guid("3b8164a9-c966-442f-903d-3d911c05bd0a"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3260), null, "Additional payment for exceeding performance expectations.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Bonus Payment", "" },
                    { new Guid("59a76eb4-c856-4f79-9800-e4106fb80083"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3250), null, "Payment held by a third party until contract terms are fulfilled.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Escrow Payment", "" },
                    { new Guid("5c688908-f1bc-458b-a8f8-ef7c60e42983"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3210), null, "Scheduled partial payment at specific intervals in the contract.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Installment", "" },
                    { new Guid("5fd70cc9-040d-4702-af4e-56128735737f"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3240), null, "Reduction in payment, often for early payment or promotional purposes.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Discount", "" },
                    { new Guid("64f7d6e6-95ed-4219-9a65-38a3c4c60586"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3220), null, "Remaining balance due upon completion of the contract.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Final Payment", "" },
                    { new Guid("70b3de78-5137-4790-b9eb-8ac6cf16e402"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3230), null, "Additional fee imposed if a payment is not made on time.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Late Fee", "" },
                    { new Guid("74a54324-1776-4ea7-ad9f-b34582529c60"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3210), null, "Payment to secure ongoing services, may or may not apply toward final balance.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Retainer", "" },
                    { new Guid("7a1e495d-bfb5-4425-b817-dda242831686"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3200), null, "Initial payment to secure services or confirm a booking.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Deposit", "" },
                    { new Guid("85b38fb2-ca97-4455-86c6-c0d42d824c2a"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3230), null, "Fee charged for contract violations or unmet deadlines.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Penalty Payment", "" },
                    { new Guid("a3114764-dead-4d80-b9d4-0c013e5500ed"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3250), null, "Portion of payment withheld until contract conditions are satisfactorily fulfilled.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Holdback", "" },
                    { new Guid("ad8f3cd4-36a2-43a7-bc39-fb227f6bbeac"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3240), null, "Amount returned to the client if conditions such as cancellations are met.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Refund", "" },
                    { new Guid("d7f5ff84-ec0f-48d1-b738-0d45a6b8322b"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3220), null, "Payment made in advance for materials, equipment, or initial requirements.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Advance Payment", "" },
                    { new Guid("fece0baa-110e-47c0-bfbd-d396c8a19d4d"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3250), null, "Additional fee for using a specific payment method.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Service Charge", "" }
                });

            migrationBuilder.InsertData(
                table: "EventVendorContractStates",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("38fb2c33-737c-4516-b3a8-0752781a0bd5"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3120), null, "Vendor provides a detailed proposal including costs, services, and timelines.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Proposal", "" },
                    { new Guid("4b6635d4-0d05-441b-8e5c-c9a5ebe75b17"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3130), null, "Vendor reviews the contract and proposes changes or confirms terms.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Contract Review", "" },
                    { new Guid("5d486580-72d1-4d1e-8893-b6f341423b22"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3160), null, "Event manager provides feedback on the vendor’s performance.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Feedback and Review", "" },
                    { new Guid("6053cfd6-71d9-41c7-a48b-78055984880b"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3170), null, "Contract is officially closed after all deliverables are met and payments are completed.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Contract Closeout", "" },
                    { new Guid("81791ddd-d703-4da5-9416-9ffb4c380098"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3120), null, "Discussion and adjustments of terms, pricing, and deliverables.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Negotiation", "" },
                    { new Guid("99a06554-2703-4021-82e4-a1a29084ddc6"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3140), null, "An initial deposit is paid to secure the vendor’s services.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Deposit Paid", "" },
                    { new Guid("9e5f7195-40be-4b69-95db-5ca8802faacf"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3110), null, "Initial contact to check vendor availability and gather preliminary information.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Inquiry", "" },
                    { new Guid("b479d512-a695-47ff-a6e5-6e0d9a339a7e"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3150), null, "Vendor begins preparations for the event based on the agreed services.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Preparation and Planning", "" },
                    { new Guid("b9a6d418-2a7f-4086-851a-cda55fdd3183"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3130), null, "Internal review and approval of the final terms.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Approval", "" },
                    { new Guid("bd0f027f-2e4a-483f-8019-1bdb4d75e797"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3160), null, "Discussion of adjustments if needed during execution.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Review and Adjustments", "" },
                    { new Guid("c091cf30-f677-4cef-8062-3903eafd8dda"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3150), null, "Vendor delivers their services during the event as outlined in the contract.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Execution", "" },
                    { new Guid("c42e6130-21c0-4c70-959f-80674e8fc427"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3160), null, "Final payment is made upon the completion of services.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Completion and Final Payment", "" },
                    { new Guid("cfcf59f8-e959-42a2-90e4-c44d72bda8d1"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3130), null, "Formal contract is drafted and sent to the vendor for review and signing.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Contract Sent", "" },
                    { new Guid("fee1da08-3a28-4b18-9075-7cf62721e605"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3140), null, "Both parties sign the contract, making it legally binding.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Signed", "" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0a8467fa-6426-4854-96e7-a31e01cfafd8"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3000), null, "The bride's chief assistant during the wedding.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Maid of Honor", "" },
                    { new Guid("14f51f71-d68d-428f-8814-b47ef2383846"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3020), null, "A person invited to attend the wedding.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Guest", "" },
                    { new Guid("1637f24e-01da-4bd9-be22-6b9e2348d550"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3060), null, "Friends or family who stand with the bride during the ceremony.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Bridesmaids", "" },
                    { new Guid("18837b52-c288-4fdd-a28d-07a5d251fa90"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3000), null, "The groom's chief assistant during the wedding.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Best Man", "" },
                    { new Guid("2488d725-be65-4d5b-b03a-0e60e7f105fa"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3010), null, "A young girl who scatters flower petals along the aisle.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Flower Girl", "" },
                    { new Guid("2918f2b5-b4db-4219-a037-e476bb798c56"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3040), null, "A person who carries the Bible during the ceremony.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Bible Bearer", "" },
                    { new Guid("315a4887-b22f-4f8d-86a6-372077e5a82f"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2990), null, "The female participant in the wedding.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Bride", "" },
                    { new Guid("763760cd-f415-48c8-aa92-d41ec546d481"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3070), null, "A key family member representing the groom's side.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Parent of the Groom", "" },
                    { new Guid("8724a487-e0bb-49b7-8ddf-155d776b24fa"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3050), null, "A role representing the candle holders during the ceremony.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Candles", "" },
                    { new Guid("9001947a-c753-4f9d-a58a-8ad37ab521ed"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3020), null, "A young child who carries the wedding rings during the ceremony.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Ring Bearer", "" },
                    { new Guid("9471c359-e60c-474f-8aa4-9848d8791358"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2990), null, "The male participant in the wedding.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Groom", "" },
                    { new Guid("9e56fb9f-0c4e-4eb7-b510-22a906941e09"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3010), null, "An additional financial supporter of the wedding.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Secondary Sponsor", "" },
                    { new Guid("b8a223b1-c283-49a2-9490-adee4d8cb6a1"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3010), null, "The main financial supporter of the wedding.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Primary Sponsor", "" },
                    { new Guid("b955214b-3b0b-4f5a-bc91-d6cbb9c85bf1"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3060), null, "Friends or family who stand with the groom during the ceremony.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Groomsmen", "" },
                    { new Guid("bc5310f8-0716-459d-bd9f-537909114983"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3070), null, "A key family member who may have a significant role.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Parent of the Bride", "" },
                    { new Guid("be7eb3c4-b45c-4a09-a27b-b4c9ad6f7457"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3050), null, "Individuals responsible for seating guests at the ceremony.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Ushers", "" },
                    { new Guid("efd34349-94e6-42fa-95ef-82b5b948b09b"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(3050), null, "A role representing the cord used in the ceremony.", new Guid("fe330c91-7ca0-4af2-8887-d789ca094599"), "Cord", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorAccounts",
                columns: new[] { "Id", "AccountId", "CreatedBy", "DateCreated", "DateUpdated", "UpdatedBy", "VendorId" },
                values: new object[] { new Guid("1e4f6432-bc58-4f0d-8eac-d314f9cc404f"), new Guid("8f0966ce-8e83-4f63-8973-fb9499aef978"), "", new DateTime(2024, 11, 8, 18, 45, 34, 958, DateTimeKind.Utc).AddTicks(2930), null, "", new Guid("b86c13b6-6f8b-4bd5-8e61-dba3c8528501") });

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
