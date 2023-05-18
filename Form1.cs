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
using System.Globalization;

namespace CheckTrips360
{
    public enum searchType
    {
        ID,
        TAG,
        XPATH
    }

    public enum Airlines
    {
        VIVA = 1,
        AEROMEXICO = 2
    }

    public partial class Form1 : Form
    {
        MappingsFlights mappingsFlights = new MappingsFlights();
        IWebDriver driver = null;
        ChromeOptions options = new ChromeOptions();
        IBusquedaBrowser browser;
        private Quotation mainQuotation;
        List<Flight> vuelosSeleccionados;
        public Form1()
        {
            InitializeComponent();
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

        private List<Flight> IniciatBusqueda(string tipo)
        {
            driver.Navigate().GoToUrl("https://www.vivaaerobus.com/");
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)); // Maximum wait time of 10 seconds
            Thread.Sleep(2000);
            try
            {
                IReadOnlyCollection<IWebElement> btnCookies = driver.FindElements(By.CssSelector(".viva-btn.quick-add"));
                if (btnCookies.Count() > 0)
                    btnCookies.ElementAt(0).Click();
            } catch(Exception ex) { }

            UIGenericActions.WaitUntilElementIsVisible("//app-booker-search//app-flight-select//label[@for='type_1']//span[1]", UIGenericActions.searchType.XPATH, driver, null, false);

            IWebElement rdbViajeSencillo = driver.FindElement(By.XPath(PageElements.RdbViajeSencillo));
            IWebElement txtViajeOrigen = driver.FindElement(By.XPath(PageElements.TxtViajeOrigen));
            IWebElement txtViajeDestino = driver.FindElement(By.XPath(PageElements.TxtViajeDestino));
            IWebElement divViajeOrigen = driver.FindElement(By.XPath(PageElements.DivActivaCamposViaje));

            IWebElement divResultadoOrigen = null;

            rdbViajeSencillo.Click();
            divViajeOrigen.Click();

            txtViajeOrigen.SendKeys(tipo == "Salida" ? txtOrigen.Text : txtDestino.Text);
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

                txtViajeDestino.SendKeys(tipo == "Salida" ? txtDestino.Text : txtOrigen.Text);
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
                UIGenericActions.SelectFechaSalida(driver, tipo == "Salida" ? dtpFechaInicio.Value : dtpFechaFin.Value);
                IWebElement btnBuscar = driver.FindElement(By.CssSelector("button.viva-btn.action"));
                btnBuscar.Click();


                FactoryBusqueda factoryBusqueda = new FactoryBusqueda(Aerolinea.VIVA);
                browser = factoryBusqueda.GetBuscador();
                this.mainQuotation = CreatQuotation(tipo);
                browser.Quotation = this.mainQuotation;
                browser.Driver = driver;

                return browser.BuscarVuelos(tipo);
            }
            return new List<Flight>();
        }

        private Quotation CreatQuotation(string tipo)
        {
            return new Quotation()
            {
                Origin = tipo == "Salida" ? txtOrigen.Text : txtDestino.Text,
                Destination = tipo == "Salida" ? txtDestino.Text : txtOrigen.Text,
                StartDate = dtpFechaInicio.Value,
                EndDate = dtpFechaFin.Value,
                IsRoundTrip = rdbRedondo.Checked,
                IncludeConexions = chkConexiones.Checked,
                AirlineCatalogId = ((int)Airlines.VIVA),
                Emision = txtEmision.Text,
                MaxResults = int.Parse(String.IsNullOrWhiteSpace(txtMaxResults.Text) ? "100" : txtMaxResults.Text)
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
            if (Validar())
            {
                Conectar();
                CargarGrid(IniciatBusqueda("Salida"));
                if (rdbRedondo.Checked)
                    CargarGrid(IniciatBusqueda("Regreso"));
            }

        }
        private bool Validar()
        {
            bool error = true;
            if (txtOrigen.Text.Trim() == "")
            {
                MessageBox.Show("Proporcione la Ciudad Origen", "Advertencia", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                error = false;
            }
            else if (txtDestino.Text.Trim() == "")
            {
                MessageBox.Show("Proporcione la Ciudad Destino", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                error = false;
            }
            else if (rdbRedondo.Checked && dtpFechaFin.Value <= dtpFechaInicio.Value)
            {
                MessageBox.Show("La Fecha Fin debe ser mayor a la Fecha Inicio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                error = false;
            }
            return error;
        }
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {

        }

        private void CargarGrid(List<Flight> vuelos)
        {
            dtgVuelos.AutoGenerateColumns = true;
            dtgVuelos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgVuelos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dtgVuelos.ReadOnly = true;

            /* DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
             checkColumn.Name = "Check";
             checkColumn.HeaderText = "Select";
             dtgVuelos.Columns.Add(checkColumn);*/

            
            if (this.browser.Quotation.AirlineCatalogId == ((int)Airlines.VIVA))
            {
                DataTable cargaPrevia = (DataTable)dtgVuelos.DataSource;
                List<VviaFlight> vviaFlights = vuelos.Select(mappingsFlights.MapToVviaFlight).ToList();
                if (cargaPrevia != null)
                {
                    cargaPrevia.Merge(vviaFlights.ToDataTableViva());
                    dtgVuelos.DataSource = cargaPrevia;
                }
                else
                    dtgVuelos.DataSource = vviaFlights.ToDataTableViva();
            }

            //dtgVuelos.Columns["StartDate"].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm";
            //dtgVuelos.Columns["EndDate"].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm";
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Format = "c";
            cellStyle.FormatProvider = CultureInfo.CurrentCulture;
            dtgVuelos.Columns["BasePrice"].DefaultCellStyle = cellStyle;
            dtgVuelos.Columns["BasePrice"].DefaultCellStyle.Format = "c";
            dtgVuelos.Columns["TUA"].DefaultCellStyle.Format = "N2";
            dtgVuelos.Columns["TUA"].DefaultCellStyle.FormatProvider = CultureInfo.CurrentCulture;
            dtgVuelos.Columns["Emision"].DefaultCellStyle.Format = "C2";

            dtgVuelos.Columns["ConexionDetail"].HeaderText = "Conexion";
            dtgVuelos.Columns["ConexionDetail"].DefaultCellStyle.Font = new Font("Arial", 09, FontStyle.Bold);
            dtgVuelos.Columns["ConexionDetail"].DefaultCellStyle.BackColor = Color.Beige;
            dtgVuelos.Columns["AlertaAsientoDetalle"].HeaderText = "Disponibilidad";
            dtgVuelos.Columns["AlertaAsientoDetalle"].DefaultCellStyle.BackColor = Color.Beige;
            dtgVuelos.Columns["AlertaAsientoDetalle"].DefaultCellStyle.Font = new Font("Arial", 09, FontStyle.Bold);

            dtgVuelos.Columns["NumVuelo"].DefaultCellStyle.Font =  new Font("Arial", 09, FontStyle.Bold);
            dtgVuelos.Columns["Horario"].DefaultCellStyle.Font = new Font("Arial", 09, FontStyle.Bold);

            dtgVuelos.Columns["CreatedDate"].Visible = true;
            if (this.browser.Quotation.AirlineCatalogId == ((int)Airlines.VIVA))
            {
                dtgVuelos.Columns["Ligth"].DefaultCellStyle.Format = "C2";
                dtgVuelos.Columns["Extra"].DefaultCellStyle.Format = "C2";
                dtgVuelos.Columns["Smart"].DefaultCellStyle.Format = "C2";
            };
            this.vuelosSeleccionados = vuelos;
            dtgVuelos.Sort(dtgVuelos.Columns["CreatedDate"], ListSortDirection.Ascending);

        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ExcelTransfer excelTransfer = new ExcelTransfer();
            if (this.mainQuotation != null)
            {
                if (this.browser.Quotation.AirlineCatalogId == ((int)Airlines.VIVA))
                {
                    List<VviaFlight> vviaFlights = this.vuelosSeleccionados.Select(mappingsFlights.MapToVviaFlight).ToList();
                    excelTransfer.StartProcesingSpreadSheet("", vviaFlights);
                }

               // excelTransfer.StartProcesingSpreadSheet("");
                excelTransfer.CopyCotizador(this.mainQuotation.Origin.ToUpper()+"-"+this.mainQuotation.Destination.ToUpper());
                MessageBox.Show("File copied successfully!");
            }
        }

        private void rdbRedondo_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdbRedondo.Checked)
            {
                dtpFechaFin.Enabled = true;
                rdbSencillo.Checked = false;
            }
        }

        private void rdbSencillo_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdbSencillo.Checked)
            {
                dtpFechaFin.Enabled = false;
                rdbRedondo.Checked = false;
                dtpFechaFin.ResetText();
            }
        }

        private void txtMaxResults_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is a number.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Prevent the key from being entered into the textbox.
                e.Handled = true;
            }
        }

        private void txtOrigen_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = textBox.Text.ToUpper();
            textBox.Select(textBox.Text.Length, 0);
        }

        private void txtDestino_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = textBox.Text.ToUpper();
            textBox.Select(textBox.Text.Length, 0);
        }
    }
}
