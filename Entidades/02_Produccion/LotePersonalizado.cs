using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._02_Produccion
{
    public class LotePersonalizado
    {
        private int idLote;
        private string galpon;
        private string raza;
        private string codigo;
        private DateTime fechaIngreso;
        private int cantInicial;
        private decimal cosInicial;
        private string estado;
        private int stockActual;

        public LotePersonalizado()
        {

        }

        public LotePersonalizado(int idLote, string galpon, string raza, string codigo, DateTime fechaIngreso, int cantInicial, decimal cosInicial, string estado, int stockActual)
        {
            this.IdLote = idLote;
            this.Galpon = galpon;
            this.Raza = raza;
            this.Codigo = codigo;
            this.FechaIngreso = fechaIngreso;
            this.CantInicial = cantInicial;
            this.CosInicial = cosInicial;
            this.Estado = estado;
            this.StockActual = stockActual;
        }

        public int IdLote { get => idLote; set => idLote = value; }
        public string Galpon { get => galpon; set => galpon = value; }
        public string Raza { get => raza; set => raza = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public int CantInicial { get => cantInicial; set => cantInicial = value; }
        public decimal CosInicial { get => cosInicial; set => cosInicial = value; }
        public string Estado { get => estado; set => estado = value; }
        public int StockActual { get => stockActual; set => stockActual = value; }
    }
}
