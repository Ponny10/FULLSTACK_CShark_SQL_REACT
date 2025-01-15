using FullStack.Models;
using FullStack.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private AlumnosDAO alumnoDAO = new AlumnosDAO();

        [HttpGet("alumnosProfesor")]
        public List<AlumnoProfesor> alumnoProfesors(string usuario)
        {
            return alumnoDAO.seleccionarAlumnosProfesor(usuario);
        }

        [HttpGet("alumno")]
        public Alumno? getAlumno(int id)
        {
            return alumnoDAO.IdAlumno(id);
        }

        [HttpPut("actualizarAlumno")]
        public bool updateAlumno([FromBody] Alumno alumno)
        {
            return alumnoDAO.ActualizarAlumno(alumno.Id, alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email);
        }

        [HttpPost("agregarAlumno")]
        public bool agregarAlumno([FromBody] Alumno alumno, int id_asig)
        {
            return alumnoDAO.insertarMatricularAlumno(
                alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email, id_asig);
        }

        [HttpDelete("eliminarAlumno")]
        public bool eliminarAlumno(int id)
        {
            return alumnoDAO.eliminarAlumno(id);
        }

    }
}
