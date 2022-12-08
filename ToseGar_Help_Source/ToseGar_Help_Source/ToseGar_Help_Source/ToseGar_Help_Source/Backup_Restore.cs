using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;

namespace ToseGar_Help_Source
{
    public partial class Backup_Restore : UserControl
    {
        public Backup_Restore()
        {
            InitializeComponent();
        }

        private string BackUpConString = @"data source=(local);initial catalog=ToseGar;integrated security=True;multipleactiveresultsets=True";//Connection String baraye Dastyabi be Data base Asli
        private string ReStoreConString = "Data Source=(local);Initial Catalog=master;Integrated Security=True";//Connection String baraye dastresi be data base Master


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
                        bkpDatabase.Database = "ToseGar";//Bayad ham nam ba Data base barname tanzim shavad
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "BackUp File|*.araDB";
                        sfd.FileName = "BackUp_" + (DateTime.Now.ToShortDateString().Replace('/', '.'));
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            BackupDeviceItem bkpDevice = new BackupDeviceItem(sfd.FileName, DeviceType.File);
                            bkpDatabase.Devices.Add(bkpDevice);
                            bkpDatabase.SqlBackup(srvr);
                            MessageBox.Show("فایل پشتیبان با موفقیت ذخیره شده", "Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception s) { MessageBox.Show("لطفا فایل بک آپ را در درایوی غیر از درایو ویندوز ذخیره کنید"); }
                }
            }
            circularProgress1.Stop();
            circularProgress1.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            circularProgress1.Visible = true;
            circularProgress1.Start();
            if (MessageBox.Show("ممکن است تمام اطلاعات حال حاظر بانک اطلاعاتی شما تغییر کند!!! \n اگر مشکلی با این مورد ندارید بله را انتخاب کنید", "DataBase ReStore", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                            rstDatabase.Database = "ToseGar";//Bayad ham nam ba Data base barname tanzim shavad
                            OpenFileDialog opfd = new OpenFileDialog();
                            opfd.Filter = "BackUp File|*.araDB";
                            if (opfd.ShowDialog() == DialogResult.OK)
                            {

                                BackupDeviceItem bkpDevice = new BackupDeviceItem(opfd.FileName, DeviceType.File);
                                rstDatabase.Devices.Add(bkpDevice);

                                rstDatabase.ReplaceDatabase = true;
                                rstDatabase.SqlRestore(srvr);
                                MessageBox.Show("اطلاعات با موفقیت بازیابی شد", "Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception f)
                        {
                            MessageBox.Show(f.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            circularProgress1.Stop();
            circularProgress1.Visible = false;
        }
    }
}
