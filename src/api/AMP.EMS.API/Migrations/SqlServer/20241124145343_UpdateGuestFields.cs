using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMP.EMS.API.Migrations.SqlServer
{
    /// <inheritdoc />
    public partial class UpdateGuestFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Guests",
                newName: "Suffix");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salutation",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "Salutation",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "Suffix",
                table: "Guests",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
