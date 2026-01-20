using Datos._02_Produccion;
using Datos._03_Procesamiento;
using Datos._04_Comercializacion;
using Entidades._04_Comercializacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica._04_Comercializacion
{
    public class DetalleLN
    {
        public List<DetallePersonalizado> ShowDetalleVenta()
        {
            try
            {
                return DetalleCD.ListarDetalleVenta();
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar DetalleVenta sin filtro con procedimiento almacenado", ex);
            }

        }
        public bool InsertDetalle(DetalleVentaE oe)
        {
            try
            {
                DetalleCD.InsertarDetalle(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert DetalleVenta en la BD", ex);
            }
        }
        public DetalleVentaE obtenerObjeto(DetallePersonalizado obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("No se ha seleccionado ninguna DetalleVenta de la lista.");
            }

            return DetalleCD.GetDetalle(obj.IdDetalle);

        }
        public void actualizarStock(int idProducto, int cantVendida)
        {
            if (idProducto == 0)
            {
                throw new ArgumentException("No se ha seleccionado ningun LoteFaenado");
            }

            LoteFaenadoCD.actualizarStock(idProducto, cantVendida);

        }
        public bool DeleteDetalle(DetalleVentaE oe)
        {
            try
            {
                DetalleCD.EliminarDetalle(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al delete DetalleVenta en la BD", ex);
            }
        }
    }
}
