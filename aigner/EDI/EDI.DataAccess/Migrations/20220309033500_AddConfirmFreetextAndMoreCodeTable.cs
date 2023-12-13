using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class AddConfirmFreetextAndMoreCodeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("update EDI_Order set DeliveryCondition1_Code = SUBSTRING(DeliveryCondition1_Code,1,5)");
            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AignerFairness",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "B1",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyRegister",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionalSales",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EXZone",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExplosionProtection",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FireProtection",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerms",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Penalty",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxCase",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UIDNumbers",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeTypePeriodCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeTypePeriodCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeTimeRelationCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeTimeRelationCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeTimeReferenceCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeTimeReferenceCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeTextSubjectCodeQualifier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeTextSubjectCodeQualifier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeTermsOfDeliveryOrTransportFunctionCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeTermsOfDeliveryOrTransportFunctionCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeSpecialServicedescriptionCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeSpecialServicedescriptionCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeReferenceCodeQualifier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeReferenceCodeQualifier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeQuantityTypeCodeQualifier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeQuantityTypeCodeQualifier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodePriceCodeQualifier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodePriceCodeQualifier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodePercentageTypeCodeQualifier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodePercentageTypeCodeQualifier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodePaymentTermsTypeCodeQualifier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodePaymentTermsTypeCodeQualifier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodePaymentTermsDescriptionIdentifier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodePaymentTermsDescriptionIdentifier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeMonetaryAmountTypeCodeQualifier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeMonetaryAmountTypeCodeQualifier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeMessageFunction",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeMessageFunction",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeLocationFunctionCodeQualifier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeLocationFunctionCodeQualifier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeItemTypeIdentificationCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeItemTypeIdentificationCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeItemDescriptionType",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeItemDescriptionType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeItemCaracteristic",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeItemCaracteristic",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeIncotermCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeIncotermCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeDutyTaxFeeTypeNameCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeDutyTaxFeeTypeNameCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeDutyTaxFeeFunctionCodeQualifier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeDutyTaxFeeFunctionCodeQualifier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeDutyTaxFeeCategoryCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeDutyTaxFeeCategoryCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeDocumentName",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeDocumentName",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeDescriptionFormatCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeDescriptionFormatCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeDateTimePeriodFunctionCodeQualifier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeDateTimePeriodFunctionCodeQualifier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeDateTimePeriodFormatCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeDateTimePeriodFormatCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeContactFunctionCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeContactFunctionCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "German",
                schema: "dbo",
                table: "CodeAllowanceOrChargeCodeQualifier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Usage",
                schema: "dbo",
                table: "CodeAllowanceOrChargeCodeQualifier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CodeActionRequest",
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
                    table.PrimaryKey("PK_CodeActionRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeDeliveryPlanStatusIndicator",
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
                    table.PrimaryKey("PK_CodeDeliveryPlanStatusIndicator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeListQualifierCode",
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
                    table.PrimaryKey("PK_CodeListQualifierCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeListResponsibleAgencyCode",
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
                    table.PrimaryKey("PK_CodeListResponsibleAgencyCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodePartyQualifier",
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
                    table.PrimaryKey("PK_CodePartyQualifier", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeActionRequest",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeDeliveryPlanStatusIndicator",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeListQualifierCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeListResponsibleAgencyCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodePartyQualifier",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "AignerFairness",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "B1",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "CompanyRegister",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "ConditionalSales",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "EXZone",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "ExplosionProtection",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "FireProtection",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "PaymentTerms",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Penalty",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "TaxCase",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "UIDNumbers",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeTypePeriodCode");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeTypePeriodCode");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeTimeRelationCode");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeTimeRelationCode");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeTimeReferenceCode");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeTimeReferenceCode");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeTextSubjectCodeQualifier");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeTextSubjectCodeQualifier");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeTermsOfDeliveryOrTransportFunctionCode");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeTermsOfDeliveryOrTransportFunctionCode");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeSpecialServicedescriptionCode");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeSpecialServicedescriptionCode");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeReferenceCodeQualifier");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeReferenceCodeQualifier");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeQuantityTypeCodeQualifier");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeQuantityTypeCodeQualifier");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodePriceCodeQualifier");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodePriceCodeQualifier");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodePercentageTypeCodeQualifier");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodePercentageTypeCodeQualifier");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodePaymentTermsTypeCodeQualifier");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodePaymentTermsTypeCodeQualifier");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodePaymentTermsDescriptionIdentifier");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodePaymentTermsDescriptionIdentifier");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeMonetaryAmountTypeCodeQualifier");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeMonetaryAmountTypeCodeQualifier");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeMessageFunction");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeMessageFunction");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeLocationFunctionCodeQualifier");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeLocationFunctionCodeQualifier");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeItemTypeIdentificationCode");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeItemTypeIdentificationCode");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeItemDescriptionType");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeItemDescriptionType");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeItemCaracteristic");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeItemCaracteristic");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeIncotermCode");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeIncotermCode");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeDutyTaxFeeTypeNameCode");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeDutyTaxFeeTypeNameCode");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeDutyTaxFeeFunctionCodeQualifier");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeDutyTaxFeeFunctionCodeQualifier");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeDutyTaxFeeCategoryCode");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeDutyTaxFeeCategoryCode");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeDocumentName");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeDocumentName");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeDescriptionFormatCode");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeDescriptionFormatCode");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeDateTimePeriodFunctionCodeQualifier");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeDateTimePeriodFunctionCodeQualifier");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeDateTimePeriodFormatCode");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeDateTimePeriodFormatCode");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeContactFunctionCode");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeContactFunctionCode");

            migrationBuilder.DropColumn(
                name: "German",
                schema: "dbo",
                table: "CodeAllowanceOrChargeCodeQualifier");

            migrationBuilder.DropColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeAllowanceOrChargeCodeQualifier");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);
        }
    }
}
