using Entidades._01_Administracion;
using Entidades._04_Comercializacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos._04_Comercializacion
{
    public class VentaCD
    {
        public static List<VentaPersonalizada> ListarVentas()
        {
            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    var origen = DB.CP_ListarVistaVenta().ToList();
                    List<VentaPersonalizada> fin = new List<VentaPersonalizada>();
                    foreach (var e in origen)
                    {
                        VentaPersonalizada oe = new VentaPersonalizada();
                        oe.IdVenta = e.IdVenta;
                        oe.Cliente = e.Cliente;
                        oe.Camion = e.Camion;
                        oe.Empleado = e.Vendedor;
                        oe.NroFac = e.NumeroFactura;
                        oe.Fecha = e.Fecha;
                        oe.TotalVenta = e.TotalVenta;
                        oe.Estado = e.Estado;

                        fin.Add(oe);
                    }

                    return fin;

                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Venta", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void InsertarVenta(VentaE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_InsertarVenta(oe.IdVenta, oe.IdCliente, oe.IdCamion, oe.IdEmpleado, oe.NroFac, oe.Fecha, oe.TotalVenta, oe.Estado);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Ventas", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static VentaE GetVenta(int idVenta)
        {
            using (DataDControlDataContext DB = new DataDControlDataContext())
            {
                Venta VentaDB = DB.Venta.SingleOrDefault(e => e.IdVenta == idVenta);

                if (VentaDB == null)
                {
                    throw new Exception("Venta no encontrado para la edición.");
                }

                VentaE VentaApp = new VentaE
                {
                    IdVenta = VentaDB.IdVenta,
                    IdCliente = (int) VentaDB.IdCliente,
                    IdCamion = (int) VentaDB.IdCamion,
                    IdEmpleado = (int) VentaDB.IdEmpleado,
                    NroFac = VentaDB.NumeroFactura,
                    Fecha = VentaDB.Fecha,
                    TotalVenta = VentaDB.TotalVenta,
                    Estado = VentaDB.Estado
                };

                return VentaApp;
            }
        }
        public static void EliminarVenta(VentaE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_EliminarVenta(oe.IdVenta);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla Venta", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
