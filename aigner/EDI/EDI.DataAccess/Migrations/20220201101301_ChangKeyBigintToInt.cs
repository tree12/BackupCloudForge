using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class ChangKeyBigintToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //check if table exists
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_ScheduleCondition_EDI_Quantity_QuantityId", table: "EDI_ScheduleCondition");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_SupplierId", table: "EDI_ScheduleAgreement");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_RecipientId", table: "EDI_ScheduleAgreement");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_DeliveryRecipientId", table: "EDI_ScheduleAgreement");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_BuyerId", table: "EDI_ScheduleAgreement");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_ScheduleAgreement_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId", table: "EDI_ScheduleAgreement");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_PaymentTerm_EDI_ScheduleAgreement_EdiScheduleAgreementId", table: "EDI_PaymentTerm");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_PaymentTerm_EDI_OrderConfirmation_EdiOrderConfirmationId", table: "EDI_PaymentTerm");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_PaymentTerm_EDI_OrderChange_EdiOrderChangeId", table: "EDI_PaymentTerm");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_PaymentTerm_EDI_Order_EdiOrderId", table: "EDI_PaymentTerm");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_PaymentTerm_EDI_Invoice_EdiInvoiceId", table: "EDI_PaymentTerm");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_OrderConfirmation_EDI_NameAndAddress_SupplierId", table: "EDI_OrderConfirmation");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_OrderConfirmation_EDI_NameAndAddress_DeliveryRecipientId", table: "EDI_OrderConfirmation");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_OrderConfirmation_EDI_NameAndAddress_BuyerId", table: "EDI_OrderConfirmation");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_OrderConfirmation_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId", table: "EDI_OrderConfirmation");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_OrderChange_EDI_NameAndAddress_SupplierId", table: "EDI_OrderChange");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_OrderChange_EDI_NameAndAddress_DeliveryRecipientId", table: "EDI_OrderChange");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_OrderChange_EDI_NameAndAddress_BuyerId", table: "EDI_OrderChange");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_OrderChange_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId", table: "EDI_OrderChange");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_Order_EDI_NameAndAddress_SupplierId", table: "EDI_Order");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_Order_EDI_NameAndAddress_DeliveryRecipientId", table: "EDI_Order");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_Order_EDI_NameAndAddress_BuyerId", table: "EDI_Order");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_Order_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId", table: "EDI_Order");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_NameAndAddress_EDI_PlaceLocation_LocationId", table: "EDI_NameAndAddress");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_NameAndAddress_EDI_FinancialInstitution_FinancialInstitutionId", table: "EDI_NameAndAddress");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_NameAndAddress_EDI_Contact_ContactId", table: "EDI_NameAndAddress");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_LineItem_EDI_ScheduleCondition_ScheduleConditionId", table: "EDI_LineItem");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_LineItem_EDI_ScheduleAgreement_EdiScheduleAgreementId", table: "EDI_LineItem");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_LineItem_EDI_Quantity_ScheduledQuantityId", table: "EDI_LineItem");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_LineItem_EDI_Quantity_ReceivedQuantityId", table: "EDI_LineItem");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_LineItem_EDI_Quantity_QuantityId", table: "EDI_LineItem");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_LineItem_EDI_Quantity_BackorderedQuantityId", table: "EDI_LineItem");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_LineItem_EDI_OrderConfirmation_EdiOrderConfirmationId", table: "EDI_LineItem");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_LineItem_EDI_OrderChange_EdiOrderChangeId", table: "EDI_LineItem");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_LineItem_EDI_Order_EdiOrderId", table: "EDI_LineItem");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_LineItem_EDI_Invoice_EdiInvoiceId", table: "EDI_LineItem");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_Invoice_EDI_NameAndAddress_SupplierId", table: "EDI_Invoice");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_Invoice_EDI_NameAndAddress_InvoiceeId", table: "EDI_Invoice");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_Invoice_EDI_NameAndAddress_DeliveryRecipientId", table: "EDI_Invoice");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_Invoice_EDI_NameAndAddress_BuyerId", table: "EDI_Invoice");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_Invoice_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId", table: "EDI_Invoice");
            //migrationBuilder.DropCheckConstraint(name: "FK_EDI_DeliveryOrTransportTerm_EDI_PlaceLocation_LocationId", table: "EDI_DeliveryOrTransportTerm");

            //migrationBuilder.DropTable(name: "RequestLog");
            //migrationBuilder.DropTable(name: "EDI_ScheduleCondition");
            //migrationBuilder.DropTable(name: "EDI_ScheduleAgreement");
            //migrationBuilder.DropTable(name: "EDI_Quantity");
            //migrationBuilder.DropTable(name: "EDI_PlaceLocation");
            //migrationBuilder.DropTable(name: "EDI_PaymentTerm");
            //migrationBuilder.DropTable(name: "EDI_OrderConfirmation");
            //migrationBuilder.DropTable(name: "EDI_OrderChange");
            //migrationBuilder.DropTable(name: "EDI_Order");
            //migrationBuilder.DropTable(name: "EDI_NameAndAddress");
            //migrationBuilder.DropTable(name: "EDI_LineItem");
            //migrationBuilder.DropTable(name: "EDI_Invoice");
            //migrationBuilder.DropTable(name: "EDI_FinancialInstitution");
            //migrationBuilder.DropTable(name: "EDI_DeliveryOrTransportTerm");
            //migrationBuilder.DropTable(name: "EDI_Contact");
            //migrationBuilder.DropTable(name: "AuditLogs");
            //migrationBuilder.DropTable(name: "CodeTypePeriodCode");
            //migrationBuilder.DropTable(name: "CodeTimeRelationCode");
            //migrationBuilder.DropTable(name: "CodeTimeReferenceCode");
            //migrationBuilder.DropTable(name: "CodeTextSubjectCodeQualifier");
            //migrationBuilder.DropTable(name: "CodeTermsOfDeliveryOrTransportFunctionCode");
            //migrationBuilder.DropTable(name: "CodeSpecialServicedescriptionCode");
            //migrationBuilder.DropTable(name: "CodeReferenceCodeQualifier");
            //migrationBuilder.DropTable(name: "CodeQuantityTypeCodeQualifier");
            //migrationBuilder.DropTable(name: "CodePriceCodeQualifier");
            //migrationBuilder.DropTable(name: "CodePercentageTypeCodeQualifier");
            //migrationBuilder.DropTable(name: "CodePaymentTermsTypeCodeQualifier");
            //migrationBuilder.DropTable(name: "CodePaymentTermsDescriptionIdentifier");
            //migrationBuilder.DropTable(name: "CodeMonetaryAmountTypeCodeQualifier");
            //migrationBuilder.DropTable(name: "CodeLocationFunctionCodeQualifier");
            //migrationBuilder.DropTable(name: "CodeItemTypeIdentificationCode");
            //migrationBuilder.DropTable(name: "CodeDutyTaxFeeTypeNameCode");
            //migrationBuilder.DropTable(name: "CodeDutyTaxFeeFunctionCodeQualifier");
            //migrationBuilder.DropTable(name: "CodeDutyTaxFeeCategoryCode");
            //migrationBuilder.DropTable(name: "CodeDescriptionFormatCode");
            //migrationBuilder.DropTable(name: "CodeDateTimePeriodFunctionCodeQualifier");
            //migrationBuilder.DropTable(name: "CodeDateTimePeriodFormatCode");
            //migrationBuilder.DropTable(name: "CodeAllowanceOrChargeCodeQualifier");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityType = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeAllowanceOrChargeCodeQualifier",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeAllowanceOrChargeCodeQualifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeDateTimePeriodFormatCode",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeDateTimePeriodFormatCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeDateTimePeriodFunctionCodeQualifier",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeDateTimePeriodFunctionCodeQualifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeDescriptionFormatCode",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeDescriptionFormatCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeDutyTaxFeeCategoryCode",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeDutyTaxFeeCategoryCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeDutyTaxFeeFunctionCodeQualifier",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeDutyTaxFeeFunctionCodeQualifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeDutyTaxFeeTypeNameCode",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeDutyTaxFeeTypeNameCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeItemTypeIdentificationCode",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeItemTypeIdentificationCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeLocationFunctionCodeQualifier",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeLocationFunctionCodeQualifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeMonetaryAmountTypeCodeQualifier",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeMonetaryAmountTypeCodeQualifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodePaymentTermsDescriptionIdentifier",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodePaymentTermsDescriptionIdentifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodePaymentTermsTypeCodeQualifier",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodePaymentTermsTypeCodeQualifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodePercentageTypeCodeQualifier",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodePercentageTypeCodeQualifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodePriceCodeQualifier",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodePriceCodeQualifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeQuantityTypeCodeQualifier",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeQuantityTypeCodeQualifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeReferenceCodeQualifier",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeReferenceCodeQualifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeSpecialServicedescriptionCode",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeSpecialServicedescriptionCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeTermsOfDeliveryOrTransportFunctionCode",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTermsOfDeliveryOrTransportFunctionCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeTextSubjectCodeQualifier",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTextSubjectCodeQualifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeTimeReferenceCode",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTimeReferenceCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeTimeRelationCode",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTimeRelationCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeTypePeriodCode",
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTypePeriodCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EDI_Contact",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    PartyQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountHolderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountHolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionBranchNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_FinancialInstitution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EDI_PlaceLocation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceLocationQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceLocationIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    QuantityQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemQuantity = table.Column<int>(type: "int", nullable: true),
                    QTYMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_Quantity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestLog",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identity = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Request = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EDI_DeliveryOrTransportTerm",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FunctionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    PartyQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    ResponsibleAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAndAddressLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    FinancialInstitutionId = table.Column<int>(type: "int", nullable: true),
                    VATRegistrationQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    DeliveryPlanStatusIndicatorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityId = table.Column<int>(type: "int", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EarliestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LatestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "EDI_Invoice",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DutyTaxFeeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DutyTaxFeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DutyTaxFeeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DutyTaxFeeCategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowanceChargeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialServicesCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentageQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonetaryTypeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonetaryAmount = table.Column<int>(type: "int", nullable: true),
                    MonetaryCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowanceDutyTaxFeeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowanceDutyTaxFeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowanceDutyTaxFeeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AllowanceDutyTaxFeeCategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceMonetaryTypeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceMonetaryAmount = table.Column<int>(type: "int", nullable: true),
                    InvoiceMonetaryCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxableMonetaryTypeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxableMonetaryAmount = table.Column<int>(type: "int", nullable: true),
                    TaxableMonetaryCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMonetaryTypeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMonetaryAmount = table.Column<int>(type: "int", nullable: true),
                    TotalMonetaryCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountDutyTaxFeeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountDutyTaxFeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountDutyTaxFeeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AmountDutyTaxFeeCategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumTaxMonetaryTypeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumTaxMonetaryAmount = table.Column<int>(type: "int", nullable: true),
                    SumTaxMonetaryCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumTaxableMonetaryTypeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumTaxableMonetaryAmount = table.Column<int>(type: "int", nullable: true),
                    SumTaxableMonetaryCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceeId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyntaxIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyntaxVersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfPerparation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterchangeControlReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTestMessage = table.Column<bool>(type: "bit", nullable: false),
                    MessageStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DocType = table.Column<int>(type: "int", nullable: false),
                    DocumentNameCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnhMessageReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeVersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeReleaseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllingAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextSubjectqualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeListQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextLiteralFreeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    DeliveryRecipientId = table.Column<int>(type: "int", nullable: true),
                    DeliveryOrTransportTermId = table.Column<int>(type: "int", nullable: true),
                    NumberOfSegment = table.Column<int>(type: "int", nullable: true),
                    MessageReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterchangeControlCount = table.Column<int>(type: "int", nullable: true),
                    UnzInterchangeControlReference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDI_Invoice_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId",
                        column: x => x.DeliveryOrTransportTermId,
                        principalSchema: "dbo",
                        principalTable: "EDI_DeliveryOrTransportTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_Invoice_EDI_NameAndAddress_BuyerId",
                        column: x => x.BuyerId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_Invoice_EDI_NameAndAddress_DeliveryRecipientId",
                        column: x => x.DeliveryRecipientId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_Invoice_EDI_NameAndAddress_InvoiceeId",
                        column: x => x.InvoiceeId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_Invoice_EDI_NameAndAddress_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDI_Order",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyntaxIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyntaxVersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfPerparation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterchangeControlReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTestMessage = table.Column<bool>(type: "bit", nullable: false),
                    MessageStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DocType = table.Column<int>(type: "int", nullable: false),
                    DocumentNameCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnhMessageReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeVersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeReleaseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllingAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextSubjectqualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeListQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextLiteralFreeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    DeliveryRecipientId = table.Column<int>(type: "int", nullable: true),
                    DeliveryOrTransportTermId = table.Column<int>(type: "int", nullable: true),
                    NumberOfSegment = table.Column<int>(type: "int", nullable: true),
                    MessageReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterchangeControlCount = table.Column<int>(type: "int", nullable: true),
                    UnzInterchangeControlReference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDI_Order_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId",
                        column: x => x.DeliveryOrTransportTermId,
                        principalSchema: "dbo",
                        principalTable: "EDI_DeliveryOrTransportTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_Order_EDI_NameAndAddress_BuyerId",
                        column: x => x.BuyerId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_Order_EDI_NameAndAddress_DeliveryRecipientId",
                        column: x => x.DeliveryRecipientId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_Order_EDI_NameAndAddress_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDI_OrderChange",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyntaxIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyntaxVersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfPerparation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterchangeControlReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTestMessage = table.Column<bool>(type: "bit", nullable: false),
                    MessageStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DocType = table.Column<int>(type: "int", nullable: false),
                    DocumentNameCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnhMessageReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeVersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeReleaseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllingAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextSubjectqualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeListQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextLiteralFreeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    DeliveryRecipientId = table.Column<int>(type: "int", nullable: true),
                    DeliveryOrTransportTermId = table.Column<int>(type: "int", nullable: true),
                    NumberOfSegment = table.Column<int>(type: "int", nullable: true),
                    MessageReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterchangeControlCount = table.Column<int>(type: "int", nullable: true),
                    UnzInterchangeControlReference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_OrderChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDI_OrderChange_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId",
                        column: x => x.DeliveryOrTransportTermId,
                        principalSchema: "dbo",
                        principalTable: "EDI_DeliveryOrTransportTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_OrderChange_EDI_NameAndAddress_BuyerId",
                        column: x => x.BuyerId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_OrderChange_EDI_NameAndAddress_DeliveryRecipientId",
                        column: x => x.DeliveryRecipientId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_OrderChange_EDI_NameAndAddress_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDI_OrderConfirmation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyntaxIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyntaxVersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfPerparation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterchangeControlReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTestMessage = table.Column<bool>(type: "bit", nullable: false),
                    MessageStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DocType = table.Column<int>(type: "int", nullable: false),
                    DocumentNameCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnhMessageReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeVersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeReleaseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllingAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextSubjectqualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeListQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextLiteralFreeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    DeliveryRecipientId = table.Column<int>(type: "int", nullable: true),
                    DeliveryOrTransportTermId = table.Column<int>(type: "int", nullable: true),
                    NumberOfSegment = table.Column<int>(type: "int", nullable: true),
                    MessageReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterchangeControlCount = table.Column<int>(type: "int", nullable: true),
                    UnzInterchangeControlReference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_OrderConfirmation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDI_OrderConfirmation_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId",
                        column: x => x.DeliveryOrTransportTermId,
                        principalSchema: "dbo",
                        principalTable: "EDI_DeliveryOrTransportTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_OrderConfirmation_EDI_NameAndAddress_BuyerId",
                        column: x => x.BuyerId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_OrderConfirmation_EDI_NameAndAddress_DeliveryRecipientId",
                        column: x => x.DeliveryRecipientId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_OrderConfirmation_EDI_NameAndAddress_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDI_ScheduleAgreement",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviousDeliveryReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousDeliveryReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousDeliveryReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentDeliveryReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentDeliveryReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentDeliveryReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyntaxIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyntaxVersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfPerparation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterchangeControlReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTestMessage = table.Column<bool>(type: "bit", nullable: false),
                    MessageStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DocType = table.Column<int>(type: "int", nullable: false),
                    DocumentNameCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnhMessageReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeVersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeReleaseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllingAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextSubjectqualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTextCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeListQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextLiteralFreeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    DeliveryRecipientId = table.Column<int>(type: "int", nullable: true),
                    DeliveryOrTransportTermId = table.Column<int>(type: "int", nullable: true),
                    NumberOfSegment = table.Column<int>(type: "int", nullable: true),
                    MessageReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterchangeControlCount = table.Column<int>(type: "int", nullable: true),
                    UnzInterchangeControlReference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_ScheduleAgreement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDI_ScheduleAgreement_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId",
                        column: x => x.DeliveryOrTransportTermId,
                        principalSchema: "dbo",
                        principalTable: "EDI_DeliveryOrTransportTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_BuyerId",
                        column: x => x.BuyerId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_DeliveryRecipientId",
                        column: x => x.DeliveryRecipientId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_RecipientId",
                        column: x => x.RecipientId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "dbo",
                        principalTable: "EDI_NameAndAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDI_LineItem",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNumberType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalProductId = table.Column<int>(type: "int", nullable: true),
                    AdditionalItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalItemNumberType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescriptionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCharacteristicCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescriptionIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeListQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeListResponsibleAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedDeliveryReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedDeliveryReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedDeliveryReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantityId = table.Column<int>(type: "int", nullable: true),
                    ReceivedQuantityId = table.Column<int>(type: "int", nullable: true),
                    BackorderedQuantityId = table.Column<int>(type: "int", nullable: true),
                    ScheduledQuantityId = table.Column<int>(type: "int", nullable: true),
                    TextSubjectQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextFunctionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonetaryTypeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonetaryAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonetaryCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitPriceBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseLineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryLineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceDutyTaxFeeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceTax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDutyTaxFeeRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxCategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxMonetaryTypeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxMonetaryAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxMonetaryCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleConditionId = table.Column<int>(type: "int", nullable: true),
                    EdiInvoiceId = table.Column<int>(type: "INT", nullable: true),
                    EdiOrderChangeId = table.Column<int>(type: "INT", nullable: true),
                    EdiOrderConfirmationId = table.Column<int>(type: "INT", nullable: true),
                    EdiOrderId = table.Column<int>(type: "INT", nullable: true),
                    EdiScheduleAgreementId = table.Column<int>(type: "INT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_LineItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDI_LineItem_EDI_Invoice_EdiInvoiceId",
                        column: x => x.EdiInvoiceId,
                        principalSchema: "dbo",
                        principalTable: "EDI_Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_LineItem_EDI_Order_EdiOrderId",
                        column: x => x.EdiOrderId,
                        principalSchema: "dbo",
                        principalTable: "EDI_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_LineItem_EDI_OrderChange_EdiOrderChangeId",
                        column: x => x.EdiOrderChangeId,
                        principalSchema: "dbo",
                        principalTable: "EDI_OrderChange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_LineItem_EDI_OrderConfirmation_EdiOrderConfirmationId",
                        column: x => x.EdiOrderConfirmationId,
                        principalSchema: "dbo",
                        principalTable: "EDI_OrderConfirmation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_LineItem_EDI_Quantity_BackorderedQuantityId",
                        column: x => x.BackorderedQuantityId,
                        principalSchema: "dbo",
                        principalTable: "EDI_Quantity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_LineItem_EDI_Quantity_QuantityId",
                        column: x => x.QuantityId,
                        principalSchema: "dbo",
                        principalTable: "EDI_Quantity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_LineItem_EDI_Quantity_ReceivedQuantityId",
                        column: x => x.ReceivedQuantityId,
                        principalSchema: "dbo",
                        principalTable: "EDI_Quantity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_LineItem_EDI_Quantity_ScheduledQuantityId",
                        column: x => x.ScheduledQuantityId,
                        principalSchema: "dbo",
                        principalTable: "EDI_Quantity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_LineItem_EDI_ScheduleAgreement_EdiScheduleAgreementId",
                        column: x => x.EdiScheduleAgreementId,
                        principalSchema: "dbo",
                        principalTable: "EDI_ScheduleAgreement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_LineItem_EDI_ScheduleCondition_ScheduleConditionId",
                        column: x => x.ScheduleConditionId,
                        principalSchema: "dbo",
                        principalTable: "EDI_ScheduleCondition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDI_PaymentTerm",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsOfPaymentIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsOfpayment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeReferenceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeRelationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPeriod = table.Column<int>(type: "int", nullable: true),
                    PercentageQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EdiInvoiceId = table.Column<int>(type: "INT", nullable: true),
                    EdiOrderChangeId = table.Column<int>(type: "INT", nullable: true),
                    EdiOrderConfirmationId = table.Column<int>(type: "INT", nullable: true),
                    EdiOrderId = table.Column<int>(type: "INT", nullable: true),
                    EdiScheduleAgreementId = table.Column<int>(type: "INT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_PaymentTerm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDI_PaymentTerm_EDI_Invoice_EdiInvoiceId",
                        column: x => x.EdiInvoiceId,
                        principalSchema: "dbo",
                        principalTable: "EDI_Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_PaymentTerm_EDI_Order_EdiOrderId",
                        column: x => x.EdiOrderId,
                        principalSchema: "dbo",
                        principalTable: "EDI_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_PaymentTerm_EDI_OrderChange_EdiOrderChangeId",
                        column: x => x.EdiOrderChangeId,
                        principalSchema: "dbo",
                        principalTable: "EDI_OrderChange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_PaymentTerm_EDI_OrderConfirmation_EdiOrderConfirmationId",
                        column: x => x.EdiOrderConfirmationId,
                        principalSchema: "dbo",
                        principalTable: "EDI_OrderConfirmation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDI_PaymentTerm_EDI_ScheduleAgreement_EdiScheduleAgreementId",
                        column: x => x.EdiScheduleAgreementId,
                        principalSchema: "dbo",
                        principalTable: "EDI_ScheduleAgreement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_EntityType",
                schema: "dbo",
                table: "AuditLogs",
                column: "EntityType");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_DeliveryOrTransportTerm_LocationId",
                schema: "dbo",
                table: "EDI_DeliveryOrTransportTerm",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_Invoice_BuyerId",
                schema: "dbo",
                table: "EDI_Invoice",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_Invoice_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_Invoice",
                column: "DeliveryOrTransportTermId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_Invoice_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_Invoice",
                column: "DeliveryRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_Invoice_InvoiceeId",
                schema: "dbo",
                table: "EDI_Invoice",
                column: "InvoiceeId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_Invoice_SupplierId",
                schema: "dbo",
                table: "EDI_Invoice",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItem_BackorderedQuantityId",
                schema: "dbo",
                table: "EDI_LineItem",
                column: "BackorderedQuantityId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItem_EdiInvoiceId",
                schema: "dbo",
                table: "EDI_LineItem",
                column: "EdiInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItem_EdiOrderChangeId",
                schema: "dbo",
                table: "EDI_LineItem",
                column: "EdiOrderChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItem_EdiOrderConfirmationId",
                schema: "dbo",
                table: "EDI_LineItem",
                column: "EdiOrderConfirmationId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItem_EdiOrderId",
                schema: "dbo",
                table: "EDI_LineItem",
                column: "EdiOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItem_EdiScheduleAgreementId",
                schema: "dbo",
                table: "EDI_LineItem",
                column: "EdiScheduleAgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItem_QuantityId",
                schema: "dbo",
                table: "EDI_LineItem",
                column: "QuantityId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItem_ReceivedQuantityId",
                schema: "dbo",
                table: "EDI_LineItem",
                column: "ReceivedQuantityId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItem_ScheduleConditionId",
                schema: "dbo",
                table: "EDI_LineItem",
                column: "ScheduleConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItem_ScheduledQuantityId",
                schema: "dbo",
                table: "EDI_LineItem",
                column: "ScheduledQuantityId");

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
                name: "IX_EDI_Order_BuyerId",
                schema: "dbo",
                table: "EDI_Order",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_Order_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_Order",
                column: "DeliveryOrTransportTermId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_Order_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_Order",
                column: "DeliveryRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_Order_SupplierId",
                schema: "dbo",
                table: "EDI_Order",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_OrderChange_BuyerId",
                schema: "dbo",
                table: "EDI_OrderChange",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_OrderChange_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_OrderChange",
                column: "DeliveryOrTransportTermId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_OrderChange_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_OrderChange",
                column: "DeliveryRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_OrderChange_SupplierId",
                schema: "dbo",
                table: "EDI_OrderChange",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_OrderConfirmation_BuyerId",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_OrderConfirmation_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                column: "DeliveryOrTransportTermId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_OrderConfirmation_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                column: "DeliveryRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_OrderConfirmation_SupplierId",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                column: "SupplierId");

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

            migrationBuilder.CreateIndex(
                name: "IX_EDI_ScheduleAgreement_BuyerId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_ScheduleAgreement_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                column: "DeliveryOrTransportTermId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_ScheduleAgreement_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                column: "DeliveryRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_ScheduleAgreement_RecipientId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_ScheduleAgreement_SupplierId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_ScheduleCondition_QuantityId",
                schema: "dbo",
                table: "EDI_ScheduleCondition",
                column: "QuantityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeAllowanceOrChargeCodeQualifier",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeDateTimePeriodFormatCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeDateTimePeriodFunctionCodeQualifier",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeDescriptionFormatCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeDutyTaxFeeCategoryCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeDutyTaxFeeFunctionCodeQualifier",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeDutyTaxFeeTypeNameCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeItemTypeIdentificationCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeLocationFunctionCodeQualifier",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeMonetaryAmountTypeCodeQualifier",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodePaymentTermsDescriptionIdentifier",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodePaymentTermsTypeCodeQualifier",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodePercentageTypeCodeQualifier",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodePriceCodeQualifier",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeQuantityTypeCodeQualifier",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeReferenceCodeQualifier",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeSpecialServicedescriptionCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeTermsOfDeliveryOrTransportFunctionCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeTextSubjectCodeQualifier",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeTimeReferenceCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeTimeRelationCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeTypePeriodCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_LineItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_PaymentTerm",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RequestLog",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_ScheduleCondition",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_Invoice",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_Order",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_OrderChange",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_OrderConfirmation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_ScheduleAgreement",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_Quantity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_DeliveryOrTransportTerm",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_NameAndAddress",
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
        }
    }
}
