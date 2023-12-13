using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class RemoveMessageStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocType",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "MessageStatus",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "DocType",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "MessageStatus",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "DocType",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "MessageStatus",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "DocType",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "MessageStatus",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "DocType",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "MessageStatus",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.RenameColumn(
                name: "DateOfPerparation",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "DateOfPreparation");

            migrationBuilder.RenameColumn(
                name: "DateOfPerparation",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "DateOfPreparation");

            migrationBuilder.RenameColumn(
                name: "DateOfPerparation",
                schema: "dbo",
                table: "EDI_OrderChange",
                newName: "DateOfPreparation");

            migrationBuilder.RenameColumn(
                name: "DateOfPerparation",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DateOfPreparation");

            migrationBuilder.RenameColumn(
                name: "DateOfPerparation",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "DateOfPreparation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfPreparation",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "DateOfPerparation");

            migrationBuilder.RenameColumn(
                name: "DateOfPreparation",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "DateOfPerparation");

            migrationBuilder.RenameColumn(
                name: "DateOfPreparation",
                schema: "dbo",
                table: "EDI_OrderChange",
                newName: "DateOfPerparation");

            migrationBuilder.RenameColumn(
                name: "DateOfPreparation",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DateOfPerparation");

            migrationBuilder.RenameColumn(
                name: "DateOfPreparation",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "DateOfPerparation");

            migrationBuilder.AddColumn<int>(
                name: "DocType",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessageStatus",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocType",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessageStatus",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocType",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessageStatus",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocType",
                schema: "dbo",
                table: "EDI_Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessageStatus",
                schema: "dbo",
                table: "EDI_Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocType",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessageStatus",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
