using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cliente
    {

        //objeto de la capa datos que se conecta a la base de datos
        private CD_Cliente objcd_Cliente = new CD_Cliente();

        //metodo que lista los Clientes
        public List<Cliente> Listar()
        {
            return objcd_Cliente.Listar();
        }

        public int Registrar(Cliente obj, out String Mensaje)
        {
            Mensaje = String.Empty;

            if (obj.DNI == "")
            {
                Mensaje += "Es necesario el DNI del Cliente \n";
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del Cliente \n";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del Cliente \n";
            }

            if (Mensaje != String.Empty)
            {
                return 0;
            }
            else
            {
                //llama a la capa datos para registrar el Cliente en la bd
                return objcd_Cliente.Registrar(obj, out Mensaje);
            }

        }

        public bool Editar(Cliente obj, out String Mensaje)
        {

            Mensaje = String.Empty;

            if (obj.DNI == "")
            {
                Mensaje += "Es necesario el DNI del Cliente \n";
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del Cliente \n";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del Cliente \n";
            }

            if (Mensaje != String.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Cliente.Editar(obj, out Mensaje);
            }

        }

        public bool Eliminar(Cliente obj, out String Mensaje)
        {
            return objcd_Cliente.Eliminar(obj, out Mensaje);
        }

    }
}
