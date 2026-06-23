using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Producto
    {
        public int IdProducto { get; set; }

        public string CodigoProducto { get; set; }

        public string NombreProducto { get; set; }

        public decimal PrecioUnitario { get; set; }

        public int IdCategoria { get; set; }

        public int? IdTipoCafe { get; set; }
    }
}
