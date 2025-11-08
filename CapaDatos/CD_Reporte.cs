using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Reporte
    {
        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("sp_ReporteVentas", oconexion);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);
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
                                MontoTotal = dr["MontoTotal"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
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
                catch (Exception ex)
                {
                    lista = new List<ReporteVenta>();
                }
            }

            return lista;

        }

        // Reporte de Vendedores con Mayores Ventas
        public List<ReporteVendedor> VendedoresMayoresVentas(string fechainicio, string fechafin)
        {
            List<ReporteVendedor> lista = new List<ReporteVendedor>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteVendedoresMayoresVentas", oconexion);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVendedor()
                            {
                                DNI = dr["DNI"].ToString(),
                                Vendedor = dr["Vendedor"].ToString(),
                                Rol = dr["Rol"].ToString(),
                                CantidadVentas = dr["CantidadVentas"].ToString(),
                                MontoTotalVendido = dr["MontoTotalVendido"].ToString(),
                                PromedioVenta = dr["PromedioVenta"].ToString(),
                                VentaMaxima = dr["VentaMaxima"].ToString(),
                                VentaMinima = dr["VentaMinima"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<ReporteVendedor>();
                }
            }

            return lista;
        }

        // Reporte de Productos Más Vendidos
        public List<ReporteProducto> ProductosMasVendidos(string fechainicio, string fechafin)
        {
            List<ReporteProducto> lista = new List<ReporteProducto>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteProductosMasVendidos", oconexion);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteProducto()
                            {
                                Categoria = dr["Categoria"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                VecesVendido = dr["VecesVendido"].ToString(),
                                CantidadTotalVendida = dr["CantidadTotalVendida"].ToString(),
                                MontoTotalGenerado = dr["MontoTotalGenerado"].ToString(),
                                PrecioPromedioVenta = dr["PrecioPromedioVenta"].ToString(),
                                StockActual = dr["StockActual"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<ReporteProducto>();
                }
            }

            return lista;
        }

        // Reporte de Clientes con Mayor Compra
        public List<ReporteCliente> ClientesMayorCompra(string fechainicio, string fechafin)
        {
            List<ReporteCliente> lista = new List<ReporteCliente>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteClientesMayorCompra", oconexion);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteCliente()
                            {
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                CorreoCliente = dr["CorreoCliente"].ToString(),
                                TelefonoCliente = dr["TelefonoCliente"].ToString(),
                                CantidadCompras = dr["CantidadCompras"].ToString(),
                                MontoTotalComprado = dr["MontoTotalComprado"].ToString(),
                                PromedioCompra = dr["PromedioCompra"].ToString(),
                                CompraMaxima = dr["CompraMaxima"].ToString(),
                                CompraMinima = dr["CompraMinima"].ToString(),
                                UltimaCompra = dr["UltimaCompra"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<ReporteCliente>();
                }
            }

            return lista;
        }

    }
}