using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Backup
    {
        public bool GenerarBackup(string rutaDestino, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = false;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    // Obtener el nombre de la base de datos de la cadena de conexión
                    string nombreBD = conexion.Database;

                    // Crear el nombre del archivo de backup con fecha y hora
                    string nombreArchivo = $"Backup_{nombreBD}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                    string rutaCompleta = Path.Combine(rutaDestino, nombreArchivo);

                    // Comando SQL para realizar el backup
                    string query = $"BACKUP DATABASE [{nombreBD}] TO DISK = @ruta WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Full Backup of {nombreBD}';";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@ruta", rutaCompleta);
                    cmd.CommandTimeout = 600; // 10 minutos de timeout

                    cmd.ExecuteNonQuery();

                    mensaje = $"Backup generado exitosamente en:\n{rutaCompleta}";
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al generar el backup: " + ex.Message;
                respuesta = false;
            }

            return respuesta;
        }
    }
}
