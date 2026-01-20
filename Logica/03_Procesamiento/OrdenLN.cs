using Datos._01_Administracion;
using Datos._02_Produccion;
using Datos._03_Procesamiento;
using Entidades._01_Administracion;
using Entidades._03_Procesamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica._03_Procesamiento
{
    public class OrdenLN
    {
        public List<OrdenPersonalizado> ShowOrdenFaenado()
        {
            try
            {
                return OrdenCD.ListarOrdenFaenado();
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar OrdenFaena sin filtro con procedimiento almacenado", ex);
            }

        }
        public bool InsertOrden(Orden_FaenadoE oe)
        {
            try
            {
                OrdenCD.InsertarOrden(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert Orden en la BD", ex);
            }
        }
        public Orden_FaenadoE obtenerObjeto(OrdenPersonalizado obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("No se ha seleccionado ninguna OrdenFaena de la lista.");
            }

            return OrdenCD.GetOrden(obj.IdOrden);

        }
        public void actualizarStockFaena(int idLote, int avesProcesadas)
        {
            if (idLote == 0)
            {
                throw new ArgumentException("No se ha seleccionado ningun lote");
            }

            LoteCD.actualizarStockFaena(idLote, avesProcesadas);

        }

        public bool DeleteOrden(Orden_FaenadoE oe)
        {
            try
            {
                OrdenCD.EliminarOrden(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al delete Orden en la BD", ex);
            }
        }
    }
}
