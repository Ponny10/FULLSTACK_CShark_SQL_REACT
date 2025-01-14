using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStack.Context;
using FullStack.Models;
using Microsoft.EntityFrameworkCore;

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
        public Alumno IdAlumno(int id)
        {
            // return context.Alumnos.Where(a => a.Id == id).FirstOrDefault();
            return context.Alumnos.SingleOrDefault(a => a.Id == id);
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
             // Verificar si el alumno existe
            var existeAlumno = IdAlumno(id);
            if (existeAlumno != null)
            {
                Console.WriteLine("Valor de ExisteAlumno => " + existeAlumno.Id);
                // Si el alumno existe, continua el seteo de los datos
                Console.WriteLine("Valor de Alumno Antes => " + existeAlumno.Direccion);
                existeAlumno.Dni = dni;
                existeAlumno.Direccion = direccion;
                existeAlumno.Edad = edad;
                existeAlumno.Email = email;
                existeAlumno.Nombre = nombre;
                Console.WriteLine("Valor de alumno depsués => " + existeAlumno.Direccion);

                try
                {
                    Console.WriteLine("Se aguardaron correctamente los datos.");
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Fallo la actualizada." + e.Message);
                    return false;
                }
            }
            return false;
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

        // Obtener listado de Profesor con Alumnos y Asignaturas
        // Antes, se crea un modelo que representa la respuesta.
        public List<AlumnoProfesor> seleccionarAlumnosProfesor(string usuario)
        {
            var query = from a in context.Alumnos
                        join m in context.Matriculas on a.Id equals m.AlumnoId
                        join s in context.Asignaturas on m.Id equals s.Id
                        where s.Profesor == usuario
                        select new AlumnoProfesor
                        {
                            Id = a.Id,
                            Dni = a.Dni,
                            Nombre = a.Nombre,
                            Direccion = a.Direccion,
                            Edad = a.Edad,
                            Email = a.Email,
                            Asignatura = s.Nombre,
                        };

            return query.ToList();
        }
    }
}
