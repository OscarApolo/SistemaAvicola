using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._02_Produccion
{
    public class BitacoraDiariaPer
    {
        private int idBitacora;
        private string empleado;
        private string lote;
        private DateTime fecha;
        private int mortalidad;
        private decimal alimentoConsumido;
        private decimal pesoPromedio;
        private string observaciones;

        public BitacoraDiariaPer()
        {

        }

        public BitacoraDiariaPer(int idBitacora, string empleado, string lote, DateTime fecha, int mortalidad, decimal alimentoConsumido, decimal pesoPromedio, string observaciones)
        {
            this.IdBitacora = idBitacora;
            this.Empleado = empleado;
            this.Lote = lote;
            this.Fecha = fecha;
            this.Mortalidad = mortalidad;
            this.AlimentoConsumido = alimentoConsumido;
            this.PesoPromedio = pesoPromedio;
            this.Observaciones = observaciones;
        }

        public int IdBitacora { get => idBitacora; set => idBitacora = value; }
        public string Empleado { get => empleado; set => empleado = value; }
        public string Lote { get => lote; set => lote = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Mortalidad { get => mortalidad; set => mortalidad = value; }
        public decimal AlimentoConsumido { get => alimentoConsumido; set => alimentoConsumido = value; }
        public decimal PesoPromedio { get => pesoPromedio; set => pesoPromedio = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
    }
}
