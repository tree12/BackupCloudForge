using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class AddErrorMessageForEachEdiFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SendErrorCount",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SendErrorMessage",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SendErrorCount",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SendErrorMessage",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SendErrorCount",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SendErrorMessage",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SendErrorCount",
                schema: "dbo",
                table: "EDI_Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SendErrorMessage",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "SendErrorCount",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SendErrorMessage",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendErrorCount",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "SendErrorMessage",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "SendErrorCount",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "SendErrorMessage",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "SendErrorCount",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "SendErrorMessage",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "SendErrorCount",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "SendErrorMessage",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "SendErrorCount",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "SendErrorMessage",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
