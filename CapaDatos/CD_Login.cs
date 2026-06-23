using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaDatos
{
    public class CD_Login
    {
        CD_Conexion conexion = new CD_Conexion();

        public Usuario ValidarUsuario(string usuario, string clave)
        {
            Usuario obj = null;
            string sql = "SELECT * FROM Usuarios WHERE NombreUsuario=@usuario AND Clave=@clave";
            var dt = conexion.EjecutarConsulta(sql, new System.Collections.Generic.Dictionary<string, object> { { "@usuario", usuario }, { "@clave", clave } });
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                obj = new Usuario();
                obj.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                obj.NombreUsuario = row["NombreUsuario"].ToString();
                obj.NombreCompleto = row["NombreCompleto"].ToString();
                obj.Rol = row["Rol"].ToString();
            }
            return obj;
        }
    }
}
