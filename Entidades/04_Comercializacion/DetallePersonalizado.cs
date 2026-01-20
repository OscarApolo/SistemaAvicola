using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades._04_Comercializacion
{
    public class DetallePersonalizado
    {
        private int idDetalle;
        private string factura;
        private int idProducto;
        private int cantVendida;
        private decimal precioUnitario;
        private decimal subtotal;

        public DetallePersonalizado()
        {

        }

        public DetallePersonalizado(int idDetalle, string factura, int idProducto, int cantVendida, decimal precioUnitario, decimal subtotal)
        {
            this.IdDetalle = idDetalle;
            this.Factura = factura;
            this.IdProducto = idProducto;
            this.CantVendida = cantVendida;
            this.PrecioUnitario = precioUnitario;
            this.Subtotal = subtotal;
        }

        public int IdDetalle { get => idDetalle; set => idDetalle = value; }
        public string Factura { get => factura; set => factura = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int CantVendida { get => cantVendida; set => cantVendida = value; }
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
    }
}
