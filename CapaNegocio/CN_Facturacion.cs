using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    /// <summary>
    /// Capa de Negocio: contiene las reglas de cálculo de la factura
    /// (IVA, subtotal, total). El formulario NO debe calcular esto,
    /// solo debe pedirle el resultado a esta clase.
    /// </summary>
    public class CN_Facturacion
    {
        // ── Regla de negocio: tasa de IVA vigente ────────────────
        // Si algún día cambia la tasa, se cambia AQUÍ, no en el formulario.
        private const decimal TASA_IVA = 0.15m; // 15%

        // ═══════════════════════════════════════════════════════
        //  CALCULAR IVA a partir de un subtotal
        // ═══════════════════════════════════════════════════════
        public decimal CalcularIVA(decimal subtotal)
        {
            return subtotal * TASA_IVA;
        }

        // ═══════════════════════════════════════════════════════
        //  CALCULAR TOTAL (subtotal + IVA)
        // ═══════════════════════════════════════════════════════
        public decimal CalcularTotal(decimal subtotal)
        {
            return subtotal + CalcularIVA(subtotal);
        }

        // ═══════════════════════════════════════════════════════
        //  CALCULAR TODO de una sola vez, a partir de la tabla
        //  detalle que arma el formulario (DataTable con columna
        //  "Subtotal" por cada línea de producto).
        // ═══════════════════════════════════════════════════════
        public (decimal Subtotal, decimal IVA, decimal Total) CalcularTotales(DataTable dtDetalle)
        {
            decimal subtotal = 0;

            foreach (DataRow row in dtDetalle.Rows)
                subtotal += Convert.ToDecimal(row["Subtotal"]);

            decimal iva = CalcularIVA(subtotal);
            decimal total = subtotal + iva;

            return (subtotal, iva, total);
        }
    }
}