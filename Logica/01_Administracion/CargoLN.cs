using Datos;
using Datos._01_Administracion;
using Entidades._01_Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica._01_Administracion
{
    public class CargoLN
    {
        public List<CargoE> ShowCargo()
        {
            try
            {
                return CargoCD.ListarCargo();
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Cargo sin filtro con procedimiento almacenado", ex);
            }
          
        }

        public bool InsertCargo(CargoE oe)
        {
            try
            {
                CargoCD.InsertarCargo(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert Cargo en la BD", ex);
            }
        }
        public bool UpdateCargo(CargoE oe)
        {
            try
            {
                CargoCD.ModificarCargo(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al update Cargo en la BD", ex);
            }
        }
        public bool DeleteCargo(CargoE oe)
        {
            try
            {
                CargoCD.EliminarCargo(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al delete Cargo en la BD", ex);
            }
        }
    }
}
