using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class AddErrorColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "RequestLog",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_ScheduleCondition",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_ScheduleCondition",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_Quantity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_Quantity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_PlaceLocation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_PlaceLocation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_NameAndAddress",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_NameAndAddress",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_LineItemChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_LineItemChange",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_FinancialInstitution",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_FinancialInstitution",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_DeliveryOrTransportTerm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_DeliveryOrTransportTerm",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_Contact",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "dbo",
                table: "AuditLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_ScheduleCondition");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_ScheduleCondition");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_Quantity");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_Quantity");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_PlaceLocation");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_PlaceLocation");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_NameAndAddress");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_NameAndAddress");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_LineItemSchedule");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_LineItemSchedule");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_LineItemOrder");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_LineItemOrder");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_LineItemInvoice");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_LineItemInvoice");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_LineItemChange");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_LineItemChange");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_FinancialInstitution");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_FinancialInstitution");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_DeliveryOrTransportTerm");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_DeliveryOrTransportTerm");

            migrationBuilder.DropColumn(
                name: "EdiConvertErrorMessage",
                schema: "dbo",
                table: "EDI_Contact");

            migrationBuilder.DropColumn(
                name: "HasEdiConvertError",
                schema: "dbo",
                table: "EDI_Contact");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "dbo",
                table: "AuditLogs");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "RequestLog",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
