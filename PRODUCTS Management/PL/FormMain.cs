using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Windows.Forms;

namespace PRODUCTS_Management.PL
{
    public partial class FormMain : Form
    {
        private static FormMain frm;


        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FormMain getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new FormMain();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }
        public FormMain()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;

            this.المنتجاتToolStripMenuItem.Enabled = false;
            this.العملاءToolStripMenuItem.Enabled = false;
            this.المستخدمينToolStripMenuItem.Enabled = false;
            this.إنشاءنسخةإحتياطيةToolStripMenuItem.Enabled = false;
            this.إستعادةنسخةمحفوظةToolStripMenuItem.Enabled = false;

        }

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();
            frm.ShowDialog();
        }

        private void إضافةمنتججديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FORM_ADD_PRODUCT frm = new FORM_ADD_PRODUCT();
            frm.ShowDialog();
        }
    }
}
