using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

    


namespace CapaDatos
{
    public class CD_Usuario
    {
        public List<Usuario> Listar() {

            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.idUsuario,u.DNI,u.NombreCompleto,u.Correo,u.Clave,u.Estado,r.idRol,r.Descripcion from usuario u ");
                    query.AppendLine("inner join ROL r on r .idRol  = u.idRol");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                DNI = dr["DNI"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["idRol"]), Descripcion = dr["Descripcion"].ToString() }
                            });
                        }
                    } 
                }
                catch (Exception ex)
                {
                    lista = new List<Usuario>();

                }
            }
            return lista;
        }

    }
}
