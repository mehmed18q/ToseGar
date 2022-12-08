using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL_ToseGar.Relations_CRUD_BLL;
using BE_ToseGar;

namespace ToseGar_Help_Source
{
    public partial class Relations_CRUD_Factor : UserControl
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        public Relations_CRUD_Factor()
        {
            InitializeComponent();
        }

        int kid;
        int mid;
        List<Kala> Kalas = new List<Kala>();
        List<int> kalasid = new List<int>();
        Factor_BLL fbll = new Factor_BLL();
        Kala_BLL kbll = new Kala_BLL();
        Moshtari_BLL mbll = new Moshtari_BLL();
        double sum;

        void DGV()
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView2.DataSource = null;
            guna2DataGridView3.DataSource = null;
            guna2DataGridView1.DataSource = kbll.Read();
            guna2DataGridView2.DataSource = mbll.Read();
            guna2DataGridView3.DataSource = Kalas;
        }

        private void Relations_CRUD_Factor_Load(object sender, EventArgs e)
        {
            DGV();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                kid = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }
            catch (Exception)
            {

            }

            Kalas.Add(kbll.Read(kid));
            kalasid.Add(kid);
            guna2DataGridView3.DataSource = null;
            guna2DataGridView3.DataSource = Kalas;
            sum = 0;
            foreach (var item in Kalas)
            {
                sum = sum + item.Price;
            }
            label2.Text = sum.ToString();
        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mid = int.Parse(guna2DataGridView2.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }
            catch (Exception)
            {

            }

            Moshtari m = mbll.Read(mid);
            label6.Text = m.Name;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Factor f = new Factor();
            fbll.Create(f, mid, kalasid);
        }
    }
}
