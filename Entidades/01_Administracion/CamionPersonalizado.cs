using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._01_Administracion
{
    public class CamionPersonalizado
    {
        private int idCamion;
        private string chofer;
        private string placa;
        private string marca;
        private decimal capacidadKG;

        public CamionPersonalizado() { }

        public CamionPersonalizado(int idCamion, string chofer, string placa, string marca, decimal capacidadKG)
        {
            this.IdCamion = idCamion;
            this.Chofer = chofer;
            this.Placa = placa;
            this.Marca = marca;
            this.CapacidadKG = capacidadKG;
        }

        public int IdCamion { get => idCamion; set => idCamion = value; }
        public string Chofer { get => chofer; set => chofer = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public decimal CapacidadKG { get => capacidadKG; set => capacidadKG = value; }
    }
}
