using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class AddQualifiernumberAndRemoveNotUsedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EDI_DeliveryOrTransportTerm",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_LineItemChange",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_NameAndAddress",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_PaymentTerm",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_ScheduleCondition",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_OrderChange",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_Contact",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_FinancialInstitution",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_PlaceLocation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_Quantity",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "RecieverUniqueId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "Supplier_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "RecieverUniqueId",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "Supplier_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "Delivery_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "CurrencyQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_FunctionCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "CurrencyDetailsQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_Code",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "Buyer_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "RecieverUniqueId",
                schema: "dbo",
                table: "EDI_Order",
                newName: "Supplier_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "Delivery_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Order",
                newName: "CurrencyQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_FunctionCode",
                schema: "dbo",
                table: "EDI_Order",
                newName: "CurrencyDetailsQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_Code",
                schema: "dbo",
                table: "EDI_Order",
                newName: "Buyer_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "RecieverUniqueId",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Supplier_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Delivery_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "CurrencyQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_FunctionCode",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "CurrencyDetailsQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_Code",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Buyer_PartyQualifier");

            migrationBuilder.AddColumn<string>(
                name: "Buyer_PartyQualifier",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyDetailsQualifier",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyQualifier",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyQualifier",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierArticleNumberQualifier",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierArticleNumberType",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierArticleNumberQualifier",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierArticleNumberType",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActionRequestCoded",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierArticleNumberQualifier",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierArticleNumberType",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierArticleNumberQualifier",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierArticleNumberType",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "nvarchar(max)",
                nullable: true);

            //Because migration it rename not-used field to be new field.
            migrationBuilder.Sql(@"update EDI_ScheduleAgreement set Supplier_PartyQualifier = NULL;
update EDI_OrderConfirmation set Supplier_PartyQualifier = NULL;
update EDI_OrderConfirmation set Delivery_PartyQualifier = NULL;
update EDI_OrderConfirmation set CurrencyQualifier = NULL;
update EDI_OrderConfirmation set CurrencyDetailsQualifier = NULL;
update EDI_OrderConfirmation set Buyer_PartyQualifier = NULL;

update EDI_Order set Supplier_PartyQualifier = NULL;
update EDI_Order set Delivery_PartyQualifier = NULL;
update EDI_Order set CurrencyQualifier = NULL;
update EDI_Order set CurrencyDetailsQualifier = NULL;
update EDI_Order set Buyer_PartyQualifier = NULL;

update EDI_Invoice set Supplier_PartyQualifier = NULL;
update EDI_Invoice set Delivery_PartyQualifier = NULL;
update EDI_Invoice set CurrencyQualifier = NULL;
update EDI_Invoice set CurrencyDetailsQualifier = NULL;
update EDI_Invoice set Buyer_PartyQualifier = NULL;
");

            migrationBuilder.Sql("delete CodeDocumentName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buyer_PartyQualifier",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "CurrencyDetailsQualifier",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "CurrencyQualifier",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyQualifier",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "SupplierArticleNumberQualifier",
                schema: "dbo",
                table: "EDI_LineItemSchedule");

            migrationBuilder.DropColumn(
                name: "SupplierArticleNumberType",
                schema: "dbo",
                table: "EDI_LineItemSchedule");

            migrationBuilder.DropColumn(
                name: "SupplierArticleNumberQualifier",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation");

            migrationBuilder.DropColumn(
                name: "SupplierArticleNumberType",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation");

            migrationBuilder.DropColumn(
                name: "ActionRequestCoded",
                schema: "dbo",
                table: "EDI_LineItemOrder");

            migrationBuilder.DropColumn(
                name: "SupplierArticleNumberQualifier",
                schema: "dbo",
                table: "EDI_LineItemOrder");

            migrationBuilder.DropColumn(
                name: "SupplierArticleNumberType",
                schema: "dbo",
                table: "EDI_LineItemOrder");

            migrationBuilder.DropColumn(
                name: "SupplierArticleNumberQualifier",
                schema: "dbo",
                table: "EDI_LineItemInvoice");

            migrationBuilder.DropColumn(
                name: "SupplierArticleNumberType",
                schema: "dbo",
                table: "EDI_LineItemInvoice");

            migrationBuilder.RenameColumn(
                name: "Supplier_PartyQualifier",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                newName: "RecieverUniqueId");

            migrationBuilder.RenameColumn(
                name: "Supplier_PartyQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "RecieverUniqueId");

            migrationBuilder.RenameColumn(
                name: "Delivery_PartyQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "DeliveryCondition2_PlaceLocationQualifier");

            migrationBuilder.RenameColumn(
                name: "CurrencyQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "DeliveryCondition2_PlaceLocationIdentification");

            migrationBuilder.RenameColumn(
                name: "CurrencyDetailsQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "DeliveryCondition2_FunctionCode");

            migrationBuilder.RenameColumn(
                name: "Buyer_PartyQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "DeliveryCondition2_Code");

            migrationBuilder.RenameColumn(
                name: "Supplier_PartyQualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "RecieverUniqueId");

            migrationBuilder.RenameColumn(
                name: "Delivery_PartyQualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition2_PlaceLocationQualifier");

            migrationBuilder.RenameColumn(
                name: "CurrencyQualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition2_PlaceLocationIdentification");

            migrationBuilder.RenameColumn(
                name: "CurrencyDetailsQualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition2_FunctionCode");

            migrationBuilder.RenameColumn(
                name: "Buyer_PartyQualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition2_Code");

            migrationBuilder.RenameColumn(
                name: "Supplier_PartyQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "RecieverUniqueId");

            migrationBuilder.RenameColumn(
                name: "Delivery_PartyQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "DeliveryCondition2_PlaceLocationQualifier");

            migrationBuilder.RenameColumn(
                name: "CurrencyQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "DeliveryCondition2_PlaceLocationIdentification");

            migrationBuilder.RenameColumn(
                name: "CurrencyDetailsQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "DeliveryCondition2_FunctionCode");

            migrationBuilder.RenameColumn(
                name: "Buyer_PartyQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "DeliveryCondition2_Code");

            migrationBuilder.CreateTable(
                name: "EDI_Contact",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdiConvertErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasEdiConvertError = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EDI_FinancialInstitution",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountHolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountHolderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdiConvertErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasEdiConvertError = table.Column<bool>(type: "bit", nullable: false),
                    InstitutionBranchNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_FinancialInstitution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EDI_OrderChange",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buyer_ContactCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Buyer_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Buyer_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Buyer_PartyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Buyer_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Buyer_ResponsibleAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllingAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfPreparation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryCondition1_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryCondition1_FunctionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryCondition1_PlaceLocationIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryCondition1_PlaceLocationQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryCondition2_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryCondition2_FunctionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryCondition2_PlaceLocationIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryCondition2_PlaceLocationQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_PartyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_PartyName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_PartyName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_PlaceLocationIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_PlaceLocationQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_ResponsibleAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentNameCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdiConvertErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasEdiConvertError = table.Column<bool>(type: "bit", nullable: false),
                    InterchangeControlReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTestMessage = table.Column<bool>(type: "bit", nullable: false),
                    MessageFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm1_NumberOfPeriod = table.Column<int>(type: "int", nullable: true),
                    PaymentTerm1_Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentTerm1_PercentageQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm1_TimeReferenceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm1_TimeRelationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm1_TypeOfPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm1_TypeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm2_NumberOfPeriod = table.Column<int>(type: "int", nullable: true),
                    PaymentTerm2_Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentTerm2_PercentageQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm2_TimeReferenceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm2_TimeRelationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm2_TypeOfPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm2_TypeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm3_NumberOfPeriod = table.Column<int>(type: "int", nullable: true),
                    PaymentTerm3_Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentTerm3_PercentageQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm3_TimeReferenceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm3_TimeRelationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm3_TypeOfPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerm3_TypeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecieverUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendErrorCount = table.Column<int>(type: "int", nullable: false),
                    SendErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Supplier_CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier_CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier_CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier_PartyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier_Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier_ResponsibleAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyntaxIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyntaxVersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextLiteralFreeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextSubjectqualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeReleaseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeVersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnhMessageReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_OrderChange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EDI_PaymentTerm",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdiConvertErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasEdiConvertError = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPeriod = table.Column<int>(type: "int", nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PercentageQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsOfPaymentIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsOfpayment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeReferenceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeRelationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_PaymentTerm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EDI_PlaceLocation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdiConvertErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasEdiConvertError = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceLocationIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceLocationQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_PlaceLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EDI_Quantity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdiConvertErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasEdiConvertError = table.Column<bool>(type: "bit", nullable: false),
                    ItemQuantity = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QTYMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_Quantity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EDI_LineItemChange",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionRequestCoded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeListQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeListResponsibleAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryPlanStatusIndicatorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdiConvertErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdiOrderChangeId = table.Column<int>(type: "int", nullable: true),
                    FreeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasEdiConvertError = table.Column<bool>(type: "bit", nullable: false),
                    ItemCharacteristicCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescriptionIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescriptionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNumberType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemQuantity = table.Column<int>(type: "int", nullable: true),
                    LineItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QTYMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleItemQuantity = table.Column<int>(type: "int", nullable: true),
                    ScheduleQTYMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleQuantityQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierArticleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextFunctionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextSubjectQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPriceBasis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_LineItemChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDI_LineItemChange_EDI_OrderChange_EdiOrderChangeId",
                        column: x => x.EdiOrderChangeId,
                        principalSchema: "dbo",
                        principalTable: "EDI_OrderChange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDI_DeliveryOrTransportTerm",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdiConvertErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunctionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasEdiConvertError = table.Column<bool>(type: "bit", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_DeliveryOrTransportTerm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDI_DeliveryOrTransportTerm_EDI_PlaceLocation_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "dbo",
                        principalTable: "EDI_PlaceLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDI_NameAndAddress",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdiConvertErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialInstitutionId = table.Column<int>(type: "int", nullable: true),
                    HasEdiConvertError = table.Column<bool>(type: "bit", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAndAddressLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsibleAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATRegistrationQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_NameAndAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDI_NameAndAddress_EDI_Contact_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "dbo",
                        principalTable: "EDI_Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_NameAndAddress_EDI_FinancialInstitution_FinancialInstitutionId",
                        column: x => x.FinancialInstitutionId,
                        principalSchema: "dbo",
                        principalTable: "EDI_FinancialInstitution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_NameAndAddress_EDI_PlaceLocation_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "dbo",
                        principalTable: "EDI_PlaceLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDI_ScheduleCondition",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryPlanStatusIndicatorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EarliestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EdiConvertErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasEdiConvertError = table.Column<bool>(type: "bit", nullable: false),
                    LatestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_ScheduleCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDI_ScheduleCondition_EDI_Quantity_QuantityId",
                        column: x => x.QuantityId,
                        principalSchema: "dbo",
                        principalTable: "EDI_Quantity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EDI_DeliveryOrTransportTerm_LocationId",
                schema: "dbo",
                table: "EDI_DeliveryOrTransportTerm",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItemChange_EdiOrderChangeId",
                schema: "dbo",
                table: "EDI_LineItemChange",
                column: "EdiOrderChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_NameAndAddress_ContactId",
                schema: "dbo",
                table: "EDI_NameAndAddress",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_NameAndAddress_FinancialInstitutionId",
                schema: "dbo",
                table: "EDI_NameAndAddress",
                column: "FinancialInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_NameAndAddress_LocationId",
                schema: "dbo",
                table: "EDI_NameAndAddress",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_ScheduleCondition_QuantityId",
                schema: "dbo",
                table: "EDI_ScheduleCondition",
                column: "QuantityId");
        }
    }
}
