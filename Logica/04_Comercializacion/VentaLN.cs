using Datos._04_Comercializacion;
using Entidades._04_Comercializacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica._04_Comercializacion
{
    public class VentaLN
    {
        public List<VentaPersonalizada> ShowVentas()
        {
            try
            {
                return VentaCD.ListarVentas();
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Ventas sin filtro con procedimiento almacenado", ex);
            }

        }
        public bool InsertVenta(VentaE oe)
        {
            try
            {
                VentaCD.InsertarVenta(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert Venta en la BD", ex);
            }
        }
        public VentaE obtenerObjeto(VentaPersonalizada obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("No se ha seleccionado ninguna Venta de la lista.");
            }

            return VentaCD.GetVenta(obj.IdVenta);

        }
        public bool DeleteEmpleado(VentaE oe)
        {
            try
            {
                VentaCD.EliminarVenta(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al delete Venta en la BD", ex);
            }
        }
    }
}
