using Datos._02_Produccion;
using Entidades._02_Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica._02_Produccion
{
    public class LoteLN
    {
        public List<LotePersonalizado> ShowLote()
        {
            try
            {
                return LoteCD.ListarLote();
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Lote sin filtro con procedimiento almacenado", ex);
            }

        }

        public bool InsertLote(LoteE oe)
        {

            GalponE galpon = GalponCD.obtenerGalponporId(oe.IdGalpon);
            if (galpon == null)
            {
                throw new LogicaExcepciones("El galpon seleccionado no existe");
            }

            if (oe.CantInicial > galpon.CapMaxima)
            {
                throw new LogicaExcepciones("Exceso de capacidad: El galpon seleccionado solo soporta " + galpon.CapMaxima + " pollos");
            }

            try
            {

                LoteCD.InsertarLote(oe);
                return true;

            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert Lote en la BD", ex);
            }
        }
            
        

        public bool UpdateLote(LoteE oe)
        {
            GalponE galpon = GalponCD.obtenerGalponporId(oe.IdGalpon);
            if (galpon == null)
            {
                throw new LogicaExcepciones("El galpon seleccionado no existe");
            }

            if (oe.CantInicial > galpon.CapMaxima)
            {
                throw new LogicaExcepciones("Exceso de capacidad: El galpon seleccionado solo soporta " + galpon.CapMaxima + " pollos");
            }


            try
            {
                LoteCD.ModificarLote(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al update Lote en la BD", ex);
            }
        }

        public LoteE obtenerObjeto(LotePersonalizado obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("No se ha seleccionado ningún Lote de la lista.");
            }

            return LoteCD.GetLote(obj.IdLote);

        }

        public LoteE obtenerporId(int idlOTE)
        {
            if (idlOTE <= 0)
            {
                throw new ArgumentException("No se ha seleccionado ningún lote de la lista.");
            }

            return LoteCD.obtenerLoteporId(idlOTE);

        }

        public bool DeleteLote(LoteE oe)
        {
            try
            {
                LoteCD.EliminarLote(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al delete Lote en la BD", ex);
            }
        }
    }
}
