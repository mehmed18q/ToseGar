using System;
using System.Windows.Forms;
using BLL_ToseGar.Relations_CRUD_BLL;
using BE_ToseGar;

namespace ToseGar_Help_Source
{
    public partial class Relations_CRUD_Moshtari : UserControl
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        public Relations_CRUD_Moshtari()
        {
            InitializeComponent();
        }

        Moshtari_BLL bll = new Moshtari_BLL();
        bool flag = true;
        int id;

        void DGV()
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = bll.Read();
        }

        private void Relations_CRUD_Moshtari_Load(object sender, EventArgs e)
        {
            DGV();
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Moshtari m = new Moshtari();
            m.Name = textBoxX1.Text;
            m.Phone = textBoxX2.Text;

            if (flag)
            {
                //Create
                MessageBox.Show(bll.Create(m));
            }
            else if (!flag)
            {
                //Update
                MessageBox.Show(bll.Update(id, m));
                flag = true;
                guna2Button1.Text = "ثبت مشتری جدید";
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

        private void ویرایشمشتریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Moshtari m = bll.Read(id);

            textBoxX1.Text = m.Name;
            textBoxX2.Text = m.Phone;

            flag = false;
            guna2Button1.Text = "ویرایش اطلاعات";
        }

        private void حذفمشتریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bll.Delete(id);
            DGV();
        }
    }
}
