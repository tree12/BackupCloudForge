using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class MoveDuplicateFieldsToBaseClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterchangeControlCount",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "InterchangeControlCount",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "NumberOfSegment",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "UnzInterchangeControlReference",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "InterchangeControlCount",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "NumberOfSegment",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "UnzInterchangeControlReference",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "InterchangeControlCount",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "NumberOfSegment",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "UnzInterchangeControlReference",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "AdditionalItemNumber",
                schema: "dbo",
                table: "EDI_LineItemSchedule");

            migrationBuilder.DropColumn(
                name: "AdditionalProductId",
                schema: "dbo",
                table: "EDI_LineItemSchedule");

            migrationBuilder.DropColumn(
                name: "AdditionalItemNumber",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation");

            migrationBuilder.DropColumn(
                name: "AdditionalProductId",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation");

            migrationBuilder.DropColumn(
                name: "AdditionalProductId",
                schema: "dbo",
                table: "EDI_LineItemOrder");

            migrationBuilder.DropColumn(
                name: "AdditionalItemNumber",
                schema: "dbo",
                table: "EDI_LineItemInvoice");

            migrationBuilder.DropColumn(
                name: "AdditionalProductId",
                schema: "dbo",
                table: "EDI_LineItemInvoice");

            migrationBuilder.DropColumn(
                name: "AdditionalItemNumber",
                schema: "dbo",
                table: "EDI_LineItemChange");

            migrationBuilder.DropColumn(
                name: "AdditionalProductId",
                schema: "dbo",
                table: "EDI_LineItemChange");

            migrationBuilder.DropColumn(
                name: "InterchangeControlCount",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.RenameColumn(
                name: "UnzInterchangeControlReference",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Supplier_Street");

            migrationBuilder.RenameColumn(
                name: "Seller_Street",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Supplier_ResponsibleAgency");

            migrationBuilder.RenameColumn(
                name: "Seller_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Supplier_Postcode");

            migrationBuilder.RenameColumn(
                name: "Seller_Postcode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Supplier_Phone");

            migrationBuilder.RenameColumn(
                name: "Seller_PartyId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Supplier_PartyName1");

            migrationBuilder.RenameColumn(
                name: "Seller_CountryCode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Supplier_PartyId");

            migrationBuilder.RenameColumn(
                name: "Seller_CompanyName",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Supplier_Name");

            migrationBuilder.RenameColumn(
                name: "Seller_CityName",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Supplier_Email");

            migrationBuilder.RenameColumn(
                name: "AdditionalItemNumberType",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                newName: "SupplierArticleNumber");

            migrationBuilder.RenameColumn(
                name: "AdditionalItemNumberType",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                newName: "SupplierArticleNumber");

            migrationBuilder.RenameColumn(
                name: "AdditionalItemNumberType",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                newName: "SupplierArticleNumber");

            migrationBuilder.RenameColumn(
                name: "AdditionalItemNumberType",
                schema: "dbo",
                table: "EDI_LineItemChange",
                newName: "SupplierArticleNumber");

            migrationBuilder.RenameColumn(
                name: "UnzInterchangeControlReference",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "PaymentTerm3_TermsOfpayment");

            migrationBuilder.RenameColumn(
                name: "Supplier_PartyName",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "PaymentTerm3_TermsOfPaymentIdentification");

            migrationBuilder.RenameColumn(
                name: "PartyQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Invoicee_CompanyName");

            migrationBuilder.RenameColumn(
                name: "Invoicee_PartyName",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "FinancialPartyQualifier");

            migrationBuilder.AddColumn<string>(
                name: "Supplier_CityName",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_CompanyName",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_ContactCode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_CountryCode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Supplier_CityName",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Supplier_CompanyName",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Supplier_ContactCode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Supplier_CountryCode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.RenameColumn(
                name: "Supplier_Street",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "UnzInterchangeControlReference");

            migrationBuilder.RenameColumn(
                name: "Supplier_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Seller_Street");

            migrationBuilder.RenameColumn(
                name: "Supplier_Postcode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Seller_ResponsibleAgency");

            migrationBuilder.RenameColumn(
                name: "Supplier_Phone",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Seller_Postcode");

            migrationBuilder.RenameColumn(
                name: "Supplier_PartyName1",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Seller_PartyId");

            migrationBuilder.RenameColumn(
                name: "Supplier_PartyId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Seller_CountryCode");

            migrationBuilder.RenameColumn(
                name: "Supplier_Name",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Seller_CompanyName");

            migrationBuilder.RenameColumn(
                name: "Supplier_Email",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Seller_CityName");

            migrationBuilder.RenameColumn(
                name: "SupplierArticleNumber",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                newName: "AdditionalItemNumberType");

            migrationBuilder.RenameColumn(
                name: "SupplierArticleNumber",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                newName: "AdditionalItemNumberType");

            migrationBuilder.RenameColumn(
                name: "SupplierArticleNumber",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                newName: "AdditionalItemNumberType");

            migrationBuilder.RenameColumn(
                name: "SupplierArticleNumber",
                schema: "dbo",
                table: "EDI_LineItemChange",
                newName: "AdditionalItemNumberType");

            migrationBuilder.RenameColumn(
                name: "PaymentTerm3_TermsOfpayment",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "UnzInterchangeControlReference");

            migrationBuilder.RenameColumn(
                name: "PaymentTerm3_TermsOfPaymentIdentification",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Supplier_PartyName");

            migrationBuilder.RenameColumn(
                name: "Invoicee_CompanyName",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "FinancialPartyQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Invoicee_PartyName");

            migrationBuilder.AddColumn<int>(
                name: "InterchangeControlCount",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterchangeControlCount",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSegment",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnzInterchangeControlReference",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterchangeControlCount",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSegment",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnzInterchangeControlReference",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterchangeControlCount",
                schema: "dbo",
                table: "EDI_Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSegment",
                schema: "dbo",
                table: "EDI_Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnzInterchangeControlReference",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalItemNumber",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalProductId",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalItemNumber",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalProductId",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalProductId",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalItemNumber",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalProductId",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalItemNumber",
                schema: "dbo",
                table: "EDI_LineItemChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalProductId",
                schema: "dbo",
                table: "EDI_LineItemChange",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterchangeControlCount",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "int",
                nullable: true);
        }
    }
}
