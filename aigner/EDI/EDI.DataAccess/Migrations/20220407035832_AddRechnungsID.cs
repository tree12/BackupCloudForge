using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class AddRechnungsID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RechnungsID",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaxCaseAigner",
                schema: "dbo",
                table: "CodeFreeTextCode",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RechnungsID",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.AlterColumn<int>(
                name: "TaxCaseAigner",
                schema: "dbo",
                table: "CodeFreeTextCode",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
