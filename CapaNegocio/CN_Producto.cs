using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;

namespace CapaNegocio
{
    public class CN_Producto
    {
        // Objeto que conecta a la capa de datos
        private CD_Producto objcd_Producto = new CD_Producto();

        // Método para listar productos
        public List<Producto> Listar()
        {
            return objcd_Producto.Listar();
        }

        // Método para registrar un producto nuevo
        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(obj.Codigo))
                Mensaje += "Es necesario el código del producto.\n";

            if (string.IsNullOrWhiteSpace(obj.Nombre))
                Mensaje += "Es necesario el nombre del producto.\n";

            if (string.IsNullOrWhiteSpace(obj.Descripcion))
                Mensaje += "Es necesaria la descripción del producto.\n";

            if (obj.oCategoria == null || obj.oCategoria.idCategoria == 0)
                Mensaje += "Debe seleccionar una categoría válida.\n";

            if (Mensaje != string.Empty)
            {
                return 0; // No se registra
            }
            else
            {
                // Llama a la capa de datos para registrar
                return objcd_Producto.Registrar(obj, out Mensaje);
            }
        }

        // Método para editar un producto existente
        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(obj.Codigo))
                Mensaje += "Es necesario el código del producto.\n";

            if (string.IsNullOrWhiteSpace(obj.Nombre))
                Mensaje += "Es necesario el nombre del producto.\n";

            if (string.IsNullOrWhiteSpace(obj.Descripcion))
                Mensaje += "Es necesaria la descripción del producto.\n";

            if (obj.oCategoria == null || obj.oCategoria.idCategoria == 0)
                Mensaje += "Debe seleccionar una categoría válida.\n";

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                // Llama al método de datos para editar
                return objcd_Producto.Editar(obj, out Mensaje);
            }
        }

        // Método para eliminar un producto
        public bool Eliminar(Producto obj, out string Mensaje)
        {
            return objcd_Producto.Eliminar(obj, out Mensaje);
        }
    }
}
