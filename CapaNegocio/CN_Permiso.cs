using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_Permiso
    {
        private CD_PERMISO objcd_permiso = new CD_PERMISO();

        public List<Permiso> Listar(int idusuario)
        {
            return objcd_permiso.Listar(idusuario);
        }
    }
}
