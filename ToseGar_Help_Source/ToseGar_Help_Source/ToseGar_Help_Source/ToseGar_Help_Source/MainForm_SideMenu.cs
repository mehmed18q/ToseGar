using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToseGar_Help_Source
{
    public partial class MainForm_SideMenu : Form
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        /*طراحی و تولید توسط تیم پشتیبانی آکادمی برنامه نویسی محسن مدحج*/
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public MainForm_SideMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            StimulSoft_Reports s = new StimulSoft_Reports();
            panel1.Controls.Clear();
            panel1.Controls.Add(s);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Charts_Compile s = new Charts_Compile();
            panel1.Controls.Clear();
            panel1.Controls.Add(s);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Backup_Restore s = new Backup_Restore();
            panel1.Controls.Clear();
            panel1.Controls.Add(s);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Save_Read_Pics s = new Save_Read_Pics();
            panel1.Controls.Clear();
            panel1.Controls.Add(s);
        }
    }
}
