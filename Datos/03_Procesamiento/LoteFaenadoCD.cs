using Entidades._01_Administracion;
using Entidades._02_Produccion;
using Entidades._03_Procesamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos._03_Procesamiento
{
    public class LoteFaenadoCD
    {
        public static List<Lote_FaenadoE> ListarLotesFaenados()
        {
            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    var origen = DB.Lote_Faenado.ToList();
                    List<Lote_FaenadoE> fin = new List<Lote_FaenadoE>();
                    foreach (var e in origen)
                    {
                        Lote_FaenadoE oe = new Lote_FaenadoE(e.IdProducto, (int)e.IdOrden, e.Cantidad, e.PesoTotal, e.FechaVencimiento, e.StockActual);
                        fin.Add(oe);
                    }

                    return fin;

                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Lote_Faenado", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarLote_Faenado(Lote_FaenadoE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_InsertarLoteFaenado(oe.IdProducto, oe.IdOrden, oe.Cantidad, oe.PesoTotal, oe.FechaVencimiento, oe.StockActual);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla LoteFaenado", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static Lote_FaenadoE obtenerLoteFaenadoporId(int lote)
        {
            using (var db = new DataDControlDataContext())
            {
                var orden = db.Lote_Faenado.FirstOrDefault(x => x.IdProducto == lote);

                if (orden != null)
                {
                    Lote_FaenadoE LoteE = new Lote_FaenadoE();
                    LoteE.IdProducto = orden.IdProducto;
                    LoteE.IdOrden = (int) orden.IdOrden;
                    LoteE.Cantidad = orden.Cantidad;
                    LoteE.PesoTotal = orden.PesoTotal;
                    LoteE.FechaVencimiento = orden.FechaVencimiento;
                    LoteE.StockActual = orden.StockActual;

                    return LoteE;
                }

                return null;
            }
        }
        public static void actualizarStock(int idProducto, int cantVender)
        {
            using (DataDControlDataContext DB = new DataDControlDataContext())
            {
                var loteFaeanado = DB.Lote_Faenado.SingleOrDefault(x => x.IdProducto == idProducto);

                if (loteFaeanado != null)
                {
                    if (loteFaeanado.StockActual >= cantVender)
                    {
                        loteFaeanado.StockActual -= cantVender;
                        DB.SubmitChanges();
                    }
                    else
                    {
                        throw new Exception("Stock insuficiente");
                    }
                }
                else
                {
                    throw new Exception("LoteFaenado no encontrado");
                }
            }
        }

        public static void EliminarLote_Faenado(Lote_FaenadoE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_EliminarLoteFaenado(oe.IdProducto);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla Lote_Faenado", ex);
            }
            finally
            {
                DB = null;
            }
        }

       

        
    }
}
