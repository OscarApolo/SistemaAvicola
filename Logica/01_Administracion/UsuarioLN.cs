using Datos._01_Administracion;
using Entidades._01_Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logica._01_Administracion
{
    public class UsuarioLN
    {
        public UsuarioE Autenticar(string usuario, string pass)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pass))
            {

                return null;

            }

            return UsuarioCD.Login(usuario, pass);
        }
    }
}

