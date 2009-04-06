using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;
using NativeWifi;

namespace Prey
{
    /// <summary>
    /// Contiene métodos que permiten recuperar información del computador en caso de robo o pérdida.
    /// </summary>
    static public class Prey
    {
        /// <summary>
        /// Obtiene la información de las interfaces de red en las que está conectado el computador actualmente.
        /// </summary>
        /// <returns>Devuelve </returns>
        static public string ObtenerInformacionRed()
        {
            Log log = new Log();
            IPGlobalProperties propiedadesIP = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            // Información del equipo
            log.AsociarSubtituloSeccion(new SubTituloLog("Información del equipo", "Equipo"));
            log.AgregarEntrada(new EntradaLog("Equipo", "Nombre de equipo", propiedadesIP.HostName));
            log.AgregarEntrada(new EntradaLog("Equipo", "Dominio", propiedadesIP.DomainName));
            log.AgregarEntrada(new EntradaLog("Equipo", "DHCP", propiedadesIP.DhcpScopeName));
            // Información de conexión activas
            log.AsociarSubtituloSeccion(new SubTituloLog("Conexiones Activas", "Conexiones"));
            TcpConnectionInformation[] conexionesActivas = propiedadesIP.GetActiveTcpConnections();
            uint contador = 1;
            foreach (TcpConnectionInformation conexionActiva in conexionesActivas)
            {
                log.AgregarEntrada(
                    new EntradaLog(
                        "Conexiones",
                        String.Format("Conexión {0}", contador.ToString()),
                        String.Format(
                            "{0}:{1} -> {2}:{3} ({4})",
                            conexionActiva.LocalEndPoint.Address.ToString(),
                            conexionActiva.LocalEndPoint.Port.ToString(),
                            conexionActiva.RemoteEndPoint.Address.ToString(),
                            conexionActiva.RemoteEndPoint.Port.ToString(),
                            conexionActiva.State.ToString()
                        )
                    )
                );
                contador++;
            }
            // Información de puertos en escucha
            log.AsociarSubtituloSeccion(new SubTituloLog("Puertos en escucha", "Servidor"));
            IPEndPoint[] TCPListeners = propiedadesIP.GetActiveTcpListeners();
            IPEndPoint[] UDPListeners = propiedadesIP.GetActiveUdpListeners();
            contador = 1;
            foreach (IPEndPoint tcplistener in TCPListeners)
            {

                log.AgregarEntrada(new EntradaLog("Servidor",
                    String.Format("Puerto {0}", contador),
                    String.Format("TCP: {0}:{1}", tcplistener.Address.ToString(), tcplistener.Port.ToString())
                    )
                );
                contador++;
            }
            foreach (IPEndPoint udplistener in UDPListeners)
            {

                log.AgregarEntrada(new EntradaLog("Servidor",
                    String.Format("Puerto {0}", contador),
                    String.Format("UDP: {0}:{1}", udplistener.Address.ToString(), udplistener.Port.ToString())
                    )
                );
                contador++;
            }
            //Interfaces de red
            log.AsociarSubtituloSeccion(new SubTituloLog("Interfaces de red", "Interfaces"));
            string identificador;
            foreach (NetworkInterface interfaz in interfaces)
            {
                identificador = String.Format("Iterfaz {0}", interfaz.Name);
                log.AsociarSubtituloSeccion(new SubTituloLog(identificador, identificador));
                log.AgregarEntrada(new EntradaLog(identificador, "Identificador", interfaz.Id));
                log.AgregarEntrada(new EntradaLog(identificador, "Tipo", interfaz.NetworkInterfaceType.ToString()));
                log.AgregarEntrada(new EntradaLog(identificador, "Descripción", interfaz.Description));
                log.AgregarEntrada(new EntradaLog(identificador, "Dirección física", interfaz.GetPhysicalAddress().ToString()));
                log.AgregarEntrada(new EntradaLog(identificador, "Estado", interfaz.OperationalStatus.ToString()));
                log.AgregarEntrada(new EntradaLog(identificador, "Velocidad", interfaz.Speed.ToString()));
                log.AgregarEntrada(new EntradaLog(identificador, "¿Sólo recibe?", (interfaz.IsReceiveOnly) ? "Si" : "No"));
                log.AgregarEntrada(new EntradaLog(identificador, "Multicast", (interfaz.SupportsMulticast) ? "Si" : "No"));
            }
            // Direcciones IP del equipo
            log.AsociarSubtituloSeccion(new SubTituloLog("Direcciones IP", "IP"));
            IPAddress[] direcciones = Dns.GetHostEntry(propiedadesIP.HostName).AddressList;
            contador = 1;
            foreach (IPAddress direccion in direcciones)
            {
                log.AgregarEntrada(new EntradaLog("IP", String.Format("Dirección {0} (Local)", contador), direccion.ToString()));
                contador++;
            }
            WebClient wc = new WebClient();
            string direccionWAN;
            try
            {
                direccionWAN = Encoding.ASCII.GetString(wc.DownloadData("http://whatismyip.com/automation/n09230945.asp"));
            }
            catch
            {
                direccionWAN = "No se pudo resolver.";
            }
            log.AgregarEntrada(new EntradaLog("IP", "Dirección WAN", direccionWAN));
            return log.ObtenerLogEnFormato("Información de la red");
        }
        /// <summary>
        /// Recolecta toda la infromación Wifi que hay disponible.
        /// </summary>
        /// <returns>Devuelve la información que se ha recolectado en una manera legible.</returns>
        static public string ObternetInformacionWifi()
        {
            Log log = new Log();
            WlanClient clienteWifi;
            // Determinar si hay adaptadores inalámbricos disponibles.
            try
            {
                clienteWifi = new WlanClient();
            }
            catch
            {
                throw new WlanNoDisponibleException("Los adaptadores inalámbricos parecen no estar disponibles");
            }
            log.AsociarSubtituloSeccion(new SubTituloLog("Interfaces de red wireless", "Interfaces"));
            uint contador = 1;
            uint contador2 = 1;
            string identificadorInterfaz;
            // Obtención de interfaces.
            foreach (WlanClient.WlanInterface interfaz in clienteWifi.Interfaces)
            {
                identificadorInterfaz = String.Format("IDI{0}", contador);
                log.AsociarSubtituloSeccion(new SubTituloLog(String.Format("Interfaz {0}", contador.ToString()), identificadorInterfaz));
                interfaz.Scan();
                Wlan.WlanAvailableNetwork[] redesDisponibles = interfaz.GetAvailableNetworkList(0);
                contador2 = 1;
                // Obtención de información de las redes por interfaz.
                foreach (Wlan.WlanAvailableNetwork redDisponible in redesDisponibles)
                {
                    log.AgregarEntrada(new EntradaLog(
                        identificadorInterfaz,
                        String.Format("Red {0} -> Nombre", contador2.ToString()),
                        Encoding.ASCII.GetString(redDisponible.dot11Ssid.SSID)
                    ));
                    log.AgregarEntrada(new EntradaLog(
                        identificadorInterfaz,
                        String.Format("Red {0} -> Cifrado", contador2.ToString()),
                        redDisponible.dot11DefaultCipherAlgorithm.ToString()
                    ));
                    log.AgregarEntrada(new EntradaLog(
                        identificadorInterfaz,
                        String.Format("Red {0} -> Autenticación", contador2.ToString()),
                        redDisponible.dot11DefaultAuthAlgorithm.ToString()
                    ));
                    log.AgregarEntrada(new EntradaLog(
                        identificadorInterfaz,
                        String.Format("Red {0} -> Intensidad de señal", contador2.ToString()),
                        redDisponible.wlanSignalQuality.ToString()
                    ));
                    log.AgregarEntrada(new EntradaLog(
                        identificadorInterfaz,
                        String.Format("Red {0} -> ¿Puede conectarse?", contador2.ToString()),
                        (redDisponible.networkConnectable) ? "Si" : "No"
                    ));
                    if (!redDisponible.networkConnectable)
                        log.AgregarEntrada(new EntradaLog(
                            identificadorInterfaz,
                            String.Format("Red {0} -> Sin conexión", contador2.ToString()),
                            redDisponible.wlanNotConnectableReason.ToString()
                        ));
                    contador2++;
                }
                contador++;
            }
            return log.ObtenerLogEnFormato("Información de la red inalámbrica");
        }
        /// <summary>
        /// Obtiene las tareas activas del equipo
        /// </summary>
        /// <returns>Devuelve un formato legible de la lista de tareas del equipo.</returns>
        static public string ObtenerTareasActivasEquipo()
        {
            Log log = new Log();
            Process[] procesos = Process.GetProcesses();
            log.AsociarSubtituloSeccion(new SubTituloLog("Procesos activos", "Procesos"));
            uint contador = 1;
            foreach (Process proceso in procesos)
            {
                log.AgregarEntrada(new EntradaLog("Procesos", String.Format("{0} {1}", contador, proceso.ProcessName), proceso.MainWindowTitle));
                contador++;
            }
            return log.ObtenerLogEnFormato("Tareas activas del equipo");
        }
        /// <summary>
        /// Obtiene la información relacionada con el sistema y el ambiente actual de la sesión.
        /// </summary>
        /// <returns>Devuelve un formato legible de la información general del sistema y sus variables de entorno actuales.</returns>
        static public string ObtenerInformacionSistema()
        {
            Log log = new Log();
            log.AsociarSubtituloSeccion(new SubTituloLog("Información general", "general"));
            TiempoEncendidoSistema tiempoEncendido = new TiempoEncendidoSistema();
            log.AgregarEntrada(new EntradaLog(
                "general",
                "Tiempo encendido",
                String.Format("{0} horas, {1} minutos y {2} segundos", tiempoEncendido.Horas, tiempoEncendido.Minutos, tiempoEncendido.Segundos)
            ));
            log.AgregarEntrada(new EntradaLog("general", "Usuario activo", Environment.UserName));
            log.AsociarSubtituloSeccion(new SubTituloLog("Variables de entorno", "variables"));
            System.Collections.IDictionary variablesEntorno = Environment.GetEnvironmentVariables();
            foreach (System.Collections.DictionaryEntry variable in variablesEntorno)
                log.AgregarEntrada(new EntradaLog("variables", (string)variable.Key, (string)variable.Value));
            return log.ObtenerLogEnFormato("Información del sistema");
        }
        /// <summary>
        /// Captura la pantalla del escritorio.
        /// </summary>
        /// <param name="RutaPrtScr">Ruta para guardar la captura de pantalla.</param>
        static public void CapturarPantalla(string RutaPrtScr)
        {
            try
            {
                CaptureScreen.CaptureScreen.GetDesktopImage().Save(RutaPrtScr, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch { }
        }
    }
}
