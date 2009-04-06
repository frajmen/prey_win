using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using WebCamera;

namespace Prey
{
    public partial class frmAgente : Form
    {
        PictureBox pbWebCam;
        bool camaraCapturada = false;
        WebCam webC = new WebCam();
        Configuracion configuracionPrey;
        Timer monitor;
        public frmAgente()
        {
            InitializeComponent();
            pbWebCam = new PictureBox();
            monitor = new Timer();
            pbWebCam.Width = 640;
            pbWebCam.Height = 480;
            this.Load += new EventHandler(frmAgente_Load);
            monitor.Tick += new EventHandler(monitor_Tick);
            this.Shown += new EventHandler(frmAgente_Shown);
            this.FormClosing += new FormClosingEventHandler(frmAgente_FormClosing);
            configuracionPrey = Configuracion.ObtenerConfiguracionActual();
            monitor.Interval = (int)configuracionPrey.IntervaloMonitoreo * 60000;
            monitor.Start();
        }

        void frmAgente_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        void frmAgente_Shown(object sender, EventArgs e)
        {
            Width = 1;
            Height = 1;
            Hide();

        }

        void frmAgente_Load(object sender, EventArgs e)
        {
            if (SenalActivacion())
                capturarCamaraWeb();
        }

        void monitor_Tick(object sender, EventArgs e)
        {
            monitor.Stop();
            try
            {
                if (SenalActivacion())
                {
                    Show();
                    capturarCamaraWeb();
                    string logPrey;
                    string rutaLog = String.Format("{0}\\{1}", Environment.GetEnvironmentVariable("TEMP"), "prey.txt");
                    string rutaImgScr = String.Format("{0}\\{1}", Environment.GetEnvironmentVariable("TEMP"), "prey-screenshot.jpg");
                    string rutaWebScr = String.Format("{0}\\{1}", Environment.GetEnvironmentVariable("TEMP"), "prey-webcam.jpg");
                    logPrey = Prey.ObtenerInformacionSistema();
                    logPrey += Prey.ObtenerTareasActivasEquipo();
                    logPrey += Prey.ObtenerInformacionRed();
                    logPrey += Prey.ObternetInformacionWifi();
                    Prey.CapturarPantalla(rutaImgScr);
                    webC.SaveImage(rutaWebScr);
                    Hide();
                    enviarPorCorreo(logPrey, rutaImgScr, rutaWebScr);
                }
            }
            catch { }
            finally
            {
                monitor.Start();
            }
        }

        private void enviarPorCorreo(string Log, string RutaScrImg, string RutaWebImg)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.To.Add(new MailAddress(configuracionPrey.CorreoElectronico));
                correo.From = new MailAddress(configuracionPrey.CorreoElectronico);
                correo.Subject = "Información Prey";
                correo.SubjectEncoding = Encoding.UTF8;
                correo.Body = Log;
                correo.BodyEncoding = Encoding.UTF8;
                correo.IsBodyHtml = false;
                correo.Attachments.Add(new Attachment(RutaScrImg));
                correo.Attachments.Add(new Attachment(RutaWebImg));
                SmtpClient smtpServ = new SmtpClient();
                smtpServ.Host = configuracionPrey.ServidorSMTP;
                smtpServ.Credentials = configuracionPrey.ObtenerCredenciales();
                smtpServ.EnableSsl = configuracionPrey.EsSSL;
                smtpServ.Port = configuracionPrey.PuertoSMTP;
                smtpServ.Send(correo);
            }
            catch { }
        }

        private bool SenalActivacion()
        {
            bool activador = false;
            string activacion;
            try
            {
                WebClient wc = new WebClient();
                activacion = Encoding.ASCII.GetString(wc.DownloadData(configuracionPrey.URLActivacion));
            }
            catch
            {
                activacion = "";
            }
            activador = (activacion != "") ? true : false;
            return activador;
        }

        private void capturarCamaraWeb()
        {
            try
            {
                if (!camaraCapturada)
                {
                    this.Controls.Add(pbWebCam);
                    webC.Container = (PictureBox)this.Controls[0];
                    webC.OpenConnection();
                    camaraCapturada = true;
                }
            }
            catch { }
        }
    }
}
