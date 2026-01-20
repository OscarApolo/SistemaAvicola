using Datos._01_Administracion;
using Entidades._01_Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica._01_Administracion
{
    public class CamionLN
    {
        public List<CamionPersonalizado> ShowCamion()
        {
            try
            {
                return CamionCD.ListarCamion();
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Camion sin filtro con procedimiento almacenado", ex);
            }

        }

        public bool InsertCamion(CamionE oe)
        {
            try
            {
                CamionCD.InsertarCamion(oe);
                return true;
              
            }
            catch (Exception ex)
            {
                
                throw new LogicaExcepciones("Error al insertar tabla Camion", ex);
            }
        }
        public bool UpdateCamion(CamionE oe)
        {
            try
            {
                CamionCD.ModificarCamion(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al atualizar tabla Camion", ex);
            }
        }

        public CamionE obtenerObjeto(CamionPersonalizado obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("No se ha seleccionado ningún Camion de la lista.");
            }

            return CamionCD.GetCamion(obj.IdCamion);

        }
        public bool DeleteCamion(CamionE oe)
        {
            try
            {
                CamionCD.EliminarCamion(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al delete Camion en la BD", ex);
            }
        }
    }
}
