using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class ChangeFreeTextToFreeTextLineItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FreeText",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                newName: "FreeTextLineItem");

            migrationBuilder.RenameColumn(
                name: "FreeText",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                newName: "FreeTextLineItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FreeTextLineItem",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                newName: "FreeText");

            migrationBuilder.RenameColumn(
                name: "FreeTextLineItem",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                newName: "FreeText");
        }
    }
}
