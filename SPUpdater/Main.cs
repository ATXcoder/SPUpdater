using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            PowerShell ps = new PowerShell();

            MessageBox.Show(ps.GetPowershellVersion());

            // Start the BackgroundWorker.
            panel1.Visible = true;
            //backgroundWorker1.RunWorkerAsync();
        }

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

        private void Menu_Help_SysInfo_Click(object sender, EventArgs e)
        {
            SysInfo sysinfo = new SysInfo();
            sysinfo.Show();
        }
    }
}
