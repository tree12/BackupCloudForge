using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class AddMoreFieldsForPatmentTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentTerm3_TermsOfpayment",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "PaymentTerm3_TermsOfPayment");

            migrationBuilder.RenameColumn(
                name: "PaymentTerm2_TermsOfpayment",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "PaymentTerm2_TermsOfPayment");

            migrationBuilder.RenameColumn(
                name: "PaymentTerm1_TermsOfpayment",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "PaymentTerm1_TermsOfPayment");

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_CodeListQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TermsOfPayment",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TermsOfPaymentIdentification",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_CodeListQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TermsOfPayment",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TermsOfPaymentIdentification",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_CodeListQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TermsOfPayment",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TermsOfPaymentIdentification",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_CodeListQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TermsOfPayment",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TermsOfPaymentIdentification",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_CodeListQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TermsOfPayment",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TermsOfPaymentIdentification",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_CodeListQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TermsOfPayment",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TermsOfPaymentIdentification",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_CodeListQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_CodeListQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_CodeListQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentTerm1_CodeListQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TermsOfPayment",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TermsOfPaymentIdentification",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_CodeListQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TermsOfPayment",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TermsOfPaymentIdentification",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_CodeListQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TermsOfPayment",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TermsOfPaymentIdentification",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_CodeListQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TermsOfPayment",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TermsOfPaymentIdentification",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_CodeListQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TermsOfPayment",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TermsOfPaymentIdentification",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_CodeListQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TermsOfPayment",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TermsOfPaymentIdentification",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_CodeListQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_CodeListQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_CodeListQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.RenameColumn(
                name: "PaymentTerm3_TermsOfPayment",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "PaymentTerm3_TermsOfpayment");

            migrationBuilder.RenameColumn(
                name: "PaymentTerm2_TermsOfPayment",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "PaymentTerm2_TermsOfpayment");

            migrationBuilder.RenameColumn(
                name: "PaymentTerm1_TermsOfPayment",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "PaymentTerm1_TermsOfpayment");
        }
    }
}
