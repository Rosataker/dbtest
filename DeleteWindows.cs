using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using dbtest.controls;
using dbtest.db;


namespace dbtest
{
    public partial class DeleteWindows : dbtest.ModelWindows
    {
        public DeleteWindows()
        {
            InitializeComponent();
        }

        private void DeleteWindows_Load(object sender, EventArgs e)
        {
            InfoControls InfoControls = new InfoControls();

            comboBox1.DataSource = InfoControls.ComboboxProduce();
            comboBox1.DisplayMember = "cbo_Name";
            comboBox1.ValueMember = "cbo_Value";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NowId > 0)
            {
                InfoControls.Rows.Add(new Info
                {
                    InfoId = NowId,
                    Title = Title.Text,
                    Contect = Contect.Text
                });

                if (InfoControls.Delete(NowId) is true)
                {
                    MessageBox.Show("刪除成功");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("沒有資料可以刪除，請重新選擇。");
            }
        }

        private static int NowId { get; set; }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NowId = 0;
            if (Convert.ToInt32(comboBox1.SelectedIndex.ToString()) > 0)
            {
                NowId = Convert.ToInt32(comboBox1.SelectedValue.ToString());

                InfoControls.Select(InfoControls.TableId + "=" + NowId);
                InfoControls.SetColVar(DatabaseControls._Table);


                Title.Text = InfoControls.ShowColVar["Title"];
                Contect.Text = InfoControls.ShowColVar["Contect"];

            }
            else
            {
                WindowsControls.ClearControls(this);
            }

        }
    }
}
