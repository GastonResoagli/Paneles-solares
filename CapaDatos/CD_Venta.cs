using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Venta
    {
        //  Obtener correlativo (numero de venta siguiente)
        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) + 1 FROM VENTA");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception)
                {
                    idcorrelativo = 0;
                }
            }
            return idcorrelativo;
        }

        // Restar stock cuando se realiza una venta
        public bool RestarStock(int idproducto, int cantidad)
        {
            bool respuesta = true;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE PRODUCTO SET Stock = Stock - @cantidad WHERE idProducto = @idproducto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        // Sumar stock (por ejemplo, si se anula una venta)
        public bool SumarStock(int idproducto, int cantidad)
        {
            bool respuesta = true;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE PRODUCTO SET Stock = Stock + @cantidad WHERE idProducto = @idproducto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        // Registrar la venta y su detalle
        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarVenta", oconexion);

                    // Parametros de entrada
                    cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.idUsuario);
                    cmd.Parameters.AddWithValue("IdCliente", obj.oCliente.idCliente);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("DocumentoCliente", obj.oCliente.DNI);
                    cmd.Parameters.AddWithValue("NombreCliente", obj.oCliente.Nombre);
                    cmd.Parameters.AddWithValue("MontoPago", obj.MontoPago);
                    cmd.Parameters.AddWithValue("MontoCambio", obj.MontoCambio);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("FechaRegistro", obj.FechaRegistro);

                    // Parametro de tipo tabla estructurado
                    SqlParameter parametroDetalle = new SqlParameter("@DetalleVenta", SqlDbType.Structured);
                    parametroDetalle.TypeName = "DetalleVentaType";
                    parametroDetalle.Value = DetalleVenta;
                    cmd.Parameters.Add(parametroDetalle);

                    // Parametros de salida
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener valores de salida
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = "Error al registrar la venta. Detalle: " + ex.Message;

            }

            return Respuesta;
        }

        public Venta ObtenerVenta(string numero)
        {
            Venta oVenta = new Venta();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT v.idVenta, u.NombreCompleto AS Usuario,");
                    query.AppendLine("c.Nombre AS Cliente, v.TipoDocumento, v.NumeroDocumento, v.DocumentoCliente,");
                    query.AppendLine("v.NombreCliente, v.MontoPago, v.MontoCambio, v.MontoTotal, v.FechaRegistro");
                    query.AppendLine("FROM VENTA v");
                    query.AppendLine("INNER JOIN USUARIO u ON u.idUsuario = v.idUsuario");
                    query.AppendLine("INNER JOIN CLIENTE c ON c.idCliente = v.idCliente");
                    query.AppendLine("WHERE v.NumeroDocumento = @numero");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@numero", Convert.ToInt32(numero));
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            oVenta = new Venta()
                            {
                                idVenta = Convert.ToInt32(dr["idVenta"]),
                                oUsuario = new Usuario() { NombreCompleto = dr["Usuario"].ToString() },
                                oCliente = new Cliente() { Nombre = dr["Cliente"].ToString() },
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                MontoPago = Convert.ToDecimal(dr["MontoPago"]),
                                MontoCambio = Convert.ToDecimal(dr["MontoCambio"]),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]).ToString("dd/MM/yyyy HH:mm")

                            };
                        }
                    }
                }
                catch
                {
                    oVenta = new Venta();
                }
            }
            return oVenta;
        }

        public List<Venta_Detalle> ObtenerDetalleVenta(int idVenta)
        {
            List<Venta_Detalle> lista = new List<Venta_Detalle>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.Nombre, dv.PrecioVenta, dv.Cantidad, dv.SubTotal");
                    query.AppendLine("FROM DETALLEVENTA dv");
                    query.AppendLine("INNER JOIN PRODUCTO p ON p.idProducto = dv.idProducto");
                    query.AppendLine("WHERE dv.idVenta = @idVenta");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Venta_Detalle()
                            {
                                oProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"])
                            });
                        }
                    }
                }
                catch
                {
                    lista = new List<Venta_Detalle>();
                }
            }
            return lista;
        }



    }
}

