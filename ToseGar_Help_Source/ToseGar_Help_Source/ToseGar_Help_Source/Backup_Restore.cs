using System;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;

namespace ToseGar_Help_Source
{
    public partial class Backup_Restore : UserControl
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        public Backup_Restore()
        {
            InitializeComponent();
        }

        #region Connection Strings
        private string BackUpConString = @"data source=(local);initial catalog=ToseGar;integrated security=True;multipleactiveresultsets=True"; // کانکشن استرینگ برای دسترسی به دیتابیس اصلی
        private string ReStoreConString = "Data Source=(local);Initial Catalog=master;Integrated Security=True"; // کانکشن استرینگ برای دسترسی به دیتابیس مستر
        #endregion

        #region Backup
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            circularProgress1.Visible = true;
            circularProgress1.Start();

            using (SqlConnection con = new SqlConnection(BackUpConString))
            {
                ServerConnection srvConn = new ServerConnection(con);
                Server srvr = new Server(srvConn);

                if (srvr != null)
                {
                    try
                    {
                        Backup bkpDatabase = new Backup();
                        bkpDatabase.Action = BackupActionType.Database;
                        bkpDatabase.Database = "ToseGar"; // باید هم نام با دیتابیس برنامه تنظیم شود
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "BackUp File|*.araDB";
                        sfd.FileName = "BackUp_" + (DateTime.Now.ToShortDateString().Replace('/', '.'));
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            BackupDeviceItem bkpDevice = new BackupDeviceItem(sfd.FileName, DeviceType.File);
                            bkpDatabase.Devices.Add(bkpDevice);
                            bkpDatabase.SqlBackup(srvr);
                            MessageBox.Show("!فایل پشتیبان با موفقیت ذخیره شد", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception s) { MessageBox.Show("!لطفا فایل بشتیبان را در درایوی غیر از درایو ویندوز ذخیره کنید", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }

            circularProgress1.Stop();
            circularProgress1.Visible = false;
        }
        #endregion

        #region Restore
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            circularProgress1.Visible = true;
            circularProgress1.Start();

            if (MessageBox.Show("!!!ممکن است تمام اطلاعات حال حاظر بانک اطلاعاتی شما تغییر کند \n !اگر مشکلی با این مورد ندارید بله را انتخاب کنید", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqlConnection.ClearAllPools();
                using (SqlConnection con = new SqlConnection(ReStoreConString))
                {
                    ServerConnection srvConn = new ServerConnection(con);
                    Server srvr = new Server(srvConn);

                    srvr.KillAllProcesses("ToseGar");
                    if (srvr != null)
                    {
                        try
                        {
                            Restore rstDatabase = new Restore();
                            rstDatabase.Action = RestoreActionType.Database;
                            rstDatabase.Database = "ToseGar"; // باید هم نام با دیتابیس برنامه تنظیم شود
                            OpenFileDialog opfd = new OpenFileDialog();
                            opfd.Filter = "BackUp File|*.araDB";

                            if (opfd.ShowDialog() == DialogResult.OK)
                            {
                                BackupDeviceItem bkpDevice = new BackupDeviceItem(opfd.FileName, DeviceType.File);
                                rstDatabase.Devices.Add(bkpDevice);

                                rstDatabase.ReplaceDatabase = true;
                                rstDatabase.SqlRestore(srvr);
                                MessageBox.Show("!اطلاعات با موفقیت بازیابی شد", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception f)
                        {
                            MessageBox.Show(f.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            circularProgress1.Stop();
            circularProgress1.Visible = false;
        }
        #endregion
    }
}
