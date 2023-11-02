using InventarioLinq.Clases;


internal class Program
{
    private static void Main(string[] args)
    {
        Linq consulta = new Linq();
        consulta.ListarProductos();
        // consulta.ListarAgotados();
        // consulta.ProductosComprar();
        // consulta.FacturasEnero();
        // consulta.ListarProductosFactura();
        // consulta.ValorTotalInventario();
    }
}