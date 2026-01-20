using Datos._04_Comercializacion;
using Entidades._04_Comercializacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica._04_Comercializacion
{
    public class ClienteLN
    {
        public List<ClienteE> ShowClientes()
        {
            try
            {
                return ClienteCD.ListarClientes();
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Cliente sin filtro con procedimiento almacenado", ex);
            }

        }

        public bool InsertCliente(ClienteE oe)
        {
            try
            {
                ClienteCD.InsertarCliente(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert Cliente en la BD", ex);
            }
        }
        public bool UpdateCliente(ClienteE oe)
        {
            try
            {
                ClienteCD.ModificarCliente(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al update Cliente en la BD", ex);
            }
        }
        public bool DeleteCliente(ClienteE oe)
        {
            try
            {
                ClienteCD.EliminarCliente(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al delete Cliente en la BD", ex);
            }
        }
    }
}
