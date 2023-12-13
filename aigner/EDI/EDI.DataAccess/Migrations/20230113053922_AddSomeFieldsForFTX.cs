using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class AddSomeFieldsForFTX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreeTextCode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "TextLiteralFreeText",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "TextSubjectqualifier",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "FreeTextCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text1",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text10",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text10FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text11",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text11FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text12",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text12FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text1FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text2",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text2FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text3",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text3FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text4",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text4FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text5",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text5FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text6",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text6FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Text7",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "FreeTextCode",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text1",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text10",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text10FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text11",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text11FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text12",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text12FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text1FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text2",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text2FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text3",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text3FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text4",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text4FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text5",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text5FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text6",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text6FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Text7",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "FreeTextCode",
                schema: "dbo",
                table: "EDI_DeliveryNote");

            migrationBuilder.DropColumn(
                name: "TextLiteralFreeText",
                schema: "dbo",
                table: "EDI_DeliveryNote");

            migrationBuilder.DropColumn(
                name: "TextSubjectqualifier",
                schema: "dbo",
                table: "EDI_DeliveryNote");

            migrationBuilder.RenameColumn(
                name: "TextSubjectqualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "FreeTextTextSubjectQualifier");

            migrationBuilder.RenameColumn(
                name: "TextLiteralFreeText",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "FreeTextFreeTextCoded");

            migrationBuilder.RenameColumn(
                name: "Text9FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "FreeText5");

            migrationBuilder.RenameColumn(
                name: "Text9",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "FreeText4");

            migrationBuilder.RenameColumn(
                name: "Text8FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "FreeText3");

            migrationBuilder.RenameColumn(
                name: "Text8",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "FreeText2");

            migrationBuilder.RenameColumn(
                name: "Text7FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "FreeText1");

            migrationBuilder.RenameColumn(
                name: "TextSubjectqualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "FreeTextTextSubjectQualifier");

            migrationBuilder.RenameColumn(
                name: "TextLiteralFreeText",
                schema: "dbo",
                table: "EDI_Order",
                newName: "FreeTextFreeTextCoded");

            migrationBuilder.RenameColumn(
                name: "FreeTextCode",
                schema: "dbo",
                table: "EDI_Order",
                newName: "FreeText5");

            migrationBuilder.RenameColumn(
                name: "TextSubjectqualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "FreeTextTextSubjectQualifier");

            migrationBuilder.RenameColumn(
                name: "TextLiteralFreeText",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "FreeTextFreeTextCoded");

            migrationBuilder.RenameColumn(
                name: "Text9FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "FreeText5");

            migrationBuilder.RenameColumn(
                name: "Text9",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "FreeText4");

            migrationBuilder.RenameColumn(
                name: "Text8FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "FreeText3");

            migrationBuilder.RenameColumn(
                name: "Text8",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "FreeText2");

            migrationBuilder.RenameColumn(
                name: "Text7FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "FreeText1");

            migrationBuilder.AddColumn<string>(
                name: "FreeText1",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreeText2",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreeText3",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreeText4",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreeText1",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "FreeText2",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "FreeText3",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.DropColumn(
                name: "FreeText4",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.RenameColumn(
                name: "FreeTextTextSubjectQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "TextSubjectqualifier");

            migrationBuilder.RenameColumn(
                name: "FreeTextFreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "TextLiteralFreeText");

            migrationBuilder.RenameColumn(
                name: "FreeText5",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "Text9FreeTextCoded");

            migrationBuilder.RenameColumn(
                name: "FreeText4",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "Text9");

            migrationBuilder.RenameColumn(
                name: "FreeText3",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "Text8FreeTextCoded");

            migrationBuilder.RenameColumn(
                name: "FreeText2",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "Text8");

            migrationBuilder.RenameColumn(
                name: "FreeText1",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "Text7FreeTextCoded");

            migrationBuilder.RenameColumn(
                name: "FreeTextTextSubjectQualifier",
                schema: "dbo",
                table: "EDI_Order",
                newName: "TextSubjectqualifier");

            migrationBuilder.RenameColumn(
                name: "FreeTextFreeTextCoded",
                schema: "dbo",
                table: "EDI_Order",
                newName: "TextLiteralFreeText");

            migrationBuilder.RenameColumn(
                name: "FreeText5",
                schema: "dbo",
                table: "EDI_Order",
                newName: "FreeTextCode");

            migrationBuilder.RenameColumn(
                name: "FreeTextTextSubjectQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "TextSubjectqualifier");

            migrationBuilder.RenameColumn(
                name: "FreeTextFreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "TextLiteralFreeText");

            migrationBuilder.RenameColumn(
                name: "FreeText5",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Text9FreeTextCoded");

            migrationBuilder.RenameColumn(
                name: "FreeText4",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Text9");

            migrationBuilder.RenameColumn(
                name: "FreeText3",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Text8FreeTextCoded");

            migrationBuilder.RenameColumn(
                name: "FreeText2",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Text8");

            migrationBuilder.RenameColumn(
                name: "FreeText1",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Text7FreeTextCoded");

            migrationBuilder.AddColumn<string>(
                name: "FreeTextCode",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextLiteralFreeText",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextSubjectqualifier",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreeTextCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text1",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text10",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text10FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text11",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text11FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text12",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text12FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text1FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text3",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text3FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text4",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text4FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text5",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text5FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text6",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text6FreeTextCoded",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text7",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreeTextCode",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text1",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text10",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text10FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text11",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text11FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text12",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text12FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text1FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text3",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text3FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text4",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text4FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text5",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text5FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text6",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text6FreeTextCoded",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text7",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreeTextCode",
                schema: "dbo",
                table: "EDI_DeliveryNote",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextLiteralFreeText",
                schema: "dbo",
                table: "EDI_DeliveryNote",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextSubjectqualifier",
                schema: "dbo",
                table: "EDI_DeliveryNote",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
