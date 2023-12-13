using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class AddFreeTextFieldsAndCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text1",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text10",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text10FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text10SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text11",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text11FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text11SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text1FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text1SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text3",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text3FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text3SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text4",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text4FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text4SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text5",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text5FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text5SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text6",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text6FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text6SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text7",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text7FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text7SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text8",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text8FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text8SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text9",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text9FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text9SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text1",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text10",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text10FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text10SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text11",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text11FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text11SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text1FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text1SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text3",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text3FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text3SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text4",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text4FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text4SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text5",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text5FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text5SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text6",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text6FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text6SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text7",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text7FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text7SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text8",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text8FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text8SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text9",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text9FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text9SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CodeTextFunctionCode",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    German = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Usage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTextFunctionCode", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeTextFunctionCode",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "Text1",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text10",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text10FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text10SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text11",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text11FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text11SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text1FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text1SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text2",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text2FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text2SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text3",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text3FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text3SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text4",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text4FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text4SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text5",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text5FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text5SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text6",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text6FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text6SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text7",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text7FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text7SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text8",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text8FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text8SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text9",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text9FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text9SubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text1",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text10",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text10FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text10SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text11",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text11FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text11SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text1FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text1SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text2",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text2FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text2SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text3",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text3FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text3SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text4",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text4FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text4SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text5",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text5FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text5SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text6",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text6FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text6SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text7",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text7FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text7SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text8",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text8FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text8SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text9",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text9FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text9SubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice");
        }
    }
}
