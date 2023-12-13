/****************************** Module Header ******************************\
* Module Name:  CSActiveXCtrl.cs
* Project:      CSActiveX
* Copyright (c) Microsoft Corporation.
* 
* The sample demonstrates an ActiveX control written in C#. ActiveX controls
* (formerly known as OLE controls) are small program building blocks that can 
* work in a variety of different containers, ranging from software development 
* tools to end-user productivity tools. For example, it can be used to create 
* distributed applications that work over the Internet through web browsers. 
* ActiveX controls can be written in MFC, ATL, C++, C#, Borland Delphi and 
* Visual Basic. In this sample, we focus on writing an ActiveX control using 
* C#. We will go through the basic steps of adding UI, properties, methods,  
* and events to the control.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Reflection;
using System.Security.Permissions;
using System.Threading;
using ActiveX.Tools;
using AignerDLL.Tools;
using ATom.CommonBasics.Collections;
using ATom.CommonBasics.Extension;
using Common.Collections;
using CrazyTeam.DarkMagick;
using Microsoft.VisualBasic;

#endregion


namespace Aigner
{
    #region Interfaces

    /// <summary>
    /// AxCSActiveXCtrl describes the COM interface of the coclass 
    /// </summary>
    [Guid("3528E6B3-BD9C-4A38-B095-4095871F166F")]
    //[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    //[ComVisible(true)]
    public interface AxComboBox
    {        

        #region Properties        

        int ForeColor { get; set; }         // Typical control property


        int BackColor { get; set; }         // Typical control property

        int DropDownItemCount { get; set; }         // Typical control property


        string TabellenName { get; set; }         // Typical control property

 
        string SchluesselSpalte { get; set; }         // Typical control property

        string TextSpalte { get; set; }         // Typical control property

        string AngezeigteSpalten { get; set; }         // Typical control property

        string SuchSpalten { get; set; }         // Typical control property


        string Spaltengroessen { get; set; }         // Typical control property        

        string SQLWhereKondition { get; set; }         // Typical control property        

        string SQLOrderBy { get; set; }         // Typical control property        


       


        long Value { get; set; }         // Typical control property        
        
        float FloatProperty { get; set; }   // Custom property

        #endregion

        #region Methods


        void Refresh();                     // Typical control method


        void LoadData();                // Custom method

        void LoadAllData();                // Custom method
        

        void SetSize(int width, int height);

        bool Visible { get; set; } // Typical control property
        bool Enabled { get; set; } // Typical control property

        string Verbindungszeichenfolge { get; set; } // Typical control property
        

        void SetFont(string fontName, float size);

        void SetTextColor(int R, int G, int B);
        void SetBackColor(int R, int G, int B);
        void SetBorderColor(int R, int G, int B);

        void Clear();

        object GetValue(int index);
        
        #endregion
    }

    /// <summary>
    /// AxCSActiveXCtrlEvents describes the events the coclass can sink
    /// </summary>
    [Guid("A4D122CF-CA7E-4C17-9A3B-708C17BB38F4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    //[ComVisible(true)]
    // The public interface describing the events of the control
    public interface AxComboBoxEvents
    {
        #region Events

        // Must explicitly define DISPID for each event, otherwise, the 
        // callback address cannot be found when the event is fired.
        [DispId(1)]
        void Click();
        [DispId(2)]
        void FloatPropertyChanging(float NewValue, ref bool Cancel);
        [DispId(3)]
        void ItemSelected();

        #endregion        
    }

    #endregion

    [ClassInterface(ClassInterfaceType.None)]        
    [ComSourceInterfaces(typeof (AxComboBoxEvents), typeof(IAxActiveXBase))]
    //[ComVisible(true)]
    [Guid("843D9C86-4DBE-478E-B361-88825E076814")]
    public partial class ComboBox : System.Windows.Forms.ComboBox, AxComboBox,IAxActiveXBase {
        #region ActiveX Control Registration

        // These routines perform the additional COM registration needed by 
        // ActiveX controls

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ComRegisterFunction()]
        public static void Register(Type t) {
            try {
                ActiveXCtrlHelper.RegasmRegisterControl(t);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message); // Log the error
                throw; // Re-throw the exception
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ComUnregisterFunction()]
        public static void Unregister(Type t) {
            try {
                ActiveXCtrlHelper.RegasmUnregisterControl(t);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message); // Log the error
                throw; // Re-throw the exception
            }
        }

        public void SetSize(int width, int height)
        {            
            this.Size= new Size(width,height);
        }

        public void SetTextColor(int R, int G, int B)
        {
            base.ForeColor=Color.FromArgb(R,G,B);
        }

        public void SetBackColor(int R, int G, int B)
        {
            base.BackColor = Color.FromArgb(R, G, B);
        }

        private int _dropDownItemCount;
        public int DropDownItemCount
        {
            set
            {
                _dropDownItemCount = value;
                this.DropDownHeight = (this.ItemHeight * (_dropDownItemCount+1))+10;
                
            }

            get { return _dropDownItemCount; }
            
        }

        private Color? _borderColor;

        public void SetBorderColor(int R, int G, int B)
        {
            _borderColor = Color.FromArgb(R, G, B);
        }

        public void SetFont(string fontName, float size)
        {
            Font font = new Font(fontName,size);
            Font = font;
            Height = 100;
        }

        #endregion


        #region Initialization

        public ComboBox() {
            InitializeComponent();            
            
            this.DrawMode=DrawMode.OwnerDrawFixed;

            // For the Click event that is re-defined.
            base.Click += new EventHandler(CSActiveXCtrl_Click);

            // These functions are used to handle Tab-stops for the ActiveX 
            // control (including its child controls) when the control is 
            // hosted in a container.
            this.LostFocus += new EventHandler(CSActiveXCtrl_LostFocus);
            this.ControlAdded += new ControlEventHandler(
                CSActiveXCtrl_ControlAdded);
            // Raise custom Load event

            this.AutoCompleteMode = AutoCompleteMode.None;
           // AutoCompleteSource = AutoCompleteSource.CustomSource;
            /*SetStyle
            (
                //ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |// ControlStyles.DoubleBuffer |
                ControlStyles.ResizeRedraw | ControlStyles.Selectable,
                true
            );
            SetStyle(ControlStyles.AllPaintingInWmPaint,false);*/
            this.DropDownItemCount = 30;            
            
            CreateEmptyItem(false);                          

            Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OnCreateControl();

            _inputCollector = new ExcecuteLastActionCollector<string>(() => !inQuery);

            /*this.Paint += (sender, args) =>
            {
                ControlPaint.DrawBorder(args.Graphics, ClientRectangle
                    , Color.BlueViolet, ButtonBorderStyle.Solid);
            };*/
        }

        /*
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (Items.Count > 0)
                {
                    Item item = Items[0] as Item;
                    if (item != null && item.Hit) SelectedIndex = 0;
                }
            }
            base.OnKeyUp(e);
        }
        */

        protected override void Select(bool directed, bool forward)
        {
            base.Select(directed, forward);
        }

        protected override void OnSelectedIndexChanged(EventArgs e) {
            Console.WriteLine("SelectedIndex changed: " + SelectedIndex);
            base.OnSelectedIndexChanged(e);
            _value = 0;
            if (this.SelectedIndex < 0 || SelectedIndex >= Items.Count) {                                
                return;
            }
            Item item = Items[SelectedIndex] as Item;
            if (item == null)
            {                
                DroppedDown = true;
                return;
            }
            if (item.Id == -666)
            {
                QueryData(_lastQuery, MAX_ROWS);             
               // DroppedDown = true;
            }
            else
            {
                    _value = item.Id;                
            }
            Select(0, 0);
            try
            {
                if (!_notFireIndexChanged) ItemSelected?.Invoke();
            } catch (Exception ex) { }
            
        }
        

        /*
        protected override void OnGotFocus(EventArgs e) {
            base.OnGotFocus(e);
           
        }*/

        private DateTime _enterTime;

        private long _oldValue;

        protected override void OnEnter(EventArgs e)
        {            
            base.OnEnter(e);            
            //SelectAll();
            _enterTime=DateTime.Now;
        }

        protected override void OnLeave(EventArgs e)
        {            
            base.OnLeave(e);

            Console.WriteLine("lost focus");
            SetItemFromText();
        }

        private void SetItemFromText()
        {
            if (Items.Count == 0 || Text == null || Text.Trim().Equals(""))
            {
                _value = 0;
                try
                {
                    Console.WriteLine("Delete Text in SetItemFromText: (Items.Count == 0 || Text == null || Text.Trim().Equals()");
                    Text = "";
                }
                catch (Exception)
                {
                }
                Clear();
            }
            else
            {
                Item item = Items[0] as Item;
                Item selected = SelectedItem as Item;
                if (item != null && item.SpecialText == null && item.Id != 0)
                {
                    if (selected != null && selected.VisibleText.NotNullOrEmpty() && selected.VisibleText.StartsWith(Text))
                        _value = selected.Id;
                    else if (item != null && item.VisibleText.NotNullOrEmpty() && item.VisibleText.StartsWith(Text))
                    {
                        _value = item.Id;
                    }
                    else
                    {
                        _value = 0;
                        Console.WriteLine("Delete Text in SetItemFromText: else");
                        Text = "";
                    }
                }
                else
                {
                    _value = 0;
                    Console.WriteLine("Delete Text in SetItemFromText: else2");
                    Text = "";
                }
            }

            SelectionLength = 0;
        }

        protected override void OnClick(EventArgs e)
        {
           //base.OnClick(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
           //base.OnMouseClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
           //base.OnMouseDown(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            _oldValue = _value;
            System.Console.WriteLine("OnGotFocus");
            //base.OnGotFocus(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_enterTime.AddMilliseconds(200) > DateTime.Now)
            {
                SelectAll();                                
            }
            else base.OnMouseUp(e);

        }

        public string SQLWhereKondition { get; set; }

        public string SQLOrderBy { get; set; }         // Typical control property        

        private const int SEPERATOR_WIDTH = 10;
        private const int MAX_ROWS = 500;

        // This event will hook up the necessary handlers
        private void CSActiveXCtrl_ControlAdded(object sender, ControlEventArgs e) {
            // Register tab handler and focus-related event handlers for 
            // the control and its child controls.
            ActiveXCtrlHelper.WireUpHandlers(e.Control, ValidationHandler);
        }



        // Ensures that the Validating and Validated events fire properly
        internal void ValidationHandler(object sender, System.EventArgs e) {
            if (this.ContainsFocus) return;

            this.OnLeave(e); // Raise Leave event

            if (this.CausesValidation) {
                CancelEventArgs validationArgs = new CancelEventArgs();
                this.OnValidating(validationArgs);

                /*if (validationArgs.Cancel && this.ActiveControl != null)
                    this.ActiveControl.Focus();
                else
                    this.OnValidated(e); // Raise Validated event*/

                if (validationArgs.Cancel)
                    this.Focus();
                else
                    this.OnValidated(e); // Raise Validated event*/
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref System.Windows.Forms.Message m) {
            const int WM_SETFOCUS = 0x7;
            const int WM_PARENTNOTIFY = 0x210;
            const int WM_DESTROY = 0x2;
            const int WM_LBUTTONDOWN = 0x201;
            const int WM_RBUTTONDOWN = 0x204;
            const int WM_KILLFOCUS = 0x0008;
           

            if (m.Msg == WM_SETFOCUS) {
                if (!this.ContainsFocus)
                {
                    // Raise Enter event
                    this.OnEnter(System.EventArgs.Empty);
                }
            }
            if (m.Msg == WM_KILLFOCUS)
            {
                if (this.ContainsFocus)
                {
                    this.OnLeave(System.EventArgs.Empty);
                }
            }
            else if (m.Msg == WM_PARENTNOTIFY && (
                         m.WParam.ToInt32() == WM_LBUTTONDOWN ||
                         m.WParam.ToInt32() == WM_RBUTTONDOWN))
            {
                if (!this.ContainsFocus)
                {
                    // Raise Enter event
                    this.OnEnter(System.EventArgs.Empty);
                }
            }
            else if (m.Msg == WM_DESTROY &&
                     !this.IsDisposed && !this.Disposing)
            {
                // Used to ensure the cleanup of the control
                this.Dispose();
            }

            base.WndProc(ref m);

            if (m.Msg == 0xF)
            {
                OnPaint(new PaintEventArgs(this.CreateGraphics(),ClientRectangle));
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x0100;
            const int WM_KEYUP = 0x0101;
            const int WM_SYSKEYUP = 0x0105;           

            bool ret= base.ProcessCmdKey(ref msg, keyData);

            if ((msg.Msg==WM_KEYDOWN || msg.Msg == WM_SYSKEYUP) && (keyData == Keys.Escape || keyData == Keys.Enter))
            {
                OnKeyUp(new System.Windows.Forms.KeyEventArgs(keyData));
                if (keyData==Keys.Enter) ret = true;
            }
            return ret;
        }

        // Ensures that tabbing across the container and the .NET controls
        // works as expected
        private void CSActiveXCtrl_LostFocus(object sender, EventArgs e) {          
            ActiveXCtrlHelper.HandleFocus(this);
        }

        #endregion


        #region Properties

        public new int ForeColor {
            get { return ActiveXCtrlHelper.GetOleColorFromColor(base.ForeColor); }
            set { base.ForeColor = ActiveXCtrlHelper.GetColorFromOleColor(value); }
        }

        public new int BackColor {
            get { return ActiveXCtrlHelper.GetOleColorFromColor(base.BackColor); }
            set { base.BackColor = ActiveXCtrlHelper.GetColorFromOleColor(value); }
        }        

        private Color ConvertToColor(string str) {
            int[] ia = StringToArray(str, 3, 0);
            return Color.FromArgb(ia[0],ia[1],ia[2]);
        }

        private string ColorToString(Color color) {
            return string.Join(";", color.R, color.G, color.B);
        }

        public object GetValue(int index) {
            Item item = SelectedItem as Item;
            if (item == null || item.Text==null || item.Text.Length<=index) return null;
            return (item.Text[index]);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Escape)
            {
                _value = _oldValue;
                LoadData();
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8) //backspace
            {
                int selStart = SelectionStart;
                int selLenght = SelectionLength;                

                if (selLenght > 0)
                {
                    if (selStart > 0)
                    {
                        SelectionStart = selStart - 1;
                        SelectionLength = selLenght + 1;
                    }
                }
                else
                {
                    base.OnKeyPress(e);
                }
            } else
            base.OnKeyPress(e);
        }

        public string TextSpalte { get; set; }

        public void Clear()
        {
            try
            {
                Console.WriteLine("Delete Text in SetItemFromText: clear");
                Text = "";
            }
            catch (Exception ex){}
            try
            {
                Items.Clear();
            } catch(Exception ex) {}
            _value = 0;
        }

        public string TabellenName { get; set; }
        public string SchluesselSpalte { get; set; }
        private string _angezeigteSpalten;

        public string AngezeigteSpalten
        {
            get { return _angezeigteSpalten; }
            set
            {
                _angezeigteSpalten = value;
                _columnsSize = null;
                _columns = null;
            }
        }

        private string _suchSpalten;


        protected override void OnPaint(PaintEventArgs e)
        {
            if (_borderColor == null) return;
            ControlPaint.DrawBorder(e.Graphics,this.ClientRectangle,_borderColor.Value, ButtonBorderStyle.Solid);
        }

        public string SuchSpalten
        {
            get { return _suchSpalten; }
            set
            {
                _suchSpalten = value;
                _searchColums = null;
            }
        } // Typical control property

        private string _spaltengroessen;

        public string Spaltengroessen
        {
            get { return _spaltengroessen; }
            set
            {
                _spaltengroessen = value;
                _columnsSize = null;
                _columns = null;
            }
        }



        private long _value;

        public long Value {
            get { return _value; }
            set {
                bool refresh = _value != value;
                _value = value;
                if (refresh) LoadData();
                if (Items.Count == 0)
                {
                    CreateEmptyItem(true);
                } else if (Items.Count == 1 && ((Item) Items[0]).Id == 0)
                {
                    SelectedItem = Items[0];
                }

                //LoadData();
            }
        }

        public string Verbindungszeichenfolge { get; set; }


        public OdbcConnection Conn => ConnectionHolder.GetConnection(Verbindungszeichenfolge);

        private string[] _columns;
        private string[] Columns {
            get {
                if (_columns == null) {
                    List<string> columnList = new List<string>();
                    //columnList.Add(SchluesselSpalte.ToLower());
                    if (AngezeigteSpalten != null && AngezeigteSpalten.Trim() != "") {                                                                                           
                        columnList.AddRange(AngezeigteSpalten.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(_ => _.Trim().ToLower()));
                        _columns = columnList.Distinct().ToArray();
                    }                         
                }
                return _columns;
            }
        }

        private string[] _searchColums;
        private string[] SearchColumns
        {
            get
            {
                if (_searchColums == null)
                {
                    List<string> columnList = new List<string>();
                    //columnList.Add(SchluesselSpalte.ToLower());
                    if (SuchSpalten != null && SuchSpalten.Trim() != "")
                    {
                        columnList.AddRange(SuchSpalten.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(_ => _.Trim().ToLower()));                        
                        if (TextSpalte.NotNullOrEmpty() && !columnList.Any(_=>_.Equals(TextSpalte,StringComparison.InvariantCultureIgnoreCase))) columnList.Add(TextSpalte);
                        _searchColums = columnList.Distinct().ToArray();
                    }
                }
                return _searchColums;
            }
        }        

        private int[] _columnsSize;
        private int[] ColumnsSize
        {
            get
            {
                if (_columnsSize == null) {
                    string[] columnList = Columns;
                    List<string> strList = new List<string>();
                    _columnsSize = new int[columnList?.Length??1];
                    _columnsSize = StringToArray(Spaltengroessen, _columnsSize.Length, 100);                                    
                    DropDownWidth= _columnsSize.Sum() + SEPERATOR_WIDTH * _columnsSize.Length - 1;
                    //columnList.Add(SchluesselSpalte.ToLower());                                          
                }
                return _columnsSize;
            }
        }

        private int[] StringToArray(string str, int size, int initvalue) {
            int[] ia = new int[size];
            for (int i = 0; i <size; i++)
                ia[i] = initvalue;
            if (str != null && str.Trim() != "")
            {
                List<string> strList = str.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();                
                for (int i = 0; i < size; i++) {
                    if (i >= strList.Count) break;
                    string s = strList[i];                
                    int iout;
                    if (int.TryParse(s, out iout))
                    {
                        ia[i] = iout;
                    }
                }                    
            }
            return ia;
        }

        /*
        private string[] _visibleColumns;
        private string[] VisibleColumns
        {
            get
            {
                if (_visibleColumns == null)
                {
                    List<string> columnList = new List<string>();                    
                    if (AngezeigteSpalten != null || AngezeigteSpalten.Trim() != "")
                    {
                        columnList.AddRange(AngezeigteSpalten.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(_ => _.Trim().ToLower()));
                        _visibleColumns = columnList.Distinct().ToArray();
                    }
                }
                return _visibleColumns;
            }
        }*/

        private bool _notFireIndexChanged = false;

        public void LoadData()
        {
            
            try
            {
                this.SuspendLayout();
                OdbcCommand command = Conn?.CreateCommand();
                if (command == null) return;
                command.CommandText =
                    $"Select {(Columns.Any(_ => _.Equals(SchluesselSpalte, StringComparison.InvariantCultureIgnoreCase)) ? "" : $"{SchluesselSpalte}, ")} {string.Join(",", Columns)} from {TabellenName} where {SchluesselSpalte}={Value}";
                
                if (SQLWhereKondition != null && SQLWhereKondition.Trim() != "") 
                    command.CommandText += " AND " + SQLWhereKondition;
                OdbcDataReader reader = command.ExecuteReader();
                Items.Clear();
                Console.WriteLine("Delete Text in LoadData");
                Text = "";
                _value = 0;
                if (reader.Read())
                {
                    Item item = ReadItem(reader,false);
                    Items.Add(item);
                    _notFireIndexChanged = true;
                    SelectedItem = item;                    
                    _value = item.Id;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                ActiveXCtrlHelper.HandleError("Fehler beim Laden der Daten", ex);
            }
            finally
            {
                _notFireIndexChanged = false;
            }
            this.ResumeLayout();
        }

        public void LoadAllData()
        {
            throw new NotImplementedException();
        }

       

        private string _lastQuery;

        private void QueryData(string query,int maxRows=0)
        {

            inQuery = true;
            try
            {
                lock (this)
                {
                    _lastQuery = query;
                    string hitInfoColumn = TextSpalte.NotNullOrEmpty() ? $"case when({TextSpalte} like '{query}%') then 1 else 0 end" : "0";
#if DEBUG
                    Thread.Sleep(3000);
#endif
                    OdbcCommand command = Conn?.CreateCommand();
                    if (command == null) return;
                    string where = "";

                    string[] searchColumns = Columns;

                    if (SearchColumns != null && SearchColumns.Any())
                    {
                        searchColumns = SearchColumns;
                    }

                    foreach (string col in searchColumns)
                    {
                        if (where != "") where += " OR ";
                        where += $"{col} like '%{query}%'";
                    }
                    command.CommandText =
                        $"Select {(maxRows > 0 ? $"top {maxRows}" : "")} {(Columns.Any(_ => _.Equals(SchluesselSpalte, StringComparison.InvariantCultureIgnoreCase)) ? "" : $"{SchluesselSpalte}, ")} {string.Join(",", Columns)},{hitInfoColumn} as HitInfo from {TabellenName} where ({where})";
                    if (SQLWhereKondition != null && SQLWhereKondition.Trim() != "")
                        command.CommandText += " AND " + SQLWhereKondition;

                    command.CommandText += $" ORDER BY {hitInfoColumn} DESC";

                    if (SQLOrderBy != null && SQLOrderBy.Trim() != "")
                    {
                        command.CommandText += ", " + SQLOrderBy;
                    }
                    else if (TextSpalte.NotNullOrEmpty()) command.CommandText += ", " + TextSpalte;
                    List<Item> items = new List<Item>();
                    using (OdbcDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = ReadItem(reader, true);
                            items.Add(item);
                        }
                        reader.Close();
                    }



                    
                    string querytxt = (string) query.Clone();
                    this.InvokeWhenRequired(() =>
                    {

                        try
                        {

                            string text = Text;
                            string inputText = "";
                            if (SelectionStart >= 0)
                            {
                                if (SelectionLength == 0) inputText = text;
                                else inputText = text.Substring(0, Math.Min(text.Length, SelectionStart + 1));
                            }

                            Console.WriteLine($"queryTxt: {querytxt} inputText:{inputText}");
                            SuspendLayout();
                            //AutoCompleteCustomSource.Clear();                        
                            while (Items.Count > 0)
                                Items.RemoveAt(0);
                            if (items.Any())
                            {

                                foreach (Item item in items)
                                {
                                    Items.Add(item);
                                    //AutoCompleteCustomSource.Add(item.VisibleText);                                
                                }
                                if (items.Count == MAX_ROWS)
                                {
                                    Items.Add(new Item(this, -667) {SpecialText = $"mehr als {MAX_ROWS} Ergebnisse"});
                                }
                                else if (items.Count >= maxRows)
                                {
                                    Items.Add(new Item(this, -666) {SpecialText = "Alle Datensätze laden..."});
                                }
                            }
                            else
                            {
                                Items.Add(new Item(this, -1) {SpecialText = ""});
                            }
                            DroppedDown = this.Focused;


                            Console.WriteLine("itemCount=" + items.Count);

                            if (items.Any() && inputText.NotNullOrEmpty())
                            {


                                List<Item> orderItems = items.Where(_ => _.Hit).ToList();
                                orderItems.ForEach(_ => _.HitIndex = MatchString(_.VisibleText, inputText));
                                orderItems.Sort();
                                Item hitItem = orderItems.FirstOrDefault();
                                Console.WriteLine("hitItem=" + hitItem);
                                if (hitItem != null)
                                {
                                    int hitIndex = MatchString(hitItem.VisibleText, inputText);
                                    Console.WriteLine($"hitindex: {hitIndex} inputTextLength {inputText.Length}");
                                    if (hitIndex >= 0 && hitIndex == inputText.Length - 1)
                                    {
                                        try
                                        {
                                            _notQueryOnTextUpdate = true;
                                            if (hitItem.VisibleText.IsNullOrEmpty()) Debugger.Break();
                                            Console.WriteLine("VisibleText hititem:"+ hitItem.VisibleText);
                                            Text = hitItem.VisibleText;

                                            _notQueryOnTextUpdate = false;
                                            Select(Math.Min(hitItem.VisibleText.Length, hitIndex + 1),
                                                hitItem.VisibleText.Length -
                                                Math.Min(hitItem.VisibleText.Length, hitIndex + 1));

                                            Console.WriteLine(
                                                $"Select: hitindex:{hitIndex} start: {Math.Min(hitItem.VisibleText.Length, hitIndex + 1)} length:{(hitItem.VisibleText.Length - Math.Min(hitItem.VisibleText.Length, hitIndex + 1))}");
                                            /*SelectionStart = cursorPos;
                                            SelectionLength = hitItem.VisibleText.Length - cursorPos;*/
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.Error.WriteLine(ex);
                                        }
                                    }
                                }
                            }
                            //cb.MaxDropDownItems = 31;
                            //cb.DropDownHeight = 600;
                            //cb.Refresh();
                            //cb.SelectedIndex = -1;
                        }
                        finally
                        {
                            inQuery = false;
                            ResumeLayout();
                        }
                    });
                    //HandleError("Query completed:" + command.CommandText);
                }

            }
            catch (Exception ex)
            {
                ActiveXCtrlHelper.HandleError("Fehler beim Abfragen", ex);
            }           
        }

        private int MatchString(string str1, string str2)
        {
            int maxLenght = Math.Min(str1.Length, str2.Length);            
            for (int i = 0; i < maxLenght; i++)
            {            
                if (Char.ToUpper(str1[i])==Char.ToUpper(str2[i])) continue;
                return i-1;
            }            
            return maxLenght - 1;
        }

        private Item ReadItem(OdbcDataReader reader, bool readHitInfo) {
            Item item = new Item(this,reader.GetInt32(0));            
            string[] text = new string[reader.FieldCount-1];
            int col = 1;
            int readFieldCount = reader.FieldCount;
            if (readHitInfo) readFieldCount--;
            for (; col < readFieldCount; col++) {
                object o = reader.GetValue(col);
                if (o is DateTime) {
                    text[col - 1] = string.Format("{0:d}", (DateTime) o);
                } else 
                text[col - 1] = "" + o;
            }
            item.Text = text;

            if (readHitInfo)
                item.Hit = reader.GetBoolean(col);

            if (TextSpalte != null && !TextSpalte.Trim().Equals(""))
            {
                int i = reader.GetOrdinal(TextSpalte);
                if (i >= 0)
                {
                    item.VisibleText = "" + reader.GetValue(i);
                }
                else TextSpalte = null;
            }
                        
            return item;
        }


        private void CreateEmptyItem(bool select)
        {
            SuspendLayout();
            try
            {
                Item item = new Item(this, 0);

                string[] text = new string[1];
                text[0] = "";
                item.Text = text;
                Items.Add(item);
                if (select)
                {
                    _notFireIndexChanged = true;
                    SelectedItem = item;
                    _notFireIndexChanged = false;
                }
            }
            catch (Exception ex)
            {

            }           

            ResumeLayout();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Enter)
            {
                SetItemFromText();
                this.Parent.SelectNextControl(this, true, true, true, true);
                
            }
        }

        private float fField = 0;

        /// <summary>
        /// A custom property with both get and set accessor methods.
        /// </summary>
        public float FloatProperty
        {
            get { return this.fField; }
            set 
            {
                bool cancel = false;
                // Raise the event FloatPropertyChanging
                if (null != FloatPropertyChanging)
                    FloatPropertyChanging(value, ref cancel);
                if (!cancel)
                {
                    this.fField = value;                    
                }
            }
        }



        #endregion


        #region Methods

        public string HelloWorld()
        {
            return "HelloWorld";
        }

        #endregion


        #region Events

        // This section shows the examples of exposing a control's events.
        // Typically, you just need to
        // 1) Declare the event as you want it.
        // 2) Raise the event in the appropriate control event.

        [ComVisible(false)]
        public delegate void ClickEventHandler();
        public new event ClickEventHandler Click = null;
        void CSActiveXCtrl_Click(object sender, EventArgs e)
        {
            if (null != Click) Click(); // Raise the new Click event.
        }

        [ComVisible(false)]
        public delegate void FloatPropertyChangingEventHandler(float NewValue, ref bool Cancel);
        public event FloatPropertyChangingEventHandler FloatPropertyChanging = null;

        [ComVisible(false)]
        public delegate void ItemSelectedEventHandler();
        public event ItemSelectedEventHandler ItemSelected = null;

        #endregion


        public class Item:IComparable {

            private ComboBox _cb;

            private bool _hit;
            private long _id;
            private string[] _text;
            private string _specialText;

            public Item(ComboBox cb, long id) {
                _cb = cb;
                _id = id;                
            }

            public long Id {
                get { return _id; }
                set { _id = value; }
            }

            public string VisibleText { get; set; }

            public string[] Text {
                get { return _text; }
                set { _text = value; }
            }

            public string SpecialText {
                get { return _specialText; }
                set { _specialText = value; }
            }

            public bool Hit
            {
                get => _hit;
                set => _hit = value;
            }

            public int CompareTo(object obj)
            {
                Item other = obj as Item;
                int res = HitIndex.CompareTo(other.HitIndex)*-1;
                if (res == 0) res = VisibleText.CompareTo(other.VisibleText);
                return res;
            }

            public int HitIndex { get; set; }

            private string _str;
            public override string ToString() {
                if (_str == null) {
                    if (VisibleText == null)
                    {
                        _str = "";
                        if (_specialText != null) _str = _specialText;
                        else
                            for (int i = 0; i < _text.Length; i++)
                            {
                                if (_cb.ColumnsSize[i] == 0) continue;
                                if (_str != "") _str += " | ";
                                _str += _text[i];
                            }
                    }
                    else
                    {
                        _str = VisibleText;
                    }
                }
                return _str;
            }

            protected bool Equals(Item other) {
                return _id == other._id;
            }

            public override bool Equals(object obj) {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Item) obj);
            }

            public override int GetHashCode() {
                return _id.GetHashCode();
            }

            public static bool operator ==(Item left, Item right) {
                return Equals(left, right);
            }

            public static bool operator !=(Item left, Item right) {
                return !Equals(left, right);
            }
        }

        private bool inQuery;

        private ExcecuteLastActionCollector<string> _inputCollector;

        protected override void OnDrawItem(DrawItemEventArgs e) {
            base.OnDrawItem(e);
            if (e.Index < 0 || e.Index >= Items.Count) return;
            Item item = Items[e.Index] as Item;
            int offset = 0;
            e.DrawBackground();
            if (e.State == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.LightSkyBlue), e.Bounds);
            }

            if (item.SpecialText != null)
            {
                Font font = new Font(Font.FontFamily,Font.Size,FontStyle.Bold|FontStyle.Italic);
                System.Drawing.SizeF sizef = e.Graphics.MeasureString(item.SpecialText, font);
                int middleOff = (e.Bounds.Width - (int)sizef.Width) / 2;
                e.Graphics.DrawString(item.SpecialText, font, new SolidBrush(Color.DarkRed),
                    new Rectangle(e.Bounds.Left + middleOff, e.Bounds.Top, e.Bounds.Width - middleOff, e.Bounds.Height));
            }
            else
            {
                Font font = Font;
                if (item.Hit) font=new Font(Font.FontFamily, Font.Size, FontStyle.Bold);
                int col = 0;
                foreach (int size in ColumnsSize)
                {
                    if (size == 0)
                    {
                        col++;
                        continue;
                    }
                    if (item.Text.Length>col)
                        e.Graphics.DrawString(item.Text[col], font, new SolidBrush(base.ForeColor), new Rectangle(e.Bounds.Left + offset, e.Bounds.Top, size, e.Bounds.Height));
                    offset += size;
                    int lineX = e.Bounds.Left + offset + (int)(SEPERATOR_WIDTH / 2);
                    e.Graphics.DrawLine(new Pen(Color.CornflowerBlue, 1), lineX, e.Bounds.Top, lineX, e.Bounds.Bottom);
                    offset += SEPERATOR_WIDTH;
                    col++;
                }



            }
            e.DrawFocusRectangle();
        }

        private bool _notQueryOnTextUpdate;
        protected override void OnTextUpdate(EventArgs e) {
            base.OnTextUpdate(e);
            if (_notQueryOnTextUpdate) return;
            _inputCollector.AddExecute(Text, (search) => {
                //HandleError("Execute Waitcollector");                
                QueryData(search, _dropDownItemCount);
            });
            //cb.DroppedDown = true;
        }              
    }    
     
} // namespace CSActiveX
