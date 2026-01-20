using Entidades._01_Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos._01_Administracion
{
    public class EmpleadoCD
    {
        public static List<EmpleadoPersonalizado> ListarEmpleado()
        {
            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    var origen = DB.CP_ListarVistaEmpleado().ToList();
                    List<EmpleadoPersonalizado> fin = new List<EmpleadoPersonalizado>();
                    foreach (var e in origen)
                    {
                        EmpleadoPersonalizado oe = new EmpleadoPersonalizado();
                        oe.Codigo = e.IdEmpleado;
                        oe.Cargo = e.NombreCargo;
                        oe.Cedula = e.Cedula;
                        oe.Nombre = e.Nombre;
                        oe.Apellido = e.Apellido;
                        oe.Ciudad = e.Ciudad;
                        oe.Direccion = e.Direccion;
                        oe.Telefono = e.Telefono;
                        oe.Correo = e.Correo;

                        fin.Add(oe);
                    }

                    return fin;

                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Empleado", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<EmpleadoPersonalizado> ListarPorTipo(string tipo)
        {
            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    var origen = DB.CP_ListarVistaEmpleado().Where(x => x.NombreCargo == tipo).ToList();
                    List<EmpleadoPersonalizado> fin = new List<EmpleadoPersonalizado>();
                    foreach (var e in origen)
                    {
                       
                            EmpleadoPersonalizado oe = new EmpleadoPersonalizado();
                            oe.Codigo = e.IdEmpleado;
                            oe.Cargo = e.NombreCargo;
                            oe.Cedula = e.Cedula;
                            oe.Nombre = e.Nombre;
                            oe.Apellido = e.Apellido;
                            oe.Ciudad = e.Ciudad;
                            oe.Direccion = e.Direccion;
                            oe.Telefono = e.Telefono;
                            oe.Correo = e.Correo;

                            fin.Add(oe);
                        
                    }

                    return fin;

                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Empleado por tipo", ex);
            }
            finally
            {
                DB = null;
            }
        }
       
        public static void InsertarEmpleado(EmpleadoE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_InsertarEmpleado(oe.Codigo, oe.IdCargo, oe.Cedula, oe.Nombre, oe.Apellido, oe.Ciudad, oe.Direccion, oe.Telefono, oe.Correo);
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

        public static void ModificarEmpleado(EmpleadoE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_ModificarEmpleado(oe.Codigo, oe.IdCargo, oe.Cedula, oe.Nombre, oe.Apellido, oe.Ciudad, oe.Direccion, oe.Telefono, oe.Correo);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla Empleado", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static EmpleadoE GetEmpleado(int idEmpleado)
        {
            using (DataDControlDataContext DB = new DataDControlDataContext())
            {
                Empleado EmpleadoDB = DB.Empleado.SingleOrDefault(e => e.IdEmpleado == idEmpleado);

                if (EmpleadoDB == null)
                {
                    throw new Exception("Empleado no encontrado para la edición.");
                }

                EmpleadoE EmpleadoApp = new EmpleadoE
                {
                    Codigo = EmpleadoDB.IdEmpleado,
                    IdCargo = (int) EmpleadoDB.IdCargo,
                    Cedula = EmpleadoDB.Cedula,
                    Nombre = EmpleadoDB.Nombre,
                    Apellido = EmpleadoDB.Apellido,
                    Ciudad = EmpleadoDB.Ciudad,
                    Direccion = EmpleadoDB.Direccion,
                    Telefono = EmpleadoDB.Telefono,
                    Correo = EmpleadoDB.Correo
                };

                return EmpleadoApp;
            }
        }

        public static void EliminarEmpleado(EmpleadoE oe)
        {

            DataDControlDataContext DB = null;
            try
            {

                using (DB = new DataDControlDataContext())
                {
                    DB.CP_EliminarEmpleado(oe.Codigo);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla Empleado", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
