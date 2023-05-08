using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTrips360.Utils
{
    public class ManageProcess
    {
        public void KillChrome()
        {
            Process[] chromeProcesses = Process.GetProcessesByName("chrome");

            // Kill all Chrome processes
            foreach (Process chromeProcess in chromeProcesses)
            {
                chromeProcess.Kill();
            }
        }

        public void KillChromeDriver()
        {
            Process[] chromeProcesses = Process.GetProcessesByName("chromedriver");

            // Kill all Chrome processes
            foreach (Process chromeProcess in chromeProcesses)
            {
                chromeProcess.Kill();
            }
        }

        public void LaunchChromeWithDebugging()
        {
            string chromeExecutablePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            string chromeOptions = "--remote-debugging-port=9014 --disable-web-security --user-data-dir=\"C:\\Users\\kandrade\\AppData\\Local\\Google\\Chrome\\User Data\" --disable-web-security --user-data-dir=~/chromeTemp";

            ProcessStartInfo startInfo = new ProcessStartInfo(chromeExecutablePath, chromeOptions);
            Process.Start(startInfo);
        }
    }
}
