using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI.DataAccess.Migrations
{
    public partial class AddSupplierContactforEdiConfirm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeListQualifier",
                schema: "dbo",
                table: "EDI_ScheduleAgreement");

            migrationBuilder.DropColumn(
                name: "CodeListQualifier",
                schema: "dbo",
                table: "EDI_OrderChange");

            migrationBuilder.DropColumn(
                name: "CodeListQualifier",
                schema: "dbo",
                table: "EDI_Order");

            migrationBuilder.RenameColumn(
                name: "CodeListQualifier",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "Supplier_Phone");

            migrationBuilder.RenameColumn(
                name: "InstitutionName",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "UidSender");

            migrationBuilder.RenameColumn(
                name: "InstitutionIdentification",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "GeneralRemark");

            migrationBuilder.RenameColumn(
                name: "InstitutionBranchNumber",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "CompanyBookNumberSender");

            migrationBuilder.RenameColumn(
                name: "FinancialPartyQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Bank3Name");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Bank3InstitutionNameId");

            migrationBuilder.RenameColumn(
                name: "CodeListQualifier",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Bank3InstitutionName");

            migrationBuilder.RenameColumn(
                name: "AccountHolderNumber",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Bank3InstitutionBranchNumber");

            migrationBuilder.RenameColumn(
                name: "AccountHolderName",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "Bank3Iban");

            migrationBuilder.AddColumn<string>(
                name: "Supplier_ContactCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_Email",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier_Name",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AignerFairness",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AraSystemSender",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank1Country",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank1Iban",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank1InstitutionBranchNumber",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank1InstitutionName",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank1InstitutionNameId",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank1Name",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank2Country",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank2Iban",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank2InstitutionBranchNumber",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank2InstitutionName",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank2InstitutionNameId",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank2Name",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank3Country",
                schema: "dbo",
                table: "EDI_Invoice",
                type: "nvarchar(max)",
                nullable: true);
            //Because migration it rename not-used field to be new field.
            migrationBuilder.Sql(@"update EDI_OrderConfirmation set Supplier_Phone = NULL;
update EDI_Invoice set UidSender = NULL; 
update EDI_Invoice set GeneralRemark =NULL; 
update EDI_Invoice set CompanyBookNumberSender = NULL; 
update EDI_Invoice set Bank3Name = NULL; 
update EDI_Invoice set Bank3InstitutionNameId = NULL; 
update EDI_Invoice set Bank3InstitutionName = NULL; 
update EDI_Invoice set Bank3InstitutionBranchNumber = NULL; 
update EDI_Invoice set Bank3Iban =NULL; 
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Supplier_ContactCode",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Supplier_Email",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "Supplier_Name",
                schema: "dbo",
                table: "EDI_OrderConfirmation");

            migrationBuilder.DropColumn(
                name: "AignerFairness",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "AraSystemSender",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Bank1Country",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Bank1Iban",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Bank1InstitutionBranchNumber",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Bank1InstitutionName",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Bank1InstitutionNameId",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Bank1Name",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Bank2Country",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Bank2Iban",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Bank2InstitutionBranchNumber",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Bank2InstitutionName",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Bank2InstitutionNameId",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Bank2Name",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.DropColumn(
                name: "Bank3Country",
                schema: "dbo",
                table: "EDI_Invoice");

            migrationBuilder.RenameColumn(
                name: "Supplier_Phone",
                schema: "dbo",
                table: "EDI_OrderConfirmation",
                newName: "CodeListQualifier");

            migrationBuilder.RenameColumn(
                name: "UidSender",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "InstitutionName");

            migrationBuilder.RenameColumn(
                name: "GeneralRemark",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "InstitutionIdentification");

            migrationBuilder.RenameColumn(
                name: "CompanyBookNumberSender",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "InstitutionBranchNumber");

            migrationBuilder.RenameColumn(
                name: "Bank3Name",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "FinancialPartyQualifier");

            migrationBuilder.RenameColumn(
                name: "Bank3InstitutionNameId",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "CountryCode");

            migrationBuilder.RenameColumn(
                name: "Bank3InstitutionName",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "CodeListQualifier");

            migrationBuilder.RenameColumn(
                name: "Bank3InstitutionBranchNumber",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "AccountHolderNumber");

            migrationBuilder.RenameColumn(
                name: "Bank3Iban",
                schema: "dbo",
                table: "EDI_Invoice",
                newName: "AccountHolderName");

            migrationBuilder.AddColumn<string>(
                name: "CodeListQualifier",
                schema: "dbo",
                table: "EDI_ScheduleAgreement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeListQualifier",
                schema: "dbo",
                table: "EDI_OrderChange",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeListQualifier",
                schema: "dbo",
                table: "EDI_Order",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
