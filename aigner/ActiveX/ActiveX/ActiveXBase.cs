using System;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;
using ActiveX.Tools;

namespace Aigner
{
    public class ActiveXBase : UserControl, IAxActiveXBase
    {
        public ActiveXBase()
        {
            // For the Click event that is re-defined.
            base.Click += new EventHandler(CSActiveXCtrl_Click);

            // These functions are used to handle Tab-stops for the ActiveX 
            // control (including its child controls) when the control is 
            // hosted in a container.
            this.LostFocus += new EventHandler(CSActiveXCtrl_LostFocus);
            this.ControlAdded += new ControlEventHandler(
                CSActiveXCtrl_ControlAdded);
            // Raise custom Load event
        }

        public string Verbindungszeichenfolge { get; set; }

        protected void HandleError(string msg, Exception ex=null) {                        
            MessageBox.Show(msg + "\n" + ex==null?"":(ex.Message+"\n"+ ex.StackTrace));
        }

        public OdbcConnection Conn => ConnectionHolder.GetConnection(Verbindungszeichenfolge);

        public void SetSize(int width, int height)
        {
            this.Size = new Size(width, height);
        }

        // This section shows the examples of exposing a control's events.
        // Typically, you just need to
        // 1) Declare the event as you want it.
        // 2) Raise the event in the appropriate control event.

        [ComVisible(false)]
        public delegate void ClickEventHandler();
        public new event ComboBox.ClickEventHandler Click = null;
        void CSActiveXCtrl_Click(object sender, EventArgs e)
        {
            if (null != Click) Click(); // Raise the new Click event.
        }

        // Ensures that tabbing across the container and the .NET controls
        // works as expected
        private void CSActiveXCtrl_LostFocus(object sender, EventArgs e)
        {
            ActiveXCtrlHelper.HandleFocus(this);
        }

        // This event will hook up the necessary handlers
        private void CSActiveXCtrl_ControlAdded(object sender, ControlEventArgs e)
        {
            // Register tab handler and focus-related event handlers for 
            // the control and its child controls.
            ActiveXCtrlHelper.WireUpHandlers(e.Control, ValidationHandler);
        }

        // Ensures that the Validating and Validated events fire properly
        internal void ValidationHandler(object sender, System.EventArgs e)
        {
            if (this.ContainsFocus) return;

            this.OnLeave(e); // Raise Leave event

            if (this.CausesValidation)
            {
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
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_SETFOCUS = 0x7;
            const int WM_PARENTNOTIFY = 0x210;
            const int WM_DESTROY = 0x2;
            const int WM_LBUTTONDOWN = 0x201;
            const int WM_RBUTTONDOWN = 0x204;
            const int WM_KILLFOCUS = 0x0008;


            if (m.Msg == WM_SETFOCUS)
            {
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
                OnPaint(new PaintEventArgs(this.CreateGraphics(), ClientRectangle));
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x0100;
            const int WM_KEYUP = 0x0101;
            const int WM_SYSKEYUP = 0x0105;

            bool ret = base.ProcessCmdKey(ref msg, keyData);

            if ((msg.Msg == WM_KEYDOWN || msg.Msg == WM_SYSKEYUP) && (keyData == Keys.Escape || keyData == Keys.Enter))
            {
                OnKeyUp(new System.Windows.Forms.KeyEventArgs(keyData));
                if (keyData == Keys.Enter) ret = true;
            }
            return ret;
        }
      
    }
}

