using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int IdMetodoPago { get; set; }
        public string MetodoPago { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }

        public List<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();
    }
}
