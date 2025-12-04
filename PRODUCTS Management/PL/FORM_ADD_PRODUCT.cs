using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace PRODUCTS_Management.PL
{
    public partial class FORM_ADD_PRODUCT : Form
    {
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
        public FORM_ADD_PRODUCT()
        {

            InitializeComponent();
            cmbCategories.DataSource = prd.GET_ALL_CATEGORIES();
            cmbCategories.DisplayMember = "DESCRIPTION_CAT";
            cmbCategories.ValueMember = "ID_CAT";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ملفات الصور  | *.JPG; *.PNG; *.GIF; *.BMP";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void FORM_ADD_PRODUCT_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pbox.Image.Save(ms, pbox.Image.RawFormat);
            byte[] byteImage = ms.ToArray();
            prd.ADD_PRODUCT(Convert.ToInt32(cmbCategories.SelectedValue), txtDes.Text, txtRef.Text, Convert.ToInt32(txtQte.Text), txtPrice.Text, byteImage);
            MessageBox.Show("تمت الإضافة بنجاح", "عملية الإضافة ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtRef_Validated(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            Dt = prd.verifyProductID(txtRef.Text);
            if (Dt.Rows.Count > 0)
            {
                MessageBox.Show("هذا المعرف موجود مسبقا ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRef.Focus();
                txtRef.SelectionStart = 0;
                txtRef.SelectionLength = txtRef.TextLength;
            }
        }
    }
}
