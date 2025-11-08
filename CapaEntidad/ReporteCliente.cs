using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ReporteCliente
    {
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string CorreoCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string CantidadCompras { get; set; }
        public string MontoTotalComprado { get; set; }
        public string PromedioCompra { get; set; }
        public string CompraMaxima { get; set; }
        public string CompraMinima { get; set; }
        public string UltimaCompra { get; set; }
    }
}
