using System;
using System.Windows.Forms;

namespace ToseGar_Help_Source
{
    public partial class Relations_CRUD : UserControl
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        public Relations_CRUD()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Relations_CRUD_Moshtari s = new Relations_CRUD_Moshtari();
            panel1.Controls.Clear();
            panel1.Controls.Add(s);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Relations_CRUD_Kala s = new Relations_CRUD_Kala();
            panel1.Controls.Clear();
            panel1.Controls.Add(s);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Relations_CRUD_Factor s = new Relations_CRUD_Factor();
            panel1.Controls.Clear();
            panel1.Controls.Add(s);
        }
    }
}
