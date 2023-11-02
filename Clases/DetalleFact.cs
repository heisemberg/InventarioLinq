using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioLinq.Clases
{
    public class DetalleFact
    {
        public int IdDetalleFactura { get; set; }
        public int NroFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double Valor { get; set; }
    }
}