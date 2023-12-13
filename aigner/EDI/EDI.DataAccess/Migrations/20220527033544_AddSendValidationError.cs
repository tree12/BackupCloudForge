using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class AddSendValidationError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SendValidationError",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SendValidationError",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SendValidationError",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SendValidationError",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendValidationError",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "SendValidationError",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "SendValidationError",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "SendValidationError",
                schema: "dbo",
                table: "EDI_Invoice");
        }
    }
}
