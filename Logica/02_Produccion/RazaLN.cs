using Datos._02_Produccion;
using Entidades._02_Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica._02_Produccion
{
    public class RazaLN
    {
        public List<RazaAveE> ShowRaza()
        {
            try
            {
                return RazaCD.ListarRazaAve();
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Raza sin filtro con procedimiento almacenado", ex);
            }

        }

        public bool InsertRaza(RazaAveE oe)
        {
            try
            {
                RazaCD.InsertarRazaAve(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert Raza en la BD", ex);
            }
        }
        public bool UpdateRaza(RazaAveE oe)
        {
            try
            {
                RazaCD.ModificarRazaAve(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al update Raza en la BD", ex);
            }
        }
        public bool DeleteRaza(RazaAveE oe)
        {
            try
            {
                RazaCD.EliminarRazaAve(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al delete Raza en la BD", ex);
            }
        }
    }
}
