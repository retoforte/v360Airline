using CheckTrips360.DTO;
using CheckTrips360.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckTrips360.Visa
{
    public class VisaViewModel
    {
        public List<VisaUser> visaUsers = new List<VisaUser>();
        IWebDriver driver = null;
        ChromeOptions options = new ChromeOptions();
        ManageProcess manageProcess = new ManageProcess();
        public void AddUser(VisaUser user)
        {
            visaUsers.Add(user);
        }
        public void Iniciar()
        {
            manageProcess.LaunchChromeWithDebugging("9018");
            this.Conectar();
        }
        private void Conectar()
        {
            Thread.Sleep(3000);
            options = new ChromeOptions();
            options.DebuggerAddress = "127.0.0.1:9018";
            driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("https://ais.usvisa-info.com/es-mx/niv/users/sign_in");
            driver.Manage().Window.Maximize();
        }

        public void ProcesarVisas()
        {
            foreach (VisaUser visaUser in this.visaUsers)
            {
                Login(visaUser);
                SeleccionarPorNombre(visaUser);
                SeleccionarReprogramar();
                BuscarEstado(visaUser);
            }
        }

        private void Login(VisaUser visaUser)
        {
            IWebElement txtUser = driver.FindElement(By.Id("user_email"));
            IWebElement txtPass = driver.FindElement(By.Id("user_password"));
            IWebElement check = driver.FindElement(By.Id("policy_confirmed"));
            
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", txtUser);
            txtUser.SendKeys(visaUser.UserName);
            txtPass.SendKeys(visaUser.Password);

            UIGenericActions.WaitUntilElementIsVisible("//[@id='policy_confirmed']", UIGenericActions.searchType.XPATH, driver, null, false);

            IWebElement btn = driver.FindElement(By.XPath("//[@id='policy_confirmed']"));

            check.Click();
            btn.Click();
        }

        private void SeleccionarPorNombre(VisaUser visaUser)
        {
            UIGenericActions.WaitUntilElementIsVisible(".application.attend_appointment.card.success", UIGenericActions.searchType.CSSLOCATOR, driver, null, true);
            IReadOnlyCollection<IWebElement> citas = driver.FindElements(By.CssSelector(".application.attend_appointment.card.success"));
            foreach (var element in citas)
            {
                string nombre = element.Text;
                if (nombre.ToUpper().Trim() == visaUser.FullName.ToUpper().Trim())
                {
                    IWebElement continuar = element.FindElement(By.CssSelector(".button.primary.small"));
                    continuar.Click();
                    break;
                }
            }
        }

        private void SeleccionarReprogramar()
        {
            UIGenericActions.WaitUntilElementIsVisible(".accordion-item", UIGenericActions.searchType.CSSLOCATOR, driver, null, true);
            IReadOnlyCollection<IWebElement> acordiones = driver.FindElements(By.CssSelector(".accordion-title"));
            foreach (var element in acordiones)
            {
                string nombre = element.Text;
                if (nombre.ToUpper().Trim() == "Reprogramar cita")
                {
                    element.Click();
                    Thread.Sleep(3000);

                    IReadOnlyCollection<IWebElement> btns = element.FindElements(By.CssSelector(".button.small.primary.small-only-expanded"));
                    btns.ElementAt(0).Click();
                    Thread.Sleep(2000);
                    break;
                }
            }
        }
        private void BuscarEstado(VisaUser visaUser)
        {
            IWebElement cmbEstado = driver.FindElement(By.Id("appointments_consulate_appointment_facility_id"));
            cmbEstado.Click();
        }
    }
}
