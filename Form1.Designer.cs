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
            this.vivaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabVuelos = new System.Windows.Forms.TabPage();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.dtgVuelos = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAeromexico = new System.Windows.Forms.Button();
            this.btnViva = new System.Windows.Forms.Button();
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
            this.btnConnectDb = new System.Windows.Forms.Button();
            this.btnStartConnection = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabVISA = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnInciarChequeo = new System.Windows.Forms.Button();
            this.dgbValidacionVISA = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalChecks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reschedule1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vivaBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabVuelos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVuelos)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabVISA.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbValidacionVISA)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // vivaBindingSource
            // 
            this.vivaBindingSource.DataSource = typeof(CheckTrips360.Buscadores.Viva);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabVuelos);
            this.tabControl1.Controls.Add(this.tabVISA);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1056, 692);
            this.tabControl1.TabIndex = 8;
            // 
            // tabVuelos
            // 
            this.tabVuelos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabVuelos.Controls.Add(this.btnExportarExcel);
            this.tabVuelos.Controls.Add(this.dtgVuelos);
            this.tabVuelos.Controls.Add(this.panel2);
            this.tabVuelos.Controls.Add(this.panel1);
            this.tabVuelos.Controls.Add(this.btnConnectDb);
            this.tabVuelos.Controls.Add(this.btnStartConnection);
            this.tabVuelos.Controls.Add(this.btnClose);
            this.tabVuelos.Controls.Add(this.button1);
            this.tabVuelos.ForeColor = System.Drawing.Color.Black;
            this.tabVuelos.Location = new System.Drawing.Point(4, 30);
            this.tabVuelos.Name = "tabVuelos";
            this.tabVuelos.Padding = new System.Windows.Forms.Padding(3);
            this.tabVuelos.Size = new System.Drawing.Size(1048, 658);
            this.tabVuelos.TabIndex = 0;
            this.tabVuelos.Text = "Busqueda de Vuelos";
            this.tabVuelos.UseVisualStyleBackColor = true;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Location = new System.Drawing.Point(747, 107);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(245, 39);
            this.btnExportarExcel.TabIndex = 15;
            this.btnExportarExcel.Text = "Exportar a Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Visible = false;
            // 
            // dtgVuelos
            // 
            this.dtgVuelos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgVuelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVuelos.Location = new System.Drawing.Point(25, 325);
            this.dtgVuelos.Name = "dtgVuelos";
            this.dtgVuelos.RowHeadersWidth = 53;
            this.dtgVuelos.RowTemplate.Height = 31;
            this.dtgVuelos.Size = new System.Drawing.Size(1012, 325);
            this.dtgVuelos.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnAeromexico);
            this.panel2.Controls.Add(this.btnViva);
            this.panel2.Location = new System.Drawing.Point(21, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(702, 77);
            this.panel2.TabIndex = 13;
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
            this.panel1.Location = new System.Drawing.Point(21, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 208);
            this.panel1.TabIndex = 12;
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
            // 
            // txtMaxResults
            // 
            this.txtMaxResults.Location = new System.Drawing.Point(230, 149);
            this.txtMaxResults.Name = "txtMaxResults";
            this.txtMaxResults.Size = new System.Drawing.Size(168, 29);
            this.txtMaxResults.TabIndex = 13;
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
            this.txtDestino.Text = "Villahermosa";
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
            this.txtOrigen.Text = "Guadalajara";
            // 
            // btnConnectDb
            // 
            this.btnConnectDb.Location = new System.Drawing.Point(931, 16);
            this.btnConnectDb.Name = "btnConnectDb";
            this.btnConnectDb.Size = new System.Drawing.Size(106, 30);
            this.btnConnectDb.TabIndex = 11;
            this.btnConnectDb.Text = "Test DB Connection";
            this.btnConnectDb.UseVisualStyleBackColor = true;
            this.btnConnectDb.Visible = false;
            // 
            // btnStartConnection
            // 
            this.btnStartConnection.Location = new System.Drawing.Point(747, 16);
            this.btnStartConnection.Name = "btnStartConnection";
            this.btnStartConnection.Size = new System.Drawing.Size(152, 30);
            this.btnStartConnection.TabIndex = 10;
            this.btnStartConnection.Text = "Conectar Browser";
            this.btnStartConnection.UseVisualStyleBackColor = true;
            this.btnStartConnection.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(939, 53);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(747, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cotizar Viaje Sencillo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // tabVISA
            // 
            this.tabVISA.BackColor = System.Drawing.Color.AliceBlue;
            this.tabVISA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabVISA.Controls.Add(this.panel5);
            this.tabVISA.Controls.Add(this.dgbValidacionVISA);
            this.tabVISA.Controls.Add(this.panel4);
            this.tabVISA.Location = new System.Drawing.Point(4, 30);
            this.tabVISA.Name = "tabVISA";
            this.tabVISA.Padding = new System.Windows.Forms.Padding(3);
            this.tabVISA.Size = new System.Drawing.Size(1048, 658);
            this.tabVISA.TabIndex = 1;
            this.tabVISA.Text = "Validación de VISA";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.textBox2);
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Controls.Add(this.btnInciarChequeo);
            this.panel5.Location = new System.Drawing.Point(600, 24);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(440, 153);
            this.panel5.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 21);
            this.label10.TabIndex = 19;
            this.label10.Text = "# Maximo por Cta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 21);
            this.label9.TabIndex = 18;
            this.label9.Text = "Intervalo (min)";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(170, 81);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(94, 29);
            this.textBox2.TabIndex = 17;
            this.textBox2.Text = "10";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(170, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(94, 29);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "20";
            // 
            // btnInciarChequeo
            // 
            this.btnInciarChequeo.Location = new System.Drawing.Point(270, 52);
            this.btnInciarChequeo.Name = "btnInciarChequeo";
            this.btnInciarChequeo.Size = new System.Drawing.Size(140, 58);
            this.btnInciarChequeo.TabIndex = 15;
            this.btnInciarChequeo.Text = "Iniciar Validación";
            this.btnInciarChequeo.UseVisualStyleBackColor = true;
            this.btnInciarChequeo.Click += new System.EventHandler(this.btnInciarChequeo_Click);
            // 
            // dgbValidacionVISA
            // 
            this.dgbValidacionVISA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgbValidacionVISA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbValidacionVISA.Location = new System.Drawing.Point(7, 201);
            this.dgbValidacionVISA.Name = "dgbValidacionVISA";
            this.dgbValidacionVISA.RowHeadersWidth = 53;
            this.dgbValidacionVISA.RowTemplate.Height = 31;
            this.dgbValidacionVISA.Size = new System.Drawing.Size(1033, 449);
            this.dgbValidacionVISA.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.txtEstado);
            this.panel4.Controls.Add(this.btnAgregar);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.dtpFecha);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtNombreCompleto);
            this.panel4.Controls.Add(this.txtUsuario);
            this.panel4.Controls.Add(this.txtPassword);
            this.panel4.Location = new System.Drawing.Point(6, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(588, 156);
            this.panel4.TabIndex = 5;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(458, 50);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 103);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar ";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(308, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 21);
            this.label8.TabIndex = 13;
            this.label8.Text = "Fecha de Cita";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(308, 50);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(142, 29);
            this.dtpFecha.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nombre completo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Usuario";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Location = new System.Drawing.Point(24, 111);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(278, 29);
            this.txtNombreCompleto.TabIndex = 7;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(24, 50);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(130, 29);
            this.txtUsuario.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(172, 50);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(130, 29);
            this.txtPassword.TabIndex = 5;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.MinimumWidth = 7;
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Width = 130;
            // 
            // Password
            // 
            this.Password.HeaderText = "Password";
            this.Password.MinimumWidth = 7;
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Width = 130;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 7;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 130;
            // 
            // FullName
            // 
            this.FullName.HeaderText = "Nombre";
            this.FullName.MinimumWidth = 7;
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 130;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "Usuario";
            this.UserName.MinimumWidth = 7;
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 130;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Password";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 7;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 130;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Fecha Cita";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 7;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 130;
            // 
            // TotalChecks
            // 
            this.TotalChecks.HeaderText = "TotalChecks";
            this.TotalChecks.MinimumWidth = 7;
            this.TotalChecks.Name = "TotalChecks";
            this.TotalChecks.ReadOnly = true;
            this.TotalChecks.Width = 130;
            // 
            // Reschedule1
            // 
            this.Reschedule1.HeaderText = "Reschedule1 ";
            this.Reschedule1.MinimumWidth = 7;
            this.Reschedule1.Name = "Reschedule1";
            this.Reschedule1.Width = 130;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(308, 111);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(130, 29);
            this.txtEstado.TabIndex = 15;
            this.txtEstado.Text = "Monterrey";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(308, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 21);
            this.label11.TabIndex = 16;
            this.label11.Text = "Estado";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 716);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Viajes360Mx - Módulo de Busqueda de Vuelos - v1.1.1";
            ((System.ComponentModel.ISupportInitialize)(this.vivaBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabVuelos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgVuelos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabVISA.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbValidacionVISA)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private BindingSource vivaBindingSource;
        private TabControl tabControl1;
        private TabPage tabVuelos;
        private Button btnExportarExcel;
        private DataGridView dtgVuelos;
        private Panel panel2;
        private Button btnAeromexico;
        private Button btnViva;
        private Panel panel1;
        private Panel panel3;
        private RadioButton rdbRedondo;
        private RadioButton rdbSencillo;
        private TextBox txtMaxResults;
        private Label label4;
        private TextBox txtEmision;
        private Label label3;
        private CheckBox chkConexiones;
        private Button btnBuscar;
        private DateTimePicker dtpFechaFin;
        private DateTimePicker dtpFechaInicio;
        private Label label2;
        private TextBox txtDestino;
        private Label label1;
        private TextBox txtOrigen;
        private Button btnConnectDb;
        private Button btnStartConnection;
        private Button btnClose;
        private Button button1;
        private TabPage tabVISA;
        private DataGridView dgbValidacionVISA;
        private Panel panel4;
        private Button btnAgregar;
        private Label label8;
        private DateTimePicker dtpFecha;
        private Label label5;
        private Label label7;
        private Label label6;
        private TextBox txtNombreCompleto;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private DataGridViewTextBoxColumn Usuario;
        private DataGridViewTextBoxColumn Password;
        private DataGridViewTextBoxColumn Nombre;
        private Panel panel5;
        private Label label10;
        private Label label9;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button btnInciarChequeo;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn UserName;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn TotalChecks;
        private DataGridViewTextBoxColumn Reschedule1;
        private Timer timer1;
        private Label label11;
        private TextBox txtEstado;
    }
}
