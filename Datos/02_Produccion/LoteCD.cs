using Entidades._02_Produccion;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Datos._02_Produccion
{
    public class LoteCD
    {
        public static List<LotePersonalizado> ListarLote()
        {
            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    var origen = DB.CP_ListarVistaLote().ToList();
                    List<LotePersonalizado> fin = new List<LotePersonalizado>();
                    foreach (var e in origen)
                    {
                        LotePersonalizado oe = new LotePersonalizado();
                        oe.IdLote = e.IdLote;
                        oe.Galpon = e.Galpon;
                        oe.Raza = e.Raza;
                        oe.Codigo = e.Codigo;
                        oe.FechaIngreso = e.FechaIIngreso;
                        oe.CantInicial = e.CantidadInicial;
                        oe.CosInicial = e.CostoInicial;
                        oe.Estado = e.Estado;
                        oe.StockActual = e.StockActual;

                        fin.Add(oe);
                    }

                    return fin;

                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Lote", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarLote(LoteE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_InsertarLote(oe.IdLote, oe.IdGalpon, oe.IdRaza, oe.Codigo, oe.FechaIngreso, 
                        oe.CantInicial, oe.CosInicial, oe.Estado, oe.StockActual);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Lote", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarLote(LoteE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_ModificarLote(oe.IdLote, oe.IdGalpon, oe.IdRaza, oe.Codigo, oe.FechaIngreso,
                        oe.CantInicial, oe.CosInicial, oe.Estado, oe.StockActual);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla Lote", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static LoteE GetLote(int idLote)
        {
            using (DataDControlDataContext DB = new DataDControlDataContext())
            {
                Lote LoteDB = DB.Lote.SingleOrDefault(e => e.IdLote == idLote);

                if (LoteDB == null)
                {
                    throw new Exception("Lote no encontrado para la edición.");
                }

                LoteE LoteApp = new LoteE
                {
                    IdLote = LoteDB.IdLote,
                    IdGalpon = LoteDB.IdGalpon,
                    IdRaza = (int) LoteDB.IdRaza,
                    Codigo = LoteDB.Codigo,
                    FechaIngreso = LoteDB.FechaIIngreso,
                    CantInicial = LoteDB.CantidadInicial,
                    CosInicial = LoteDB.CostoInicial,
                    Estado = LoteDB.Estado,
                    StockActual = LoteDB.StockActual
                };

                return LoteApp;
            }
        }
        public static LoteE obtenerLoteporId(int idLote)
        {
            using (var db = new DataDControlDataContext())
            {
                var lote = db.Lote.FirstOrDefault(x => x.IdLote == idLote);

                if (lote != null)
                {
                    LoteE loteE = new LoteE();
                    loteE.IdLote = lote.IdLote;
                    loteE.IdGalpon = lote.IdGalpon;
                    loteE.IdRaza = (int) lote.IdRaza;
                    loteE.Codigo = lote.Codigo;
                    loteE.FechaIngreso = lote.FechaIIngreso;
                    loteE.CantInicial = lote.CantidadInicial;
                    loteE.CosInicial = lote.CostoInicial;
                    loteE.Estado = lote.Estado;
                    loteE.StockActual = lote.StockActual;

                    return loteE;
                }

                return null;
            }
        }

        public static void actualizarStock(int idLote, int mortalidad)
        {
            using (DataDControlDataContext DB = new DataDControlDataContext())
            {
                var lote = DB.Lote.SingleOrDefault(x => x.IdLote == idLote);

                if (lote != null)
                {
                    if (lote.StockActual >= mortalidad)
                    {
                        lote.StockActual -= mortalidad;
                        DB.SubmitChanges();
                    } else
                    {
                        throw new Exception("Stock insuficiente");
                    }
                } else
                {
                    throw new Exception("Lote no encontrado");
                }
            }
        }
        public static void actualizarStockFaena(int idLote, int avesProcesadas)
        {
            using (DataDControlDataContext DB = new DataDControlDataContext())
            {
                var lote = DB.Lote.SingleOrDefault(x => x.IdLote == idLote);

                if (lote != null)
                {
                    
                    if (lote.StockActual >= avesProcesadas)
                    {
                        lote.StockActual -= avesProcesadas;
                        if (lote.StockActual == 0)
                        {
                            lote.Estado = "Cerrado";
                        }
                        DB.SubmitChanges();
                    }
                    else
                    {
                        throw new Exception("Stock insuficiente");
                    }
                }
                else
                {
                    throw new Exception("Lote no encontrado");
                }
            }
        }
        


        public static void EliminarLote(LoteE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_EliminarLote(oe.IdLote);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla Lote", ex);
            }
            finally
            {
                DB = null;
            }
        }
    
    }
}
