using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferre
{
    public class DetalleFact
    {
    public int ID { get; set; }
    public int NumeroFactura { get; set; }
    public int IDProducto { get; set; }
    public int Cantidad { get; set; }
    public decimal Valor { get; set; }
    }
}