using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace AignerDLL.Service
{
    public class FileService
    {
        /*7
        public static System.Drawing.Icon GetFileIcon(string name, IconSize size,
                                              bool linkOverlay)
        {            
            SystemProperties.System.Shell
            Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
            uint flags = Shell32.SHGFI_ICON | Shell32.SHGFI_USEFILEATTRIBUTES;

            if (true == linkOverlay) flags += Shell32.SHGFI_LINKOVERLAY;


            // Check the size specified for return. 
            if (IconSize.Small == size)
            {
                flags += Shell32.SHGFI_SMALLICON; // include the small icon flag
            }
            else
            {
                flags += Shell32.SHGFI_LARGEICON;  // include the large icon flag
            }           
            Shell32.SHGetFileInfo(name,
                Shell32.FILE_ATTRIBUTE_NORMAL,
                ref shfi,
                (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                flags);


            // Copy (clone) the returned icon to a new object, thus allowing us 
            // to call DestroyIcon immediately
            System.Drawing.Icon icon = (System.Drawing.Icon)
                                 System.Drawing.Icon.FromHandle(shfi.hIcon).Clone();
            User32.DestroyIcon(shfi.hIcon); // Cleanup
            return icon;
        }*/

        public static List<Tuple<String, String, Icon>> RecommendedPrograms(string ext)
        {
            List<Tuple<String, String, Icon>> progs = new List<Tuple<String, String, Icon>>();
            List<String> programmIDList = new List<string>();

            string baseKey = (ext.StartsWith(".")?"":".") + ext;

            string fileType = null;


            using (RegistryKey rkExtension = Registry.ClassesRoot.OpenSubKey(baseKey))
            {
                fileType = (string)rkExtension.GetValue("", null);
                if (rkExtension != null)
                {
                    using (RegistryKey rkExtensionOpenWith = rkExtension.OpenSubKey(@"OpenWithProgids"))
                    {
                        if (rkExtensionOpenWith!=null)
                        foreach (string progId in rkExtensionOpenWith.GetValueNames())
                        {
                            programmIDList.Add(progId);
                            System.Console.WriteLine(progId);
                        }
                    }
                }
            }


            using (RegistryKey rkFileTypeShell = Registry.ClassesRoot.OpenSubKey(fileType + @"\shell"))
                if (rkFileTypeShell != null)
                {
                    foreach (string subKeyName in rkFileTypeShell.GetSubKeyNames())
                    {
                        using (RegistryKey rkShellEntry = rkFileTypeShell.OpenSubKey(subKeyName))
                            if (rkShellEntry != null)
                            {
                                string commandName = rkShellEntry.GetValue("", "") as string;
                                if (commandName.Equals("")) commandName = subKeyName;
                                using (RegistryKey rkCommand = rkShellEntry.OpenSubKey("command"))
                                    if (rkCommand != null)
                                    {
                                        string command = rkCommand.GetValue("", null) as string;
                                        System.Console.WriteLine(commandName + ":" + command);
                                        Icon icon = null;
                                        try
                                        {
                                            String exe = Regex.Match(command, "\"([^\"]*)\"").Groups[0].Value;
                                            exe = exe.Replace("\"", "");
                                            icon = Icon.ExtractAssociatedIcon(exe);
                                            System.Console.WriteLine(exe);
                                        }
                                        catch (Exception ex)
                                        {
                                            System.Console.WriteLine("Konnte Icon nicht ermitteln: " + ex.Message);
                                        }
                                        progs.Add(new Tuple<string, string, Icon>(commandName, command, icon));
                                    }
                            }
                    }
                }
            return progs;
        }

        static public long GetMD5Hash(FileInfo fi) {                        
            using (FileStream fs = new FileStream(fi.FullName,FileMode.Open,FileAccess.Read)) {
                return GetMD5Hash(fs);
            }            
        }

        static public long GetMD5Hash(Stream stream)
        {
            MD5 md5 = MD5.Create();
            byte[] hash=md5.ComputeHash(stream);                 
            for (int i = sizeof(long); i < hash.Length; i++) {
                hash[i%sizeof (long)] ^= hash[i];
            }
            return BitConverter.ToInt64(hash, 0);
        }
    }
}
