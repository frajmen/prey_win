using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prey
{
    public partial class Form1 : Form
    {
        Configuracion configuracionPrey;
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            configuracionPrey = Configuracion.ObtenerConfiguracionActual();
            tbURLActivacion.Text = configuracionPrey.URLActivacion;
            nudMonitoreo.Value = (decimal)configuracionPrey.IntervaloMonitoreo;
            if (configuracionPrey.RutaPreyAgent != "")
                cbActivarPrey.Checked = true;
            tbCorreoElectronico.Text = configuracionPrey.CorreoElectronico;
            tbServSMTP.Text = configuracionPrey.ServidorSMTP;
            tbUsuario.Text = configuracionPrey.UsuarioSMTP;
            cbSSL.Checked = configuracionPrey.EsSSL;
            tbPuertoSMTP.Text = configuracionPrey.PuertoSMTP.ToString();
            cbActivarPrey.CheckedChanged +=new EventHandler(cbActivarPrey_CheckedChanged);
            btnActivar.Click += new EventHandler(btnActivar_Click);
        }

        void btnActivar_Click(object sender, EventArgs e)
        {
            configuracionPrey.URLActivacion = tbURLActivacion.Text;
            configuracionPrey.IntervaloMonitoreo = (int)nudMonitoreo.Value;
            configuracionPrey.CorreoElectronico = tbCorreoElectronico.Text;
            configuracionPrey.ServidorSMTP = tbServSMTP.Text;
            configuracionPrey.UsuarioSMTP = tbUsuario.Text;
            configuracionPrey.PuertoSMTP = int.Parse(tbPuertoSMTP.Text);
            configuracionPrey.EsSSL = cbSSL.Checked;
            if (tbClave.Text != "")
                configuracionPrey.ClaveSMTP = tbClave.Text;
            configuracionPrey.GuardarConfiguracion();
            MessageBox.Show("La configuración de Prey se ha realizado correctamente.", "Configuración de Prey", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void cbActivarPrey_CheckedChanged(object sender, EventArgs e)
        {
            if (cbActivarPrey.Checked)
            {
                OpenFileDialog ofdRutaPreyAgent = new OpenFileDialog();
                ofdRutaPreyAgent.CheckFileExists = true;
                ofdRutaPreyAgent.CheckPathExists = true;
                ofdRutaPreyAgent.FileName = "PreyAgent.exe";
                ofdRutaPreyAgent.Filter = "Agente Prey (PreyAgent.exe)|PreyAgent.exe";
                ofdRutaPreyAgent.Title = "Ubicación de PreyAgent.exe";
                if (ofdRutaPreyAgent.ShowDialog() == DialogResult.OK)
                    configuracionPrey.RutaPreyAgent = ofdRutaPreyAgent.FileName;
                else
                {
                    cbActivarPrey.Checked = false;
                    configuracionPrey.RutaPreyAgent = "";
                }
            }
            else
            {
                configuracionPrey.RutaPreyAgent = "";
            }
        }
    }
}
