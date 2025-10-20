﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    //tabla Venta
    public class Venta
    {
        public int idVenta { get; set; }
        public Usuario oUsuario { get; set; }
        public Cliente oCliente { set; get; }
        public string TipoDocumento { get; set; }
        public string DocumentoCliente { get; set; }
        public int NumeroDocumento { get; set; }
        public string NombreCliente { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoCambio { get; set; }
        public decimal MontoTotal { get; set; }
        public string FechaRegistro { get; set; }
        public List<Venta_Detalle> oVenta_Detalle { get; set; }

    }
}
