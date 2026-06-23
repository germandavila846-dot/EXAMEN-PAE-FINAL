using System;
using System.Collections.Generic;
using System.Data;
namespace CapaDatos
{
    public class CD_Reportes
    {
        private CD_Conexion cn = new CD_Conexion();

        // ── Ventas por rango de fechas ───────────────────────────
        public DataTable VentasPorFecha(DateTime desde, DateTime hasta)
        {
            return cn.EjecutarConsulta(@"
                SELECT
                    f.IdFactura          AS [N° Factura],
                    f.FechaFactura       AS Fecha,
                    c.NombreCompleto     AS Cliente,
                    m.NombreMetodo       AS [Método Pago],
                    f.Subtotal,
                    f.IVA,
                    f.Total
                FROM Facturas f
                INNER JOIN Clientes    c ON f.IdCliente    = c.IdCliente
                INNER JOIN MetodosPago m ON f.IdMetodoPago = m.IdMetodoPago
                WHERE f.FechaFactura BETWEEN @desde AND @hasta
                ORDER BY f.FechaFactura DESC",
                new Dictionary<string, object>
                {
                    { "@desde", desde },
                    { "@hasta", hasta }
                });
        }

        // ── Productos más vendidos ───────────────────────────────
        public DataTable ProductosMasVendidos(DateTime desde, DateTime hasta)
        {
            return cn.EjecutarConsulta(@"
                SELECT
                    p.CodigoProducto        AS Código,
                    p.NombreProducto        AS Producto,
                    SUM(d.Cantidad)         AS [Total Vendido],
                    AVG(d.PrecioUnitario)   AS [Precio Promedio],
                    SUM(d.SubtotalLinea)    AS [Total Ingresos]
                FROM DetalleFactura d
                INNER JOIN Productos p ON d.IdProducto = p.IdProducto
                INNER JOIN Facturas  f ON d.IdFactura  = f.IdFactura
                WHERE f.FechaFactura BETWEEN @desde AND @hasta
                GROUP BY p.CodigoProducto, p.NombreProducto
                ORDER BY SUM(d.Cantidad) DESC",
                new Dictionary<string, object>
                {
                    { "@desde", desde },
                    { "@hasta", hasta }
                });
        }

        // ── Ingresos por método de pago ──────────────────────────
        public DataTable IngresosPorMetodoPago(DateTime desde, DateTime hasta)
        {
            return cn.EjecutarConsulta(@"
                SELECT
                    m.NombreMetodo       AS [Método de Pago],
                    COUNT(f.IdFactura)   AS [N° Facturas],
                    SUM(f.Subtotal)      AS Subtotal,
                    SUM(f.IVA)          AS IVA,
                    SUM(f.Total)        AS Total
                FROM Facturas f
                INNER JOIN MetodosPago m ON f.IdMetodoPago = m.IdMetodoPago
                WHERE f.FechaFactura BETWEEN @desde AND @hasta
                GROUP BY m.NombreMetodo
                ORDER BY SUM(f.Total) DESC",
                new Dictionary<string, object>
                {
                    { "@desde", desde },
                    { "@hasta", hasta }
                });
        }

        // ── Resumen general ──────────────────────────────────────
        public DataTable ResumenGeneral(DateTime desde, DateTime hasta)
        {
            return cn.EjecutarConsulta(@"
                SELECT
                    COUNT(IdFactura)  AS [Total Facturas],
                    SUM(Subtotal)     AS [Total Subtotal],
                    SUM(IVA)         AS [Total IVA],
                    SUM(Total)       AS [Total General]
                FROM Facturas
                WHERE FechaFactura BETWEEN @desde AND @hasta",
                new Dictionary<string, object>
                {
                    { "@desde", desde },
                    { "@hasta", hasta }
                });
        }

        // ── Resumen para el Dashboard ────────────────────────────
        public DataTable ResumenDashboard()
        {
            return cn.EjecutarConsulta(@"
        SELECT
            (SELECT COUNT(*) FROM Productos)              AS TotalProductos,
            (SELECT COUNT(*) FROM Clientes)               AS TotalClientes,
            (SELECT COUNT(*) FROM Facturas
             WHERE CAST(FechaFactura AS DATE) = CAST(GETDATE() AS DATE))
                                                          AS FacturasHoy,
            (SELECT ISNULL(SUM(Total), 0) FROM Facturas
             WHERE CAST(FechaFactura AS DATE) = CAST(GETDATE() AS DATE))
                                                          AS VentasHoy,
            (SELECT ISNULL(SUM(Total), 0) FROM Facturas
             WHERE MONTH(FechaFactura) = MONTH(GETDATE())
             AND   YEAR(FechaFactura)  = YEAR(GETDATE()))
                                                          AS VentasMes");
        }
    }
}