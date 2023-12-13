using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class FlattenLineItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EDI_LineItem",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "EDI_LineItemChange",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionRequestCoded = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    QuantityQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemQuantity = table.Column<int>(type: "int", nullable: true),
                    QTYMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextSubjectQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextFunctionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitPriceBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryPlanStatusIndicatorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleQuantityQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleItemQuantity = table.Column<int>(type: "int", nullable: true),
                    ScheduleQTYMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EdiOrderChangeId = table.Column<int>(type: "INT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "EDI_LineItemConfirmation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionRequestCoded = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    QuantityQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemQuantity = table.Column<int>(type: "int", nullable: true),
                    QTYMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitPriceBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseLineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryPlanStatusIndicatorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleQuantityQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleItemQuantity = table.Column<int>(type: "int", nullable: true),
                    ScheduleQTYMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EdiOrderConfirmationId = table.Column<int>(type: "INT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_LineItemConfirmation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDI_LineItemConfirmation_EDI_OrderConfirmation_EdiOrderConfirmationId",
                        column: x => x.EdiOrderConfirmationId,
                        principalSchema: "dbo",
                        principalTable: "EDI_OrderConfirmation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDI_LineItemInvoice",
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
                    QuantityQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemQuantity = table.Column<int>(type: "int", nullable: true),
                    QTYMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextSubjectQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    EdiInvoiceId = table.Column<int>(type: "INT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_LineItemInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDI_LineItemInvoice_EDI_Invoice_EdiInvoiceId",
                        column: x => x.EdiInvoiceId,
                        principalSchema: "dbo",
                        principalTable: "EDI_Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDI_LineItemOrder",
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
                    QuantityQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemQuantity = table.Column<int>(type: "int", nullable: true),
                    QTYMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextSubjectQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextFunctionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitPriceBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryPlanStatusIndicatorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleQuantityQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleItemQuantity = table.Column<int>(type: "int", nullable: true),
                    ScheduleQTYMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EdiOrderId = table.Column<int>(type: "INT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDI_LineItemOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDI_LineItemOrder_EDI_Order_EdiOrderId",
                        column: x => x.EdiOrderId,
                        principalSchema: "dbo",
                        principalTable: "EDI_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDI_LineItemSchedule",
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
                    QuantityQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemQuantity = table.Column<int>(type: "int", nullable: true),
                    QTYMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedQuantityQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedItemQuantity = table.Column<int>(type: "int", nullable: true),
                    ReceivedQTYMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackorderedQuantityQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackorderedItemQuantity = table.Column<int>(type: "int", nullable: true),
                    BackorderedQTYMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduledQuantityQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduledItemQuantity = table.Column<int>(type: "int", nullable: true),
                    ScheduledQTYMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryPlanStatusIndicatorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryRequirementsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrequencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EarliestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LatestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_EDI_LineItemSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDI_LineItemSchedule_EDI_ScheduleAgreement_EdiScheduleAgreementId",
                        column: x => x.EdiScheduleAgreementId,
                        principalSchema: "dbo",
                        principalTable: "EDI_ScheduleAgreement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItemChange_EdiOrderChangeId",
                schema: "dbo",
                table: "EDI_LineItemChange",
                column: "EdiOrderChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItemConfirmation_EdiOrderConfirmationId",
                schema: "dbo",
                table: "EDI_LineItemConfirmation",
                column: "EdiOrderConfirmationId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItemInvoice_EdiInvoiceId",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                column: "EdiInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItemOrder_EdiOrderId",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                column: "EdiOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_EDI_LineItemSchedule_EdiScheduleAgreementId",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                column: "EdiScheduleAgreementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EDI_LineItemChange",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_LineItemConfirmation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_LineItemInvoice",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_LineItemOrder",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EDI_LineItemSchedule",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "EDI_LineItem",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalItemNumberType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalProductId = table.Column<int>(type: "int", nullable: true),
                    BackorderedQuantityId = table.Column<int>(type: "int", nullable: true),
                    CodeListQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeListResponsibleAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryLineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdiInvoiceId = table.Column<int>(type: "INT", nullable: true),
                    EdiOrderChangeId = table.Column<int>(type: "INT", nullable: true),
                    EdiOrderConfirmationId = table.Column<int>(type: "INT", nullable: true),
                    EdiOrderId = table.Column<int>(type: "INT", nullable: true),
                    EdiScheduleAgreementId = table.Column<int>(type: "INT", nullable: true),
                    FreeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDutyTaxFeeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDutyTaxFeeRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceTax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCharacteristicCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescriptionIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescriptionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNumberType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonetaryAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonetaryCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonetaryTypeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceMeasureUnitQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseLineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityId = table.Column<int>(type: "int", nullable: true),
                    ReceivedDeliveryReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceivedDeliveryReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedDeliveryReferenceQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedQuantityId = table.Column<int>(type: "int", nullable: true),
                    ScheduleConditionId = table.Column<int>(type: "int", nullable: true),
                    ScheduledQuantityId = table.Column<int>(type: "int", nullable: true),
                    TaxCategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxMonetaryAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxMonetaryCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxMonetaryTypeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextFunctionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextSubjectQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPriceBasis = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
        }
    }
}
