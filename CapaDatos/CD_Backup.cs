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
            string rutaTemporal = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    // Obtener el nombre de la base de datos de la cadena de conexión
                    string nombreBD = conexion.Database;

                    // Crear el nombre del archivo de backup con fecha y hora
                    string nombreArchivo = $"Backup_{nombreBD}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

                    // Obtener la ruta de backup por defecto de SQL Server
                    string carpetaBackupSQL = ObtenerRutaBackupPorDefecto(conexion);

                    if (string.IsNullOrEmpty(carpetaBackupSQL))
                    {
                        // Si no se puede obtener, usar la ruta de datos de SQL Server
                        carpetaBackupSQL = ObtenerRutaDatosSQL(conexion);
                    }

                    rutaTemporal = Path.Combine(carpetaBackupSQL, nombreArchivo);

                    // Comando SQL para realizar el backup en la carpeta de SQL Server
                    string query = $"BACKUP DATABASE [{nombreBD}] TO DISK = @ruta WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Full Backup of {nombreBD}';";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@ruta", rutaTemporal);
                    cmd.CommandTimeout = 600; // 10 minutos de timeout

                    cmd.ExecuteNonQuery();

                    // Cerrar la conexión antes de copiar el archivo
                    conexion.Close();
                }

                // Ahora copiar el archivo desde la carpeta de SQL Server a la ubicación deseada
                string rutaFinal = Path.Combine(rutaDestino, Path.GetFileName(rutaTemporal));

                // Si ya existe un archivo con el mismo nombre, eliminarlo
                if (File.Exists(rutaFinal))
                {
                    File.Delete(rutaFinal);
                }

                // Copiar el archivo
                File.Copy(rutaTemporal, rutaFinal, true);

                // Eliminar el archivo temporal
                if (File.Exists(rutaTemporal))
                {
                    File.Delete(rutaTemporal);
                }

                mensaje = $"Backup generado exitosamente en:\n{rutaFinal}";
                respuesta = true;
            }
            catch (Exception ex)
            {
                mensaje = "Error al generar el backup: " + ex.Message;
                respuesta = false;

                // Limpiar el archivo temporal si existe
                try
                {
                    if (!string.IsNullOrEmpty(rutaTemporal) && File.Exists(rutaTemporal))
                    {
                        File.Delete(rutaTemporal);
                    }
                }
                catch
                {
                    // Ignorar errores al limpiar
                }
            }

            return respuesta;
        }

        private string ObtenerRutaBackupPorDefecto(SqlConnection conexion)
        {
            try
            {
                string query = @"
                    DECLARE @BackupDirectory NVARCHAR(512)
                    EXEC master.dbo.xp_instance_regread
                        N'HKEY_LOCAL_MACHINE',
                        N'Software\Microsoft\MSSQLServer\MSSQLServer',
                        N'BackupDirectory',
                        @BackupDirectory OUTPUT
                    SELECT @BackupDirectory AS BackupDirectory";

                SqlCommand cmd = new SqlCommand(query, conexion);

                object resultado = cmd.ExecuteScalar();
                if (resultado != null && resultado != DBNull.Value)
                {
                    return resultado.ToString();
                }
            }
            catch
            {
                // Si falla, retornar null
            }

            return null;
        }

        private string ObtenerRutaDatosSQL(SqlConnection conexion)
        {
            try
            {
                string query = "SELECT LEFT(physical_name, LEN(physical_name) - CHARINDEX('\\', REVERSE(physical_name))) AS ruta FROM sys.master_files WHERE database_id = DB_ID() AND type = 0";
                SqlCommand cmd = new SqlCommand(query, conexion);

                object resultado = cmd.ExecuteScalar();
                if (resultado != null && resultado != DBNull.Value)
                {
                    return resultado.ToString();
                }
            }
            catch
            {
                // Si falla, usar carpeta temporal como último recurso
                return Path.GetTempPath();
            }

            return Path.GetTempPath();
        }
    }
}
