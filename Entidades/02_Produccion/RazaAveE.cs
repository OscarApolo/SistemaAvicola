using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._02_Produccion
{
    public class RazaAveE
    {
        private int idRaza;
        private string nombre;
        private string origen;
        private string descripcion;

        public RazaAveE() { }

        public RazaAveE(int idRaza, string nombre, string origen, string descripcion)
        {
            this.IdRaza = idRaza;
            this.Nombre = nombre;
            this.Origen = origen;
            this.Descripcion = descripcion;
        }

        public int IdRaza { get => idRaza; set => idRaza = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Origen { get => origen; set => origen = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
