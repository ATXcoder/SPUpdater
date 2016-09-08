using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management.Automation;
using PWS = System.Management.Automation.PowerShell;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using log4net;

namespace SPUpdater
{
    class PowerShell
    {
        ILog log = LogManager.GetLogger(typeof(PowerShell));
        public bool PowershellExists()
        {
            log.Info("Checking for the exsistence of Powershell");
            string regval = Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1", "Install", null).ToString();
            if (regval.Equals("1"))
                return true;
            else
                return false;
        }

        public string GetPowershellVersion()
        {
            log.Info("Checking to see what version of Powershell is installed");
            string version = String.Empty;
            using (PWS ps = PWS.Create())
            {
                
                ps.AddScript("./Scripts/PowerShell/PSVersion.ps1");
                if (ps.Streams.Error.Count > 0)
                {
                    foreach (var item in ps.Streams.Error)
                    {
                        log.Error(item.ErrorDetails.Message.ToString());
                        version = "ERROR";
                    }
                }
                else
                {
                    foreach (PSObject item in ps.Invoke())
                    {
                        version = item.Members["Major"].Value + "." + item.Members["Minor"].Value;
                        log.Info("Powershell version: " + version);
                    }
                }                
            }
            return version;
        }

        public void GetPatchBaseline()
        {
            
        }

        public Dictionary<string, string> GetSystemInfo()
        {
            Dictionary<string, string> obj = new Dictionary<string, string>();
            
            using (PWS ps = PWS.Create())
            {

                ps.AddScript("./Scripts/PowerShell/SysInfo.ps1");

                foreach (PSObject item in ps.Invoke())
                {
                    obj.Add("PS_Version", item.Members["PowerShell_Version"].Value.ToString());
                    obj.Add("OS_Version", item.Members["OS_Version"].Value.ToString());
                }
            }
            return obj;
        }

        public void UpdateExecutionPolicy(Microsoft.PowerShell.ExecutionPolicy policy)
        {
            log.Info("Attempting to update Powershell Execution policy");
            using (PWS ps = PWS.Create())
            {
                ps.AddScript("Set-Executionpolicy -Scope CurrentUser -ExecutionPolicy " + policy.ToString());
                
                //ps.AddScript("./Scripts/PowerShell/UpdateExecutionPolicy.ps1 -policy " + policy.ToString());
                var result = ps.Invoke();
                if (ps.Streams.Error.Count > 0)
                {
                    log.Error(ps.Streams.Error[0].ErrorDetails.Message);
                }
               
                //log.Info("Current Powershell execution policy changed from '" + result[0].Members["CurrentPolicy"].Value.ToString() + "' to '"+ result[0].Members["NewPolicy"].Value.ToString()+"'");
                
            }
        }
    }
}
