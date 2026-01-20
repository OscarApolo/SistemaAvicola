using Entidades._04_Comercializacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos._04_Comercializacion
{
    public class ClienteCD
    {
        public static List<ClienteE> ListarClientes()
        {
            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    var origen = DB.Cliente.ToList();
                    List<ClienteE> fin = new List<ClienteE>();
                    foreach (var e in origen)
                    {
                        ClienteE oe = new ClienteE(e.IdCliente, e.RazonSocial, e.Cedula, e.Ciudad, e.Direccion, e.Telefono);
                        fin.Add(oe);
                    }

                    return fin;

                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Clientes", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarCliente(ClienteE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_InsertarCliente(oe.IdCliente, oe.RazonSocial, oe.Cedula, oe.Cedula, oe.Direccion, oe.Telefono);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Clientes", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarCliente(ClienteE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_ModificarCliente(oe.IdCliente, oe.RazonSocial, oe.Cedula, oe.Cedula, oe.Direccion, oe.Telefono);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla Cliente", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarCliente(ClienteE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_EliminarCliente(oe.IdCliente);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla Cliente", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
