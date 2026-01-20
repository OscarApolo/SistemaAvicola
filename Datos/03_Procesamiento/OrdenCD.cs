using Entidades._02_Produccion;
using Entidades._03_Procesamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos._03_Procesamiento
{
    public class OrdenCD
    {
        public static List<OrdenPersonalizado> ListarOrdenFaenado()
        {
            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    var origen = DB.CP_ListarVistaOrden().ToList();
                    List<OrdenPersonalizado> fin = new List<OrdenPersonalizado>();
                    foreach (var e in origen)
                    {
                        OrdenPersonalizado oe = new OrdenPersonalizado();
                        oe.IdOrden = e.IdOrden;
                        oe.Lote = e.Lote;
                        oe.Empleado = e.Empleado;
                        oe.FechaFaena = e.FechaFaena;
                        oe.AvesProcesadas = e.AvesProcesadas;
                        oe.PesoVivoTotal = e.PesoVivoTotal;


                        fin.Add(oe);
                    }

                    return fin;

                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar OrdenFaena", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void InsertarOrden(Orden_FaenadoE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_InsertarOrdenFaenado(oe.IdOrden, oe.IdLote, oe.IdEmpleado, oe.FechaFaena, oe.AvesProcesadas, oe.PesoVivoTotal);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Orden Faena", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static Orden_FaenadoE GetOrden(int idOrden)
        {
            using (DataDControlDataContext DB = new DataDControlDataContext())
            {
                Orden_Faenado OrdenDB = DB.Orden_Faenado.SingleOrDefault(e => e.IdOrden == idOrden);

                if (OrdenDB == null)
                {
                    throw new Exception("Orden Faena no encontrada para la edición.");
                }

                Orden_FaenadoE OrdenApp = new Orden_FaenadoE()
                {
                    IdOrden = OrdenDB.IdOrden,
                    IdLote = (int) OrdenDB.IdLote,
                    IdEmpleado = (int) OrdenDB.IdEmpleado,
                    FechaFaena = OrdenDB.FechaFaena,
                    AvesProcesadas = OrdenDB.AvesProcesadas,
                    PesoVivoTotal = OrdenDB.PesoVivoTotal
                };

                return OrdenApp;
            }
        }
        public static Orden_FaenadoE obtenerOrdenFaenadoporId(int ordenFaena)
        {
            using (var db = new DataDControlDataContext())
            {
                var orden = db.Orden_Faenado.FirstOrDefault(x => x.IdOrden == ordenFaena);

                if (orden != null)
                {
                    Orden_FaenadoE OrdenE = new Orden_FaenadoE();
                    OrdenE.IdOrden = orden.IdOrden;
                    OrdenE.IdLote = (int) orden.IdLote;
                    OrdenE.IdEmpleado = (int) orden.IdEmpleado;
                    OrdenE.IdOrden = (int)orden.IdOrden;
                    OrdenE.FechaFaena = orden.FechaFaena;
                    OrdenE.AvesProcesadas = orden.AvesProcesadas;
                    orden.PesoVivoTotal = orden.PesoVivoTotal;

                    return OrdenE;
                }

                return null;
            }
        }

        public static void EliminarOrden(Orden_FaenadoE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_EliminarOrdenFaenado(oe.IdOrden);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla Orden_Faena", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
