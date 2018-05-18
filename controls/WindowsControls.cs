using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbtest.controls
{
    class WindowsControls
    {
        public static void ClearControls(Control form )
        {
            foreach (Control ctrl in form.Controls )
            {
                if(ctrl is TextBox)
                {
                    ctrl.Text = null;
                }
            }
        }

    }
}
