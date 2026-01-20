using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._01_Administracion
{
    public class EmpleadoPersonalizado
    {
        private int codigo;
        private string cargo;
        private string cedula;
        private string nombre;
        private string apellido;
        private string ciudad;
        private string direccion;
        private string telefono;
        private string correo;

        public EmpleadoPersonalizado() { }

        public EmpleadoPersonalizado(int codigo, string cargo, string cedula, string nombre, string apellido, string ciudad, string direccion, string telefono, string correo)
        {
            this.Codigo = codigo;
            this.Cargo = cargo;
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Ciudad = ciudad;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Correo = correo;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }

        public string NombresApellidos { get { return Nombre + " " + Apellido; } }
        
    }
}
