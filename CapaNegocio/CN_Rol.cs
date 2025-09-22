using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaNegocio
{
    //clase de la capa negocio que maneja los roles/permisos
    public class CN_Rol
    {
        //objeto de la capa datos que se conecta a la base de datos
        private CD_Rol objcd_rol = new CD_Rol();

        //metodo que lista los roles de los usuarios
        public List<Rol> Listar()
        {
            return objcd_rol.Listar();
        }
    }
}
