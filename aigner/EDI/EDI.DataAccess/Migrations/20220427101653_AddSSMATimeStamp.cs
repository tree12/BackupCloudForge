using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class AddSSMATimeStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_Order",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeTypePeriodCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeTimeRelationCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeTimeReferenceCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeTextSubjectCodeQualifier",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeTextFunctionCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeTermsOfDeliveryOrTransportFunctionCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeSpecialServicedescriptionCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeReferenceCodeQualifier",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeQuantityTypeCodeQualifier",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodePriceCodeQualifier",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodePercentageTypeCodeQualifier",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodePaymentTermsTypeCodeQualifier",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodePaymentTermsDescriptionIdentifier",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodePartyQualifier",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeMonetaryAmountTypeCodeQualifier",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeMessageFunction",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeLocationFunctionCodeQualifier",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeListResponsibleAgencyCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeListQualifierCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeItemTypeIdentificationCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeItemDescriptionType",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeItemCaracteristic",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeIncotermCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeFreeTextCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDutyTaxFeeTypeNameCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDutyTaxFeeFunctionCodeQualifier",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDutyTaxFeeCategoryCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDocumentName",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDescriptionFormatCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDeliveryPlanStatusIndicator",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDateTimePeriodFunctionCodeQualifier",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDateTimePeriodFormatCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeContactFunctionCode",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeAllowanceOrChargeCodeQualifier",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeActionRequest",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_LineItemSchedule");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_LineItemOrder");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_LineItemInvoice");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeTypePeriodCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeTimeRelationCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeTimeReferenceCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeTextSubjectCodeQualifier");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeTextFunctionCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeTermsOfDeliveryOrTransportFunctionCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeSpecialServicedescriptionCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeReferenceCodeQualifier");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeQuantityTypeCodeQualifier");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodePriceCodeQualifier");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodePercentageTypeCodeQualifier");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodePaymentTermsTypeCodeQualifier");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodePaymentTermsDescriptionIdentifier");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodePartyQualifier");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeMonetaryAmountTypeCodeQualifier");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeMessageFunction");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeLocationFunctionCodeQualifier");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeListResponsibleAgencyCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeListQualifierCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeItemTypeIdentificationCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeItemDescriptionType");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeItemCaracteristic");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeIncotermCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeFreeTextCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDutyTaxFeeTypeNameCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDutyTaxFeeFunctionCodeQualifier");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDutyTaxFeeCategoryCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDocumentName");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDescriptionFormatCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDeliveryPlanStatusIndicator");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDateTimePeriodFunctionCodeQualifier");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeDateTimePeriodFormatCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeContactFunctionCode");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeAllowanceOrChargeCodeQualifier");

            migrationBuilder.DropColumn(
                name: "SSMA_TimeStamp",
                schema: "dbo",
                table: "CodeActionRequest");
        }
    }
}
