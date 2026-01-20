using Entidades._04_Comercializacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos._04_Comercializacion
{
    public class DetalleCD
    {
        public static List<DetallePersonalizado> ListarDetalleVenta()
        {
            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    var origen = DB.CP_ListarVistaDetalle().ToList();
                    List<DetallePersonalizado> fin = new List<DetallePersonalizado>();
                    foreach (var e in origen)
                    {
                        DetallePersonalizado oe = new DetallePersonalizado();
                        oe.IdDetalle = e.IdDetalle;
                        oe.Factura = e.Factura;
                        oe.IdProducto = (int) e.IdProducto;
                        oe.CantVendida = e.CantidadVendida;
                        oe.PrecioUnitario = (decimal)e.PrecioUnitario;
                        oe.Subtotal = (decimal)e.Subtotal;
                        fin.Add(oe);
                    }

                    return fin;

                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Detalle", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void InsertarDetalle(DetalleVentaE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_InsertarDetalleVenta(oe.IdDetalle, oe.IdVenta, oe.IdProducto, oe.CantVendida, oe.PrecioUnitario, oe.Subtotal);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla DetalleVenta", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static DetalleVentaE GetDetalle(int idDetalle)
        {
            using (DataDControlDataContext DB = new DataDControlDataContext())
            {
                DetalleVenta DetalleDB = DB.DetalleVenta.SingleOrDefault(e => e.IdDetalle == idDetalle);

                if (DetalleDB == null)
                {
                    throw new Exception("Detalle no encontrado para la edición.");
                }

                DetalleVentaE DetalleApp = new DetalleVentaE
                {
                    IdDetalle = DetalleDB.IdDetalle,
                    IdVenta = (int)DetalleDB.IdVenta,
                    IdProducto = (int)DetalleDB.IdProducto,
                    CantVendida = DetalleDB.CantidadVendida,
                    PrecioUnitario = (decimal) DetalleDB.PrecioUnitario,
                    Subtotal = DetalleDB.Subtotal

                };

                return DetalleApp;
            }
        }
        public static void EliminarDetalle(DetalleVentaE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_EliminarDetalleVenta(oe.IdDetalle);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla DetalleVenta", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
