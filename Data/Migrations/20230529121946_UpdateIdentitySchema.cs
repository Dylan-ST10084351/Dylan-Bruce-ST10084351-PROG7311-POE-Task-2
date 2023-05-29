using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dylan_Bruce_ST10084351_PROG7311_POE_Task_2.Data.Migrations
{
    public partial class UpdateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Farmer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Farmer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Farmer");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Farmer");
        }
    }
}
