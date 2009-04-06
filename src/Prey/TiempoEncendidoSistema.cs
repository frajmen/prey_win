using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prey
{
    /// <summary>
    /// Representa un intervalo de tiempo.
    /// </summary>
    class TiempoEncendidoSistema
    {
        /// <summary>
        /// Contiene las unidades expresadas en segundos.
        /// </summary>
        private enum UnidadesSegundo
        {
            /// <summary>
            /// Segundos en un segundo.
            /// </summary>
            Segundo = 1,
            /// <summary>
            /// Segundos en un minuto.
            /// </summary>
            Minuto = 60,
            /// <summary>
            /// Segundos en una hora.
            /// </summary>
            Hora = 3600
        }
        /// <summary>
        /// Contiene los segundo del intervalo.
        /// </summary>
        private int segundos;
        /// <summary>
        /// Contiene los minutos del intervalo.
        /// </summary>
        private int minutos;
        /// <summary>
        /// Contiene las horas del intervalo.
        /// </summary>
        private int horas;
        /// <summary>
        /// Obtiene los segundos del intervalo.
        /// </summary>
        public int Segundos
        {
            get { return segundos; }
            private set { segundos = value; }
        }
        /// <summary>
        /// Obtiene los minutos del intervalo.
        /// </summary>
        public int Minutos
        {
            get { return minutos; }
            private set { minutos = value; }
        }
        /// <summary>
        /// Obtiene las horas del intervalo.
        /// </summary>
        public int Horas
        {
            get { return horas; }
            private set { horas = value; }
        }
        /// <summary>
        /// Crea un nuevo intervalo de tiempo.
        /// </summary>
        public TiempoEncendidoSistema()
        {
            int segundos = Environment.TickCount / 1000;
            Horas = (int)Math.Floor((decimal)segundos / (decimal)UnidadesSegundo.Hora);
            segundos -= Horas * (int)UnidadesSegundo.Hora;
            Minutos = (int)Math.Floor((decimal)segundos / (decimal)UnidadesSegundo.Minuto);
            segundos -= Minutos * (int)UnidadesSegundo.Minuto;
            Segundos = segundos;
        }
    }
}
