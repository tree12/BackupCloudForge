using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class AddommittedQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CommittedItemQuantity",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommittedQTYMeasureUnitQualifier",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommittedQuantityQualifier",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommittedItemQuantity",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation");

            migrationBuilder.DropColumn(
                name: "CommittedQTYMeasureUnitQualifier",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation");

            migrationBuilder.DropColumn(
                name: "CommittedQuantityQualifier",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation");
        }
    }
}
