using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EDI.DataAccess;
using EDI.DataAccess.Entities;
using Xunit;
using EDI.Web;
using EDI.Web.Controllers;
using EDI.Web.Services;
using EDI.Web.Util;
using EdiFabric;
using EdiFabric.Templates.EdifactD96A;
using log4net;
using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Namotion.Reflection;
using Assert = Xunit.Assert;

namespace EDI.Web.Test
{
    public class EdiImportExportTest
    {
        #region constants

        //private const string CONNECTIONSTRING = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=EdiUnitTestDb;Integrated Security=True;";

        #endregion
        //private ApplicationDbContext ApplicationDbContext { get; set; }
        private static ILog log = LogManager.GetLogger(typeof(EdiImportExportTest));
        private readonly EdiService _ediService;
        private Encoding _utf8WithoutBom = new UTF8Encoding(false);
       
        //private static DbContextOptions<ApplicationDbContext> DbOptions =>
        //    new DbContextOptionsBuilder<ApplicationDbContext>()
        //        .UseSqlServer(CONNECTIONSTRING)
        //        .Options;
        public EdiImportExportTest()
        {
            //ApplicationDbContext = new ApplicationDbContext(DbOptions);
            //ApplicationDbContext.Database.EnsureDeleted();
            //ApplicationDbContext.Database.Migrate();
            SerialKey.Set("42QRJ-ZXKIN-4KTOH-GWC3Y-WSJNE-D24WX-VNOTU-OUGQF-YYBYU-X6HF5-E3LE2-PNA");
        }

        [Fact]
        public async Task TestImportAndExportEDIs()
        {
            //CurrentDirectory is bin folder.
            //var CurrentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            bool result = true;
            foreach (string file in Directory.EnumerateFiles(@"D:\DEV\BackupCloudForge\aigner\EDI\Data", "*.txt"))
            {
                string content = await File.ReadAllTextAsync(file);
                string outContent = GetReturnString(content);
                bool isSame = content.Equals(outContent);
                if (!isSame)
                {
                    log.Error($"string mismatch \n original: {content} \n output : {outContent}");
                }
                //At least 1 file is false. All of it be false.
                result = result && isSame;
            }
            Assert.True(result);

        }
        [Fact]
        public async Task TestImportAndExportEDI()
        {
            string content = "UNA:+.? 'UNB+UNOC:3+341301537:1+KTMAG:ZZZ+210428:1738+12345++++++1'UNH+1+INVOIC:D:96A:UN'BGM+380+9500000001+9'DTM+137:20210430:102'FTX+REG++IGL+Innergemeinschaftliche Lieferung'RFF+IV:4500000001'DTM+171:20210428:102'RFF+DQ:650004'DTM+171:20210428:102'NAD+BY+1100::92'NAD+SU+11111::92++Supplier AG+Steet+City++Zip Code+AT'FII+RB+IBAN:Supplier AG+76020070:::10090000:::Volksbank+AT'RFF+VA:ATU123456789'CTA+OC+:Fr. Muster'COM+muster@ktm.com:EM'COM+07742 60000:TE'NAD+IV+1100::92++KTM+Steet+City++Zip Code+AT'RFF+VA:ATU987456321'NAD+DP+0030::92++KTM AG:Logistikzentrum+Gewerbegebiet Nord 16+Munderfing++5222+AT'TAX+7+VAT+++:::20+S'CUX+2:EUR:4'PAT+22+6:::Payment description+5:3:D:30'PCD+12:3'TOD+5++CIF'LOC+1+Mattighofen'ALC+C++++FC:::Description'PCD+3:10'MOA+8:1500:EUR'TAX+7+VAT+++:::20+S'LIN+10++1234567:BP'PIA+1+7654321:SA'IMD+F++:::Item Description'QTY+47:1200:PCE'FTX+AAI+++Free text'MOA+203:15000:EUR'PRI+AAA:12.5:::1:PCE'RFF+ON:4500000001:10'DTM+171:20210428:102'RFF+DQ:650004:10'DTM+171:20210428:102'TAX+7+VAT+++:::20+S'MOA+124:3000:EUR'UNS+S'MOA+77:13200:EUR'MOA+125:16500:EUR'MOA+79:15000:EUR'TAX+7+VAT+++:::20+S'MOA+124:3300:EUR'MOA+125:16500:EUR'UNT+49+1'UNZ+1+12345'";
            string output = GetReturnString(content);
            Assert.Equal(content, output);

        }

        private string GetReturnString(string input)
        {
            byte[] byteArray = _utf8WithoutBom.GetBytes(input);
            MemoryStream stream = new MemoryStream(byteArray);
            //Get our DB object from input (not edifact object)
            var ediMessage = EdiController.GenerateMessage(stream);
            string returnString = "";

            if (ediMessage.GetType().Name == typeof(EdiOrder).GetDisplayName())
            {
                //Convert our DB object to edifact object
                var edifactObject = ((EdiOrder)ediMessage).CreateEdiDocument();
                //Get byte array from edifact object
                var data = ConvertEdiFact.GetEdiDataAsBytes(ediMessage, edifactObject);
                //convert edifact byte array to string
                returnString = _utf8WithoutBom.GetString(data);
            }
            else if (ediMessage.GetType().Name == typeof(EdiInvoice).GetDisplayName())
            {
                var edifactObject = ((EdiInvoice)ediMessage).CreateEdiDocument();
                var data = ConvertEdiFact.GetEdiDataAsBytes(ediMessage, edifactObject);
                returnString = _utf8WithoutBom.GetString(data);
            }
            else if (ediMessage.GetType().Name == typeof(EdiScheduleAgreement).GetDisplayName())
            {
                var edifactObject = ((EdiScheduleAgreement)ediMessage).CreateEdiDocument();
                var data = ConvertEdiFact.GetEdiDataAsBytes(ediMessage, edifactObject);
                returnString = _utf8WithoutBom.GetString(data);
            }
            else if (ediMessage.GetType().Name == typeof(EdiOrderConfirmation).GetDisplayName())
            {
                var edifactObject = ((EdiOrderConfirmation)ediMessage).CreateEdiDocument();
                var data = ConvertEdiFact.GetEdiDataAsBytes(ediMessage, edifactObject);
                returnString = _utf8WithoutBom.GetString(data);
            }

            return returnString;
        }
    }
}
