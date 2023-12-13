using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class ChangeUsageToInUseAndItemQuantityToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeTypePeriodCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeTimeRelationCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeTimeReferenceCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeTextSubjectCodeQualifier",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeTextFunctionCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeTermsOfDeliveryOrTransportFunctionCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeSpecialServicedescriptionCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeReferenceCodeQualifier",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeQuantityTypeCodeQualifier",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodePriceCodeQualifier",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodePercentageTypeCodeQualifier",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodePaymentTermsTypeCodeQualifier",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodePaymentTermsDescriptionIdentifier",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodePartyQualifier",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeMonetaryAmountTypeCodeQualifier",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeMessageFunction",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeLocationFunctionCodeQualifier",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeListResponsibleAgencyCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeListQualifierCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeItemTypeIdentificationCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeItemDescriptionType",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeItemCaracteristic",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeIncotermCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeFreeTextCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeDutyTaxFeeTypeNameCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeDutyTaxFeeFunctionCodeQualifier",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeDutyTaxFeeCategoryCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeDocumentName",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeDescriptionFormatCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeDeliveryPlanStatusIndicator",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeDateTimePeriodFunctionCodeQualifier",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeDateTimePeriodFormatCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeContactFunctionCode",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeAllowanceOrChargeCodeQualifier",
                newName: "InUse");

            migrationBuilder.RenameColumn(
                name: "Usage",
                schema: "dbo",
                table: "CodeActionRequest",
                newName: "InUse");

            migrationBuilder.AlterColumn<decimal>(
                name: "ItemQuantity",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ItemQuantity",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ItemQuantity",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ItemQuantity",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeTypePeriodCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeTimeRelationCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeTimeReferenceCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeTextSubjectCodeQualifier",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeTextFunctionCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeTermsOfDeliveryOrTransportFunctionCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeSpecialServicedescriptionCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeReferenceCodeQualifier",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeQuantityTypeCodeQualifier",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodePriceCodeQualifier",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodePercentageTypeCodeQualifier",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodePaymentTermsTypeCodeQualifier",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodePaymentTermsDescriptionIdentifier",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodePartyQualifier",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeMonetaryAmountTypeCodeQualifier",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeMessageFunction",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeLocationFunctionCodeQualifier",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeListResponsibleAgencyCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeListQualifierCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeItemTypeIdentificationCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeItemDescriptionType",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeItemCaracteristic",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeIncotermCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeFreeTextCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeDutyTaxFeeTypeNameCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeDutyTaxFeeFunctionCodeQualifier",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeDutyTaxFeeCategoryCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeDocumentName",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeDescriptionFormatCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeDeliveryPlanStatusIndicator",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeDateTimePeriodFunctionCodeQualifier",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeDateTimePeriodFormatCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeContactFunctionCode",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeAllowanceOrChargeCodeQualifier",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "InUse",
                schema: "dbo",
                table: "CodeActionRequest",
                newName: "Usage");

            migrationBuilder.AlterColumn<int>(
                name: "ItemQuantity",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemQuantity",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemQuantity",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemQuantity",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
