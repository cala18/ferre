using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferre;

    public class Factura
    {
            internal int numeroFactura;

    public int NumeroFactura { get; set; }
    public DateTime Fecha { get; set; }
    public int IDCliente { get; set; }
    public decimal TotalFactura { get; set; }
    }
