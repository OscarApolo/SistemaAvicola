using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._01_Administracion
{
    public class CamionE
    {
        private int idCamion;
        private int idEmpleado;
        private string placa;
        private string marca;
        private decimal capacidadKG;

        public CamionE()
        {

        }

        public CamionE(int idCamion, int idEmpleado, string placa, string marca, decimal capacidadKG)
        {
            this.IdCamion = idCamion;
            this.IdEmpleado = idEmpleado;
            this.Placa = placa;
            this.Marca = marca;
            this.CapacidadKG = capacidadKG;
        }

        public int IdCamion { get => idCamion; set => idCamion = value; }
        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public decimal CapacidadKG { get => capacidadKG; set => capacidadKG = value; }
    }
}
