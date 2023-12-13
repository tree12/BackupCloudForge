using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class addInvoiceeForOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Invoicee_PartyId",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Invoicee_PartyQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Invoicee_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invoicee_PartyId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Invoicee_PartyQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Invoicee_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_Order");
        }
    }
}
