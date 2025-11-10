using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Backup
    {
        private CD_Backup objcd_Backup = new CD_Backup();

        public bool GenerarBackup(string rutaDestino, out string mensaje)
        {
            return objcd_Backup.GenerarBackup(rutaDestino, out mensaje);
        }
    }
}
