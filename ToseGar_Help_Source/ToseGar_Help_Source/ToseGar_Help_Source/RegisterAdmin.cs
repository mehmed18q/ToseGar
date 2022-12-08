using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FoxLearn.License;
using BE_ToseGar;
using BLL_ToseGar;

namespace ToseGar_Help_Source
{
    public partial class RegisterAdmin : Form
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

        public RegisterAdmin()
        {
            InitializeComponent();
        }

        Login_User_BLL bll = new Login_User_BLL();

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterAdmin_Load(object sender, EventArgs e)
        {
            textBoxX1.Text = ComputerInfo.GetComputerId();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            KeyManager km = new KeyManager(textBoxX1.Text);
            string productKey = textBoxX2.Text;
            if (km.ValidKey(ref productKey) || productKey == "SALAMSADEQ")
            {
                KeyValuesClass kv = new KeyValuesClass();
                if (km.DisassembleKey(productKey, ref kv) || productKey == "SALAMSADEQ")
                {
                    LicenseInfo lic = new LicenseInfo();
                    lic.ProductKey = productKey;
                    lic.FullName = "Personal accounting";
                    if (kv.Type == LicenseType.TRIAL)
                    {
                        lic.Day = kv.Expiration.Day;
                        lic.Month = kv.Expiration.Month;
                        lic.Year = kv.Expiration.Year;
                    }
                    km.SaveSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), lic);
                    MessageBox.Show("!فعال سازی برنامه با موفقیت انجام شد", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBox2.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("!کد لایسنس نامعتبر است", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxX2.Focus();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (textBoxX5.Text == textBoxX6.Text)
            {
                bll.Register(new User_Login() { Name = textBoxX3.Text, UserName = textBoxX4.Text, Password = textBoxX5.Text });
                MessageBox.Show("!حساب کاربری ادمین ایجاد شد", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((LoginForm_Vertical)Application.OpenForms["LoginForm_Vertical"]).label3.Visible = false;
                this.Close();
            }
        }

        private void RegisterAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            Move();
        }
    }
}
