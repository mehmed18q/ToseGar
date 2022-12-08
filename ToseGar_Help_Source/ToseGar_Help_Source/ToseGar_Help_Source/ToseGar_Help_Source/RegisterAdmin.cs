using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoxLearn.License;
using BE_ToseGar;
using BLL_ToseGar;

namespace ToseGar_Help_Source
{
    public partial class RegisterAdmin : Form
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

        public RegisterAdmin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        const int ProductCode = 1;
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
            if (km.ValidKey(ref productKey))
            {
                KeyValuesClass kv = new KeyValuesClass();
                if (km.DisassembleKey(productKey, ref kv))
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
                    MessageBox.Show("فعال سازی برنامه با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBox2.Enabled = true;
                }
            }
            else
                MessageBox.Show("کد لایسنس نامعتبر است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        Login_User_BLL bll = new Login_User_BLL();

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (textBoxX5.Text == textBoxX6.Text)
            {
                bll.Register(new User_Login() { Name = textBoxX3.Text, UserName = textBoxX4.Text, Password = textBoxX5.Text });
                MessageBox.Show("اطلاعات ادمین ایجاد شد");
                ((LoginForm_Vertical)Application.OpenForms["LoginForm_Vertical"]).label3.Visible = false;
                this.Close();
                
            }
            
        }
    }
}
