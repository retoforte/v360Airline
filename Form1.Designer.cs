using System.Windows.Forms;

namespace CheckTrips360
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStartConnection = new System.Windows.Forms.Button();
            this.btnConnectDb = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdbRedondo = new System.Windows.Forms.RadioButton();
            this.rdbSencillo = new System.Windows.Forms.RadioButton();
            this.txtMaxResults = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmision = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkConexiones = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAeromexico = new System.Windows.Forms.Button();
            this.btnViva = new System.Windows.Forms.Button();
            this.dtgVuelos = new System.Windows.Forms.DataGridView();
            this.vivaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVuelos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vivaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(736, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cotizar Viaje Sencillo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(928, 60);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            // 
            // btnStartConnection
            // 
            this.btnStartConnection.Location = new System.Drawing.Point(736, 23);
            this.btnStartConnection.Name = "btnStartConnection";
            this.btnStartConnection.Size = new System.Drawing.Size(152, 30);
            this.btnStartConnection.TabIndex = 2;
            this.btnStartConnection.Text = "Conectar Browser";
            this.btnStartConnection.UseVisualStyleBackColor = true;
            this.btnStartConnection.Visible = false;
            // 
            // btnConnectDb
            // 
            this.btnConnectDb.Location = new System.Drawing.Point(920, 23);
            this.btnConnectDb.Name = "btnConnectDb";
            this.btnConnectDb.Size = new System.Drawing.Size(106, 30);
            this.btnConnectDb.TabIndex = 3;
            this.btnConnectDb.Text = "Test DB Connection";
            this.btnConnectDb.UseVisualStyleBackColor = true;
            this.btnConnectDb.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.txtMaxResults);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtEmision);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkConexiones);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.dtpFechaFin);
            this.panel1.Controls.Add(this.dtpFechaInicio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDestino);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtOrigen);
            this.panel1.Location = new System.Drawing.Point(19, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 208);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rdbRedondo);
            this.panel3.Controls.Add(this.rdbSencillo);
            this.panel3.Location = new System.Drawing.Point(440, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(226, 45);
            this.panel3.TabIndex = 8;
            // 
            // rdbRedondo
            // 
            this.rdbRedondo.AutoSize = true;
            this.rdbRedondo.Location = new System.Drawing.Point(116, 9);
            this.rdbRedondo.Name = "rdbRedondo";
            this.rdbRedondo.Size = new System.Drawing.Size(94, 25);
            this.rdbRedondo.TabIndex = 4;
            this.rdbRedondo.Text = "Redondo";
            this.rdbRedondo.UseVisualStyleBackColor = true;
            this.rdbRedondo.CheckedChanged += new System.EventHandler(this.rdbRedondo_CheckedChanged_1);
            // 
            // rdbSencillo
            // 
            this.rdbSencillo.AutoSize = true;
            this.rdbSencillo.Checked = true;
            this.rdbSencillo.Location = new System.Drawing.Point(17, 9);
            this.rdbSencillo.Name = "rdbSencillo";
            this.rdbSencillo.Size = new System.Drawing.Size(85, 25);
            this.rdbSencillo.TabIndex = 5;
            this.rdbSencillo.TabStop = true;
            this.rdbSencillo.Text = "Sencillo";
            this.rdbSencillo.UseVisualStyleBackColor = true;
            this.rdbSencillo.CheckedChanged += new System.EventHandler(this.rdbSencillo_CheckedChanged_1);
            // 
            // txtMaxResults
            // 
            this.txtMaxResults.Location = new System.Drawing.Point(230, 149);
            this.txtMaxResults.Name = "txtMaxResults";
            this.txtMaxResults.Size = new System.Drawing.Size(168, 29);
            this.txtMaxResults.TabIndex = 13;
            this.txtMaxResults.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxResults_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(230, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "Max Results";
            // 
            // txtEmision
            // 
            this.txtEmision.Location = new System.Drawing.Point(14, 149);
            this.txtEmision.Name = "txtEmision";
            this.txtEmision.Size = new System.Drawing.Size(168, 29);
            this.txtEmision.TabIndex = 11;
            this.txtEmision.Text = "300.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(14, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "$ Emisión";
            // 
            // chkConexiones
            // 
            this.chkConexiones.AutoSize = true;
            this.chkConexiones.Location = new System.Drawing.Point(464, 88);
            this.chkConexiones.Name = "chkConexiones";
            this.chkConexiones.Size = new System.Drawing.Size(159, 25);
            this.chkConexiones.TabIndex = 9;
            this.chkConexiones.Text = "Incluir Conexiones";
            this.chkConexiones.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::CheckTrips360.Properties.Resources.search;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(429, 124);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(248, 73);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFin.Enabled = false;
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(230, 86);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(168, 29);
            this.dtpFechaFin.TabIndex = 7;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(14, 86);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(168, 29);
            this.dtpFechaInicio.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(230, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destino";
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(230, 41);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(194, 29);
            this.txtDestino.TabIndex = 2;
            this.txtDestino.TextChanged += new System.EventHandler(this.txtDestino_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Origen";
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(14, 41);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(198, 29);
            this.txtOrigen.TabIndex = 0;
            this.txtOrigen.Text = "VSA";
            this.txtOrigen.TextChanged += new System.EventHandler(this.txtOrigen_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnAeromexico);
            this.panel2.Controls.Add(this.btnViva);
            this.panel2.Location = new System.Drawing.Point(19, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(702, 77);
            this.panel2.TabIndex = 5;
            // 
            // btnAeromexico
            // 
            this.btnAeromexico.Enabled = false;
            this.btnAeromexico.Image = global::CheckTrips360.Properties.Resources.aeromexico;
            this.btnAeromexico.Location = new System.Drawing.Point(255, 9);
            this.btnAeromexico.Name = "btnAeromexico";
            this.btnAeromexico.Size = new System.Drawing.Size(213, 52);
            this.btnAeromexico.TabIndex = 1;
            this.btnAeromexico.UseVisualStyleBackColor = true;
            // 
            // btnViva
            // 
            this.btnViva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViva.Image = global::CheckTrips360.Properties.Resources.viva;
            this.btnViva.Location = new System.Drawing.Point(16, 9);
            this.btnViva.Name = "btnViva";
            this.btnViva.Size = new System.Drawing.Size(213, 52);
            this.btnViva.TabIndex = 0;
            this.btnViva.UseVisualStyleBackColor = true;
            // 
            // dtgVuelos
            // 
            this.dtgVuelos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgVuelos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgVuelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVuelos.Location = new System.Drawing.Point(23, 369);
            this.dtgVuelos.Name = "dtgVuelos";
            this.dtgVuelos.RowHeadersWidth = 53;
            this.dtgVuelos.RowTemplate.Height = 31;
            this.dtgVuelos.Size = new System.Drawing.Size(1036, 335);
            this.dtgVuelos.TabIndex = 6;
            // 
            // vivaBindingSource
            // 
            this.vivaBindingSource.DataSource = typeof(CheckTrips360.Buscadores.Viva);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Location = new System.Drawing.Point(745, 249);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(245, 39);
            this.btnExportarExcel.TabIndex = 7;
            this.btnExportarExcel.Text = "Exportar a Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Visible = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 716);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.dtgVuelos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnConnectDb);
            this.Controls.Add(this.btnStartConnection);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Viajes360Mx - Módulo de Busqueda de Vuelos - v1.1.1.2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgVuelos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vivaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStartConnection;
        private System.Windows.Forms.Button btnConnectDb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.RadioButton rdbSencillo;
        private System.Windows.Forms.RadioButton rdbRedondo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrigen;
        private Button btnBuscar;
        private Panel panel2;
        private Button btnAeromexico;
        private Button btnViva;
        private CheckBox chkConexiones;
        private DataGridView dtgVuelos;
        private Label label3;
        private TextBox txtEmision;
        private BindingSource vivaBindingSource;
        private Button btnExportarExcel;
        private TextBox txtMaxResults;
        private Label label4;
        private Panel panel3;
    }
}
