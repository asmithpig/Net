using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResumeUrl",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "EmailId",
                table: "Customers",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Customers",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customers",
                newName: "EmailId");

            migrationBuilder.AddColumn<string>(
                name: "ResumeUrl",
                table: "Customers",
                type: "varchar(200)",
                nullable: true);
        }
    }
}
