using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._04_Comercializacion
{
    public class VentaE
    {
        private int idVenta;
        private int idCliente;
        private int idCamion;
        private int idEmpleado;
        private string nroFac;
        private DateTime fecha;
        private decimal totalVenta;
        private string estado;

        public VentaE()
        {

        }

        public VentaE(int idVenta, int idCliente, int idCamion, int idEmpleado, string nroFac, DateTime fecha, decimal totalVenta, string estado)
        {
            this.IdVenta = idVenta;
            this.IdCliente = idCliente;
            this.IdCamion = idCamion;
            this.IdEmpleado = idEmpleado;
            this.NroFac = nroFac;
            this.Fecha = fecha;
            this.TotalVenta = totalVenta;
            this.Estado = estado;
        }

        public int IdVenta { get => idVenta; set => idVenta = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdCamion { get => idCamion; set => idCamion = value; }
        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public string NroFac { get => nroFac; set => nroFac = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal TotalVenta { get => totalVenta; set => totalVenta = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
