using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class AddQualifierForInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bank1PartyQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank2PartyQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank3PartyQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Invoicee_VATReferenceQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_VATReferenceQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.Sql(@"   IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Log' and xtype='U')
  CREATE TABLE [dbo].[Log] (
    [Id] [int] IDENTITY (1, 1) NOT NULL,
    [Date] [datetime] NOT NULL,
    [Thread] [varchar] (255) NOT NULL,
    [Level] [varchar] (50) NOT NULL,
    [Logger] [varchar] (255) NOT NULL,
    [Message] [varchar] (4000) NOT NULL,
    [Exception] [varchar] (2000) NULL
)
GO
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bank1PartyQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Bank2PartyQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Bank3PartyQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Invoicee_VATReferenceQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Supplier_VATReferenceQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

        }
    }
}
