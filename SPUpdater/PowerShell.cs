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


namespace SPUpdater
{
    class PowerShell
    {
        public bool PowershellExists()
        {
            string regval = Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1", "Install", null).ToString();
            if (regval.Equals("1"))
                return true;
            else
                return false;
        }

        public string GetPowershellVersion()
        {
            string version = String.Empty;
            using (PWS ps = PWS.Create())
            {
                
                ps.AddScript("./Scripts/PowerShell/PSVersion.ps1");

                foreach (PSObject item in ps.Invoke())
                {
                    version = item.Members["Major"].Value + "." + item.Members["Minor"].Value;
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
            using (System.Management.Automation.PowerShell PowerShellInstance = System.Management.Automation.PowerShell.Create())
            {
                string script = "Set-ExecutionPolicy -Scope Process -ExecutionPolicy Unrestricted; Get-ExecutionPolicy"; // the second command to know the ExecutionPolicy level
                PowerShellInstance.AddScript(script);
                var someResult = PowerShellInstance.Invoke();
                PSObject tess = someResult[0];
            }
        }
    }
}
