using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._03_Procesamiento
{
    public class Orden_FaenadoE
    {
        private int idOrden;
        private int idLote;
        private int idEmpleado;
        private DateTime fechaFaena;
        private int avesProcesadas;
        private decimal pesoVivoTotal;

        public Orden_FaenadoE() { }

        public Orden_FaenadoE(int idOrden, int idLote, int idEmpleado, DateTime fechaFaena, int avesProcesadas, decimal pesoVivoTotal)
        {
            this.IdOrden = idOrden;
            this.IdLote = idLote;
            this.IdEmpleado = idEmpleado;
            this.FechaFaena = fechaFaena;
            this.AvesProcesadas = avesProcesadas;
            this.PesoVivoTotal = pesoVivoTotal;
        }

        public int IdOrden { get => idOrden; set => idOrden = value; }
        public int IdLote { get => idLote; set => idLote = value; }
        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public DateTime FechaFaena { get => fechaFaena; set => fechaFaena = value; }
        public int AvesProcesadas { get => avesProcesadas; set => avesProcesadas = value; }
        public decimal PesoVivoTotal { get => pesoVivoTotal; set => pesoVivoTotal = value; }
    }
}
