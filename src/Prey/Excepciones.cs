using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prey
{
    // Excepciones personalizadas.
    public class EntradaDuplicadaException : ApplicationException
    {
        public EntradaDuplicadaException(string Mensaje)
            : base(Mensaje)
        {
        }
    }

    public class SubtituloDuplicadoException : ApplicationException
    {
        public SubtituloDuplicadoException(string Mensaje)
            : base(Mensaje)
        {
        }
    }

    public class WlanNoDisponibleException : ApplicationException
    {
        public WlanNoDisponibleException(string Mensaje)
            : base(Mensaje)
        {
        }
    }
    public class ResolucionIPException : ApplicationException
    {
        public ResolucionIPException(string Mensaje)
            : base(Mensaje)
        {
        }
    }
}
