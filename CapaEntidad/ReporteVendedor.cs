using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ReporteVendedor
    {
        public string DNI { get; set; }
        public string Vendedor { get; set; }
        public string Rol { get; set; }
        public string CantidadVentas { get; set; }
        public string MontoTotalVendido { get; set; }
        public string PromedioVenta { get; set; }
        public string VentaMaxima { get; set; }
        public string VentaMinima { get; set; }
    }
}
