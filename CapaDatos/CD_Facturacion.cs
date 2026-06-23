using System;
using System.Collections.Generic;
using System.Data;
using CapaEntidades;

namespace CapaDatos
{
    public class CD_Facturacion
    {
        private CD_Conexion cn = new CD_Conexion();

        // ── Obtener clientes para ComboBox ───────────────────────
        public DataTable ObtenerClientes()
        {
            return cn.EjecutarConsulta(
                "SELECT IdCliente, NombreCompleto FROM Clientes ORDER BY NombreCompleto");
        }

        // ── Obtener métodos de pago para ComboBox ────────────────
        public DataTable ObtenerMetodosPago()
        {
            return cn.EjecutarConsulta(
                "SELECT IdMetodoPago, NombreMetodo FROM MetodosPago ORDER BY IdMetodoPago");
        }

        // ── Obtener productos para ComboBox ──────────────────────
        public DataTable ObtenerProductos()
        {
            return cn.EjecutarConsulta(@"
                SELECT
                    IdProducto,
                    CodigoProducto,
                    NombreProducto,
                    PrecioUnitario
                FROM Productos
                ORDER BY NombreProducto");
        }

        // ── Obtener precio de un producto ────────────────────────
        public decimal ObtenerPrecioProducto(int idProducto)
        {
            object res = cn.EjecutarEscalar(
                "SELECT PrecioUnitario FROM Productos WHERE IdProducto = @id",
                new Dictionary<string, object> { { "@id", idProducto } });
            return Convert.ToDecimal(res ?? 0);
        }

        // ── Obtener próximo número de factura ────────────────────
        public object ObtenerProximoNumFactura()
        {
            return cn.EjecutarEscalar(
                "SELECT ISNULL(MAX(IdFactura), 0) + 1 FROM Facturas");
        }

        // ── Guardar factura completa con detalle ─────────────────
        public int GuardarFactura(Factura factura)
        {
            // 1. Insertar cabecera y obtener ID generado
            object res = cn.EjecutarEscalar(@"
                INSERT INTO Facturas
                    (FechaFactura, IdCliente, IdMetodoPago, Subtotal, IVA, Total)
                VALUES
                    (GETDATE(), @idCliente, @idMetodo, @subtotal, @iva, @total);
                SELECT SCOPE_IDENTITY();",
                new Dictionary<string, object>
                {
                    { "@idCliente", factura.IdCliente    },
                    { "@idMetodo",  factura.IdMetodoPago },
                    { "@subtotal",  factura.Subtotal     },
                    { "@iva",       factura.IVA          },
                    { "@total",     factura.Total        }
                });

            int idFactura = Convert.ToInt32(res);

            // 2. Insertar cada línea de detalle
            foreach (var detalle in factura.Detalles)
            {
                cn.EjecutarNonQuery(@"
                    INSERT INTO DetalleFactura
                        (IdFactura, IdProducto, Cantidad, PrecioUnitario, SubtotalLinea)
                    VALUES
                        (@idFactura, @idProducto, @cantidad, @precio, @subtotal)",
                    new Dictionary<string, object>
                    {
                        { "@idFactura",  idFactura              },
                        { "@idProducto", detalle.IdProducto     },
                        { "@cantidad",   detalle.Cantidad       },
                        { "@precio",     detalle.PrecioUnitario },
                        { "@subtotal",   detalle.SubtotalLinea  }
                    });
            }

            return idFactura;
        }

        // ── Obtener historial completo ───────────────────────────
        public DataTable ObtenerHistorial()
        {
            return cn.EjecutarConsulta(@"
                SELECT
                    f.IdFactura       AS [N° Factura],
                    f.FechaFactura    AS Fecha,
                    c.NombreCompleto  AS Cliente,
                    m.NombreMetodo    AS [Método Pago],
                    f.Subtotal,
                    f.IVA,
                    f.Total
                FROM Facturas f
                INNER JOIN Clientes     c ON f.IdCliente    = c.IdCliente
                INNER JOIN MetodosPago  m ON f.IdMetodoPago = m.IdMetodoPago
                ORDER BY f.FechaFactura DESC");
        }

        // ── Obtener historial con filtros ────────────────────────
        public DataTable ObtenerHistorialFiltrado(
            string cliente, DateTime desde, DateTime hasta)
        {
            return cn.EjecutarConsulta(@"
                SELECT
                    f.IdFactura       AS [N° Factura],
                    f.FechaFactura    AS Fecha,
                    c.NombreCompleto  AS Cliente,
                    m.NombreMetodo    AS [Método Pago],
                    f.Subtotal,
                    f.IVA,
                    f.Total
                FROM Facturas f
                INNER JOIN Clientes    c ON f.IdCliente    = c.IdCliente
                INNER JOIN MetodosPago m ON f.IdMetodoPago = m.IdMetodoPago
                WHERE f.FechaFactura BETWEEN @desde AND @hasta
                  AND (@cliente = '' OR c.NombreCompleto LIKE @clienteLike)
                ORDER BY f.FechaFactura DESC",
                new Dictionary<string, object>
                {
                    { "@desde",       desde              },
                    { "@hasta",       hasta              },
                    { "@cliente",     cliente            },
                    { "@clienteLike", $"%{cliente}%"    }
                });
        }

        // ── Obtener detalle de una factura ───────────────────────
        public DataTable ObtenerDetalle(int idFactura)
        {
            return cn.EjecutarConsulta(@"
                SELECT
                    p.CodigoProducto  AS Código,
                    p.NombreProducto  AS Producto,
                    d.Cantidad,
                    d.PrecioUnitario  AS Precio,
                    d.SubtotalLinea   AS Subtotal
                FROM DetalleFactura d
                INNER JOIN Productos p ON d.IdProducto = p.IdProducto
                WHERE d.IdFactura = @id",
                new Dictionary<string, object> { { "@id", idFactura } });
        }
    }
}




































































