using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AignerDLL
{
    public static class Global {
        private const string FILE_CONFIG = "config.xml";
        private static String sqlServer;
        private static String dbName;
        private static String dataDir;

        public static bool IsExchangeConfigured { get; private set; }
        public static string Exchange_Username { get; private set; }
        public static string Exchange_Password { get; private set; }
        public static string Exchange_Domain { get; private set; }
        public static string Exchange_URL { get; private set; }

        static Global() {
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load(FILE_CONFIG);

                XmlNode rootNode = doc.DocumentElement.SelectSingleNode("/config/MSSQL");
                sqlServer = rootNode.SelectSingleNode("Server").InnerText;
                dbName = rootNode.SelectSingleNode("DB-Name").InnerText;

                rootNode = doc.DocumentElement.SelectSingleNode("/config/Data-Dir");
                dataDir = rootNode.InnerText;

                rootNode = doc.DocumentElement.SelectSingleNode("/config/Exchange");
                if (rootNode != null) {                    
                    Exchange_Username = rootNode.SelectSingleNode("User").InnerText;
                    Exchange_Password = rootNode.SelectSingleNode("Password").InnerText;
                    Exchange_Domain = rootNode.SelectSingleNode("Domain").InnerText;
                    Exchange_URL = rootNode.SelectSingleNode("URL").InnerText;
                    IsExchangeConfigured = true;
                }
            }
            catch (Exception ex) {
                Error($"Error reading config from file {FILE_CONFIG}.",ex);    
                WriteDefaultXML();
                Environment.Exit(-1);
            }
        }

        public static DirectoryInfo DataDir {
            get {
                DirectoryInfo dir = new DirectoryInfo(dataDir);
                if (!dir.Exists) dir.Create();
                return dir;
            }
        }


        public static SqlConnection Conn {
            get {
                SqlConnection myConnection = new SqlConnection("user id=username;" +
                                       $"password=password;Server={sqlServer};" +
                                       "Trusted_Connection=yes;" +
                                       $"database={dbName}; " +
                                       "connection timeout=30");
                try
                {
                    myConnection.Open();
                    return myConnection;
                }
                catch (Exception ex)
                {
                    Error("Fehler beim Öffnen der DB-Verbindung", ex);
                    throw;
                }
            }
        }

        public static void Error(Exception ex)
        {
            Error(null, ex);
        }
        

        public static void Error(string message, Exception ex=null)
        {
            MessageBox.Show( (message == null ? "" : message + Environment.NewLine) + (ex==null?"":(ex.Message + Environment.NewLine + ex.StackTrace)), "Fehler");
        }

        private static void WriteDefaultXML() {
            try {
                Console.Write($"Erzeuge {FILE_CONFIG} Datei...");
                using (FileStream fs = new FileStream(FILE_CONFIG, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(fs)) {
                    sw.Write("<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + @"
<config>
  <MSSQL>
  <!--Server, zb.: localhost\sqlexpress-->
    <Server>localhost\sqlexpress</Server>
    <DB-Name>AignerSQL</DB-Name>
  </MSSQL>
  <Data-Dir>Data</Data-Dir>
  <Exchange>
    <User>benutzer</User>
    <Password>pwd</Password>
    <Domain>Aigner</Domain>
    <URL>https://ctatwes05.crazyteam.local/ews/Exchange.asmx</URL>
  </Exchange>
</config>
");
                    Console.WriteLine("Fertig!");
                    Error("Config datei erzeugt. Bitte bearbeiten!");
                }
            }
            catch (Exception ex) {
                Error($"Fehler beim erzeugen der Datei {FILE_CONFIG}", ex);
            }
        }
    
    }
}
