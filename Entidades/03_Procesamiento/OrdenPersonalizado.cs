using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._03_Procesamiento
{
    public class OrdenPersonalizado
    {
        private int idOrden;
        private string lote;
        private string empleado;
        private DateTime fechaFaena;
        private int avesProcesadas;
        private decimal pesoVivoTotal;

        public OrdenPersonalizado()
        {

        }

        public OrdenPersonalizado(int idOrden, string lote, string empleado, DateTime fechaFaena, int avesProcesadas, decimal pesoVivoTotal)
        {
            this.IdOrden = idOrden;
            this.Lote = lote;
            this.Empleado = empleado;
            this.FechaFaena = fechaFaena;
            this.AvesProcesadas = avesProcesadas;
            this.PesoVivoTotal = pesoVivoTotal;
        }

        public int IdOrden { get => idOrden; set => idOrden = value; }
        public string Lote { get => lote; set => lote = value; }
        public string Empleado { get => empleado; set => empleado = value; }
        public DateTime FechaFaena { get => fechaFaena; set => fechaFaena = value; }
        public int AvesProcesadas { get => avesProcesadas; set => avesProcesadas = value; }
        public decimal PesoVivoTotal { get => pesoVivoTotal; set => pesoVivoTotal = value; }
    }
}
