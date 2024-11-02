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
                name: "EventVendorStatus",
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
                    table.PrimaryKey("PK_EventVendorStatus", x => x.Id);
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
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_DebitAccountId",
                        column: x => x.DebitAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "EventBudgets",
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
                    table.PrimaryKey("PK_EventBudgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventBudgets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventBudgets_VendorTypes_VendorTypeId",
                        column: x => x.VendorTypeId,
                        principalTable: "VendorTypes",
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
                name: "EventVendors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VendorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventVendorStatusId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventVendors_EventVendorStatus_EventVendorStatusId",
                        column: x => x.EventVendorStatusId,
                        principalTable: "EventVendorStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventVendors_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventVendors_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
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
                    { new Guid("39c7f89e-d573-43f0-b60c-80f29234b6e6"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1910), null, "", "Cash", "" },
                    { new Guid("5d7f9c89-7886-43c5-a609-f83022c6e793"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1910), null, "", "Savings", "" },
                    { new Guid("b38e5113-0634-428a-9e03-28f6ff65477e"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1910), null, "", "GCash", "" },
                    { new Guid("e5df034b-4f1d-4092-8cee-8c286d2b17f4"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1920), null, "", "Checking", "" },
                    { new Guid("fa3d4349-a34e-4d22-a21d-a470a57e2760"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1920), null, "", "Credit Card", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("51ec424c-18bf-4467-b2d9-deaf4303281f"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1680), null, "A live performance of music by one or more musicians.", "Concert", "" },
                    { new Guid("55f6f124-917d-4d1f-aca5-51a0bf0d8640"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1660), null, "A celebration to honor the completion of an academic program.", "Graduation Party", "" },
                    { new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1570), null, "A ceremony where two people are united in marriage.", "Wedding", "" },
                    { new Guid("601cc735-2f79-4454-a8ac-f670a77969e3"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1640), null, "A celebration of the anniversary of a person's birth.", "Birthday Party", "" },
                    { new Guid("6c8333dc-a284-4e3f-8cbe-9319e9250918"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1640), null, "A celebration commemorating a significant milestone in a couple's relationship.", "Anniversary Celebration", "" },
                    { new Guid("805f3b18-c524-4aea-b7bc-0ab9884dad15"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1670), null, "An event organized to raise funds or awareness for a charitable cause.", "Charity Event", "" },
                    { new Guid("a22558d4-58eb-4d55-a815-873f88a29d17"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1630), null, "An event organized by a company or business for its employees or clients.", "Corporate Event", "" },
                    { new Guid("b4918248-220f-4217-8359-ce5f79791b08"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1670), null, "A celebration held to honor the expectant mother and her baby.", "Baby Shower", "" },
                    { new Guid("de00b82c-d344-486b-9910-452f73ae697a"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1680), null, "A series of events or activities celebrating a particular theme or occasion.", "Festival", "" },
                    { new Guid("f42b983e-56c5-4f65-a6b0-0e226d366ccd"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1690), null, "An exhibition where businesses showcase their products and services.", "Trade Show", "" }
                });

            migrationBuilder.InsertData(
                table: "EventVendorStatus",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("004c66cc-f3f6-4b86-a4f3-25a95c1615c2"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2000), null, "The vendor is actively working on preparations for the event.", "In Progress", "" },
                    { new Guid("509aa82a-7d9d-42d1-bdb0-ebe14d8f0e87"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1980), null, "The vendor has been identified but the booking has not yet been finalized.", "Pending", "" },
                    { new Guid("542e5117-292c-44ab-b1b9-26cf3d801f8d"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1990), null, "The vendor was booked but has been removed from the event.", "Cancelled", "" },
                    { new Guid("75439e31-f371-49d7-836b-2bae648dea34"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2000), null, "The vendor has fulfilled their obligations, and the event has occurred.", "Completed", "" },
                    { new Guid("b01800c6-6f28-4c78-9dbb-a47c986768d3"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2010), null, "The vendor is of interest for potential future events.", "Wishlist", "" },
                    { new Guid("cc5b3c0e-af60-4a32-b007-a8aa7910c525"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1990), null, "The vendor is on hold for the event while waiting for confirmation.", "Reserved", "" },
                    { new Guid("d88dfe5e-bb85-4169-b02a-543f46693bed"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1980), null, "The vendor has been officially booked for the event.", "Confirmed", "" },
                    { new Guid("def1c0b8-3c8a-4045-bd85-bf277eaadeb1"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1990), null, "The vendor has formally declined the offer to provide services.", "Declined", "" },
                    { new Guid("e4ffc16e-89b9-4cab-a156-72e847626f02"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2020), null, "The vendor's status is temporarily suspended due to ongoing discussions.", "On Hold", "" },
                    { new Guid("f0914dc5-2cd1-4cff-aebb-d775ce6c7e45"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2010), null, "The vendor's performance is under review, and feedback is required.", "Feedback Needed", "" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("668a0f1e-1b0a-45c3-904b-09a397ecd949"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1950), null, "A general payment or debit from a user’s account, often for non-purchase activities, such as bill payments or installment payments.", "Payment", "" },
                    { new Guid("90963680-0dfb-4f6f-aaa1-abb3241a2f2f"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1950), null, "Represents adding funds to an account, usually as a top-up or a prepayment.", "Deposit", "" },
                    { new Guid("d73bcb66-4def-459d-9e44-fa85c78b0cf1"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1960), null, "Represents money returned to the user for a previous purchase, usually due to a return or an issue with the product/service.", "Refund", "" }
                });

            migrationBuilder.InsertData(
                table: "VendorTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("12ec116a-6e6d-4613-9560-2e4171fffc5c"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2100), null, "Offers items for rent such as tables, chairs, linens, and decor.", "Rentals", "" },
                    { new Guid("16eb2c9f-28a0-48c2-9006-946fffcc6c7a"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2070), null, "Coordinates all aspects of the wedding planning process from start to finish.", "Wedding Planner", "" },
                    { new Guid("1f61d0c4-aa07-409e-b87e-031a78909edf"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2100), null, "Provides professional makeup services for the bride and bridal party.", "Makeup Artist", "" },
                    { new Guid("232f1fba-ea73-4fba-9c76-dceec31bde74"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2060), null, "Records the wedding ceremony and reception with high-quality video.", "Videographer", "" },
                    { new Guid("24380723-2d08-45b5-84d7-653bff7a093e"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2050), null, "Captures memories through professional photography during the wedding.", "Photographer", "" },
                    { new Guid("2748dca1-edb8-4660-a8ba-11f15614bf8d"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2110), null, "Provides a fun photo booth setup with props for guests to enjoy.", "Photo Booth", "" },
                    { new Guid("29b0fae2-6b4f-4021-9028-4264d4673ed9"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2090), null, "Provides vehicles for transporting the wedding party and guests.", "Transportation", "" },
                    { new Guid("315406a2-d0ec-42d5-9668-a985868aef4a"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2110), null, "Designs and prints wedding invitations, save-the-dates, and programs.", "Stationery", "" },
                    { new Guid("3861e1df-790e-47ff-9b12-cadc6773bbef"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2050), null, "Supplies floral arrangements, bouquets, and centerpieces.", "Florist", "" },
                    { new Guid("3b0ef132-5648-4abb-bd56-803cf915d3ef"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2120), null, "Creates customized lighting plans to enhance the wedding ambiance.", "Lighting Designer", "" },
                    { new Guid("42a63e48-52cf-4ad2-98a0-5a847d6924f1"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2050), null, "Provides food and beverage services for the wedding.", "Caterer", "" },
                    { new Guid("5361af9b-4339-46a6-9d9d-66b2afd1a99f"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2120), null, "Ensures the safety and security of the wedding event and guests.", "Security", "" },
                    { new Guid("789ee902-687a-41f9-b6ae-f3b3cbf62bda"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2100), null, "Styles hair for the bride, bridesmaids, and other family members.", "Hair Stylist", "" },
                    { new Guid("9fb30448-7dc1-4295-9fa3-ebf5e6b2eff5"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2090), null, "Conducts the wedding ceremony and ensures it is legally binding.", "Officiant", "" },
                    { new Guid("bbb6face-d1dd-4e56-abfc-bad6d61ed491"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2120), null, "Manages sound systems and audio equipment for the ceremony and reception.", "Sound Engineer", "" },
                    { new Guid("c99d91b3-a118-44d3-8238-09714d0fc4cd"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2080), null, "Creates wedding cakes, cupcakes, and desserts for the celebration.", "Baker", "" },
                    { new Guid("e2eeea58-40e4-47a9-a8d3-8ef062cc95aa"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2070), null, "Provides music entertainment and emceeing for the wedding and reception.", "DJ", "" },
                    { new Guid("efff4bf7-b20b-42dc-90e4-41e6190927a6"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2080), null, "Location where the wedding ceremony and/or reception is held.", "Venue", "" },
                    { new Guid("f6813150-0b44-4678-a758-4803f967b793"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(2070), null, "A musical group that performs live at the wedding reception.", "Live Band", "" }
                });

            migrationBuilder.InsertData(
                table: "EventTypeRoles",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Description", "EventTypeId", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("123023dc-0444-4867-8a2b-cfc43d5aeb7b"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1860), null, "A key family member who may have a significant role.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Parent of the Bride", "" },
                    { new Guid("17de235b-7516-4dd6-94e1-fcff215147c7"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1800), null, "The female participant in the wedding.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Bride", "" },
                    { new Guid("22a2d957-6fa6-4be8-9658-0d1d67fd3282"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1810), null, "The male participant in the wedding.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Groom", "" },
                    { new Guid("2cebd2eb-1a24-4b6d-9ca3-88c4c59f0c2b"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1860), null, "Friends or family who stand with the bride during the ceremony.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Bridesmaids", "" },
                    { new Guid("35d0ab2e-b32a-47c5-8658-404773e460c0"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1850), null, "Individuals responsible for seating guests at the ceremony.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Ushers", "" },
                    { new Guid("35ddad54-b2b7-430b-b1a5-b0a07711f837"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1810), null, "The bride's chief assistant during the wedding.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Maid of Honor", "" },
                    { new Guid("496bd411-ec28-44e2-a17b-b610b6855126"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1830), null, "A person invited to attend the wedding.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Guest", "" },
                    { new Guid("4d8a788d-7592-45ce-babc-ccd8cf3d8529"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1870), null, "A key family member representing the groom's side.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Parent of the Groom", "" },
                    { new Guid("5e6eb995-38cb-41ff-8aaa-1dbc0d2e6a27"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1840), null, "A role representing the cord used in the ceremony.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Cord", "" },
                    { new Guid("8cf1629b-6f26-4e88-9009-5eb45665a052"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1830), null, "A young child who carries the wedding rings during the ceremony.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Ring Bearer", "" },
                    { new Guid("8dda2d8c-dca1-4c1c-8370-8bd22b4b4442"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1820), null, "An additional financial supporter of the wedding.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Secondary Sponsor", "" },
                    { new Guid("adc63af1-e617-4821-ae3a-96cadb1c7890"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1810), null, "The groom's chief assistant during the wedding.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Best Man", "" },
                    { new Guid("cb4c47d6-27e2-41f6-ac2c-c30e5ca76c6d"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1830), null, "A young girl who scatters flower petals along the aisle.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Flower Girl", "" },
                    { new Guid("cda0cf93-b223-48bb-bbf0-0f9134518960"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1820), null, "The main financial supporter of the wedding.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Primary Sponsor", "" },
                    { new Guid("e9ef94c7-0338-46ca-876b-0ffa02014233"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1850), null, "A role representing the candle holders during the ceremony.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Candles", "" },
                    { new Guid("f4362dd1-04c0-4808-8c5c-f1364b809d92"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1860), null, "Friends or family who stand with the groom during the ceremony.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Groomsmen", "" },
                    { new Guid("fee9aa40-c186-4922-8e9d-8ef175559302"), "", new DateTime(2024, 11, 2, 19, 55, 28, 962, DateTimeKind.Utc).AddTicks(1840), null, "A person who carries the Bible during the ceremony.", new Guid("5a2996d5-aff6-48aa-9cee-4012d93452ec"), "Bible Bearer", "" }
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
                name: "IX_EventBudgets_EventId",
                table: "EventBudgets",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventBudgets_VendorTypeId",
                table: "EventBudgets",
                column: "VendorTypeId");

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
                name: "IX_EventVendors_EventId",
                table: "EventVendors",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendors_EventVendorStatusId",
                table: "EventVendors",
                column: "EventVendorStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVendors_VendorId",
                table: "EventVendors",
                column: "VendorId");

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
                name: "EventBudgets");

            migrationBuilder.DropTable(
                name: "EventGuestInvitationsRsvpItems");

            migrationBuilder.DropTable(
                name: "EventGuestRoles");

            migrationBuilder.DropTable(
                name: "EventTypeRoles");

            migrationBuilder.DropTable(
                name: "EventVendors");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "VendorAccounts");

            migrationBuilder.DropTable(
                name: "EventGuestInvitationRsvps");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "EventVendorStatus");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "EventGuestInvitations");

            migrationBuilder.DropTable(
                name: "AccountsTypes");

            migrationBuilder.DropTable(
                name: "VendorTypes");

            migrationBuilder.DropTable(
                name: "EventGuests");

            migrationBuilder.DropTable(
                name: "EventInvitations");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "EventTypes");
        }
    }
}
