using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dylan_Bruce_ST10084351_PROG7311_POE_Task_2.Data.Migrations
{
    public partial class AddedEmailAddressToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Product");
        }
    }
}
