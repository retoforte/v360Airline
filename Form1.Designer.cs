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
            button1 = new Button();
            btnClose = new Button();
            btnStartConnection = new Button();
            btnConnectDb = new Button();
            panel1 = new Panel();
            chkConexiones = new CheckBox();
            btnBuscar = new Button();
            dtpFechaFin = new DateTimePicker();
            dtpFechaInicio = new DateTimePicker();
            rdbSencillo = new RadioButton();
            rdbRedondo = new RadioButton();
            label2 = new Label();
            txtDestino = new TextBox();
            label1 = new Label();
            txtOrigen = new TextBox();
            panel2 = new Panel();
            btnAeromexico = new Button();
            btnViva = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(21, 376);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(148, 29);
            button1.TabIndex = 0;
            button1.Text = "Cotizar Viaje Sencillo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new System.Drawing.Point(192, 376);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(87, 29);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnStartConnection
            // 
            btnStartConnection.Location = new System.Drawing.Point(21, 341);
            btnStartConnection.Name = "btnStartConnection";
            btnStartConnection.Size = new System.Drawing.Size(135, 29);
            btnStartConnection.TabIndex = 2;
            btnStartConnection.Text = "Conectar Browser";
            btnStartConnection.UseVisualStyleBackColor = true;
            btnStartConnection.Click += btnStartConnection_Click;
            // 
            // btnConnectDb
            // 
            btnConnectDb.Location = new System.Drawing.Point(185, 341);
            btnConnectDb.Name = "btnConnectDb";
            btnConnectDb.Size = new System.Drawing.Size(94, 29);
            btnConnectDb.TabIndex = 3;
            btnConnectDb.Text = "Test DB Connection";
            btnConnectDb.UseVisualStyleBackColor = true;
            btnConnectDb.Click += btnConnectDb_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(chkConexiones);
            panel1.Controls.Add(btnBuscar);
            panel1.Controls.Add(dtpFechaFin);
            panel1.Controls.Add(dtpFechaInicio);
            panel1.Controls.Add(rdbSencillo);
            panel1.Controls.Add(rdbRedondo);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtDestino);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtOrigen);
            panel1.Location = new System.Drawing.Point(17, 118);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(624, 170);
            panel1.TabIndex = 4;
            // 
            // chkConexiones
            // 
            chkConexiones.AutoSize = true;
            chkConexiones.Location = new System.Drawing.Point(401, 84);
            chkConexiones.Name = "chkConexiones";
            chkConexiones.Size = new System.Drawing.Size(151, 24);
            chkConexiones.TabIndex = 9;
            chkConexiones.Text = "Incluir Conexiones";
            chkConexiones.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new System.Drawing.Point(381, 114);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new System.Drawing.Size(220, 42);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.CustomFormat = "dd/MM/yyyy";
            dtpFechaFin.Format = DateTimePickerFormat.Custom;
            dtpFechaFin.Location = new System.Drawing.Point(204, 82);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new System.Drawing.Size(150, 27);
            dtpFechaFin.TabIndex = 7;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.CustomFormat = "dd/MM/yyyy";
            dtpFechaInicio.Format = DateTimePickerFormat.Custom;
            dtpFechaInicio.Location = new System.Drawing.Point(12, 82);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new System.Drawing.Size(150, 27);
            dtpFechaInicio.TabIndex = 6;
            // 
            // rdbSencillo
            // 
            rdbSencillo.AutoSize = true;
            rdbSencillo.Checked = true;
            rdbSencillo.Location = new System.Drawing.Point(401, 39);
            rdbSencillo.Name = "rdbSencillo";
            rdbSencillo.Size = new System.Drawing.Size(82, 24);
            rdbSencillo.TabIndex = 5;
            rdbSencillo.TabStop = true;
            rdbSencillo.Text = "Sencillo";
            rdbSencillo.UseVisualStyleBackColor = true;
            rdbSencillo.CheckedChanged += rdbSencillo_CheckedChanged;
            // 
            // rdbRedondo
            // 
            rdbRedondo.AutoSize = true;
            rdbRedondo.Location = new System.Drawing.Point(489, 39);
            rdbRedondo.Name = "rdbRedondo";
            rdbRedondo.Size = new System.Drawing.Size(91, 24);
            rdbRedondo.TabIndex = 4;
            rdbRedondo.Text = "Redondo";
            rdbRedondo.UseVisualStyleBackColor = true;
            rdbRedondo.CheckedChanged += rdbRedondo_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(204, 16);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(63, 20);
            label2.TabIndex = 3;
            label2.Text = "Destino";
            // 
            // txtDestino
            // 
            txtDestino.Location = new System.Drawing.Point(204, 39);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new System.Drawing.Size(173, 27);
            txtDestino.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(12, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 20);
            label1.TabIndex = 1;
            label1.Text = "Origen";
            // 
            // txtOrigen
            // 
            txtOrigen.Location = new System.Drawing.Point(12, 39);
            txtOrigen.Name = "txtOrigen";
            txtOrigen.Size = new System.Drawing.Size(176, 27);
            txtOrigen.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnAeromexico);
            panel2.Controls.Add(btnViva);
            panel2.Location = new System.Drawing.Point(17, 22);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(624, 73);
            panel2.TabIndex = 5;
            // 
            // btnAeromexico
            // 
            btnAeromexico.Image = Properties.Resources.aeromexico;
            btnAeromexico.Location = new System.Drawing.Point(227, 9);
            btnAeromexico.Name = "btnAeromexico";
            btnAeromexico.Size = new System.Drawing.Size(189, 50);
            btnAeromexico.TabIndex = 1;
            btnAeromexico.UseVisualStyleBackColor = true;
            // 
            // btnViva
            // 
            btnViva.Image = Properties.Resources.viva;
            btnViva.Location = new System.Drawing.Point(14, 9);
            btnViva.Name = "btnViva";
            btnViva.Size = new System.Drawing.Size(189, 50);
            btnViva.TabIndex = 0;
            btnViva.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(760, 441);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnConnectDb);
            Controls.Add(btnStartConnection);
            Controls.Add(btnClose);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
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
    }
}
