using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMP.EMS.API.Migrations.SqlServer
{
    /// <inheritdoc />
    public partial class RemovedGuestInvitationRsvps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZoneSeats_Zones_ZoneId",
                table: "ZoneSeats");

            migrationBuilder.DropTable(
                name: "GuestInvitationsRsvpItems");

            migrationBuilder.DropTable(
                name: "GuestInvitationRsvps");

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "GuestInvitations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ZoneSeats_Zones_ZoneId",
                table: "ZoneSeats",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZoneSeats_Zones_ZoneId",
                table: "ZoneSeats");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "GuestInvitations");

            migrationBuilder.CreateTable(
                name: "GuestInvitationRsvps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuestInvitationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Response = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestInvitationRsvps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestInvitationRsvps_GuestInvitations_GuestInvitationId",
                        column: x => x.GuestInvitationId,
                        principalTable: "GuestInvitations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuestInvitationsRsvpItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuestInvitationRsvpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestInvitationsRsvpItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestInvitationsRsvpItems_GuestInvitationRsvps_GuestInvitationRsvpId",
                        column: x => x.GuestInvitationRsvpId,
                        principalTable: "GuestInvitationRsvps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestInvitationRsvps_GuestInvitationId",
                table: "GuestInvitationRsvps",
                column: "GuestInvitationId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestInvitationsRsvpItems_GuestInvitationRsvpId",
                table: "GuestInvitationsRsvpItems",
                column: "GuestInvitationRsvpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ZoneSeats_Zones_ZoneId",
                table: "ZoneSeats",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
