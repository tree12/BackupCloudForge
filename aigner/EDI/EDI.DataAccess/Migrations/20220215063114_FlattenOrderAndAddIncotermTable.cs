using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class FlattenOrderAndAddIncotermTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSegment",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "Buyer_PartyQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery1_Code",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "Delivery1_FunctionCode",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "NumberOfSegment",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.RenameColumn(
                name: "Supplier_PartyQualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition2_PlaceLocationQualifier");

            migrationBuilder.RenameColumn(
                name: "Delivery_PartyQualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition2_PlaceLocationIdentification");

            migrationBuilder.RenameColumn(
                name: "Delivery2_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition2_FunctionCode");

            migrationBuilder.RenameColumn(
                name: "Delivery2_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition2_Code");

            migrationBuilder.RenameColumn(
                name: "Delivery2_FunctionCode",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition1_PlaceLocationQualifier");

            migrationBuilder.RenameColumn(
                name: "Delivery2_Code",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition1_PlaceLocationIdentification");

            migrationBuilder.RenameColumn(
                name: "Delivery1_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition1_FunctionCode");

            migrationBuilder.RenameColumn(
                name: "Delivery1_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Order",
                newName: "DeliveryCondition1_Code");

            migrationBuilder.RenameColumn(
                name: "AdditionalItemNumberType",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                newName: "SupplierArticleNumber");

            migrationBuilder.RenameColumn(
                name: "AdditionalItemNumber",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                newName: "ScheduleQuantityQualifier2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate2",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryPlanStatusIndicatorCode2",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleItemQuantity2",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScheduleQTYMeasureUnitQualifier2",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CodeIncotermCode",
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
                    table.PrimaryKey("PK_CodeIncotermCode", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeIncotermCode",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "DeliveryDate2",
                schema: "dbo",
                table: "EDI_LineItemOrder");

            migrationBuilder.DropColumn(
                name: "DeliveryPlanStatusIndicatorCode2",
                schema: "dbo",
                table: "EDI_LineItemOrder");

            migrationBuilder.DropColumn(
                name: "ScheduleItemQuantity2",
                schema: "dbo",
                table: "EDI_LineItemOrder");

            migrationBuilder.DropColumn(
                name: "ScheduleQTYMeasureUnitQualifier2",
                schema: "dbo",
                table: "EDI_LineItemOrder");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "Supplier_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Order",
                newName: "Delivery_PartyQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_FunctionCode",
                schema: "dbo",
                table: "EDI_Order",
                newName: "Delivery2_PlaceLocationQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition2_Code",
                schema: "dbo",
                table: "EDI_Order",
                newName: "Delivery2_PlaceLocationIdentification");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_PlaceLocationQualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "Delivery2_FunctionCode");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_PlaceLocationIdentification",
                schema: "dbo",
                table: "EDI_Order",
                newName: "Delivery2_Code");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_FunctionCode",
                schema: "dbo",
                table: "EDI_Order",
                newName: "Delivery1_PlaceLocationQualifier");

            migrationBuilder.RenameColumn(
                name: "DeliveryCondition1_Code",
                schema: "dbo",
                table: "EDI_Order",
                newName: "Delivery1_PlaceLocationIdentification");

            migrationBuilder.RenameColumn(
                name: "SupplierArticleNumber",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                newName: "AdditionalItemNumberType");

            migrationBuilder.RenameColumn(
                name: "ScheduleQuantityQualifier2",
                schema: "dbo",
                table: "EDI_LineItemOrder",
                newName: "AdditionalItemNumber");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSegment",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_PartyQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery1_Code",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Delivery1_FunctionCode",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSegment",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "int",
                nullable: true);
        }
    }
}
