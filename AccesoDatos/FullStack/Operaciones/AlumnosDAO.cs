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
            return context.Alumnos.Where(a => a.Id == id).FirstOrDefault();
        }

        // Seleccionar por DNI alumno
        public Alumno DniAlumno(string dniAlumno)
        {
            return context.Alumnos.Where(a => a.Dni == dniAlumno).FirstOrDefault();
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
                // Si el alumno existe, continua el seteo de los datos
                existeAlumno.Dni = dni;
                existeAlumno.Direccion = direccion;
                existeAlumno.Edad = edad;
                existeAlumno.Email = email;
                existeAlumno.Nombre = nombre;

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch
                {
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

        // Agregar y matricular alumno
        public bool insertarMatricularAlumno(string dni, string nombre, string direccion, int edad, string email, int id_asig)
        {
            try
            {
                // Verificar si existe el dni del alumno
                var existeAlumno = DniAlumno(dni);

                if (existeAlumno == null)
                {
                    // Si no existe, agregar alumno
                    NuevoAlumno(dni, nombre, direccion, edad, email);

                    // Inmediatamente obtener el id del registro de alumno
                    var alumnoRecienAgregado = DniAlumno(dni);

                    Matricula matricula = new Matricula();
                    matricula.AlumnoId = alumnoRecienAgregado.Id;
                    matricula.AsignaturaId = id_asig;

                    context.Matriculas.Add(matricula);
                    context.SaveChanges();

                }
                else
                {
                    Matricula matricula = new Matricula();
                    matricula.AlumnoId = existeAlumno.Id;
                    matricula.AsignaturaId = id_asig;

                    context.Matriculas.Add(matricula);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Eliminar alumno
        public bool eliminarAlumno(int id)
        {
            try
            {
                // 1: Verificar que el alumno exista
                var existealumno = context.Alumnos.Where(a => a.Id == id).FirstOrDefault();
                Console.WriteLine("Valor de existeAlumno = " + existealumno + " Es falso = " + existealumno == null);

                if(existealumno == null)
                {
                    return false;
                }

                // 2: Obtener las matriculaciones del alumno
                var matriculas = context.Matriculas.Where(m => m.AlumnoId == id).ToList();

                // 3: Recorrer y eliminar las calificaciones de cada matricula
                foreach(Matricula m in matriculas)
                {
                    // 4: Obtener las calificaiones cuyo idMatricula sea igual a m.matriculaID
                    var calificaciones = context.Calificacions.Where(c => c.MatriculaId == m.Id).ToList();
                    context.Calificacions.RemoveRange(calificaciones);
                }

                // 5: Borar matrículas y Alumno
                context.Matriculas.RemoveRange(matriculas);
                context.Alumnos.Remove(existealumno);

                context.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error => " + e.Message);
                return false;
            }
        }
    }
}
