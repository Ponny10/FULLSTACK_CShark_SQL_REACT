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

        [HttpPut("update")]
        public bool updateAlumno([FromBody] Alumno alumno)
        {
            return alumnoDAO.ActualizarAlumno(alumno.Id, alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email);
        }

    }
}
