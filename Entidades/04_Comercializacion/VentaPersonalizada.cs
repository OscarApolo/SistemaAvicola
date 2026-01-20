using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._04_Comercializacion
{
    public class VentaPersonalizada
    {
        private int idVenta;
        private string cliente;
        private string camion;
        private string empleado;
        private string nroFac;
        private DateTime fecha;
        private decimal totalVenta;
        private string estado;

        public VentaPersonalizada() { }

        public VentaPersonalizada(int idVenta, string cliente, string camion, string empleado, string nroFac, DateTime fecha, decimal totalVenta, string estado)
        {
            this.IdVenta = idVenta;
            this.Cliente = cliente;
            this.Camion = camion;
            this.Empleado = empleado;
            this.NroFac = nroFac;
            this.Fecha = fecha;
            this.TotalVenta = totalVenta;
            this.Estado = estado;
        }

        public int IdVenta { get => idVenta; set => idVenta = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public string Camion { get => camion; set => camion = value; }
        public string Empleado { get => empleado; set => empleado = value; }
        public string NroFac { get => nroFac; set => nroFac = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal TotalVenta { get => totalVenta; set => totalVenta = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
