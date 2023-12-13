using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class ChangPaymentToEachOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EDI_PaymentTerm_EDI_Invoice_EdiInvoiceId",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_PaymentTerm_EDI_Order_EdiOrderId",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_PaymentTerm_EDI_OrderChange_EdiOrderChangeId",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_PaymentTerm_EDI_OrderConfirmation_EdiOrderConfirmationId",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_PaymentTerm_EDI_ScheduleAgreement_EdiScheduleAgreementId",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropIndex(
                name: "IX_EDI_PaymentTerm_EdiInvoiceId",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropIndex(
                name: "IX_EDI_PaymentTerm_EdiOrderChangeId",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropIndex(
                name: "IX_EDI_PaymentTerm_EdiOrderConfirmationId",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropIndex(
                name: "IX_EDI_PaymentTerm_EdiOrderId",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropIndex(
                name: "IX_EDI_PaymentTerm_EdiScheduleAgreementId",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropColumn(
                name: "EdiInvoiceId",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropColumn(
                name: "EdiOrderChangeId",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropColumn(
                name: "EdiOrderConfirmationId",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropColumn(
                name: "EdiOrderId",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.DropColumn(
                name: "EdiScheduleAgreementId",
                schema: "dbo",
                table: "EDI_PaymentTerm");

            migrationBuilder.AddColumn<string>(
                name: "Delivery1_Code",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery1_FunctionCode",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery1_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery1_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery2_Code",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery2_FunctionCode",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery2_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery2_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTerm1_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TimeRelationCode",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TypeQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTerm2_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TimeRelationCode",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TypeQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delivery1_Code",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery1_FunctionCode",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery1_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery1_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery2_Code",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery2_FunctionCode",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery2_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery2_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TimeRelationCode",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TypeQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TimeRelationCode",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TypeQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.AddColumn<int>(
                name: "EdiInvoiceId",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EdiOrderChangeId",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EdiOrderConfirmationId",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EdiOrderId",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EdiScheduleAgreementId",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                type: "INT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EDI_PaymentTerm_EdiInvoiceId",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                column: "EdiInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_PaymentTerm_EdiOrderChangeId",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                column: "EdiOrderChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_PaymentTerm_EdiOrderConfirmationId",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                column: "EdiOrderConfirmationId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_PaymentTerm_EdiOrderId",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                column: "EdiOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_PaymentTerm_EdiScheduleAgreementId",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                column: "EdiScheduleAgreementId");

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_PaymentTerm_EDI_Invoice_EdiInvoiceId",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                column: "EdiInvoiceId",
                principalSchema: "dbo",
                principalTable: "EDI_Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_PaymentTerm_EDI_Order_EdiOrderId",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                column: "EdiOrderId",
                principalSchema: "dbo",
                principalTable: "EDI_Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_PaymentTerm_EDI_OrderChange_EdiOrderChangeId",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                column: "EdiOrderChangeId",
                principalSchema: "dbo",
                principalTable: "EDI_OrderChange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_PaymentTerm_EDI_OrderConfirmation_EdiOrderConfirmationId",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                column: "EdiOrderConfirmationId",
                principalSchema: "dbo",
                principalTable: "EDI_OrderConfirmation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_PaymentTerm_EDI_ScheduleAgreement_EdiScheduleAgreementId",
                schema: "dbo",
                table: "EDI_PaymentTerm",
                column: "EdiScheduleAgreementId",
                principalSchema: "dbo",
                principalTable: "EDI_ScheduleAgreement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
