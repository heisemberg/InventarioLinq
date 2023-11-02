using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace InventarioLinq.Clases
{
    public class Linq
    {
        List<Productos> productos = new List<Productos>(){
            new Productos { IdProducto = 1, NombreProducto = "Arroz", PrecioUnidad = 1000, Cantidad = 4, StockMinimo = 5, StockMaximo = 20 },
            new Productos { IdProducto = 2, NombreProducto = "Panela", PrecioUnidad = 2000, Cantidad = 20, StockMinimo = 5, StockMaximo = 20 },
            new Productos { IdProducto = 3, NombreProducto = "Papa", PrecioUnidad = 3000, Cantidad = 30, StockMinimo = 5, StockMaximo = 20 },
            new Productos { IdProducto = 4, NombreProducto = "Yuca", PrecioUnidad = 4000, Cantidad = 40, StockMinimo = 5, StockMaximo = 20 },
            new Productos { IdProducto = 5, NombreProducto = "Tomate", PrecioUnidad = 5000, Cantidad = 50, StockMinimo = 5, StockMaximo = 20 }
        };

        List<Cliente> clientes = new List<Cliente>(){
            new Cliente { IdCliente = 1, NombreCliente = "Juan", Mail = "juam@gmail.com" },
            new Cliente { IdCliente = 2, NombreCliente = "Pedro", Mail = "pedro@gmail.com" },
            new Cliente { IdCliente = 3, NombreCliente = "Maria", Mail = "maria@gmail.com" },
            new Cliente { IdCliente = 4, NombreCliente = "Jose", Mail = "jose@gmail.com" },
            new Cliente { IdCliente = 5, NombreCliente = "Luis", Mail = "luis@gmail.com"}
        };

        List<Factura> facturas = new  List<Factura>(){
            new Factura { NroFactura = 1, Fecha = new DateTime(2023, 11, 22), IdCliente = 5, TotalFactura = 14000 },
            new Factura { NroFactura = 2, Fecha = new DateTime(2023, 1, 24), IdCliente = 4, TotalFactura = 19000 },
            new Factura { NroFactura = 3, Fecha = new DateTime(2023, 1, 3), IdCliente = 3, TotalFactura = 30000 },
            new Factura { NroFactura = 4, Fecha = new DateTime(2023, 8, 14), IdCliente = 2, TotalFactura = 40000 },
            new Factura { NroFactura = 5, Fecha = new DateTime(2023, 5, 5), IdCliente = 1, TotalFactura = 50000 }
        };

        List<DetalleFact> detalleFacts = new List<DetalleFact>(){
            new DetalleFact { IdDetalleFactura = 1, NroFactura = 1, IdProducto = 1, Cantidad = 1, Valor = 1000 },
            new DetalleFact { IdDetalleFactura = 2, NroFactura = 1, IdProducto = 2, Cantidad = 2, Valor = 4000 },
            new DetalleFact { IdDetalleFactura = 3, NroFactura = 1, IdProducto = 3, Cantidad = 3, Valor = 9000 },
            new DetalleFact { IdDetalleFactura = 4, NroFactura = 2, IdProducto = 1, Cantidad = 4, Valor = 4000 },
            new DetalleFact { IdDetalleFactura = 5, NroFactura = 2, IdProducto = 3, Cantidad = 5, Valor = 15000 },
            new DetalleFact { IdDetalleFactura = 6, NroFactura = 3, IdProducto = 1, Cantidad = 6, Valor = 6000 },
            new DetalleFact { IdDetalleFactura = 7, NroFactura = 3, IdProducto = 2, Cantidad = 7, Valor = 14000 },
            new DetalleFact { IdDetalleFactura = 8, NroFactura = 3, IdProducto = 3, Cantidad = 8, Valor = 24000 },
            new DetalleFact { IdDetalleFactura = 9, NroFactura = 4, IdProducto = 4, Cantidad = 9, Valor = 36000 },
            new DetalleFact { IdDetalleFactura = 10, NroFactura = 5, IdProducto = 5, Cantidad = 10, Valor = 50000 },
        };

        public void ListarProductos(){
            var consulta = from p in productos
                           select p;
            foreach (var item in consulta)
            {
                Console.WriteLine(item.NombreProducto);
            }
        }

        public void ListarAgotados(){
            var consulta = from p in productos
                           where p.Cantidad < 5
                           select p;
            foreach (var item in consulta)
            {
                Console.WriteLine(item.NombreProducto);
            }
        }

        public void ProductosComprar(){
            var consulta = from p in productos
                           where p.Cantidad < p.StockMinimo
                           select new ProductoComprarDto(){
                                     Producto = p.NombreProducto, 
                                     Total= p.StockMaximo-p.Cantidad};

            foreach (var item in consulta)
            {
                Console.WriteLine(item.Producto + " " + item.Total);
            }
        }

        public void FacturasEnero(){
            var consulta = from p in facturas
                            where p.Fecha.Month == 1 &&  p.Fecha.Year == 2023
                            select p;

            foreach (var item in consulta)
            {
                Console.WriteLine(item.NroFactura);
            }
        }

        public void ListarProductosFactura(){
            Console.WriteLine("Ingrese el numero de factura");
            int nroFactura = int.Parse(Console.ReadLine());

            var consulta = from p in detalleFacts
                            join pr in productos 
                            on p.IdProducto equals pr.IdProducto
                            where p.NroFactura == nroFactura
                            select new {pr.NombreProducto, p.Cantidad, p.Valor};
            
            foreach (var item in consulta)
            {
                Console.WriteLine(item.NombreProducto + " " + item.Cantidad + " " + item.Valor);
            }
        }


        public void ValorTotalInventario(){
            var consulta = from p in productos
                            select p.PrecioUnidad * p.Cantidad;
            double total = consulta.Sum();

            Console.WriteLine(total);   
        }

    }
}















