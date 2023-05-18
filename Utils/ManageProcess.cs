using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        /// <summary>
        /// Only allows one instance of chrome
        /// </summary>
        public bool CheckIfChromeIsRunning()
        {
            Process[] chromeProcesses = Process.GetProcessesByName("chrome");

            if (chromeProcesses != null && chromeProcesses.Length > 1)
            {
                for (int i = 1; i < chromeProcesses.Length; i++)
                    chromeProcesses[i].Kill();

                return true;
            }
            else
                return false;
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

        public bool CheckIfRunningChromeDriver()
        {
            Process[] chromeProcesses = Process.GetProcessesByName("chromedriver");
            return chromeProcesses != null && chromeProcesses.Length > 0;
        }

        public void LaunchChromeWithDebugging()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string chromeProfilePath = Path.Combine(appDataPath, "Google\\Chrome\\User\\Default");
            string chromeExecutablePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            
            string chromeOptions = "--remote-debugging-port=9014 --disable-web-security --disable-web-security --user-data-dir="+ chromeProfilePath;
            //string chromeOptions = "--remote-debugging-port=9014 --disable-web-security --user-data-dir=\"C:\\Users\\kandrade\\AppData\\Local\\Google\\Chrome\\User Data\" --disable-web-security --user-data-dir=~/chromeTemp";

            ProcessStartInfo startInfo = new ProcessStartInfo(chromeExecutablePath, chromeOptions);
            Process.Start(startInfo);
        }
    }
}
