using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStack.Context;
using FullStack.Models;

namespace FullStack.Operaciones
{
    public class CalificacionDAO
    {
        CursoFullstackContext context = new CursoFullstackContext();

        public List<Calificacion> getCalificaciones(int id)
        {
            var calificaciones = context.Calificacions.Where(c => c.MatriculaId == id).ToList();
            return calificaciones;
        }

        public bool agregarCalificacion(Calificacion cal)
        {
            try
            {
                context.Calificacions.Add(cal);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarCalificacion(int id)
        {
            try
            {
                var calificacion = context.Calificacions.Where(c => c.Id == id).FirstOrDefault();

                if (calificacion == null)
                {
                    return false;
                }

                context.Calificacions.Remove(calificacion);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
