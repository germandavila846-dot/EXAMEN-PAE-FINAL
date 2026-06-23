using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Conexion
    {
        private string cadena = @"Server=GERMAN\SQLEXPRESS;
                                   Database=CoffeeSoftCafe;
                                   Trusted_Connection=True;
                                   TrustServerCertificate=True";

        // ── EjecutarConsulta ─────────────────────────────────────
        public DataTable EjecutarConsulta(string sql, Dictionary<string, object> parametros = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        AgregarParametros(cmd, parametros);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en consulta: {ex.Message}");
            }
            return dt;
        }

        // ── EjecutarNonQuery ─────────────────────────────────────
        public int EjecutarNonQuery(string sql, Dictionary<string, object> parametros = null)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        AgregarParametros(cmd, parametros);
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al ejecutar: {ex.Message}");
            }
        }

        // ── EjecutarEscalar ──────────────────────────────────────
        public object EjecutarEscalar(string sql, Dictionary<string, object> parametros = null)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        AgregarParametros(cmd, parametros);
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en escalar: {ex.Message}");
            }
        }

        // ── Helper parámetros ────────────────────────────────────
        private void AgregarParametros(SqlCommand cmd, Dictionary<string, object> parametros)
        {
            if (parametros == null) return;
            foreach (var kv in parametros)
                cmd.Parameters.AddWithValue(kv.Key, kv.Value ?? DBNull.Value);
        }
    }
}