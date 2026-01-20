using Entidades._01_Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos._01_Administracion
{
    public class UsuarioCD
    {
        public static UsuarioE Login(string user, string password)
        {
            using (var db = new DataDControlDataContext())
            {
                var usu = db.Usuarios.FirstOrDefault(u => u.NombreLogin == user && u.Password == password);

                if (usu != null)
                {
                    return new UsuarioE
                    {
                        IdUsuario = usu.IdUsuario,
                        Nombre = usu.NombreLogin,
                        Password = usu.Password,
                        NombreCompleto = usu.NombreCompleto
                    };
                }
                return null;
            }

        }
    }
}
