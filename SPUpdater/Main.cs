using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPUpdater
{
    public partial class Main : Form
    {
        // Configure logger
        ILog log = LogManager.GetLogger(typeof(Main));

        DataTable dt;
        DataView dv;

        DatabaseHelper db;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Service service = new Service();
            ////service.GetServices();
            ////Service.ServiceObject so = service.GetServiceInfo("AdobeARMservice");

            //Update update = new SPUpdater.Update();
            ////update.CheckForUpdates("SharePoint Server 2013", "CU");
            log.Info(System.Environment.NewLine +
                     "########################################" + System.Environment.NewLine +
                     "# SharePoint 2013 Updater              #" + System.Environment.NewLine +
                     "# By: Thomas Sloan                     #" + System.Environment.NewLine +
                     "########################################" + System.Environment.NewLine);
            db = new DatabaseHelper();
            PowerShell ps = new PowerShell();
            ps.UpdateExecutionPolicy(Microsoft.PowerShell.ExecutionPolicy.Unrestricted);
            ps.GetPowershellVersion();

            // Start the BackgroundWorker.
            panel1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        #region Download Updates Information
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            log.Info("Downloading updated information from https://sharepointupdates.com");
            Update update = new SPUpdater.Update();
            DataTable data = new DataTable();
            data = update.CheckForUpdates();

            e.Result = data;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            log.Info("Updated information downloaded");
            panel1.Visible = false;

            dt = (DataTable)e.Result;
            dt.DefaultView.Sort = "Product";

            dv = dt.DefaultView;
            GView_spupdates.DataSource = dv;
        }
        #endregion

        private void BTN_Search_Click(object sender, EventArgs e)
        {
            string product = String.Empty;
            string patch = String.Empty;

            if (DROP_Product.Text != null)
            {
                product = DROP_Product.Text;
            }

            if (DROP_Patch.Text != null)
            {
                /*
                 * Cumulative Update (CU)
                    Public Update (PU)
                    Security Hotfix (SC)
                    Non-Securirty Hotfix (HF)
                    Service Pack (SP)
                    Release to Manufacturing (RM)
                 */
                switch (DROP_Patch.Text)
                {
                    case "Cumulative Update (CU)":
                        patch = "CU";
                        break;
                    case "Public Update (PU)":
                        patch = "PU";
                        break;
                    case "Security Hotfix (SC)":
                        patch = "SC";
                        break;
                    case "Non-Security Hotfix (HF)":
                        patch = "HF";
                        break;
                    case "Service Pack (SP)":
                        patch = "SP";
                        break;
                    case "Release to Manufacturing (RM)":
                        patch = "RM";
                        break;
                    default:
                        break;
                }
                string filterQuery = "Product = '" + product + "' AND [Patch Type] = '" + patch + "'";
                log.Info("Filtering current data: " + filterQuery);
                dv.RowFilter = filterQuery;
                GView_spupdates.DataSource = dv;
                GView_spupdates.Refresh();
            }

        }

       

        private void Menu_Help_SysInfo_Click(object sender, EventArgs e)
        {
            SysInfo sysinfo = new SysInfo();
            sysinfo.Show();
        }

        private void CKBOX_DownloadOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (!CKBOX_DownloadOnly.Checked)
            {
                BTN_Download.Text = "Download and Install";
                log.Info("Download settings set to: DOWNLOAD AND INSTALL");
                BTN_Download.Refresh();
            }
            else
            {
                BTN_Download.Text = "Download Only";
                log.Info("Download settings set to: DOWNLOAD ONLY");
                BTN_Download.Refresh();
            }
        }

        private void BTN_Download_Click(object sender, EventArgs e)
        {
            if (BTN_Download.Text == "Download Only")
            {
                //Just going to download the updates
                foreach (DataGridViewRow item in GView_spupdates.SelectedRows)
                {
                    string product = item.Cells[0].Value.ToString();
                    string title = item.Cells[1].Value.ToString();
                    string kbnumber = item.Cells[3].Value.ToString();
                    log.Info("Begining download for: " + product + "(" + kbnumber + ") - " + title);

                    Update update = new Update();
                    update.DownloadUpdates(kbnumber, "./Updates/" + kbnumber);
                }
            }
            else
            {

            }
        }
    }
}
