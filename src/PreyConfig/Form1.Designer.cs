namespace Prey
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gbActivacion = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudMonitoreo = new System.Windows.Forms.NumericUpDown();
            this.lbMonitoreo = new System.Windows.Forms.Label();
            this.cbActivarPrey = new System.Windows.Forms.CheckBox();
            this.tbURLActivacion = new System.Windows.Forms.TextBox();
            this.lbURL = new System.Windows.Forms.Label();
            this.gbEnvioInformacion = new System.Windows.Forms.GroupBox();
            this.cbSSL = new System.Windows.Forms.CheckBox();
            this.tbPuertoSMTP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbClave = new System.Windows.Forms.TextBox();
            this.lbClave = new System.Windows.Forms.Label();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.tbServSMTP = new System.Windows.Forms.TextBox();
            this.lbServSMTP = new System.Windows.Forms.Label();
            this.tbCorreoElectronico = new System.Windows.Forms.TextBox();
            this.lbCorreoElectronico = new System.Windows.Forms.Label();
            this.btnActivar = new System.Windows.Forms.Button();
            this.gbActivacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonitoreo)).BeginInit();
            this.gbEnvioInformacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbActivacion
            // 
            this.gbActivacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbActivacion.Controls.Add(this.label1);
            this.gbActivacion.Controls.Add(this.nudMonitoreo);
            this.gbActivacion.Controls.Add(this.lbMonitoreo);
            this.gbActivacion.Controls.Add(this.cbActivarPrey);
            this.gbActivacion.Controls.Add(this.tbURLActivacion);
            this.gbActivacion.Controls.Add(this.lbURL);
            this.gbActivacion.Location = new System.Drawing.Point(12, 12);
            this.gbActivacion.Name = "gbActivacion";
            this.gbActivacion.Size = new System.Drawing.Size(400, 92);
            this.gbActivacion.TabIndex = 0;
            this.gbActivacion.TabStop = false;
            this.gbActivacion.Text = "Activación";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Minutos";
            // 
            // nudMonitoreo
            // 
            this.nudMonitoreo.Location = new System.Drawing.Point(66, 41);
            this.nudMonitoreo.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudMonitoreo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMonitoreo.Name = "nudMonitoreo";
            this.nudMonitoreo.Size = new System.Drawing.Size(53, 21);
            this.nudMonitoreo.TabIndex = 4;
            this.nudMonitoreo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbMonitoreo
            // 
            this.lbMonitoreo.AutoSize = true;
            this.lbMonitoreo.Location = new System.Drawing.Point(6, 43);
            this.lbMonitoreo.Name = "lbMonitoreo";
            this.lbMonitoreo.Size = new System.Drawing.Size(55, 13);
            this.lbMonitoreo.TabIndex = 3;
            this.lbMonitoreo.Text = "&Monitoreo";
            // 
            // cbActivarPrey
            // 
            this.cbActivarPrey.AutoSize = true;
            this.cbActivarPrey.Location = new System.Drawing.Point(66, 68);
            this.cbActivarPrey.Name = "cbActivarPrey";
            this.cbActivarPrey.Size = new System.Drawing.Size(85, 17);
            this.cbActivarPrey.TabIndex = 2;
            this.cbActivarPrey.Text = "&Activar Prey";
            this.cbActivarPrey.UseVisualStyleBackColor = true;
            // 
            // tbURLActivacion
            // 
            this.tbURLActivacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbURLActivacion.Location = new System.Drawing.Point(66, 14);
            this.tbURLActivacion.Name = "tbURLActivacion";
            this.tbURLActivacion.Size = new System.Drawing.Size(328, 21);
            this.tbURLActivacion.TabIndex = 1;
            this.tbURLActivacion.Text = "http://";
            // 
            // lbURL
            // 
            this.lbURL.AutoSize = true;
            this.lbURL.Location = new System.Drawing.Point(6, 17);
            this.lbURL.Name = "lbURL";
            this.lbURL.Size = new System.Drawing.Size(26, 13);
            this.lbURL.TabIndex = 0;
            this.lbURL.Text = "&URL";
            // 
            // gbEnvioInformacion
            // 
            this.gbEnvioInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEnvioInformacion.Controls.Add(this.cbSSL);
            this.gbEnvioInformacion.Controls.Add(this.tbPuertoSMTP);
            this.gbEnvioInformacion.Controls.Add(this.label2);
            this.gbEnvioInformacion.Controls.Add(this.tbClave);
            this.gbEnvioInformacion.Controls.Add(this.lbClave);
            this.gbEnvioInformacion.Controls.Add(this.tbUsuario);
            this.gbEnvioInformacion.Controls.Add(this.lbUsuario);
            this.gbEnvioInformacion.Controls.Add(this.tbServSMTP);
            this.gbEnvioInformacion.Controls.Add(this.lbServSMTP);
            this.gbEnvioInformacion.Controls.Add(this.tbCorreoElectronico);
            this.gbEnvioInformacion.Controls.Add(this.lbCorreoElectronico);
            this.gbEnvioInformacion.Location = new System.Drawing.Point(12, 110);
            this.gbEnvioInformacion.Name = "gbEnvioInformacion";
            this.gbEnvioInformacion.Size = new System.Drawing.Size(400, 125);
            this.gbEnvioInformacion.TabIndex = 1;
            this.gbEnvioInformacion.TabStop = false;
            this.gbEnvioInformacion.Text = "Envío de información";
            // 
            // cbSSL
            // 
            this.cbSSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSSL.AutoSize = true;
            this.cbSSL.Location = new System.Drawing.Point(351, 43);
            this.cbSSL.Name = "cbSSL";
            this.cbSSL.Size = new System.Drawing.Size(43, 17);
            this.cbSSL.TabIndex = 10;
            this.cbSSL.Text = "SSL";
            this.cbSSL.UseVisualStyleBackColor = true;
            // 
            // tbPuertoSMTP
            // 
            this.tbPuertoSMTP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPuertoSMTP.Location = new System.Drawing.Point(300, 41);
            this.tbPuertoSMTP.Name = "tbPuertoSMTP";
            this.tbPuertoSMTP.Size = new System.Drawing.Size(45, 21);
            this.tbPuertoSMTP.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "&Puerto";
            // 
            // tbClave
            // 
            this.tbClave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbClave.Location = new System.Drawing.Point(107, 95);
            this.tbClave.Name = "tbClave";
            this.tbClave.PasswordChar = '•';
            this.tbClave.Size = new System.Drawing.Size(287, 21);
            this.tbClave.TabIndex = 7;
            // 
            // lbClave
            // 
            this.lbClave.AutoSize = true;
            this.lbClave.Location = new System.Drawing.Point(6, 98);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(63, 13);
            this.lbClave.TabIndex = 6;
            this.lbClave.Text = "C&ontraseña";
            // 
            // tbUsuario
            // 
            this.tbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUsuario.Location = new System.Drawing.Point(107, 68);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(287, 21);
            this.tbUsuario.TabIndex = 5;
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(6, 71);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(43, 13);
            this.lbUsuario.TabIndex = 4;
            this.lbUsuario.Text = "Usua&rio";
            // 
            // tbServSMTP
            // 
            this.tbServSMTP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbServSMTP.Location = new System.Drawing.Point(107, 41);
            this.tbServSMTP.Name = "tbServSMTP";
            this.tbServSMTP.Size = new System.Drawing.Size(142, 21);
            this.tbServSMTP.TabIndex = 3;
            // 
            // lbServSMTP
            // 
            this.lbServSMTP.AutoSize = true;
            this.lbServSMTP.Location = new System.Drawing.Point(6, 44);
            this.lbServSMTP.Name = "lbServSMTP";
            this.lbServSMTP.Size = new System.Drawing.Size(76, 13);
            this.lbServSMTP.TabIndex = 2;
            this.lbServSMTP.Text = "&Servidor SMTP";
            // 
            // tbCorreoElectronico
            // 
            this.tbCorreoElectronico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCorreoElectronico.Location = new System.Drawing.Point(107, 14);
            this.tbCorreoElectronico.Name = "tbCorreoElectronico";
            this.tbCorreoElectronico.Size = new System.Drawing.Size(287, 21);
            this.tbCorreoElectronico.TabIndex = 1;
            // 
            // lbCorreoElectronico
            // 
            this.lbCorreoElectronico.AutoSize = true;
            this.lbCorreoElectronico.Location = new System.Drawing.Point(6, 17);
            this.lbCorreoElectronico.Name = "lbCorreoElectronico";
            this.lbCorreoElectronico.Size = new System.Drawing.Size(95, 13);
            this.lbCorreoElectronico.TabIndex = 0;
            this.lbCorreoElectronico.Text = "&Correo electrónico";
            // 
            // btnActivar
            // 
            this.btnActivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivar.Location = new System.Drawing.Point(337, 241);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(75, 23);
            this.btnActivar.TabIndex = 2;
            this.btnActivar.Text = "&Guardar";
            this.btnActivar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(424, 276);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.gbEnvioInformacion);
            this.Controls.Add(this.gbActivacion);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(430, 300);
            this.Name = "Form1";
            this.Text = "Prey - Utilidad de configuración";
            this.gbActivacion.ResumeLayout(false);
            this.gbActivacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonitoreo)).EndInit();
            this.gbEnvioInformacion.ResumeLayout(false);
            this.gbEnvioInformacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbActivacion;
        private System.Windows.Forms.Label lbURL;
        private System.Windows.Forms.TextBox tbURLActivacion;
        private System.Windows.Forms.CheckBox cbActivarPrey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudMonitoreo;
        private System.Windows.Forms.Label lbMonitoreo;
        private System.Windows.Forms.GroupBox gbEnvioInformacion;
        private System.Windows.Forms.TextBox tbCorreoElectronico;
        private System.Windows.Forms.Label lbCorreoElectronico;
        private System.Windows.Forms.TextBox tbClave;
        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.TextBox tbServSMTP;
        private System.Windows.Forms.Label lbServSMTP;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.CheckBox cbSSL;
        private System.Windows.Forms.TextBox tbPuertoSMTP;
        private System.Windows.Forms.Label label2;
    }
}

