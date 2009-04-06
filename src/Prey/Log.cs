using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Prey
{
    /// <summary>
    /// Define los diferentes tipos de títulos que hay.
    /// </summary>
    internal enum TipoTitulo
    {
        /// <summary>
        /// Título principal.
        /// </summary>
        Titulo,
        /// <summary>
        /// Título secundario.
        /// </summary>
        Subtitulo
    }
    /// <summary>
    /// Escritor de archivos de log.
    /// </summary>
    internal class Log
    {
        /// <summary>
        /// Contiene las entradas del log.
        /// </summary>
        private Collection<EntradaLog> entradas;
        /// <summary>
        /// Contiene los subtítulos del log.
        /// </summary>
        private Collection<SubTituloLog> subtitulos;
        /// <summary>
        /// Obtiene el número de entradas que hay en el log.
        /// </summary>
        public uint NumeroEntradasActuales
        {
            get { return (uint)entradas.Count; }
        }
        /// <summary>
        /// Crea un log.
        /// </summary>
        public Log()
        {
            entradas = new Collection<EntradaLog>();
            subtitulos = new Collection<SubTituloLog>();
        }
        /// <summary>
        /// Agrega una nueva entrada al log.
        /// </summary>
        /// <param name="Entrada">Entrada a agregar.</param>
        /// <exception cref="EntradaDuplicadaException">Se arroja cuando la entrada ya se encuentra dentro de log. La entrada es la misma si tiene igual sección e igual nombre de campo.</exception>
        public void AgregarEntrada(EntradaLog Entrada)
        {
            foreach (EntradaLog entrada in entradas)
                if (Entrada.Seccion == entrada.Seccion && Entrada.Campo == entrada.Campo)
                    throw new EntradaDuplicadaException(String.Format("La entrada ya está en la lista: sección {0}, campo {1}", Entrada.Seccion, Entrada.Campo));
            entradas.Add(Entrada);
        }
        /// <summary>
        /// Asocia un subtítulo con una sección de entradas.
        /// </summary>
        /// <param name="Subtitulo">Subtítulo a asociar.</param>
        /// <remarks>Si se va a utilizar el método ObtenerLogEnFormato() deben establecerse subtítulos, de lo contrario las secciones que no estén asociadas a un subtítulo no aparecerán.</remarks>
        /// <exception cref="SubtituloDuplicadoException">Se arroja cuando el subtítulo ya se encuentra en la lista de subtítulos. El subtítulo es el mismo si su sección es el mismo.</exception>
        public void AsociarSubtituloSeccion(SubTituloLog Subtitulo)
        {
            foreach (SubTituloLog subtitulo in subtitulos)
                if (Subtitulo.Seccion == subtitulo.Seccion)
                    throw new SubtituloDuplicadoException("Ya hay un subtítulo definido para esta sección");
            subtitulos.Add(Subtitulo);
        }
        /// <summary>
        /// Obtiene el log con un formato legible.
        /// </summary>
        /// <param name="Titulo">Título del log.</param>
        /// <param name="ImprimirFechaActual">Determina si se coloca la fecha actual en el reporte.</param>
        /// <returns>Devuelve el log con un formato legible.</returns>
        public string ObtenerLogEnFormato(string Titulo, bool ImprimirFechaActual)
        {
            string log = construirTitulo(Titulo,TipoTitulo.Titulo);
            if (ImprimirFechaActual)
                log += construirTitulo(String.Format("Fecha actual: {0}", DateTime.Now.ToString("o")), TipoTitulo.Subtitulo);
            uint espacioReservado;
            Collection<EntradaLog> entradasTemporales;
            foreach (SubTituloLog subtitulo in subtitulos)
            {
                entradasTemporales = new Collection<EntradaLog>();
                espacioReservado = 0;
                log += construirTitulo(subtitulo.Subtitulo, TipoTitulo.Subtitulo);
                foreach (EntradaLog entrada in entradas)
                    if (entrada.Seccion == subtitulo.Seccion)
                    {
                        entradasTemporales.Add(entrada);
                        if (entrada.Campo.Length > espacioReservado)
                            espacioReservado = (uint)entrada.Campo.Length;
                    }
                foreach (EntradaLog entrada in entradasTemporales)
                    log += construirEntradaLegible(entrada, (uint)(espacioReservado - entrada.Campo.Length));
                log += "\r\n\r\n";
            }
            return log;
        }
        /// <summary>
        /// Obtiene el log con un formato legible.
        /// </summary>
        /// <param name="Titulo">Título del log.</param>
        /// <returns>Devuelve el log con un formato legible.</returns>
        public string ObtenerLogEnFormato(string Titulo)
        {
            return ObtenerLogEnFormato(Titulo, true);
        }
        /// <summary>
        /// Construye un título para el blog.
        /// </summary>
        /// <param name="Titulo">Título a construir.</param>
        /// <param name="Tipo">Tipo de título.</param>
        /// <returns>Devuelve una cadena de caracteres con el título formateado.</returns>
        private string construirTitulo(string Titulo, TipoTitulo Tipo)
        {
            string titulo = "";
            switch (Tipo)
            {
                case TipoTitulo.Titulo:
                    for (byte i = 1; i <= (byte)Titulo.Length; i++)
                        titulo += "=";
                    titulo += String.Format("====\r\n| {0} |\r\n====", Titulo.ToUpper());
                    for (byte i = 1; i <= (byte)Titulo.Length; i++)
                        titulo += "=";
                    titulo += "\r\n\r\n";
                    break;
                case TipoTitulo.Subtitulo:
                    titulo = String.Format("{0}\r\n", Titulo);
                    for (byte i = 1; i <= (byte)Titulo.Length; i++)
                        titulo += "=";
                    titulo += "\r\n";
                    break;
                default:
                    titulo = String.Format("{0}\r\n", Titulo);
                    break;
            }
            return titulo;
        }
        /// <summary>
        /// Construye una entrada legible
        /// </summary>
        /// <param name="Entrada">Entrada del log que se va a construir.</param>
        /// <param name="EspacioReservadoCampo">Número de caracteres que van después del nombre del campo antes de colocar el valor de éste.</param>
        /// <returns></returns>
        private string construirEntradaLegible(EntradaLog Entrada, uint EspacioReservadoCampo)
        {
            string entradaLegible = "";
            entradaLegible += Entrada.Campo;
            for (uint i = 1; i <= EspacioReservadoCampo+1; i++)
                entradaLegible += " ";
            entradaLegible += String.Format(":\t{0}", Entrada.Valor);
            if (Entrada.InformacionAdicional != null)
                entradaLegible += String.Format("\r\n\t{0}", Entrada.InformacionAdicional);
            entradaLegible += "\r\n";
            return entradaLegible;
        }
    }

    internal class EntradaLog
    {
        /// <summary>
        /// Contiene la sección de la entrada.
        /// </summary>
        private string seccion;
        /// <summary>
        /// Contiene el campo de la entrada.
        /// </summary>
        private string campo;
        /// <summary>
        /// Contiene el valor de la entrada.
        /// </summary>
        private string valor;
        /// <summary>
        /// Contiene alguna información adicional sobre la entrada.
        /// </summary>
        private string informacionAdicional;
        /// <summary>
        /// Obtiene o establece la sección de la entrada.
        /// </summary>
        public string Seccion
        {
            get { return seccion; }
            set { seccion = value; }
        }
        /// <summary>
        /// Obtiene o establece el nombre del campo de la entrada.
        /// </summary>
        public string Campo
        {
            get { return campo; }
            set { campo = value; }
        }
        /// <summary>
        /// Obtiene o establece el valor de la entrada
        /// </summary>
        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        /// <summary>
        /// Obtiene o establece información adicional sobre la entrada.
        /// </summary>
        public string InformacionAdicional
        {
            get { return informacionAdicional; }
            set { informacionAdicional = value; }
        }
        /// <summary>
        /// Crea una entrada de log.
        /// </summary>
        /// <param name="Seccion">Sección de la entrada.</param>
        /// <param name="Campo">Nombre del campo de la entrada.</param>
        /// <param name="Valor">Valor de la entrada.</param>
        /// <param name="InformacionAdicional">Información adicional sobre la entrada.</param>
        public EntradaLog(string Seccion, string Campo, string Valor, string InformacionAdicional)
        {
            this.Seccion = Seccion;
            this.Campo = Campo;
            this.Valor = Valor;
            this.InformacionAdicional = InformacionAdicional;
        }
        /// <summary>
        /// Crea una entrada de log.
        /// </summary>
        /// <param name="Sección">Sección de la entrada.</param>
        /// <param name="Campo">Nombre del campo de la entrada.</param>
        /// <param name="Valor">Valor de la entrada.</param>
        public EntradaLog(string Sección, string Campo, string Valor)
        {
            this.Seccion = Sección;
            this.Campo = Campo;
            this.Valor = Valor;
        }
    }

    internal class SubTituloLog
    {
        /// <summary>
        /// Contiene el título de la subsección del log.
        /// </summary>
        private string subtitulo;
        /// <summary>
        /// Contiene la sección asociada al subtítulo.
        /// </summary>
        private string seccion;
        /// <summary>
        /// Obtiene o establece el subtítulo del log.
        /// </summary>
        public string Subtitulo
        {
            get { return subtitulo; }
            set { subtitulo = value; }
        }
        /// <summary>
        /// Obtiene o establece la sección asociada al subtítulo.
        /// </summary>
        public string Seccion
        {
            get { return seccion; }
            set { seccion = value; }
        }
        /// <summary>
        /// Crea un nuevo subtítulo.
        /// </summary>
        /// <param name="Subtitulo">Subtítulo de la subsección.</param>
        /// <param name="Seccion">Sección asociada al subtítulo.</param>
        public SubTituloLog(string Subtitulo, string Seccion)
        {
            this.Subtitulo = Subtitulo;
            this.Seccion = Seccion;
        }
    }
}