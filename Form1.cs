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
using CheckTrips360.Exceptions;

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
        private Aerolinea selectedAerolinea;

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
            try
            {
                FactoryBusqueda factoryBusqueda = new FactoryBusqueda(this.selectedAerolinea);
                browser = factoryBusqueda.GetBuscador();
                this.mainQuotation = CreatQuotation(tipo);
                browser.Quotation = this.mainQuotation;
                browser.Driver = driver;
                browser.IniciarProceso(driver, tipo, txtOrigen.Text, txtDestino.Text, dtpFechaInicio.Value, dtpFechaFin.Value);
                return browser.BuscarVuelos(tipo);
            }
            catch (UIValidationMessageException uiEx)
            {
                MessageBox.Show(uiEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                AirlineCatalogId = ((int)this.selectedAerolinea),
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
            
            if (this.browser.Quotation.AirlineCatalogId == ((int)Aerolinea.VIVA))
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
            if (this.browser.Quotation.AirlineCatalogId == ((int)Aerolinea.VIVA))
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
                if (this.browser.Quotation.AirlineCatalogId == ((int)Aerolinea.VIVA))
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

        private void btnAeromexico_Click(object sender, EventArgs e)
        {
            btnViva.FlatAppearance.BorderSize = 0;
            btnAeromexico.FlatAppearance.BorderSize = 5;
            this.selectedAerolinea = Aerolinea.AEROMEXICO;
        }

        private void btnViva_Click(object sender, EventArgs e)
        {
            btnViva.FlatAppearance.BorderSize = 5;
            btnAeromexico.FlatAppearance.BorderSize = 0;
            this.selectedAerolinea = Aerolinea.VIVA;
        }
    }
}
