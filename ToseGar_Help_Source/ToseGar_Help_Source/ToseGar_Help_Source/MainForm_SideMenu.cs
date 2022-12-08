using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ToseGar_Help_Source
{
    public partial class MainForm_SideMenu : Form
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

        public MainForm_SideMenu()
        {
            InitializeComponent();
        }

        public string loginformusername;

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
            DialogResult Exit = MessageBox.Show("آیا مایلید از برنامه خارج شوید؟", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Save_Read_Pics s = new Save_Read_Pics();
            panel1.Controls.Clear();
            panel1.Controls.Add(s);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            CRUD s = new CRUD();
            panel1.Controls.Clear();
            panel1.Controls.Add(s);
        }

        private void guna2Button7_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("*** طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر *** \n به روز شده در دی ماه 1400 - ورژن 1.2", "About Us!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Relations_CRUD s = new Relations_CRUD();
            panel1.Controls.Clear();
            panel1.Controls.Add(s);
        }

        private void FormsPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Move();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Move();
        }

        private void Menupanel_MouseDown(object sender, MouseEventArgs e)
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

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            Move();
        }

        private void MainForm_SideMenu_Load(object sender, EventArgs e)
        {
            label2.Text = loginformusername;
        }
    }
}
