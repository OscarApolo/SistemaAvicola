using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._02_Produccion
{
    public class LoteE
    {
        private int idLote;
        private int idGalpon;
        private int idRaza;
        private string codigo;
        private DateTime fechaIngreso;
        private int cantInicial;
        private decimal cosInicial;
        private string estado;
        private int stockActual;

        public LoteE()
        {

        }

        public LoteE(int idLote, int idGalpon, int idRaza, string codigo, DateTime fechaIngreso, int cantInicial, decimal cosInicial, string estado, int stockActual)
        {
            this.IdLote = idLote;
            this.IdGalpon = idGalpon;
            this.IdRaza = idRaza;
            this.Codigo = codigo;
            this.FechaIngreso = fechaIngreso;
            this.CantInicial = cantInicial;
            this.CosInicial = cosInicial;
            this.Estado = estado;
            this.StockActual = stockActual;
        }

        public int IdLote { get => idLote; set => idLote = value; }
        public int IdGalpon { get => idGalpon; set => idGalpon = value; }
        public int IdRaza { get => idRaza; set => idRaza = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public int CantInicial { get => cantInicial; set => cantInicial = value; }
        public decimal CosInicial { get => cosInicial; set => cosInicial = value; }
        public string Estado { get => estado; set => estado = value; }
        public int StockActual { get => stockActual; set => stockActual = value; }
    }
}
