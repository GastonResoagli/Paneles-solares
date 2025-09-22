using CapaDatos; //para conectar con la capa de datos CD_Usuario
using CapaEntidad; //para usar la entidad Usuario 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    //clase de la capa negocio que maneja los usuarios
    public class CN_Usuario
    {
        //objeto de la capa datos que se conecta a la base de datos
        private CD_Usuario objcd_usuario = new CD_Usuario();

        //metodo que lista los usuarios
        public List<Usuario> Listar()
        {
            return objcd_usuario.Listar();
        }

        public int Registrar(Usuario obj, out String Mensaje)
        {
            Mensaje = String.Empty;

            if(obj.DNI == "")
            {
                Mensaje += "Es necesario el DNI del usuario \n";
            }

            if(obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre del usuario \n";
            }

            if(obj.Clave == "")
            {
                Mensaje += "Es necesario la clave del usuario \n";
            }

            if(Mensaje != String.Empty)
            {
                return 0;
            }
            else
            {
                //llama a la capa datos para registrar el usuario en la bd
                return objcd_usuario.Registrar(obj, out Mensaje);
            }

        }

        public bool Editar(Usuario obj, out String Mensaje)
        {

            Mensaje = String.Empty;

            if (obj.DNI == "")
            {
                Mensaje += "Es necesario el DNI del usuario \n";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre del usuario \n";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Es necesario la clave del usuario \n";
            }

            if (Mensaje != String.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.Editar(obj, out Mensaje);
            }

        }

        public bool Eliminar(Usuario obj, out String Mensaje)
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);
        }
    }
}
