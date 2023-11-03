
using ferre;

Random random = new Random();
var idRandom1 = random.Next(1, 1500);

List<Producto> inventario = new List<Producto>();
List<Cliente> clientes = new List<Cliente>();
List<Factura> facturas = new List<Factura>();
List<DetalleFact> detalles = new List<DetalleFact>();





inventario.Add(new Producto { ID = 1, Nombre = "Martillo", PrecioUnit = 10.0m, Cantidad = 50, StockMin = 10, StockMax = 100 });
inventario.Add(new Producto { ID = 2, Nombre = "caladora", PrecioUnit = 10.0m, Cantidad = 50, StockMin = 50, StockMax = 100 });
inventario.Add(new Producto { ID = 3, Nombre = "carretilla", PrecioUnit = 10.0m, Cantidad = 50, StockMin = 20, StockMax = 100 });

clientes.Add(new Cliente { ID = 1, Nombre = "Brayan Cala", Email = "brayancala2375@gmail.com" });
clientes.Add(new Cliente { ID = 2, Nombre = "Juan David", Email = "Juancho03@gmail.com" });
clientes.Add(new Cliente { ID = 3, Nombre = "Yael Cano", Email = "YaelyElba@gmail.com" });

facturas.Add(new Factura { numeroFactura = 1, Fecha = DateTime.Parse("2023-01-15"), IDCliente = 1, TotalFactura = 150.0m });
facturas.Add(new Factura { numeroFactura = 2, Fecha = DateTime.Parse("2023-01-15"), IDCliente = 2, TotalFactura = 150.0m });
facturas.Add(new Factura { numeroFactura = 3, Fecha = DateTime.Parse("2023-01-15"), IDCliente = 3, TotalFactura = 150.0m });

detalles.Add(new DetalleFact { ID = 1, NumeroFactura = 1, IDProducto = 1, Cantidad = 5, Valor = 50.0m });
detalles.Add(new DetalleFact { ID = 2, NumeroFactura = 2, IDProducto = 2, Cantidad = 10, Valor = 50.0m });
detalles.Add(new DetalleFact { ID = 3, NumeroFactura = 3, IDProducto = 3, Cantidad = 15, Valor = 50.0m });

while (true)
{
    Console.WriteLine("seleccione una opcion");
    Console.WriteLine("1. Listar Productos del inventaio ");
    Console.WriteLine("2. Listar Productos Casi agotados ");
    Console.WriteLine("3. lisatr prosuctos a comprar y cantidad a comprar ");
    Console.WriteLine("4. Listar total de facturas 2023");
    Console.WriteLine("5. Lista productos vendidos en una factura");
    Console.WriteLine("6. Calcular valor total del inventario");
    Console.WriteLine("0. Salir");
    // Console.WriteLine("");

    string opcion = Console.ReadLine();

    switch (opcion)
    {

        case "1":
            ListarProductos();
            break;

        case "2":
            ListarProductosAgotarse();
            break;

        case "3":
            ListarProductosAComprar();
            break;

        case "4":
            ListarFacturasEnero2023();
            break;

        case "5":
            Console.WriteLine("Ingrese el nummero de la factura");
            if (int.TryParse(Console.ReadLine(), out int numeroFactura))
            {
                ListarProductosEnFactura(numeroFactura);
            }
            else
            {
                Console.WriteLine("numero de factura invalido ");
            }
            break;

        case "6":
            CalcularValorTotalInventario();
            break;

        case "0":
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("opcion no valida, elija una opcion valida ");
            break;
    }
}



void ListarProductos()
{

//     Random random = new Random();
// var idRandom1 = random.Next(1, 1500);
    Console.WriteLine("listado de  productos en el inventario");

    foreach (var producto in inventario)
    {
        Console.WriteLine($"ID : {producto.ID}");
        Console.WriteLine($"Nombre : {producto.Nombre}");
        Console.WriteLine($"Precio : {producto.PrecioUnit:C}");
        Console.WriteLine($"Cantidad en stock : {producto.Cantidad}");
        Console.WriteLine($"Stock Min : {producto.StockMin}");
        Console.WriteLine($"Stock Max : {producto.StockMax}");
        Console.WriteLine($"------------------------------------------");


    }
}

void ListarProductosAgotarse()
{
    Console.WriteLine("Productos por agotarse");

    foreach (var producto in inventario)
    {
        if (producto.Cantidad < producto.StockMin)
        {
            Console.WriteLine($"ID : {producto.ID}");
            Console.WriteLine($"Nommbre : {producto.Nombre}");
            Console.WriteLine($"Cantidad en stock : {producto.Cantidad}");
            Console.WriteLine($"Stock Minimo : {producto.StockMin}");
            Console.WriteLine($"-++-++-++-++-++-++-++-++-++-++-++-++-++-++");
        }
        
    }
}

void ListarProductosAComprar()
{
    Console.WriteLine("productos que se deben comprar y la cantidad a comprar");

    foreach (var producto in inventario)
    {
        if (producto.Cantidad < producto.StockMax)
        {
            int cantidadAComprar = producto.StockMax - producto.Cantidad;
            if (cantidadAComprar > 0)
            {
                Console.WriteLine($"ID : {producto.ID}");
                Console.WriteLine($"Nombre : {producto.Nombre}");
                Console.WriteLine($"Cantidad a comprar : {cantidadAComprar}");
                Console.WriteLine($"************************************************");
            }
        }
    }
}

void ListarFacturasEnero2023()
{
    Console.WriteLine("lsiatado de facturas del 2023 ");

    foreach (var factura in facturas)
    {
        if(factura.Fecha.Year == 2023 && factura.Fecha.Month == 1)
        {
            Console.WriteLine($"Numero de factura : {factura.NumeroFactura}");
            Console.WriteLine($"Fecha : {factura.Fecha.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"ID cliente : {factura.IDCliente}");
            Console.WriteLine($"total de la factura : {factura.TotalFactura:C}");
            Console.WriteLine($"---------------------------------------");
        }
    }
}

void ListarProductosEnFactura(int numeroFactura)
{
    foreach (var detalle in detalles)
    {
        if(detalle.NumeroFactura == numeroFactura)
        {
            Producto producto = inventario.Find(p => p.ID == detalle.IDProducto);

            Console.WriteLine($"ID del producto = {producto.ID}");
            Console.WriteLine($"nombre : {producto.Nombre}");
            Console.WriteLine($"Cantidad vendida : {detalle.Cantidad}");
            Console.WriteLine($"valor total : {detalle.Valor:C}");
            Console.WriteLine($"-----------------------------------------------");
        }
        
    }
}

void CalcularValorTotalInventario()
{
    decimal valorTotalInventario = 0;
    
    foreach (var producto in inventario)
    {
        decimal valorProducto = producto.PrecioUnit * producto.Cantidad;
        valorTotalInventario += valorProducto;
    }

    Console.WriteLine($"valor total del inventario : {valorTotalInventario:C}");
 }

