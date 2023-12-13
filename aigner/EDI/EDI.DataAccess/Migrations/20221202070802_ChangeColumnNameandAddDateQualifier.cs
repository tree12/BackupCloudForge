using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class ChangeColumnNameandAddDateQualifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /***EDI_ScheduleAgreement***/
            migrationBuilder.DropColumn(
                name: "Delivery_PartyName1",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyName2",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            /***EDI_OrderConfirmation***/
            migrationBuilder.DropColumn(
                name: "Delivery_PartyName1",
                schema: "dbo",
                table: "EDI_OrderConfirmation");
            migrationBuilder.DropColumn(
                name: "Delivery_PartyName2",
                schema: "dbo",
                table: "EDI_OrderConfirmation");
            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_FunctionCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "TermsOfDeliveryFunctionCode");
            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "TermsOfDeliveryIncoterms");
            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "TermsOfDeliveryPlaceLocationQualifier");
            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "TermsOfDeliveryPlaceLocationIdentification");

            /***EDI_Order***/
            migrationBuilder.DropColumn(
                name: "Delivery_PartyName1",
                schema: "dbo",
                table: "EDI_Order");
            migrationBuilder.DropColumn(
                name: "Delivery_PartyName2",
                schema: "dbo",
                table: "EDI_Order");
            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_FunctionCode",
                schema: "dbo",
                table: "EDI_Order",
                newName: "TermsOfDeliveryFunctionCode");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_Order",
                newName: "TermsOfDeliveryIncoterms");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "TermsOfDeliveryPlaceLocationQualifier");
            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Order",
                newName: "TermsOfDeliveryPlaceLocationIdentification");

            /***EDI_Invoice***/
            migrationBuilder.DropColumn(
                name: "Delivery_PartyName1",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyName2",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_FunctionCode",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "TermsOfDeliveryFunctionCode");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "TermsOfDeliveryIncoterms");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "TermsOfDeliveryPlaceLocationIdentification");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "TermsOfDeliveryPlaceLocationQualifier");

            migrationBuilder.DropColumn(
                name: "DeliveryReferenceDate",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "DeliveryReferenceNumber",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "DeliveryReferenceQualifier",
                schema: "dbo",
                table: "EDI_Invoice");

            /****EDI_DeliveryNote****/
            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_DeliveryNote",
                newName: "TermsOfDeliveryIncoterms");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_FunctionCode",
                schema: "dbo",
                table: "EDI_DeliveryNote",
                newName: "TermsOfDeliveryFunctionCode");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyName2",
                schema: "dbo",
                table: "EDI_DeliveryNote");

            migrationBuilder.DropColumn(
                name: "Delivery_PartyName1",
                schema: "dbo",
                table: "EDI_DeliveryNote");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_DeliveryNote",
                newName: "TermsOfDeliveryPlaceLocationQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_DeliveryNote",
                newName: "TermsOfDeliveryPlaceLocationIdentification");

            /*****EDI_LineItemSchedule*****/
            migrationBuilder.RenameColumn(
                name: "ItemNumberType",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                newName: "BuyersArticleNumberType");

            migrationBuilder.RenameColumn(
                name: "ItemNumber",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                newName: "BuyersArticleNumber");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryDateFormat",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                type: "nvarchar(max)",
                nullable: true);

            /*****EDI_LineItemOrderConfirmation****/
            migrationBuilder.RenameColumn(
                name: "ItemNumberType",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                newName: "BuyersArticleNumberType");

            migrationBuilder.RenameColumn(
                name: "ItemNumber",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                newName: "BuyersArticleNumber");

            migrationBuilder.AddColumn<string>(
                name: "PurchaseDateFormat",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryDateFormat",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            /*****EDI_LineItemOrder*****/
            migrationBuilder.RenameColumn(
                name: "ItemNumberType",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                newName: "BuyersArticleNumberType");

            migrationBuilder.RenameColumn(
                name: "ItemNumber",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                newName: "BuyersArticleNumber");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryDateFormat",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "nvarchar(max)",
                nullable: true);

            /*****EDI_LineItemInvoice*****/
            migrationBuilder.RenameColumn(
                name: "ItemNumberType",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                newName: "BuyersArticleNumberType");

            migrationBuilder.RenameColumn(
                name: "ItemNumber",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                newName: "BuyersArticleNumber");

            migrationBuilder.AddColumn<string>(
                name: "PurchaseDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseDateFormat",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryDateFormat",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                type: "nvarchar(max)",
                nullable: true);

            /******EDI_LineItemDeliveryNote******/
            migrationBuilder.RenameColumn(
                name: "ItemNumberType",
                schema: "dbo",
                table: "EDI_LineItemDeliveryNote",
                newName: "BuyersArticleNumberType");

            migrationBuilder.RenameColumn(
                name: "ItemNumber",
                schema: "dbo",
                table: "EDI_LineItemDeliveryNote",
                newName: "BuyersArticleNumber");

            migrationBuilder.AddColumn<string>(
                name: "PurchaseDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemDeliveryNote",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseDateFormat",
                schema: "dbo",
                table: "EDI_LineItemDeliveryNote",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryDateFormat",
                schema: "dbo",
                table: "EDI_LineItemDeliveryNote",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemDeliveryNote",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

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

            /***EDI_OrderConfirmation***/
            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyName1",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyName2",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);
            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryFunctionCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "DeliveryCondition1_FunctionCode");
            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryIncoterms",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "DeliveryCondition1_Code");
            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryPlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "DeliveryCondition1_PlaceLocationQualifier");
            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryPlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "DeliveryCondition1_PlaceLocationIdentification");

            /***EDI_Order***/
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

            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryFunctionCode",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition1_FunctionCode");

            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryIncoterms",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition1_Code");

            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryPlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition1_PlaceLocationQualifier");
            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryPlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition1_PlaceLocationIdentification");

            /***EDI_Invoice***/
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

            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryFunctionCode",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "DeliveryCondition1_FunctionCode");

            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryIncoterms",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "DeliveryCondition1_Code");

            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryPlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "DeliveryCondition1_PlaceLocationIdentification");

            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryPlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "DeliveryCondition1_PlaceLocationQualifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryReferenceDate",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeliveryReferenceNumber",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryReferenceQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            /****EDI_DeliveryNote****/
            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryIncoterms",
                schema: "dbo",
                table: "EDI_DeliveryNote",
                newName: "DeliveryCondition1_Code");

            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryFunctionCode",
                schema: "dbo",
                table: "EDI_DeliveryNote",
                newName: "DeliveryCondition1_FunctionCode");

            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyName1",
                schema: "dbo",
                table: "EDI_DeliveryNote",
                type: "nvarchar(max)",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Delivery_PartyName2",
                schema: "dbo",
                table: "EDI_DeliveryNote",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryPlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_DeliveryNote",
                newName: "DeliveryCondition1_PlaceLocationQualifier");

            migrationBuilder.RenameColumn(
                name: "TermsOfDeliveryPlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_DeliveryNote",
                newName: "DeliveryCondition1_PlaceLocationIdentification");

            /*****EDI_LineItemSchedule*****/
            migrationBuilder.RenameColumn(
                name: "BuyersArticleNumberType",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                newName: "ItemNumberType");

            migrationBuilder.RenameColumn(
                name: "BuyersArticleNumber",
                schema: "dbo",
                table: "EDI_LineItemSchedule",
                newName: "ItemNumber");

            migrationBuilder.DropColumn(
                name: "DeliveryDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemSchedule");
            migrationBuilder.DropColumn(
                name: "DeliveryDateFormat",
                schema: "dbo",
                table: "EDI_LineItemSchedule");

            /*****EDI_LineItemOrderConfirmation****/
            migrationBuilder.RenameColumn(
                name: "BuyersArticleNumberType",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                newName: "ItemNumberType");

            migrationBuilder.RenameColumn(
                name: "BuyersArticleNumber",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation",
                newName: "ItemNumber");

            migrationBuilder.DropColumn(
                name: "PurchaseDateFormat",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation");
            migrationBuilder.DropColumn(
                name: "PurchaseDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation");

            migrationBuilder.DropColumn(
                name: "DeliveryDateFormat",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation");
            migrationBuilder.DropColumn(
                name: "DeliveryDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemOrderConfirmation");

            /*****EDI_LineItemOrder*****/
            migrationBuilder.RenameColumn(
                name: "BuyersArticleNumberType",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                newName: "ItemNumberType");

            migrationBuilder.RenameColumn(
                name: "BuyersArticleNumber",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                newName: "ItemNumber");

            migrationBuilder.DropColumn(
                name: "DeliveryDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemOrder");

            migrationBuilder.DropColumn(
                name: "DeliveryDateFormat",
                schema: "dbo",
                table: "EDI_LineItemOrder");

            /*****EDI_LineItemInvoice*****/
            migrationBuilder.RenameColumn(
                name: "BuyersArticleNumberType",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                newName: "ItemNumberType");

            migrationBuilder.RenameColumn(
                name: "BuyersArticleNumber",
                schema: "dbo",
                table: "EDI_LineItemInvoice",
                newName: "ItemNumber");

            migrationBuilder.DropColumn(
                name: "PurchaseDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemInvoice");

            migrationBuilder.DropColumn(
                name: "PurchaseDateFormat",
                schema: "dbo",
                table: "EDI_LineItemInvoice");

            migrationBuilder.DropColumn(
                name: "DeliveryDateFormat",
                schema: "dbo",
                table: "EDI_LineItemInvoice");

            migrationBuilder.DropColumn(
                name: "DeliveryDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemInvoice");

            //
            /******EDI_LineItemDeliveryNote******/
            migrationBuilder.RenameColumn(
                name: "BuyersArticleNumberType",
                schema: "dbo",
                table: "EDI_LineItemDeliveryNote",
                newName: "ItemNumberType");

            migrationBuilder.RenameColumn(
                name: "BuyersArticleNumber",
                schema: "dbo",
                table: "EDI_LineItemDeliveryNote",
                newName: "ItemNumber");

            migrationBuilder.DropColumn(
                name: "PurchaseDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemDeliveryNote");

            migrationBuilder.DropColumn(
                name: "PurchaseDateFormat",
                schema: "dbo",
                table: "EDI_LineItemDeliveryNote");

            migrationBuilder.DropColumn(
                name: "DeliveryDateFormat",
                schema: "dbo",
                table: "EDI_LineItemDeliveryNote");

            migrationBuilder.DropColumn(
                name: "DeliveryDateQualifier",
                schema: "dbo",
                table: "EDI_LineItemDeliveryNote");


        }
    }
}
