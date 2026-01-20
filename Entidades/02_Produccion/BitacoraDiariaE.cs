using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._02_Produccion
{
    public class BitacoraDiariaE
    {
        private int idBitacora;
        private int idEmpleado;
        private int idLote;
        private DateTime fecha;
        private int mortalidad;
        private decimal alimentoConsumido;
        private decimal pesoPromedio;
        private string observaciones;

        public BitacoraDiariaE() { }

        public BitacoraDiariaE(int idBitacora, int idEmpleado, int idLote, DateTime fecha, int mortalidad, decimal alimentoConsumido, decimal pesoPromedio, string observaciones)
        {
            this.IdBitacora = idBitacora;
            this.IdEmpleado = idEmpleado;
            this.IdLote = idLote;
            this.Fecha = fecha;
            this.Mortalidad = mortalidad;
            this.AlimentoConsumido = alimentoConsumido;
            this.PesoPromedio = pesoPromedio;
            this.Observaciones = observaciones;
        }

        public int IdBitacora { get => idBitacora; set => idBitacora = value; }
        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public int IdLote { get => idLote; set => idLote = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Mortalidad { get => mortalidad; set => mortalidad = value; }
        public decimal AlimentoConsumido { get => alimentoConsumido; set => alimentoConsumido = value; }
        public decimal PesoPromedio { get => pesoPromedio; set => pesoPromedio = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
    }
}
