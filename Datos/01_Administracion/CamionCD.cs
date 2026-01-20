using Entidades._01_Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos._01_Administracion
{
    public class CamionCD
    {
        public static List<CamionPersonalizado> ListarCamion()
        {
            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    var origen = DB.CP_ListarVistaCamion().ToList();
                    List<CamionPersonalizado> fin = new List<CamionPersonalizado>();
                    foreach (var e in origen)
                    {
                        CamionPersonalizado oe = new CamionPersonalizado();
                        oe.IdCamion = e.IdCamion;
                        oe.Chofer = e.Chofer;
                        oe.Placa = e.Placa;
                        oe.Marca = e.Marca;
                        oe.CapacidadKG = e.CapacidadKG;
                        fin.Add(oe);
                    }

                    return fin;

                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Camion", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarCamion(CamionE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_InsertarCamion(oe.IdCamion, oe.IdEmpleado, oe.Placa, oe.Marca, oe.CapacidadKG);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla camion", ex);
                
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarCamion(CamionE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_ModificarCamion(oe.IdCamion, oe.IdEmpleado, oe.Placa, oe.Marca, oe.CapacidadKG);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al update tabla camion", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static CamionE GetCamion(int idCamion)
        {
            using (DataDControlDataContext DB = new DataDControlDataContext())
            { 
                Camion CamionDB = DB.Camion.SingleOrDefault(e => e.IdCamion == idCamion);

                if (CamionDB == null)
                {
                    throw new Exception("Camion no encontrado para la edición.");
                }

                CamionE CamionApp = new CamionE
                {
                    IdCamion = CamionDB.IdCamion,
                    IdEmpleado = (int) CamionDB.IdEmpleado,
                    Placa = CamionDB.Placa,
                    Marca = CamionDB.Marca,
                    CapacidadKG = CamionDB.CapacidadKG
                };

                return CamionApp;
            }
        }

        public static void EliminarCamion(CamionE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_EliminarCamion(oe.IdCamion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla camion", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
