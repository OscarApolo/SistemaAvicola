using Datos._01_Administracion;
using Entidades._01_Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica._01_Administracion
{
    public class EmpleadoLN
    {
        public List<EmpleadoPersonalizado> ShowEmpleado()
        {
            try
            {
                return EmpleadoCD.ListarEmpleado();
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Empleado sin filtro con procedimiento almacenado", ex);
            }

        }

        public List<EmpleadoPersonalizado> ShowEmpleadoPorTipo(string tipo)
        {
            try
            {
                return EmpleadoCD.ListarPorTipo(tipo);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Empleado por tipo sin filtro con procedimiento almacenado", ex);
            }

        }

        public bool InsertEmpleado(EmpleadoE oe)
        {
            try
            {
                EmpleadoCD.InsertarEmpleado(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert Empleado en la BD", ex);
            }
        }
        public bool UpdateEmpleado(EmpleadoE oe)
        {
            try
            {
                EmpleadoCD.ModificarEmpleado(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al update Empleado en la BD", ex);
            }
        }

        public EmpleadoE obtenerObjeto(EmpleadoPersonalizado obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("No se ha seleccionado ningún Empleado de la lista.");
            }

            return EmpleadoCD.GetEmpleado(obj.Codigo);

        }
        public bool DeleteEmpleado(EmpleadoE oe)
        {
            try
            {
                EmpleadoCD.EliminarEmpleado(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al delete Empleado en la BD", ex);
            }
        }
    }
}
