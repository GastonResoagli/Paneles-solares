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
            List<ReporteVenta> lista = new List<ReporteVenta>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_ReporteVentas", oconexion);
                cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                cmd.Parameters.AddWithValue("@fechafin", fechafin);
                cmd.CommandType = CommandType.StoredProcedure;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ReporteVenta()
                        {
                            FechaRegistro = dr["FechaRegistro"].ToString(),
                            TipoDocumento = dr["TipoDocumento"].ToString(),
                            NumeroDocumento = dr["NumeroDocumento"].ToString(),
                            DocumentoCliente = dr["DocumentoCliente"].ToString(),
                            NombreCliente = dr["NombreCliente"].ToString(),
                            MontoTotal = dr["MontoTotal"].ToString(),
                            UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                            CodigoProducto = dr["CodigoProducto"].ToString(),
                            NombreProducto = dr["NombreProducto"].ToString(),
                            Categoria = dr["Categoria"].ToString(),
                            PrecioVenta = dr["PrecioVenta"].ToString(),
                            Cantidad = dr["Cantidad"].ToString(),
                            SubTotal = dr["SubTotal"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }
    }
}