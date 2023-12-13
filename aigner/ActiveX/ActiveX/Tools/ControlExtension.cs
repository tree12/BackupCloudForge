using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveX.Tools
{
    public static class ControlExtension
    {
        public static T InvokeWhenRequired<T>(this Control control, Func<T> action)
        {
            if (!control.InvokeRequired) return action();
            T result = default(T);
            control.Invoke(new Action(() => {
                result = action();
            }));
            return result;
        }

        public static void InvokeWhenRequired(this Control control, Action action)
        {
            if (control.IsHandleCreated)
            {
                if (!control.InvokeRequired) action();
                else
                    control.Invoke(action);
            }
            else
            {
                bool firstRun = true;
                control.VisibleChanged += (sender, args) => {
                    if (firstRun && control.Visible)
                    {
                        firstRun = false;
                        InvokeWhenRequired(control, action);
                    }
                };               
            }
        }
    }
}
