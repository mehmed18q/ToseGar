using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BLL_ToseGar;

namespace ToseGar_Help_Source
{
    public partial class LoginForm_Vertical : Form
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        void Move()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public LoginForm_Vertical()
        {
            InitializeComponent();
        }

        Login_User_BLL bll = new Login_User_BLL();
        RegisterAdmin r = new RegisterAdmin();
        MainForm_SideMenu m = new MainForm_SideMenu();

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
            textBoxX1.WordWrap = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (bll.Login(textBoxX1.Text, textBoxX2.Text) == 1)
            {
                m.loginformusername = "(: خوش آمدید " +textBoxX1.Text ;
                label1.Text = "خوش آمدید!";
                m.Show();
                this.Hide();
            }
            else if (bll.Login("", "") == 0)
            {
                label1.Text = "برنامه هنوز فعال سازی نشده است!";
            }
            else
            {
                label1.Text = "نام کاربری و یا کلمه عبور اشتباه است!";
            }
        }

        private void LoginForm_Vertical_Load(object sender, EventArgs e)
        {
            if (bll.Login("", "") == 0)
            {
                label3.Visible = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            r.ShowDialog();
        }

        private void LoginForm_Vertical_MouseDown(object sender, MouseEventArgs e)
        {
            Move();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Move();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Move();
        }
    }
}
