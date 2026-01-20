using Entidades._01_Administracion;
using Entidades._02_Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos._02_Produccion
{
    public class GalponCD
    {
        public static List<GalponE> ListarGalpon()
        {
            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    var origen = DB.Galpon.ToList();
                    List<GalponE> fin = new List<GalponE>();
                    foreach (var e in origen)
                    {
                        GalponE oe = new GalponE(e.IdGalpon, e.Nombre, e.CapacidadMaxima, e.Ubicacion, e.Estado);
                        fin.Add(oe);
                    }

                    return fin;

                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Galpon", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static List<GalponE> ListarGalponesDisponibles(int idGalpon)
        {
            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    var origen = DB.Galpon.Where(x => x.Estado == "Disponible" || x.IdGalpon == idGalpon).ToList();
                    List<GalponE> fin = new List<GalponE>();
                    foreach (var e in origen)
                    {
                        GalponE oe = new GalponE(e.IdGalpon, e.Nombre, e.CapacidadMaxima, e.Ubicacion, e.Estado);
                        fin.Add(oe);
                    }

                    return fin;

                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Galpones disponibles", ex);
            }
            finally
            {
                DB = null;
            }
        }


        public static void InsertarGalpon(GalponE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_InsertarGalpon(oe.IdGalpon, oe.Nombre, oe.CapMaxima, oe.Ubicacion, oe.Estado);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Galpon", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarGalpon(GalponE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_ModificarGalpon(oe.IdGalpon, oe.Nombre, oe.CapMaxima, oe.Ubicacion, oe.Estado);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla Galpon", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static GalponE obtenerGalponporId(int idGalpon)
        {
            using (var db = new DataDControlDataContext()) 
            {
                var galpon = db.Galpon.FirstOrDefault(x => x.IdGalpon == idGalpon);

                if (galpon != null)
                {
                    GalponE galponE = new GalponE();
                    galponE.IdGalpon = galpon.IdGalpon;
                    galponE.Nombre = galpon.Nombre;
                    galponE.CapMaxima = galpon.CapacidadMaxima;
                    galponE.Ubicacion = galpon.Ubicacion;
                    galponE.Estado = galpon.Estado;
               
                    return galponE;
                }

                return null;
            }
        }

        public static void actualizarEstado(int idGalpon, string nuevoEstado)
        {
            using (var db = new DataDControlDataContext())
            {
                try
                {
                    var galpon = db.Galpon.FirstOrDefault(g => g.IdGalpon == idGalpon);

                    if (galpon != null)
                    {
                        galpon.Estado = nuevoEstado;

                        db.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new DatosExcepciones("Error al actualizar el estado del galpón con LINQ", ex);
                }
            }
        }


        public static void EliminarGalpon(GalponE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_EliminarGalpon(oe.IdGalpon);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla Galpon", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
