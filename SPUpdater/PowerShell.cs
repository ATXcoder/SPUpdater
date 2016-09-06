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

                foreach (PSObject item in ps.Invoke())
                {
                    version = item.Members["Major"].Value + "." + item.Members["Minor"].Value;
                    log.Info("Powershell version: " + version);
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

        public void UpdateExecutionPolicy()
        {
            log.Info("Attempting to update Powershell Execution policy");
            using (System.Management.Automation.PowerShell PowerShellInstance = System.Management.Automation.PowerShell.Create())
            {
                string script = "Set-ExecutionPolicy -Scope Process -ExecutionPolicy Unrestricted; Get-ExecutionPolicy"; // the second command to know the ExecutionPolicy level
                PowerShellInstance.AddScript(script);
                var someResult = PowerShellInstance.Invoke();
                PSObject test = someResult[0];
                if (test.Members["ToString"].Value.ToString() != null)
                {
                    log.Info("Powershell execution policy set to '" + test.Members["ToString"].Value.ToString());
                }
            }
        }
    }
}
