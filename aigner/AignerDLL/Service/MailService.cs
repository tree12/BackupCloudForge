using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AignerDLL.DB;
using Microsoft.Exchange.WebServices.Data;

namespace AignerDLL.Service {

    public class MailService
    {

        const string FOLDER_NAME = "Scanned";


        public static void InsertMailAttachmentsToDB(string object_FK,string tag,bool deleteMails) {
            if (!Global.IsExchangeConfigured) throw new Exception("Exhange nicht im XML Konfiguriert.");
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            service.Credentials = new NetworkCredential(Global.Exchange_Username, Global.Exchange_Password, Global.Exchange_Domain);
            service.Url = new Uri(Global.Exchange_URL);
            //service.AutodiscoverUrl("antlinger@controllerbox.eu");
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;

            Folder folderInbox = Folder.Bind(service, WellKnownFolderName.Inbox);            
            FindFoldersResults folderResult = folderInbox.FindFolders(new FolderView(100));
            Folder scannedFolder = folderResult.Folders.FirstOrDefault(_=>_.DisplayName.Equals(FOLDER_NAME));
            if (scannedFolder==null) {
                scannedFolder = new Folder(service);
                scannedFolder.DisplayName = FOLDER_NAME;
                scannedFolder.Save(WellKnownFolderName.Inbox);

                //TODO regel erstellen aufgrund welcher verschoben wird....
            }

            FindItemsResults<Item> findResults = service.FindItems(
               scannedFolder.Id,
              new ItemView(10));
                                  
            foreach (Item item in findResults.Items) {
                EmailMessage email = item as EmailMessage;
                if (email==null) continue;
                item.Load();
                Console.WriteLine(item.Subject);
                foreach (Attachment attachment in item.Attachments) {
                    if (attachment is FileAttachment) {
                        FileAttachment fileAttachment = (FileAttachment) attachment;
                        MemoryStream ms = new MemoryStream();
                        fileAttachment.Load(ms);
                        using (FileTable ft = new FileTable()) {
                            string fileName = fileAttachment.Name;
                            int i = fileName.LastIndexOf('.');
                            string extension = "";
                            if (i > 0) extension = fileName.Substring(i);
                            ft.InsertFile(object_FK, tag, fileName, extension, ms.GetBuffer());
                        }                   
                    }
                }
                if (deleteMails) {
                    item.Delete(DeleteMode.MoveToDeletedItems);
                }
            }
        }
    }
}
