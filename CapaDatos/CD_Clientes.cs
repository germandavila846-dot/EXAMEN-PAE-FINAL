using System;
using System.Collections.Generic;
using System.Data;
using CapaEntidades;

namespace CapaDatos
{
    public class CD_Clientes
    {
        private CD_Conexion cn = new CD_Conexion();

        // ── Obtener todos los clientes ───────────────────────────
        public DataTable ObtenerTodos()
        {
            return cn.EjecutarConsulta(@"
                SELECT
                    IdCliente       AS ID,
                    NombreCompleto  AS Nombre,
                    Direccion       AS Dirección,
                    Telefono        AS Teléfono
                FROM Clientes
                ORDER BY IdCliente");
        }

        // ── Obtener cliente por ID ───────────────────────────────
        public Cliente ObtenerPorId(int idCliente)
        {
            DataTable dt = cn.EjecutarConsulta(
                "SELECT * FROM Clientes WHERE IdCliente = @id",
                new Dictionary<string, object> { { "@id", idCliente } });

            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new Cliente
            {
                IdCliente = Convert.ToInt32(row["IdCliente"]),
                NombreCompleto = row["NombreCompleto"].ToString(),
                Direccion = row["Direccion"].ToString(),
                Telefono = row["Telefono"].ToString()
            };
        }

        // ── Insertar cliente ─────────────────────────────────────
        public bool Insertar(Cliente cliente)
        {
            try
            {
                cn.EjecutarNonQuery(@"
                    INSERT INTO Clientes
                        (NombreCompleto, Direccion, Telefono)
                    VALUES
                        (@nombre, @direccion, @telefono)",
                    new Dictionary<string, object>
                    {
                        { "@nombre",    cliente.NombreCompleto },
                        { "@direccion", cliente.Direccion      },
                        { "@telefono",  cliente.Telefono       }
                    });
                return true;
            }
            catch { return false; }
        }

        // ── Actualizar cliente ───────────────────────────────────
        public bool Actualizar(Cliente cliente)
        {
            try
            {
                cn.EjecutarNonQuery(@"
                    UPDATE Clientes SET
                        NombreCompleto = @nombre,
                        Direccion      = @direccion,
                        Telefono       = @telefono
                    WHERE IdCliente = @id",
                    new Dictionary<string, object>
                    {
                        { "@nombre",    cliente.NombreCompleto },
                        { "@direccion", cliente.Direccion      },
                        { "@telefono",  cliente.Telefono       },
                        { "@id",        cliente.IdCliente      }
                    });
                return true;
            }
            catch { return false; }
        }

        // ── Eliminar cliente ─────────────────────────────────────
        public bool Eliminar(int idCliente)
        {
            try
            {
                cn.EjecutarNonQuery(
                    "DELETE FROM Clientes WHERE IdCliente = @id",
                    new Dictionary<string, object> { { "@id", idCliente } });
                return true;
            }
            catch { return false; }
        }

        // ── Obtener próximo ID ───────────────────────────────────
        public int ObtenerProximoId()
        {
            object res = cn.EjecutarEscalar(
                "SELECT ISNULL(MAX(IdCliente), 0) + 1 FROM Clientes");
            return Convert.ToInt32(res ?? 1);
        }

        // ── Buscar clientes ──────────────────────────────────────
        public DataTable Buscar(string filtro)
        {
            return cn.EjecutarConsulta(@"
                SELECT
                    IdCliente       AS ID,
                    NombreCompleto  AS Nombre,
                    Direccion       AS Dirección,
                    Telefono        AS Teléfono
                FROM Clientes
                WHERE NombreCompleto LIKE @filtro
                   OR Telefono       LIKE @filtro
                ORDER BY IdCliente",
                new Dictionary<string, object>
                {
                    { "@filtro", $"%{filtro}%" }
                });
        }
    }
}