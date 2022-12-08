using System;
using System.Windows.Forms;
using BE_ToseGar;
using BLL_ToseGar.Relations_CRUD_BLL;

namespace ToseGar_Help_Source
{
    public partial class Relations_CRUD_Kala : UserControl
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        public Relations_CRUD_Kala()
        {
            InitializeComponent();
        }

        Kala_BLL bll = new Kala_BLL();
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

        private void Relations_CRUD_Kala_Load(object sender, EventArgs e)
        {
            DGV();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Kala k = new Kala();
            k.Name = textBoxX1.Text;
            k.Barcode = textBoxX3.Text;
            k.Price = Convert.ToInt64(textBoxX2.Text);

            if (flag)
            {
                //Create
                MessageBox.Show(bll.Create(k));
            }
            else if (!flag)
            {
                //Update
                MessageBox.Show(bll.Update(id, k));
                flag = true;
                guna2Button1.Text = "ثبت کالا";
            }

            DGV();
            Clear();
        }

        private void guna2DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
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

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kala k = bll.Read(id);

            textBoxX1.Text = k.Name;
            textBoxX3.Text = k.Barcode;
            textBoxX2.Text = k.Price.ToString();

            flag = false;
            guna2Button1.Text = "ویرایش اطلاعات";
        }

        private void حذفکالاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bll.Delete(id);
            DGV();
        }
    }
}
