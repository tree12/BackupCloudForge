using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AignerDLL;
using AignerDLL.DB;
using AignerDLL.Service;
using AignerDLL.Win32;
using Microsoft.Win32;

namespace FileMgr
{
    static class Program {

        private const string PARAM_ACTION = "ACTION";
        private const string PARAM_FILE = "FILE";        
        private const string PARAM_FILE_PK = "FILE_PK";
        private const string PARAM_OBJECT_FK = "OBJECT_FK";
        private const string PARAM_TAG = "TAG";
        private const string PARAM_PATH = "PATH";
        private const string PARAM_OPEN_WITH = "OPEN_WITH";

        private static int _parentPID = -1;
        private static int _thisPID = -1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
                                   
            _parentPID=ParentProcess.ProcessId;
            _thisPID = Process.GetCurrentProcess().Id;

            Dictionary<string,string> argDict = ReadArgs(args);


            if (!argDict.ContainsKey(PARAM_ACTION)) {
                ShowHelp("/ACTION muss immer angegeben werden.");
            }

            string action = argDict[PARAM_ACTION];
            if (action.Equals("open", StringComparison.OrdinalIgnoreCase)) {
                OpenAction(argDict);
            } else if (action.Equals("edit", StringComparison.OrdinalIgnoreCase)) {
                EditAction(argDict);
            } else if (action.Equals("insert", StringComparison.OrdinalIgnoreCase)) {
                InsertAction(argDict);
            } else if (action.Equals("mail", StringComparison.OrdinalIgnoreCase)) {
                MailAction(argDict);     
            } else if (action.Equals("gui", StringComparison.OrdinalIgnoreCase)) {
                GUIAction(argDict);
            }
            else {
                ShowHelp("/ACTION "+action+" existiert nicht.");
            }
        }

        private static void GUIAction(Dictionary<string, string> argDict) {
            if (!argDict.ContainsKey(PARAM_OBJECT_FK) || !argDict.ContainsKey(PARAM_TAG)) ShowHelp("/ACTION GUI benötigt die Parameter /OBJECT_PK und /TAG");
            string object_FK = "0";
            string tag = "SCANED_DOC";
            if (argDict.ContainsKey(PARAM_OBJECT_FK)) object_FK = argDict[PARAM_OBJECT_FK];
            if (argDict.ContainsKey(PARAM_TAG)) tag = argDict[PARAM_TAG];
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FileForm frm = new FileForm(object_FK,tag);
            Application.Run(frm);
        }

        private static void MailAction(Dictionary<string, string> argDict) {
            string object_FK = "0";
            string TAG = "SCANED_DOC";
            if (argDict.ContainsKey(PARAM_OBJECT_FK)) object_FK = argDict[PARAM_OBJECT_FK];
            if (argDict.ContainsKey(PARAM_TAG)) TAG = argDict[PARAM_TAG];
            MailService.InsertMailAttachmentsToDB(object_FK,TAG,false);
        }

        private static void InsertAction(Dictionary<string, string> argDict) {
            if (!argDict.ContainsKey(PARAM_OBJECT_FK) || !argDict.ContainsKey(PARAM_TAG)) ShowHelp("/ACTION insert benötigt die Parameter /OBJECT_PK und /TAG ... optional /FILE");
            FileInfo fi=GetFile(argDict);
            using (FileTable ft = new FileTable()) {
                ft.InsertFile(argDict[PARAM_OBJECT_FK], argDict[PARAM_TAG], fi);
            }
        }

        private static FileInfo GetFile(Dictionary<string, string> argDict) {
            FileInfo fi;
            if (argDict.ContainsKey(PARAM_FILE)) {
                fi = new FileInfo(argDict[PARAM_FILE]);
                if (!fi.Exists) {
                    ShowHelp("/FILE \"" + fi.FullName + "\" konnte nicht gefunden werden.");
                }                
            }
            else {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.CheckFileExists = true;
                dlg.ReadOnlyChecked = true;
                dlg.CheckPathExists = true;
                dlg.Multiselect = false;
                DirectoryInfo di = null;
                if (argDict.ContainsKey(PARAM_PATH)) {
                    di=new DirectoryInfo(argDict[PARAM_PATH]);
                }
                if (di != null && di.Exists)
                    dlg.InitialDirectory = di.FullName;
                if (DialogResult.OK != dlg.ShowDialog()) Environment.Exit(-1);
                fi= new FileInfo(dlg.FileName);
            }
            return fi;
        }

        private static void EditAction(Dictionary<string, string> argDict) {
            if (!argDict.ContainsKey(PARAM_FILE_PK)) ShowHelp("/ACTION edit benötigt die Parameter /FILE_PK");
            int filePK = GetFile_PK(argDict);

            FileInfo fi;
            using (FileTable ft = new FileTable()) {
                fi = ft.GetFile(filePK, Global.DataDir, FileAccess.Write);             
            }
            DateTime lastWriteTime = fi.LastWriteTime;
            Process p= StartOpenProcess(fi,true,true,ShowOpenWithForm);
            if (p==null) return;
            WaitForExit(p);
            using (FileTable ft = new FileTable())
            {
                if (fi.LastWriteTime > lastWriteTime) {
                    ft.UpdateFile(filePK, fi);
                } else {
                    ft.UnLockFile(filePK);
                }
            }
        }

        private static void WaitForExit(Process process) {
            if (process!=null)process.WaitForExit();
            else if (_windowCloseMonitor != null) {
                lock (_windowCloseMonitor) Monitor.Wait(_windowCloseMonitor);
            }
        }

        internal delegate string ShowOpenWithFormDelegate(List<Tuple<string, string, Icon>> commandList);

        private static string ShowOpenWithForm(List<Tuple<string,string,Icon>> commandList) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OpenWithForm frm =new OpenWithForm(commandList,true);
            Application.Run(frm);
            Tuple<string, string, Icon> ret = frm.SelectedValue;
            if (ret == null) return null;
            return ret.Item2;
        }

        private static IntPtr _parentWindow;

        private static object _windowCloseMonitor;

        internal static Process StartOpenProcess(FileInfo fi,bool edit,bool openWith,ShowOpenWithFormDelegate showOpenWithForm) {

            Process p=null;
            _parentWindow = Window.GetForegroundWindow();

            if (openWith || edit) {
/*                if (Environment.OSVersion.Platform == PlatformID.Win32NT &&
                    Environment.OSVersion.Version >= new Version(6, 1))
                    p = Process.Start("rundll32.exe", string.Format("shell32,OpenAs_RunDLL \"{0}\"", fi.FullName));
                else {*/
               /* try {
                    ProcessStartInfo startInfo = new ProcessStartInfo() {
                        WindowStyle = ProcessWindowStyle.Normal,
                        FileName = fi.FullName,
                        Verb = "openas",
                        UseShellExecute = true,
                        ErrorDialog = false,
                    };
                    p = Process.Start(startInfo);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Fehler");*/
                    List < Tuple<string, string, Icon>> recommendedList = FileService.RecommendedPrograms(fi.Extension);
                    recommendedList=recommendedList.Where(_ => !_.Item3.Equals("printto")).ToList();

                    string cmd = null;
                if (recommendedList.Any()) {
                    if (recommendedList.Count > 1)
                        cmd = showOpenWithForm(recommendedList);
                    else {
                        cmd = recommendedList.First().Item2;
                    }
                }
                if (cmd == null) return null;
                cmd=cmd.Replace("%1", fi.FullName);
                    MessageBox.Show(cmd,"test");
                    ProcessStartInfo startInfo = new ProcessStartInfo()
                    {
                        WindowStyle = ProcessWindowStyle.Normal,
                        FileName = cmd,                        
                        UseShellExecute = false,
                        ErrorDialog = true
                    };
                    p = Process.Start(startInfo);       
            } else {
                p = Process.Start(fi.FullName);
            }            
            
            if (p != null) {
                AdjustWindow(Window.GetRootWindowsOfProcess(p.Id));
                Window.MoveWindowToMonitor(p.Id, 0);
            }
            
            _windowWatchThread = new Thread(()=>WindowWatcherThreadMethod(p?.Id));
            _windowWatchThread.Name = "WindowWatcherThread";
            _windowWatchThread.Start();
            return p;
        }

        private static void AdjustWindow(List<IntPtr> window) {
            //TODO-adjust
            
        }

        private static Thread _windowWatchThread;
        

        private static void WindowWatcherThreadMethod(int? pid) {
            _windowCloseMonitor = new object();
            bool foundWindow = false;
            IntPtr window = new IntPtr();
            while (!foundWindow) {
                Thread.Sleep(300);                
                if (pid == null) {
                    window = Window.GetForegroundWindow();
                    uint windowPid = Window.GetProcessForWindow(window);
                    foundWindow = _parentPID != windowPid && _thisPID != windowPid;
                } else {
                    window = Window.GetForegroundWindow();
                    uint windowPid = Window.GetProcessForWindow(window);
                    foundWindow = windowPid == pid.Value;
                }
            }

            bool windowClosed=false;
            WINDOWPLACEMENT placement;
            while (!windowClosed) {
                Thread.Sleep(500);
                windowClosed=!Window.IsWindowVisible(window);
                
                if (!windowClosed) {
                    placement=Window.GetPlacement(window);
                }
            }


            //TODO hier weitermachen, placement validieren und in registry speichern. :)
            Console.WriteLine("Window closed!");
            lock (_windowCloseMonitor) {
                Monitor.PulseAll(_windowCloseMonitor);
            }
        }


        private static void OpenAction(Dictionary<string, string> argDict) {
            if (!argDict.ContainsKey(PARAM_FILE_PK)) ShowHelp("/ACTION open benötigt die Parameter /FILE_PK");
            int filePK = GetFile_PK(argDict);
            
            using (FileTable ft = new FileTable())
            {
                FileInfo fi = ft.GetFile(filePK,Global.DataDir,FileAccess.Read);
                Process p = StartOpenProcess(fi,false,false,ShowOpenWithForm);
            }
        }

        private static int GetFile_PK(Dictionary<string, string> argDict) {
            int file_PK;
            if (!int.TryParse(argDict[PARAM_FILE_PK], out file_PK)) ShowHelp("Der Parameter /FILE_PK muss eine Nummer sein...");
            return file_PK;
        }

        private static Dictionary<string, string> ReadArgs(string[] args) {
            Dictionary<string, string> argDict = new Dictionary<string, string>();

            string argName = null;

            foreach (string s in args) {
                if (argName == null) {
                    if (!s.StartsWith("/")) {
                        ShowHelp(
                            "Es muss immer /key1 value1 /key2 value2 übergeben werden.Es wurde ein value ohne key übergeben.");
                    }
                    argName = s.Trim().ToUpper().Substring(1);
                    argDict[argName] = "";
                } else if (argName != null) {
                    argDict[argName] = s;
                    argName = null;
                }
            }
            return argDict;
        }

        private static void ShowHelp(string msg) {
            MessageBox.Show($@"{msg}

Usage:
FileMgr /ACTION [open|edit|insert|mail] /FILE <filename> /FILE_PK <FILE_PK> /TAG <tag> /OBJECT_FK <object_fk> /PATH <path-for-openfile-dialog> /OPEN_WITH

Version 0.1", "Hilfe",
                MessageBoxButtons.OK);
            Environment.Exit(-1);
        }
    }
}
