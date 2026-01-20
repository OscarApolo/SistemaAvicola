using Datos._01_Administracion;
using Datos._02_Produccion;
using Datos._03_Procesamiento;
using Entidades._01_Administracion;
using Entidades._02_Produccion;
using Entidades._03_Procesamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica._03_Procesamiento
{
    public class LoteFaenadoLN
    {

        public List<Lote_FaenadoE> ShowLoteFaenado()
        {
            try
            {
                return LoteFaenadoCD.ListarLotesFaenados();
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Lote_Faenado sin filtro con procedimiento almacenado", ex);
            }

        }

        public bool InsertLoteFaenado(Lote_FaenadoE oe)
        {
            try
            {
                LoteFaenadoCD.InsertarLote_Faenado(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert LoteFaenado en la BD", ex);
            }
        }
        public Orden_FaenadoE obtenerporId(int idlOTE)
        {
            if (idlOTE <= 0)
            {
                throw new ArgumentException("No se ha seleccionado ningún lote de la lista.");
            }

            return OrdenCD.obtenerOrdenFaenadoporId(idlOTE);

        }
        public Lote_FaenadoE obtenerLoteFaenadoporId(int idlOTE)
        {
            if (idlOTE <= 0)
            {
                throw new ArgumentException("No se ha seleccionado ningún lote de la lista.");
            }

            return LoteFaenadoCD.obtenerLoteFaenadoporId(idlOTE);

        }

        public bool DeleteLoteFaenado(Lote_FaenadoE oe)
        {
            try
            {
                LoteFaenadoCD.EliminarLote_Faenado(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al delete LoteFaenado en la BD", ex);
            }
        }
    }
}
