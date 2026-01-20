using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._01_Administracion
{
    public class CargoE
    {
        private int idCargo;
        private string nombre;
        private string descripcion;

        public CargoE()
        {

        }

        public CargoE(int idCargo, string nombre, string descripcion)
        {
            this.IdCargo = idCargo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public int IdCargo { get => idCargo; set => idCargo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
