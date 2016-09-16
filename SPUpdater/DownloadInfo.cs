using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPUpdater
{
    public partial class DownloadInfo : Form
    {
        // Configure logger
        ILog log = LogManager.GetLogger("Download_Info");
        string FileName = "";


        public string KBNUMBER { get; set; }

        public DownloadInfo()
        {
            InitializeComponent();
        }

        private void DownloadInfo_Load(object sender, EventArgs e)
        {

        }

        public void Download(string url, string downloadPath)
        {
            try
            {
                WebClient wb = new WebClient();
                
                wb.DownloadFileCompleted += wb_DownloadFileCompleted;
                wb.DownloadProgressChanged += wb_DownloadProgressChanged;
                Regex regex = new Regex(@"([^\/]+)\/?$");
                Match match = regex.Match(url);

                FileName = match.Value;
                wb.DownloadFileAsync(new Uri(url), downloadPath + "/" + match.Value);
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        private void wb_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            LBL_FileName.Text = FileName + "(" + e.ProgressPercentage.ToString() + ")";
        }

        private void wb_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.Text = "DOWNLOAD COMPLETE";
        }
    }
}
