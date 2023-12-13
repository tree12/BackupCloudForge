using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class ChangeTermBuyerSuplierDeliveryFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_RecipientId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropIndex(
                name: "IX_EDI_ScheduleAgreement_RecipientId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.RenameColumn(
                name: "Supplier_PartyQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "Supplier_Phone");

            migrationBuilder.RenameColumn(
                name: "Delivery_PartyQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "Supplier_Name");

            migrationBuilder.RenameColumn(
                name: "Buyer_PartyQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "Supplier_Email");

            migrationBuilder.RenameColumn(
                name: "Supplier_PartyQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Supplier_VATRegistrationNumber");

            migrationBuilder.RenameColumn(
                name: "SupplierReferenceQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Supplier_Phone");

            migrationBuilder.RenameColumn(
                name: "SupplierReferenceNumber",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Supplier_PartyName1");

            migrationBuilder.RenameColumn(
                name: "SupplierPhone",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Supplier_Name");

            migrationBuilder.RenameColumn(
                name: "SupplierName",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Supplier_Email");

            migrationBuilder.RenameColumn(
                name: "SupplierEmail",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Supplier_ContactCode");

            migrationBuilder.RenameColumn(
                name: "SupplierContactCode",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Supplier_CompanyName");

            migrationBuilder.RenameColumn(
                name: "Invoicee_PartyQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "PaymentTerm3_TypeQualifier");

            migrationBuilder.RenameColumn(
                name: "Delivery2_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "PaymentTerm3_TypeOfPeriod");

            migrationBuilder.RenameColumn(
                name: "Delivery2_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "PaymentTerm3_TimeRelationCode");

            migrationBuilder.RenameColumn(
                name: "Delivery2_FunctionCode",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "PaymentTerm3_TimeReferenceCode");

            migrationBuilder.RenameColumn(
                name: "Delivery2_Code",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "PaymentTerm3_PercentageQualifier");

            migrationBuilder.RenameColumn(
                name: "Delivery1_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Invoicee_VATRegistrationNumber");

            migrationBuilder.RenameColumn(
                name: "Delivery1_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Delivery_Street");

            migrationBuilder.RenameColumn(
                name: "Delivery1_FunctionCode",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Delivery_ResponsibleAgency");

            migrationBuilder.RenameColumn(
                name: "Delivery1_Code",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Delivery_Postcode");

            migrationBuilder.RenameColumn(
                name: "Buyer_PartyQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Delivery_PlaceLocationQualifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Buyer_ContactCode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_Email",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_Name",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_PartyId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_Phone",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_CityName",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_CompanyName",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_CountryCode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyName1",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyName2",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_Postcode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_Street",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seller_CityName",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seller_CompanyName",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seller_CountryCode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seller_PartyId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seller_Postcode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seller_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seller_Street",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition1_FunctionCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition1_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition1_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition2_Code",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition2_FunctionCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition2_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition2_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTerm1_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentTerm1_Percentage",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_PercentageQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TimeRelationCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TypeQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTerm2_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentTerm2_Percentage",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_PercentageQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TimeRelationCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TypeQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTerm3_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentTerm3_Percentage",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_PercentageQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TimeRelationCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TypeQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_CompanyName",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_ContactCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Buyer_ContactCode",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_Email",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_Name",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_PartyId",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_Phone",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition1_FunctionCode",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition1_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition1_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition2_Code",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition2_FunctionCode",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition2_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition2_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_CityName",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_CompanyName",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_CountryCode",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyId",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyName1",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyName2",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_Postcode",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_Street",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTerm1_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentTerm1_Percentage",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_PercentageQualifier",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TimeRelationCode",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_TypeQualifier",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTerm2_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentTerm2_Percentage",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_PercentageQualifier",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TimeRelationCode",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_TypeQualifier",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTerm3_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentTerm3_Percentage",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_PercentageQualifier",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TimeRelationCode",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TypeQualifier",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_CityName",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_CompanyName",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_ContactCode",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_CountryCode",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_Email",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_Name",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_PartyId",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_PartyName1",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_Phone",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_Postcode",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_Street",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "EDI_Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PaymentTerm3_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentTerm3_Percentage",
                schema: "dbo",
                table: "EDI_Order",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_PercentageQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TimeRelationCode",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm3_TypeQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_ContactCode",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_Email",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_Name",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_Phone",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EdiScheduleAgreementId",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EdiOrderConfirmationId",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EdiOrderId",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EdiInvoiceId",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EdiOrderChangeId",
                schema: "dbo",
                table: "EDI_LineItemChange",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Buyer_ContactCode",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_Email",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_Name",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_Phone",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition1_FunctionCode",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition1_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition1_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition2_Code",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition2_FunctionCode",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition2_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCondition2_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_CityName",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_CompanyName",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_CountryCode",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyId",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyName1",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyName2",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTerm3_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentTerm3_Percentage",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buyer_ContactCode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Buyer_Email",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Buyer_Name",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Buyer_PartyId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Buyer_Phone",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Buyer_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Delivery_CityName",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Delivery_CompanyName",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Delivery_CountryCode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyName1",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyName2",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Delivery_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Delivery_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Delivery_Postcode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Delivery_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Delivery_Street",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Seller_CityName",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Seller_CompanyName",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Seller_CountryCode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Seller_PartyId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Seller_Postcode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Seller_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Seller_Street",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition1_FunctionCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition1_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition1_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition2_Code",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition2_FunctionCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition2_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition2_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_Percentage",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_PercentageQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TimeRelationCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TypeQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_Percentage",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_PercentageQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TimeRelationCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TypeQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_Percentage",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_PercentageQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TimeRelationCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TypeQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Supplier_CompanyName",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Supplier_ContactCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Buyer_ContactCode",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Buyer_Email",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Buyer_Name",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Buyer_PartyId",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Buyer_Phone",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Buyer_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition1_FunctionCode",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition1_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition1_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition2_Code",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition2_FunctionCode",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition2_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition2_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Delivery_CityName",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Delivery_CompanyName",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Delivery_CountryCode",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyId",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyName1",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyName2",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Delivery_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Delivery_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Delivery_Postcode",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Delivery_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Delivery_Street",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_Percentage",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_PercentageQualifier",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TimeRelationCode",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_TypeQualifier",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_Percentage",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_PercentageQualifier",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TimeRelationCode",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_TypeQualifier",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_Percentage",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_PercentageQualifier",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TimeRelationCode",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TypeQualifier",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Supplier_CityName",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Supplier_CompanyName",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Supplier_ContactCode",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Supplier_CountryCode",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Supplier_Email",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Supplier_Name",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Supplier_PartyId",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Supplier_PartyName1",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Supplier_Phone",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Supplier_Postcode",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Supplier_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "Supplier_Street",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_Percentage",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_PercentageQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TimeRelationCode",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_TypeQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Supplier_ContactCode",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Supplier_Email",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Supplier_Name",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Supplier_Phone",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Buyer_ContactCode",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Buyer_Email",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Buyer_Name",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Buyer_Phone",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition1_FunctionCode",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition1_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition1_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition2_Code",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition2_FunctionCode",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition2_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "DeliveryCondition2_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Delivery_CityName",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Delivery_CompanyName",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Delivery_CountryCode",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyId",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyName1",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyName2",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Delivery_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_NumberOfPeriod",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "PaymentTerm3_Percentage",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.RenameColumn(
                name: "Supplier_Phone",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "Supplier_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "Supplier_Name",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "Delivery_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "Supplier_Email",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "Buyer_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "Supplier_VATRegistrationNumber",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Supplier_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "Supplier_Phone",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "SupplierReferenceQualifier");

            migrationBuilder.RenameColumn(
                name: "Supplier_PartyName1",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "SupplierReferenceNumber");

            migrationBuilder.RenameColumn(
                name: "Supplier_Name",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "SupplierPhone");

            migrationBuilder.RenameColumn(
                name: "Supplier_Email",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "SupplierName");

            migrationBuilder.RenameColumn(
                name: "Supplier_ContactCode",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "SupplierEmail");

            migrationBuilder.RenameColumn(
                name: "Supplier_CompanyName",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "SupplierContactCode");

            migrationBuilder.RenameColumn(
                name: "PaymentTerm3_TypeQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Invoicee_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "PaymentTerm3_TypeOfPeriod",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Delivery2_PlaceLocationQualifier");

            migrationBuilder.RenameColumn(
                name: "PaymentTerm3_TimeRelationCode",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Delivery2_PlaceLocationIdentification");

            migrationBuilder.RenameColumn(
                name: "PaymentTerm3_TimeReferenceCode",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Delivery2_FunctionCode");

            migrationBuilder.RenameColumn(
                name: "PaymentTerm3_PercentageQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Delivery2_Code");

            migrationBuilder.RenameColumn(
                name: "Invoicee_VATRegistrationNumber",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Delivery1_PlaceLocationQualifier");

            migrationBuilder.RenameColumn(
                name: "Delivery_Street",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Delivery1_PlaceLocationIdentification");

            migrationBuilder.RenameColumn(
                name: "Delivery_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Delivery1_FunctionCode");

            migrationBuilder.RenameColumn(
                name: "Delivery_Postcode",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Delivery1_Code");

            migrationBuilder.RenameColumn(
                name: "Delivery_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Buyer_PartyQualifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RecipientId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "EDI_Order",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "EdiScheduleAgreementId",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EdiOrderConfirmationId",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EdiOrderId",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EdiInvoiceId",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EdiOrderChangeId",
                schema: "dbo",
                table: "EDI_LineItemChange",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_ScheduleAgreement_RecipientId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_RecipientId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                column: "RecipientId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
