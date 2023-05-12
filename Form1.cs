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
using CheckTrips360.DbClasses;
using static CheckTrips360.Utils.Enumerados;
using CheckTrips360.DTO;

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
            IniciatBusqueda();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            driver.Quit();
        }

        private void btnStartConnection_Click(object sender, EventArgs e)
        {
            Conectar();
        }

        private void Conectar()
        {
            ManageProcess manageProcess = new ManageProcess();
            manageProcess.KillChrome();
            manageProcess.KillChromeDriver();
            manageProcess.LaunchChromeWithDebugging();
            Thread.Sleep(3000);
            options = new ChromeOptions();

            options.DebuggerAddress = "127.0.0.1:9014";
            driver = new ChromeDriver(options);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (driver != null)
                driver.Quit();
        }

        private void btnConnectDb_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.BackColor = Color.Red;
            DBManager bBManager = new DBManager();
            bBManager.CountQuotation();
        }

        private void IniciatBusqueda()
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

            txtViajeOrigen.SendKeys("GUADALAJARA");
            Thread.Sleep(2000);
            // Del dropdown buscar el primer elemento y seleccionarlo
            UIGenericActions.WaitUntilElementIsVisible("//app-station-results", UIGenericActions.searchType.XPATH, driver, null);
            //divResultadoOrigen = driver.FindElements(By.XPath("//app-station-item//div[contains(@class, 'main-container')]"));
            IReadOnlyCollection<IWebElement> stationSavedItems = driver.FindElements(By.XPath("//app-station-item//div[contains(@class, 'main-container')]"));

            if (stationSavedItems.Count == 0)
                MessageBox.Show("La Ciudad Origen Proporcionada no fue encontrada!", "Advertencia", MessageBoxButtons.OK);
            else
            {
                // Seleccionar el viaje Origen
                IWebElement firstStationSavedItem = stationSavedItems.First();
                firstStationSavedItem.Click();

                txtViajeDestino.SendKeys("CANCUN");
                // Del dropdown buscar el primer elemento y seleccionarlo
                // Buscando el Destino
                Thread.Sleep(500);
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
                Thread.Sleep(2000);
                UIGenericActions.SelectFechaSalida(driver, DateTime.Now.AddDays(80));
                IWebElement btnBuscar = driver.FindElement(By.CssSelector("button.viva-btn.action"));
                btnBuscar.Click();


                FactoryBusqueda factoryBusqueda = new FactoryBusqueda(Aerolinea.VIVA);
                IBusquedaBrowser browser = factoryBusqueda.GetBuscador();
                browser.Quotation = CreatQuotation();
                browser.Driver = driver;
                browser.BuscarVuelos();
            }
        }

        private Quotation CreatQuotation()
        {
            return new Quotation()
            {
                Origin = txtOrigen.Text,
                Destination = txtDestino.Text,
                StartDate = dtpFechaInicio.Value,
                EndDate = dtpFechaFin.Value,
                IsRoundTrip = rdbRedondo.Checked,
                IncludeConexions = chkConexiones.Checked
            };
        }

        private void rdbSencillo_CheckedChanged(object sender, EventArgs e)
        {
            rdbRedondo.Checked = false;
        }

        private void rdbRedondo_CheckedChanged(object sender, EventArgs e)
        {
            rdbSencillo.Checked = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Conectar();
            IniciatBusqueda();
        }
    }
}
