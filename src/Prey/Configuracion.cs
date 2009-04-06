using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Prey
{
    /// <summary>
    /// Lee o establece la configuración que tiene la máquina para Prey. Compatible con PreyAgent.
    /// </summary>
    public class Configuracion
    {
        /// <summary>
        /// Contiene la URL de activación para Prey.
        /// </summary>
        private string urlActivacion;
        /// <summary>
        /// Contiene el número de minutos que debe esperar PreyAgent para realizar un monitoreo.
        /// </summary>
        private int intervaloMonitoreo;
        /// <summary>
        /// Contiene la ruta del ejecutable de PreyAgent.
        /// </summary>
        private string rutaPreyAgent;
        /// <summary>
        /// Contiene el correo electrónico que se utilizará para enviar los mensajes generados por PreyAgent.
        /// </summary>
        private string correoElectronico;
        /// <summary>
        /// Servidor SMTP desde el que se enviarán lo correos.
        /// </summary>
        private string servidorSMTP;
        /// <summary>
        /// Usuario para la autenticación SMTP.
        /// </summary>
        private string usuarioSMTP;
        /// <summary>
        /// Clave para la autenticación SMTP.
        /// </summary>
        private string claveSMTP;
        /// <summary>
        /// Determina si el servidor SMTP es SSL.
        /// </summary>
        private bool esSSL;
        /// <summary>
        /// Contiene el puerto SMTP.
        /// </summary>
        private int puertoSMTP;
        /// <summary>
        /// Obtiene o establece la URL para la activación de Prey.
        /// </summary>
        public string URLActivacion
        {
            get { return urlActivacion; }
            set { urlActivacion = value; }
        }
        /// <summary>
        /// Obtiene o establece el intervalo de monitoreo de Prey.
        /// </summary>
        /// <remarks>El intervalo está dado en minutos.</remarks>
        public int IntervaloMonitoreo
        {
            get { return intervaloMonitoreo; }
            set { intervaloMonitoreo = value; }
        }
        /// <summary>
        /// Obtiene o establece la ruta hacia PreyAgent en la máquina.
        /// </summary>
        public string RutaPreyAgent
        {
            get { return rutaPreyAgent; }
            set { rutaPreyAgent = value; }
        }
        /// <summary>
        /// Obtiene o establece el correo al cual se enviarán los reportes de Prey.
        /// </summary>
        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }
        /// <summary>
        /// Obtiene o establece la dirección del servidor SMTP para el envío de correos.
        /// </summary>
        public string ServidorSMTP
        {
            get { return servidorSMTP; }
            set { servidorSMTP = value; }
        }
        /// <summary>
        /// Obtiene o establece el usuario para la autenticación SMTP.
        /// </summary>
        public string UsuarioSMTP
        {
            get { return usuarioSMTP; }
            set { usuarioSMTP = value; }
        }
        /// <summary>
        /// Establece la clave SMTP para la autenticación SMTP.
        /// </summary>
        public string ClaveSMTP
        {
            internal get { return claveSMTP; }
            set { claveSMTP = value; }
        }
        /// <summary>
        /// Obtiene o establece si el servidor SMTP es SSL.
        /// </summary>
        public bool EsSSL
        {
            get { return esSSL; }
            set { esSSL = value; }
        }
        /// <summary>
        /// Obtiene o establece el puerto SMTP.
        /// </summary>
        public int PuertoSMTP
        {
            get { return puertoSMTP; }
            set { puertoSMTP = value; }
        }
        /// <summary>
        /// Crea un nuevo perfil de configuración para Prey y PreyAgent.
        /// </summary>
        /// <param name="URLActivacion">URL para la activación de Prey.</param>
        /// <param name="IntervaloMonitoreo">Intervalo en minutos para el monitoreo de Prey.</param>
        /// <param name="RutaPreyAgent">Ruta al ejecutable en la máquina de Prey.</param>
        /// <param name="CorreoElectronico">Correo electrónico al que se enviarán losd atos de Prey.</param>
        /// <param name="ServidorSMTP">Servidor SMTP desde donde se enviarán los correos.</param>
        /// <param name="UsuarioSMTP">Usuario para la autenticación SMTP.</param>
        /// <param name="ClaveSMTP">Contraseña para la autenticación SMTP.</param>
        /// <param name="EsSSL">Determina si el servidor es SSL.</param>
        /// <param name="PuertoSMTP">Determian el puerto de conexión.</param>
        public Configuracion(string URLActivacion, int IntervaloMonitoreo, string RutaPreyAgent, string CorreoElectronico, string ServidorSMTP, string UsuarioSMTP, string ClaveSMTP, int PuertoSMTP,bool EsSSL)
        {
            this.URLActivacion = URLActivacion;
            this.IntervaloMonitoreo = IntervaloMonitoreo;
            this.RutaPreyAgent = RutaPreyAgent;
            this.CorreoElectronico = CorreoElectronico;
            this.ServidorSMTP = ServidorSMTP;
            this.UsuarioSMTP = UsuarioSMTP;
            this.ClaveSMTP = ClaveSMTP;
            this.EsSSL = EsSSL;
            this.PuertoSMTP = PuertoSMTP;
        }
        /// <summary>
        /// Guarda la configuración de Prey en el registro de Windows.
        /// </summary>
        public void GuardarConfiguracion()
        {
            RegistryKey configuracion = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Prey\Configuracion");
            configuracion.SetValue("URLActivacion", URLActivacion);
            configuracion.SetValue("IntervaloMonitoreo", intervaloMonitoreo);
            configuracion.SetValue("RutaPreyAgent", RutaPreyAgent);
            configuracion.SetValue("CorreoElectronico", CorreoElectronico);
            configuracion.SetValue("ServidorSMTP", ServidorSMTP);
            configuracion.SetValue("UsuarioSMTP", UsuarioSMTP);
            configuracion.SetValue("ClSMTP", ClaveSMTP);
            configuracion.SetValue("EsSSL", (EsSSL) ? "Si" : "No");
            configuracion.SetValue("PuertoSMTP", PuertoSMTP);
            if (RutaPreyAgent != "")
            {
                RegistryKey autorun = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                autorun.SetValue("PreyAgent", String.Format("\"{0}\"", RutaPreyAgent));
            }
            else
            {
                RegistryKey autorunD = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                autorunD.DeleteValue("PreyAgent");
            }
        }
        /// <summary>
        /// Obtiene la configuración actual de Prey. Si no hay configuración, los datos serán vacíos.
        /// </summary>
        /// <returns>Devuelve un objeto que contiene la configuración obtenida.</returns>
        static public Configuracion ObtenerConfiguracionActual()
        {
            Configuracion configuracionActual;
            RegistryKey configuracion = Registry.LocalMachine.OpenSubKey(@"Software\Prey\Configuracion");
            if (configuracion != null)
            {
                string urlActivacion = (string)configuracion.GetValue("URLActivacion", (string)"");
                int intervaloMonitoreo = (int)configuracion.GetValue("IntervaloMonitoreo", 1);
                string rutaPreyAgent = (string)configuracion.GetValue("RutaPreyAgent", (string)"");
                string correoElectronico = (string)configuracion.GetValue("CorreoElectronico", (string)"");
                string servidorSMTP = (string)configuracion.GetValue("ServidorSMTP", (string)"");
                string usuarioSMTP = (string)configuracion.GetValue("UsuarioSMTP", (string)"");
                string claveSMTP = (string)configuracion.GetValue("clSMTP", (string)"");
                bool esSSL = ((string)configuracion.GetValue("EsSSL", (string)"") == "Si") ? true : false;
                int puertoSMTP = (int)configuracion.GetValue("PuertoSMTP", 25);
                configuracionActual = new Configuracion(
                    urlActivacion,
                    intervaloMonitoreo,
                    rutaPreyAgent,
                    correoElectronico,
                    servidorSMTP,
                    usuarioSMTP,
                    claveSMTP,
                    puertoSMTP,
                    esSSL
                );
            }
            else
            {
                configuracionActual = new Configuracion("", 1, "", "", "", "", "", 25, false);
            }
            return configuracionActual;
        }
        public System.Net.NetworkCredential ObtenerCredenciales()
        {
            return new System.Net.NetworkCredential(UsuarioSMTP, ClaveSMTP);
        }
    }
}
