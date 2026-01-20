using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._02_Produccion
{
    public class GalponE
    {
        private int idGalpon;
        private string nombre;
        private int capMaxima;
        private string ubicacion;
        private string estado;

        public GalponE()
        {

        }

        public GalponE(int idGalpon, string nombre, int capMaxima, string ubicacion, string estado)
        {
            this.IdGalpon = idGalpon;
            this.Nombre = nombre;
            this.CapMaxima = capMaxima;
            this.Ubicacion = ubicacion;
            this.Estado = estado;
        }

        public int IdGalpon { get => idGalpon; set => idGalpon = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int CapMaxima { get => capMaxima; set => capMaxima = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
