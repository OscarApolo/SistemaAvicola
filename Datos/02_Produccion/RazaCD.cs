using Entidades._02_Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos._02_Produccion
{
    public class RazaCD
    {
        public static List<RazaAveE> ListarRazaAve()
        {
            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    var origen = DB.RazaAve.ToList();
                    List<RazaAveE> fin = new List<RazaAveE>();
                    foreach (var e in origen)
                    {
                        RazaAveE oe = new RazaAveE(e.IdRaza, e.Nombre, e.Origen, e.Descripcion);
                        fin.Add(oe);
                    }
                    
                    return fin;

                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar RazaAve", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarRazaAve(RazaAveE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_InsertarRazaAve(oe.IdRaza, oe.Nombre, oe.Origen, oe.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Raza Ave", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarRazaAve(RazaAveE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_ModificarRazaAve(oe.IdRaza, oe.Nombre, oe.Origen, oe.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla RazaAve", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarRazaAve(RazaAveE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_EliminarRazaAve(oe.IdRaza);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla RazaAve", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
