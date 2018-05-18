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

namespace dbtest
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InfoControls InfoControls = new InfoControls();
            InfoControls.Select();


            label1.Text = InfoControls.ShowColumns();



        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveWindows frm = new SaveWindows();
            frm.Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateWindows frm = new UpdateWindows();
            frm.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteWindows frm = new DeleteWindows();
            frm.Show();
        }

 






    }
}
