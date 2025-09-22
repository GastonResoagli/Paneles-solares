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
    public class CD_Rol
    {
        public List<Rol> Listar()
        {
            //listar todos los roles
            List<Rol> lista = new List<Rol>();

           // Se abre una conexión a la base de datos usando la cadena de conexión
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Consulta SQL para traer todos los roles
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select idRol,Descripcion from ROL");
                 
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    // Se ejecuta la consulta y se recorre el resultado
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                           // Se crea un objeto Rol por cada fila leída
                            lista.Add(new Rol()
                            {
                                IdRol = Convert.ToInt32(dr["idRol"]),
                                Descripcion = dr["Descripcion"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // En caso de error, devuelve una lista vacia
                    lista = new List<Rol>();

                }
            }
            //retorno lista de roles
            return lista;
        }


    }
}
