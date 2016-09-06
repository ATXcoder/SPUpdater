using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPUpdater
{
    public partial class SysInfo : Form
    {
        public SysInfo()
        {
            InitializeComponent();
        }

        private void SysInfo_Load(object sender, EventArgs e)
        {
            PowerShell ps = new PowerShell();
            Dictionary<string, string> obj = ps.GetSystemInfo();

            LBL_OSVersion.Text = obj["OS_Version"];
            LBL_PSVersion.Text = obj["PS_Version"];
        }
    }
}
