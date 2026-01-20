using Datos._02_Produccion;
using Entidades._02_Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica._02_Produccion
{
    public class GalponLN
    {
        public List<GalponE> ShowGalpon()
        {
            try
            {
                return GalponCD.ListarGalpon();
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Galpon sin filtro con procedimiento almacenado", ex);
            }

        }
        public List<GalponE> ShowGalponesDisponibles(int idGalpon)
        {
            try
            {
                return GalponCD.ListarGalponesDisponibles(idGalpon);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Galpones disponibles sin filtro con procedimiento almacenado", ex);
            }

        }

        public bool InsertGalpon(GalponE oe)
        {
            try
            {
                GalponCD.InsertarGalpon(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert Galpon en la BD", ex);
            }
        }
        public bool UpdateGalpon(GalponE oe)
        {
            try
            {
                GalponCD.ModificarGalpon(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al update Galpon en la BD", ex);
            }
        }

        public GalponE obtenerObjeto(int idGalpon)
        {
            if (idGalpon <= -1)
            {
                throw new ArgumentException("No se ha seleccionado ningún Galpon de la lista.");
            }

            return GalponCD.obtenerGalponporId(idGalpon);

        }


        public void actualizarGalpon(int idGalpon, string nuevoEstado)
        {
            if (idGalpon <=-1 && nuevoEstado == null)
            {
                throw new ArgumentException("No se ha seleccionado ningún Galpon de la lista.");
            }

            GalponCD.actualizarEstado(idGalpon, nuevoEstado);

        }


        public bool DeleteGalpon(GalponE oe)
        {
            try
            {
                GalponCD.EliminarGalpon(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al delete Galpon en la BD", ex);
            }
        }
    }
}
