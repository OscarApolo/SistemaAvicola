using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._04_Comercializacion
{
    public class ClienteE
    {
        private int idCliente;
        private string razonSocial;
        private string cedula;
        private string ciudad;
        private string direccion;
        private string telefono;

        public ClienteE() { }

        public ClienteE(int idCliente, string razonSocial, string cedula, string ciudad, string direccion, string telefono)
        {
            this.IdCliente = idCliente;
            this.RazonSocial = razonSocial;
            this.Cedula = cedula;
            this.Ciudad = ciudad;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
