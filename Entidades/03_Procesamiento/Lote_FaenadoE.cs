using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._03_Procesamiento
{
    public class Lote_FaenadoE
    {
        private int idProducto;
        private int idOrden;
        private int cantidad;
        private decimal pesoTotal;
        private DateTime fechaVencimiento;
        private int stockActual;

        public Lote_FaenadoE()
        {

        }

        public Lote_FaenadoE(int idProducto, int idOrden, int cantidad, decimal pesoTotal, DateTime fechaVencimiento, int stockActual)
        {
            this.IdProducto = idProducto;
            this.IdOrden = idOrden;
            this.Cantidad = cantidad;
            this.PesoTotal = pesoTotal;
            this.FechaVencimiento = fechaVencimiento;
            this.StockActual = stockActual;
        }

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int IdOrden { get => idOrden; set => idOrden = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal PesoTotal { get => pesoTotal; set => pesoTotal = value; }
        public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        public int StockActual { get => stockActual; set => stockActual = value; }
    }
}
