using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Reporte
    {
        private CD_Reporte objcd_reporte = new CD_Reporte();

        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            return objcd_reporte.Venta(fechainicio, fechafin);
        }

        public List<ReporteVendedor> VendedoresMayoresVentas(string fechainicio, string fechafin)
        {
            return objcd_reporte.VendedoresMayoresVentas(fechainicio, fechafin);
        }

        public List<ReporteProducto> ProductosMasVendidos(string fechainicio, string fechafin)
        {
            return objcd_reporte.ProductosMasVendidos(fechainicio, fechafin);
        }

        public List<ReporteCliente> ClientesMayorCompra(string fechainicio, string fechafin)
        {
            return objcd_reporte.ClientesMayorCompra(fechainicio, fechafin);
        }
    }
}