using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dbtest.controls;
using dbtest.db;

namespace dbtest
{
    public partial class SaveWindows : dbtest.ModelWindows
    {
        public SaveWindows()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowsControls.ClearControls(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //從這邊把值傳到Info controls

            InfoControls.Rows.Add(new Info
            {
                Title = Title.Text,
                Contect = Contect.Text
            }); 

            if (InfoControls.Create() is true)
            {
                MessageBox.Show("新增成功");
                this.Close();
            }
        }
    }

}
