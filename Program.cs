using InventarioLinq.Clases;


internal class Program
{
    private static void Main(string[] args)
    {
        Linq consulta = new Linq();
        consulta.ProductosComprar();
    }
}