using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Permiso
    {
        //listar permisos de un usuario especifico 
        public List<Permiso> Listar(int idusuario)
        {

            List<Permiso> lista = new List<Permiso>();

            //llamamos a la conexion con la DB
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Consulta SQL para obtener los permisos segun el usuario
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.idRol, p.NombreMenu from PERMISO p");
                    query.AppendLine("inner join ROL r on r.idRol = p.idRol");
                    query.AppendLine("inner join USUARIO u on u.idRol = r.idRol");
                    query.AppendLine("where u.idUsuario = @idusuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idusuario", idusuario);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    // Ejecuta la consulta y recorre los resultados
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Crea un objeto Permiso por cada fila
                            lista.Add(new Permiso()
                            {
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["idRol"]) },
                                NombreMenu = dr["NombreMenu"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // En caso de error, devuelve una lista vacia
                    lista = new List<Permiso>();

                }
            }
            // Retorna la lista de permisos del usuario
            return lista;
        }

    }
}
