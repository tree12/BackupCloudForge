using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class FlattenOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EDI_Invoice_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_Invoice_EDI_NameAndAddress_BuyerId",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_Invoice_EDI_NameAndAddress_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_Invoice_EDI_NameAndAddress_SupplierId",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_Order_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_Order_EDI_NameAndAddress_BuyerId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_Order_EDI_NameAndAddress_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_Order_EDI_NameAndAddress_SupplierId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_OrderChange_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_OrderChange_EDI_NameAndAddress_BuyerId",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_OrderChange_EDI_NameAndAddress_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_OrderChange_EDI_NameAndAddress_SupplierId",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_OrderConfirmation_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_OrderConfirmation_EDI_NameAndAddress_BuyerId",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_OrderConfirmation_EDI_NameAndAddress_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_OrderConfirmation_EDI_NameAndAddress_SupplierId",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_ScheduleAgreement_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_BuyerId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropForeignKey(
                name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_SupplierId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropIndex(
                name: "IX_EDI_ScheduleAgreement_BuyerId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropIndex(
                name: "IX_EDI_ScheduleAgreement_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropIndex(
                name: "IX_EDI_ScheduleAgreement_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropIndex(
                name: "IX_EDI_ScheduleAgreement_SupplierId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropIndex(
                name: "IX_EDI_OrderConfirmation_BuyerId",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropIndex(
                name: "IX_EDI_OrderConfirmation_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropIndex(
                name: "IX_EDI_OrderConfirmation_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropIndex(
                name: "IX_EDI_OrderConfirmation_SupplierId",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropIndex(
                name: "IX_EDI_OrderChange_BuyerId",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropIndex(
                name: "IX_EDI_OrderChange_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropIndex(
                name: "IX_EDI_OrderChange_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropIndex(
                name: "IX_EDI_OrderChange_SupplierId",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropIndex(
                name: "IX_EDI_Order_BuyerId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropIndex(
                name: "IX_EDI_Order_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropIndex(
                name: "IX_EDI_Order_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropIndex(
                name: "IX_EDI_Order_SupplierId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropIndex(
                name: "IX_EDI_Invoice_BuyerId",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropIndex(
                name: "IX_EDI_Invoice_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropIndex(
                name: "IX_EDI_Invoice_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropIndex(
                name: "IX_EDI_Invoice_SupplierId",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.AddColumn<string>(
                name: "Buyer_ContactCode",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_Email",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_Name",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_PartyId",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_PartyQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_Phone",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_CityName",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_CompanyName",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_CountryCode",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyId",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyName1",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyName2",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_Postcode",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery_Street",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentTerm1_Percentage",
                schema: "dbo",
                table: "EDI_Order",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm1_PercentageQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentTerm2_Percentage",
                schema: "dbo",
                table: "EDI_Order",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm2_PercentageQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_CityName",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_CompanyName",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_CountryCode",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_PartyId",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_PartyName1",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_PartyQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_Postcode",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_Street",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buyer_ContactCode",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Buyer_Email",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Buyer_Name",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Buyer_PartyId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Buyer_PartyQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Buyer_Phone",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Buyer_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery_CityName",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery_CompanyName",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery_CountryCode",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyName1",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyName2",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery_Postcode",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery_Street",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_Percentage",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm1_PercentageQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_Percentage",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "PaymentTerm2_PercentageQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Supplier_CityName",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Supplier_CompanyName",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Supplier_CountryCode",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Supplier_PartyId",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Supplier_PartyName1",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Supplier_PartyQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Supplier_Postcode",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Supplier_ResponsibleAgency",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Supplier_Street",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                schema: "dbo",
                table: "EDI_Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                schema: "dbo",
                table: "EDI_Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "int",
                nullable: true);

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
                name: "IX_EDI_ScheduleAgreement_SupplierId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
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
                name: "IX_EDI_Invoice_SupplierId",
                schema: "dbo",
                table: "EDI_Invoice",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_Invoice_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_Invoice",
                column: "DeliveryOrTransportTermId",
                principalSchema: "dbo",
                principalTable: "EDI_DeliveryOrTransportTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_Invoice_EDI_NameAndAddress_BuyerId",
                schema: "dbo",
                table: "EDI_Invoice",
                column: "BuyerId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_Invoice_EDI_NameAndAddress_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_Invoice",
                column: "DeliveryRecipientId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_Invoice_EDI_NameAndAddress_SupplierId",
                schema: "dbo",
                table: "EDI_Invoice",
                column: "SupplierId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_Order_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_Order",
                column: "DeliveryOrTransportTermId",
                principalSchema: "dbo",
                principalTable: "EDI_DeliveryOrTransportTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_Order_EDI_NameAndAddress_BuyerId",
                schema: "dbo",
                table: "EDI_Order",
                column: "BuyerId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_Order_EDI_NameAndAddress_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_Order",
                column: "DeliveryRecipientId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_Order_EDI_NameAndAddress_SupplierId",
                schema: "dbo",
                table: "EDI_Order",
                column: "SupplierId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_OrderChange_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_OrderChange",
                column: "DeliveryOrTransportTermId",
                principalSchema: "dbo",
                principalTable: "EDI_DeliveryOrTransportTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_OrderChange_EDI_NameAndAddress_BuyerId",
                schema: "dbo",
                table: "EDI_OrderChange",
                column: "BuyerId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_OrderChange_EDI_NameAndAddress_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_OrderChange",
                column: "DeliveryRecipientId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_OrderChange_EDI_NameAndAddress_SupplierId",
                schema: "dbo",
                table: "EDI_OrderChange",
                column: "SupplierId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_OrderConfirmation_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                column: "DeliveryOrTransportTermId",
                principalSchema: "dbo",
                principalTable: "EDI_DeliveryOrTransportTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_OrderConfirmation_EDI_NameAndAddress_BuyerId",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                column: "BuyerId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_OrderConfirmation_EDI_NameAndAddress_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                column: "DeliveryRecipientId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_OrderConfirmation_EDI_NameAndAddress_SupplierId",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                column: "SupplierId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_ScheduleAgreement_EDI_DeliveryOrTransportTerm_DeliveryOrTransportTermId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                column: "DeliveryOrTransportTermId",
                principalSchema: "dbo",
                principalTable: "EDI_DeliveryOrTransportTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_BuyerId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                column: "BuyerId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_DeliveryRecipientId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                column: "DeliveryRecipientId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EDI_ScheduleAgreement_EDI_NameAndAddress_SupplierId",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                column: "SupplierId",
                principalSchema: "dbo",
                principalTable: "EDI_NameAndAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
