using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;


namespace CapaNegocio
{
    //clase de la capa negocio que maneja los permisos
    public class CN_Permiso
    {
        //objeto de la capa datos, se conecta a la base de datos
        private CD_Permiso objcd_permiso = new CD_Permiso();

        //metodo que lista los permisos de un usuario
        public List<Permiso> Listar(int idusuario)
        {
            return objcd_permiso.Listar(idusuario);
        }
    }
}
