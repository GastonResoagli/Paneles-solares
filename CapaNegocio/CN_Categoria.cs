using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        // Objeto que conecta a la capa de datos
        private CD_Categoria objcd_Categoria = new CD_Categoria();

        // Método para listar categorías
        public List<Categoria> Listar()
        {
            return objcd_Categoria.Listar();
        }

        // Método para registrar una categoría nueva
        public int Registrar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(obj.Descripcion))
                Mensaje += "Es necesario ingresar la descripción de la categoría.\n";

            if (Mensaje != string.Empty)
            {
                return 0; // No se registra
            }
            else
            {
                // Llama a la capa de datos
                return objcd_Categoria.Registrar(obj, out Mensaje);
            }
        }

        // Método para editar una categoría existente
        public bool Editar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(obj.Descripcion))
                Mensaje += "Es necesario ingresar la descripción de la categoría.\n";

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                // Llama al método de datos para editar
                return objcd_Categoria.Editar(obj, out Mensaje);
            }
        }

        // Método para eliminar una categoría
        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            return objcd_Categoria.Eliminar(obj, out Mensaje);
        }
    }
}
