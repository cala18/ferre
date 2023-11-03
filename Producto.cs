using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferre;

public class Producto
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public decimal PrecioUnit { get; set; }
    public int Cantidad { get; set; }
    public int StockMin { get; set; }
    public int StockMax { get; set; }
}
