using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class CN_Login
    {
        CD_Login datos = new CD_Login();

        public Usuario IniciarSesion(string usuario, string clave)
        {
            return datos.ValidarUsuario(usuario, clave);
        }
    }
}
