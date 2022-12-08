using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using BLL_ToseGar;
using BE_ToseGar;
using System.IO;

namespace ToseGar_Help_Source
{
    public partial class Save_Read_Pics : UserControl
    {
        public Save_Read_Pics()
        {
            InitializeComponent();
        }
        Human_Picture_BLL BLL = new Human_Picture_BLL();
        Image Pic;
        OpenFileDialog f = new OpenFileDialog();

        void SetDataGrid()
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = BLL.Read();
            guna2DataGridView1.Columns["id"].Visible = false;
            guna2DataGridView1.Columns["PictureAddress"].Visible = false;
            guna2DataGridView1.Columns["Name"].HeaderText = "نام و نام خانوادگی";
            guna2DataGridView1.Columns["HCode"].HeaderText = "کد ملی";
        }

        string SavePic(string code)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Pictures\";
            if (Directory.Exists(appPath) == false)
            {
                Directory.CreateDirectory(appPath);
            }
            string iName = code + ".jpg";
            try
            {
                   // <---
                string filepath = f.FileName;    // <---
                File.Copy(filepath, appPath + iName); // <---

            }
            catch (Exception exp)
            {
                MessageBox.Show("Unable to save file " + exp.Message);
            }
            return appPath + iName;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            var a = groupBox1.Controls.OfType<TextBoxX>().Any(i => i.Text == "");
            if (a)
            {
                MessageBox.Show("لطفا ابتدا تمام اطلاعات کالا را تکمیل کنید");
            }
            else
            {
                Human_Picture h = new Human_Picture();
                h.Name = textBoxX1.Text;
                h.HCode = textBoxX2.Text;
                h.PictureAddress = SavePic(textBoxX2.Text);

                BLL.Create(h);

                SetDataGrid();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            f.Filter = "JPG(*.JPG)|*.JPG";

            if (f.ShowDialog() == DialogResult.OK)
            {
                Pic = Image.FromFile(f.FileName);
                pictureBox1.Image = Pic;
            }
        }

        private void Save_Read_Pics_Load(object sender, EventArgs e)
        {
            SetDataGrid();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells["id"].Value);


            Human_Picture h = BLL.Read(id);

            label7.Text = h.Name;
            label4.Text = h.HCode;

            label7.Visible = true;
            label4.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

            pictureBox2.Image = Image.FromFile(h.PictureAddress);
        }
    }
}
