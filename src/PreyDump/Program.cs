using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Prey
{
    class Program
    {
        static string salidaLog;
        static string opcion;
        static void Main(string[] args)
        {
            Console.WriteLine("Utilidad de dumpeo de Prey");
            Console.WriteLine("Esta utilidad te permite generar un log con la información que recolecta Prey acerca de su sistema.");
            Console.WriteLine("Se generarán los archivos prey.log y prey-screenshot.jpg en la carpeta donde se ejecute esta utilidad (sobreescribirá los archivos).");
        seleccionEjecucion:
            Console.Write("¿Quieres ejecuatr este programa? (S ó N): ");
            opcion = Console.ReadLine();
            switch (opcion)
            {
                case "S":
                    goto ejecutarPrey;
                    break;
                case "N":
                    goto salirPrey;
                    break;
                default:
                    Console.WriteLine("Debes escoger una opción válida");
                    goto seleccionEjecucion;
            }
        ejecutarPrey:
            Console.WriteLine("Recolectando información del equipo...");
            salidaLog += Prey.ObtenerInformacionSistema();
            salidaLog += Prey.ObtenerTareasActivasEquipo();
            Console.WriteLine("Recolectando información de la red...");
            salidaLog += Prey.ObtenerInformacionRed();
            Console.WriteLine("Recolectando información de red inalámbrica...");
            salidaLog += Prey.ObternetInformacionWifi();
            Console.WriteLine("Obteniendo captura de pantalla...");
            try
            {
                Prey.CapturarPantalla("prey-screenshot.jpg");
            }
            catch (Exception ex)
            {
                Console.WriteLine("¡Error al guardar prey-screenshot.jpg!: {0}", ex.Message);
            }
            Console.WriteLine("Guardando prey.log...");
            try
            {
                using (StreamWriter sw = File.CreateText("prey.log"))
                {
                    sw.Write(salidaLog);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("¡Error al guardar prey.log!: {0}", ex.Message);
            }
            Console.WriteLine("El dumpeo de Prey está listo. Para ver los resultados abra los archivos prey.log y prey-screenshot.jpg.");
        salirPrey:
            Console.WriteLine("Para salir presione <ENTER>");
            Console.ReadLine();
        }
    }
}
