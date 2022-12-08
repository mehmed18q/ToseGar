using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_ToseGar;
using BE_ToseGar;

namespace ToseGar_Help_Source
{
    public partial class LoginForm_Vertical : Form
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

        public LoginForm_Vertical()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Login_User_BLL bll = new Login_User_BLL();
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (bll.Login(textBoxX1.Text,textBoxX2.Text) == 1)
            {
                label1.Text = "خوش آمدید";
                MainForm_SideMenu m = new MainForm_SideMenu();
                m.Show();
                this.Hide();
            }
            else
            {
                label1.Text = "نام کاربری و یا کلمه عبور اشتباه است";
            }
        }

        private void LoginForm_Vertical_Load(object sender, EventArgs e)
        {
            if (bll.Login("","") == 0)
            {
                label3.Visible = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            RegisterAdmin r = new RegisterAdmin();
            r.ShowDialog();
        }
    }
}
