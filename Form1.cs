using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using CheckTrips360.Utils;
using OpenQA.Selenium.Remote;
using System.Threading;
using System.Reflection;

namespace CheckTrips360
{
    public enum searchType
    {
        ID,
        TAG,
        XPATH
    }
    public partial class Form1 : Form
    {
        IWebDriver driver = null;
        ChromeOptions options = new ChromeOptions();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            driver.Navigate().GoToUrl("https://www.vivaaerobus.com/");
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)); // Maximum wait time of 10 seconds
            Thread.Sleep(2000);
            By elementLocator = By.XPath("//app-booker-search//app-flight-select//label[@for='type_1']//span[1]");
            wait.Until(driver =>
            {
                IWebElement element = driver.FindElement(elementLocator);
                return element.Displayed;
            });

            IWebElement rdbViajeSencillo = driver.FindElement(By.XPath(PageElements.RdbViajeSencillo));
            IWebElement txtViajeOrigen = driver.FindElement(By.XPath(PageElements.TxtViajeOrigen));
            IWebElement txtViajeDestino = driver.FindElement(By.XPath(PageElements.TxtViajeDestino));
            IWebElement divViajeOrigen = driver.FindElement(By.XPath(PageElements.DivActivaCamposViaje));

            IWebElement divResultadoOrigen = null;

            rdbViajeSencillo.Click();
            divViajeOrigen.Click();

            txtViajeOrigen.SendKeys("MONTERREY");
            Thread.Sleep(2000);
            // Del dropdown buscar el primer elemento y seleccionarlo
            UIGenericActions.WaitUntilElementIsVisible("//app-station-results", UIGenericActions.searchType.XPATH, driver);
            //divResultadoOrigen = driver.FindElements(By.XPath("//app-station-item//div[contains(@class, 'main-container')]"));
            IReadOnlyCollection<IWebElement> stationSavedItems = driver.FindElements(By.XPath("//app-station-item//div[contains(@class, 'main-container')]"));

            if (stationSavedItems.Count == 0)
                MessageBox.Show("La Ciudad Origen Proporcionada no fue encontrada!", "Advertencia", MessageBoxButtons.OK);
            else
            {
                // Seleccionar el viaje Origen
                IWebElement firstStationSavedItem = stationSavedItems.First();
                firstStationSavedItem.Click();

                txtViajeDestino.SendKeys("VILLAHERMOSA");
                // Del dropdown buscar el primer elemento y seleccionarlo
                // Buscando el Destino
                Thread.Sleep(1000);
                stationSavedItems = driver.FindElements(By.XPath("//app-station-destination-item//div[contains(@class, 'main-container')]"));

                if (stationSavedItems.Count == 0)
                {
                    MessageBox.Show("La Ciudad Destino Proporcionada no fue encontrada!", "Advertencia", MessageBoxButtons.OK);
                    driver.Quit();
                }
                else
                {
                    // Seleccionar el viaje Origen
                    firstStationSavedItem = stationSavedItems.First();
                    firstStationSavedItem.Click();
                }
                Thread.Sleep(3000);
                UIGenericActions.SelectFechaSalida(driver, DateTime.Now.AddDays(80));
                IWebElement btnBuscar = driver.FindElement(By.CssSelector("button.viva-btn.action"));
                btnBuscar.Click();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            driver.Quit();
        }

        private void btnStartConnection_Click(object sender, EventArgs e)
        {
            ManageProcess manageProcess = new ManageProcess();
            //manageProcess.KillChrome();
         //   manageProcess.LaunchChromeWithDebugging();
            manageProcess.KillChromeDriver();
            options = new ChromeOptions();
            /*options.AddArgument("--disable-web-security");
            options.AddArgument("--user-data-dir=C:\\Users\\khristian.andrade\\AppData\\Local\\Google\\Chrome\\User Data");
            */string chromeDriverPath = @"C:\temp\"; //chromedriver.exe
            options.DebuggerAddress = "127.0.0.1:9015";
            driver = new ChromeDriver(options);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (driver != null)
                driver.Quit();
        }
    }
}
