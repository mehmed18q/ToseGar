using System;
using System.Windows.Forms;
using BE_ToseGar;
using BLL_ToseGar;

namespace ToseGar_Help_Source
{
    public partial class CRUD : UserControl
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        public CRUD()
        {
            InitializeComponent();
        }

        CRUD_Human_BLL bll = new CRUD_Human_BLL();
        bool flag = true;
        int id;

        void DGV()
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = bll.Read();
        }

        void Clear()
        {
            foreach (var item in Controls)
            {
                if (item.GetType().ToString() == "DevComponents.DotNetBar.Controls.TextBoxX")
                {
                    (item as TextBox).Text = "";
                }
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            CRUD_human h = new CRUD_human();
            h.Name = textBoxX1.Text;
            h.Username = textBoxX2.Text;
            h.Code = textBoxX3.Text;
            h.Password = textBoxX4.Text;

            if (flag)
            {
                //Create
                MessageBox.Show(bll.Create(h));
            }
            else if (!flag)
            {
                //Update
                MessageBox.Show(bll.Update(id, h));
                flag = true;
                guna2Button6.Text = "ثبت مشتری جدید";
            }

            DGV();
            Clear();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }
            catch (Exception)
            {

            }
        }

        private void guna2DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CRUD_human h = bll.Read(id);

            textBoxX1.Text = h.Name;
            textBoxX2.Text = h.Username;
            textBoxX3.Text = h.Code;
            textBoxX4.Text = h.Password;

            flag = false;
            guna2Button6.Text = "ویرایش اطلاعات";
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bll.Delete(id);
            DGV();
        }

        private void CRUD_Load(object sender, EventArgs e)
        {
            DGV();
        }

        private void textBoxX5_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = bll.Read(textBoxX5.Text);
        }
    }
}
