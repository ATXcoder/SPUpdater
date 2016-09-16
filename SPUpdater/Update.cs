using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;
using Newtonsoft.Json;
using System.Net.Http;
using RestSharp;
using RestSharp.Deserializers;
using System.Data;
using System.ComponentModel;
using System.Net;
using log4net;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace SPUpdater
{
    public class SPUpdate
    {
        public string fileName { get; set; }
        public string version { get; set; }
        public string downloadURI { get; set; }
        public string filePath { get; set; }
        public bool needed { get; set; }
        public bool optional { get; set; } 
    }

    public class SharePointUpdates
    {
        public class Article
        {
            public string ProductInfo { get; set; }
            public string KnownIssues { get; set; }
            public string Id { get; set; }
            public string Title { get; set; }
            public string KBNumb { get; set; }
            public string KBUrl { get; set; }
            public string BuildNumber { get; set; }
            public string Product { get; set; }
            public string RequiredLevel { get; set; }
            public string PatchType { get; set; }
            public string PatchNotes { get; set; }
            public string DateAdded { get; set; }
            public string Guid { get; set; }
        }

        public class ArticleDetail
        {
            public string Title { get; set; }
            public string KBNumb { get; set; }
            public string KBUrl { get; set; }
            public string BuildNumber { get; set; }
            public string RequiredLevel { get; set; }
            public string PatchNotes { get; set; }
            public string PatchUrl1 { get; set; }
            public string PatchUrl2 { get; set; }
            public string PatchUrl3 { get; set; }
        }

        public class KnownIssue
        {
            public string IssueTitle { get; set; }
        }
    }

    public class Update
    {
        static Dictionary<string, string> DownloadList = new Dictionary<string, string>();
        static DataTable DownloadTable = new DataTable();



        public enum UpdateStatus{
            Queued, Pending, Downloading, Complete, Error
        }
        // Configure logger
        ILog log = LogManager.GetLogger(typeof(Update));

        public DataTable CheckForUpdates()
        {
            string baseURL = "https://sharepointupdates.com/api/";

            var client = new RestClient(baseURL);

            var request = new RestRequest();
            request.Resource = "articles";
            request.Method = Method.GET;
            request.RequestFormat = DataFormat.Json;

            
            IRestResponse<SharePointUpdates.Article> response = client.Execute<SharePointUpdates.Article>(request);
            JsonDeserializer deserial = new JsonDeserializer();
            List<SharePointUpdates.Article> content = deserial.Deserialize<List<SharePointUpdates.Article>>(response);

            DataTable dt = new DataTable();
            dt.Columns.Add("Product");
            dt.Columns.Add("Title");
            dt.Columns.Add("Build Number");
            dt.Columns.Add("KB Number");
            dt.Columns.Add("KB URL");
            dt.Columns.Add("Required Level");
            dt.Columns.Add("Patch Type");
            dt.Columns.Add("Patch Notes");
            dt.Columns.Add("Date Added");
            dt.Columns.Add("GUID");
            

            foreach (var item in content)
            {
                DataRow dr = dt.NewRow();

                dr["Product"] = item.Product;
                dr["Title"] = item.Title;
                dr["Build Number"] = item.BuildNumber;
                dr["KB Number"] = item.KBNumb;
                dr["KB URL"] = item.KBUrl;
                dr["Required Level"] = item.RequiredLevel;
                dr["Patch Type"] = item.PatchType;
                dr["Patch Notes"] = item.PatchNotes;
                dr["Date Added"] = item.DateAdded;
                dr["GUID"] = item.Guid;

                dt.Rows.Add(dr);
            }

            return dt;    
        }

        public void DownloadUpdates(string kbnumber, string downloadPath)
        {
            // Create a folder for the download
            string dlFolder = "./Updates/" + kbnumber;
            System.IO.Directory.CreateDirectory(dlFolder);

            string baseURL = "https://sharepointupdates.com/api/";

            var client = new RestClient(baseURL);

            var request = new RestRequest();
            request.Resource = "articles/" + kbnumber;
            request.Method = Method.GET;
            request.RequestFormat = DataFormat.Json;

            
            IRestResponse<SharePointUpdates.ArticleDetail> response = client.Execute<SharePointUpdates.ArticleDetail>(request);
            JsonDeserializer deserial = new JsonDeserializer();
            List<SharePointUpdates.ArticleDetail> content = deserial.Deserialize<List<SharePointUpdates.ArticleDetail>>(response);

            List<string> patches = new List<string>();
 
            if (content[0].PatchUrl1 != null)
            {
                patches.Add(content[0].PatchUrl1);
            }

            if (content[0].PatchUrl2 != null)
            {
                patches.Add(content[0].PatchUrl2);
            }

            if (content[0].PatchUrl3 != null)
            {
                patches.Add(content[0].PatchUrl3);
            }


            foreach (var item in patches)
            {
                try
                {
                    log.Info("Downloading update from " + item);

                    string downloadID = Guid.NewGuid().ToString();
                    
                    DownloadInfo downloadinfo = new DownloadInfo();
                    downloadinfo.Download(item, dlFolder);
                    downloadinfo.Show();
                    downloadinfo.KBNUMBER = kbnumber;
                } catch(Exception ex)
                {
                    log.Error(ex.ToString());
                }
            }
           
        }

        void UpdateDownloadList(string KBNumber, string guid, UpdateStatus status)
        {
            
        }

        public void InstallUpdate(SPUpdate update)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = update.fileName;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using-statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }
        }


    }
}
