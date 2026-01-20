using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._04_Comercializacion
{
    public class DetalleVentaE
    {
        private int idDetalle;
        private int idVenta;
        private int idProducto;
        private int cantVendida;
        private decimal precioUnitario;
        private decimal subtotal;

        public DetalleVentaE()
        {

        }

        public DetalleVentaE(int idDetalle, int idVenta, int idProducto, int cantVendida, decimal precioUnitario, decimal subtotal)
        {
            this.IdDetalle = idDetalle;
            this.IdVenta = idVenta;
            this.IdProducto = idProducto;
            this.CantVendida = cantVendida;
            this.PrecioUnitario = precioUnitario;
            this.Subtotal = subtotal;
        }

        public int IdDetalle { get => idDetalle; set => idDetalle = value; }
        public int IdVenta { get => idVenta; set => idVenta = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int CantVendida { get => cantVendida; set => cantVendida = value; }
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
    }
}
