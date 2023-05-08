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
            button1 = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            btnStartConnection = new System.Windows.Forms.Button();
            btnConnectDb = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(40, 123);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(148, 29);
            button1.TabIndex = 0;
            button1.Text = "Cotizar Viaje Sencillo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new System.Drawing.Point(225, 123);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(87, 29);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnStartConnection
            // 
            btnStartConnection.Location = new System.Drawing.Point(40, 72);
            btnStartConnection.Name = "btnStartConnection";
            btnStartConnection.Size = new System.Drawing.Size(135, 29);
            btnStartConnection.TabIndex = 2;
            btnStartConnection.Text = "Conectar Browser";
            btnStartConnection.UseVisualStyleBackColor = true;
            btnStartConnection.Click += btnStartConnection_Click;
            // 
            // btnConnectDb
            // 
            btnConnectDb.Location = new System.Drawing.Point(251, 58);
            btnConnectDb.Name = "btnConnectDb";
            btnConnectDb.Size = new System.Drawing.Size(94, 29);
            btnConnectDb.TabIndex = 3;
            btnConnectDb.Text = "Test DB Connection";
            btnConnectDb.UseVisualStyleBackColor = true;
            btnConnectDb.Click += btnConnectDb_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(711, 429);
            Controls.Add(btnConnectDb);
            Controls.Add(btnStartConnection);
            Controls.Add(btnClose);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStartConnection;
        private System.Windows.Forms.Button btnConnectDb;
    }
}
