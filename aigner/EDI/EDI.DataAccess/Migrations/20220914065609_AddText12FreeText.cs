using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class AddText12FreeText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text12",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text12FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text12",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text12FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text12",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text12FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text12",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text12FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");
        }
    }
}
