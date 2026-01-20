using Entidades._01_Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos._01_Administracion
{
    public class CargoCD
    {
        public static List<CargoE> ListarCargo()
        {
            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    var origen = DB.Cargo.ToList();
                    List<CargoE> fin = new List<CargoE>();
                    foreach (var e in origen)
                    {
                        CargoE oe = new CargoE(e.IdCargo, e.NombreCargo, e.Descripcion);
                        fin.Add(oe);
                    }

                    return fin;

                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar cargo", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarCargo(CargoE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_InsertarCargo(oe.IdCargo, oe.Nombre, oe.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla cargo", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarCargo(CargoE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_ModificarCargo(oe.IdCargo, oe.Nombre, oe.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla cargo", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarCargo(CargoE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_EliminarCargo(oe.IdCargo);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla cargo", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
