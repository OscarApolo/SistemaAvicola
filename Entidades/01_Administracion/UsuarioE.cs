using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._01_Administracion
{
    public class UsuarioE
    {
        private int idUsuario;
        private string nombre;
        private string password;
        private string nombreCompleto;

        public UsuarioE()
        {

        }

        public UsuarioE(int idUsuario, string nombre, 
            string password, string nombreCompleto)
        {
            this.IdUsuario = idUsuario;
            this.Nombre = nombre;
            this.Password = password;
            this.NombreCompleto = nombreCompleto;
        }

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Password { get => password; set => password = value; }
        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }
    }
}
