using Entidades._02_Produccion;
using Datos._02_Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica._02_Produccion
{
    
    public class BitacoraLN
    {
        public List<BitacoraDiariaPer> ShowBitacora()
        {
            try
            {
                return BitacoraDiariaCD.ListarBitacoras();
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Bitacora sin filtro con procedimiento almacenado", ex);
            }

        }

 
        public bool InsertBitacora(BitacoraDiariaE oe)
        {
            try
            {
                BitacoraDiariaCD.InsertarBitacora(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert Bitacora en la BD", ex);
            }
        }
   
        public BitacoraDiariaE obtenerObjeto(BitacoraDiariaPer obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("No se ha seleccionado ninguna Bitacora de la lista.");
            }

            return BitacoraDiariaCD.GetBitacora(obj.IdBitacora);

        }

        public void actualizarStock(int idLote, int mortalidad)
        {
            if (idLote == 0)
            {
                throw new ArgumentException("No se ha seleccionado ningun lote");
            }

            LoteCD.actualizarStock(idLote, mortalidad);
            
        }
        public bool DeleteBitacora(BitacoraDiariaE oe)
        {
            try
            {
                BitacoraDiariaCD.EliminarBitacora(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al delete Bitacora en la BD", ex);
            }
        }
    }
}
