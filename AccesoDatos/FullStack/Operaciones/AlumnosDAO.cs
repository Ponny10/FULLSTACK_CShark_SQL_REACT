using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStack.Context;
using FullStack.Models;

namespace FullStack.Operaciones
{
    // Clase con CRUD de Alumnos
    public class AlumnosDAO
    {
        // Instanciar el Context a la DB
        public CursoFullstackContext context = new CursoFullstackContext();

        // Lista para retornar todos los Alumnos
        public List<Alumno> Alumnos()
        {
            return [.. context.Alumnos];
        }

        // Seleccionar al primer alumno que coincida con el id de parámetro
        public Alumno? IdAlumno(int idAlumno)
        {
            return context.Alumnos.Where(a => a.Id == idAlumno).FirstOrDefault();
        }

        // Insertar nuevo alumno a la BD
        public bool NuevoAlumno(string dni, string nombre, string direccion, int edad, string email)
        {
            try
            {
                // Instanciar modelo de alumnos
                Alumno alumno = new Alumno();
                alumno.Dni = dni;
                alumno.Direccion = direccion;
                alumno.Edad = edad;
                alumno.Email = email;
                alumno.Nombre = nombre;

                // Agregar y guardar el nuevo alumno
                context.Alumnos.Add(alumno);
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        // Actualizar registro de alumno
        public bool ActualizarAlumno(int id, string dni, string nombre, string direccion, int edad, string email)
        {
            try
            {
                // Verificar si el alumno existe
                if (IdAlumno(id) == null)
                {
                    return false;
                }

                // Si el alumno existe, continua el seteo de los datos
                Alumno alumno = new Alumno();
                alumno.Dni = dni;
                alumno.Direccion = direccion;
                alumno.Edad = edad;
                alumno.Email = email;
                alumno.Nombre = nombre;

                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        // Eliminar un alumno
        public bool EliminarAlumno(int id)
        {
            try
            {
                // Verificar si el alumno existe
                var existeAlumno = IdAlumno(id);
                if (existeAlumno == null)
                {
                    return false;
                }

                context.Alumnos.Remove(existeAlumno);
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
