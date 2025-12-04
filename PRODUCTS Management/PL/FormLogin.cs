using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PRODUCTS_Management.PL
{
    public partial class FormLogin : Form
    {
        BL.ClS_LOGIN log = new BL.ClS_LOGIN();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable Dt = log.LOGIN(txtID.Text, TxtPass.Text);
            if (Dt.Rows.Count > 0)
            {
                FormMain.getMainForm.المنتجاتToolStripMenuItem.Enabled = true;
                FormMain.getMainForm.العملاءToolStripMenuItem.Enabled = true;

                FormMain.getMainForm.المستخدمينToolStripMenuItem.Enabled = true;
                FormMain.getMainForm.إنشاءنسخةإحتياطيةToolStripMenuItem.Enabled = true;
                FormMain.getMainForm.إستعادةنسخةمحفوظةToolStripMenuItem.Enabled = true;

                this.Close();


            }
            else
            {

                MessageBox.Show("Login failed !");
            }

        }
    }
}
