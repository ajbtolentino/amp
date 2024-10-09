using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMP.EMS.API.Migrations
{
    /// <inheritdoc />
    public partial class AddNewForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RSVPs_InvitationId",
                table: "RSVPs",
                column: "InvitationId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_EventId",
                table: "Invitations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_GuestId",
                table: "Invitations",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Events_EventId",
                table: "Invitations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Guests_GuestId",
                table: "Invitations",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPs_Invitations_InvitationId",
                table: "RSVPs",
                column: "InvitationId",
                principalTable: "Invitations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Events_EventId",
                table: "Invitations");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Guests_GuestId",
                table: "Invitations");

            migrationBuilder.DropForeignKey(
                name: "FK_RSVPs_Invitations_InvitationId",
                table: "RSVPs");

            migrationBuilder.DropIndex(
                name: "IX_RSVPs_InvitationId",
                table: "RSVPs");

            migrationBuilder.DropIndex(
                name: "IX_Invitations_EventId",
                table: "Invitations");

            migrationBuilder.DropIndex(
                name: "IX_Invitations_GuestId",
                table: "Invitations");
        }
    }
}
