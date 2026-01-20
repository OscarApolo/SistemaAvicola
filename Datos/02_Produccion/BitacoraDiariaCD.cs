using Entidades._02_Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos._02_Produccion
{
    public class BitacoraDiariaCD
    {
        public static List<BitacoraDiariaPer> ListarBitacoras()
        {
            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    var origen = DB.CP_ListarVistaBitacora().ToList();
                    List<BitacoraDiariaPer> fin = new List<BitacoraDiariaPer>();
                    foreach (var e in origen)
                    {
                        BitacoraDiariaPer oe = new BitacoraDiariaPer();
                        oe.IdBitacora = e.IdBitacora;
                        oe.Empleado = e.Empleado;
                        oe.Lote = e.Lote;
                        oe.Fecha = e.Fecha;
                        oe.Mortalidad = (int) e.Mortalidad;
                        oe.AlimentoConsumido = e.AlimentoConsumido;
                        oe.PesoPromedio = e.PesoPromedio;
                        oe.Observaciones = e.Observaciones;
                        
                        fin.Add(oe);
                    }

                    return fin;

                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Bitacora", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void InsertarBitacora(BitacoraDiariaE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_InsertarBitacora(oe.IdBitacora, oe.IdEmpleado, oe.IdLote, oe.Fecha, oe.Mortalidad, oe.AlimentoConsumido, oe.PesoPromedio, oe.Observaciones);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Empleado", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static BitacoraDiariaE GetBitacora(int idBitacora)
        {
            using (DataDControlDataContext DB = new DataDControlDataContext())
            {
                BitacoraDiaria BitacoraDB = DB.BitacoraDiaria.SingleOrDefault(e => e.IdBitacora == idBitacora);

                if (BitacoraDB == null)
                {
                    throw new Exception("Bitacora no encontrada para la edición.");
                }

                BitacoraDiariaE BitacoraApp = new BitacoraDiariaE
                {
                    IdBitacora = BitacoraDB.IdBitacora,
                    IdEmpleado = (int) BitacoraDB.IdEmpleado,
                    IdLote = BitacoraDB.IdLote,
                    Fecha = BitacoraDB.Fecha,
                    Mortalidad = (int )BitacoraDB.Mortalidad,
                    AlimentoConsumido = BitacoraDB.AlimentoConsumido,
                    PesoPromedio = BitacoraDB.PesoPromedio,
                    Observaciones = BitacoraDB.Observaciones
                };

                return BitacoraApp;
            }
        }

        public static void EliminarBitacora(BitacoraDiariaE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_EliminarBitacora(oe.IdBitacora);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla Bitacora", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
