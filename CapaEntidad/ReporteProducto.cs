using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ReporteProducto
    {
        public string Categoria { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string VecesVendido { get; set; }
        public string CantidadTotalVendida { get; set; }
        public string MontoTotalGenerado { get; set; }
        public string PrecioPromedioVenta { get; set; }
        public string StockActual { get; set; }
    }
}
