using FullStack.Models;
using FullStack.Operaciones;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class CalificacionController : Controller
    {
        private CalificacionDAO calificacion = new CalificacionDAO();

        [HttpGet("calificaciones")]
        public List<Calificacion> get(int matriculaId)
        {
            return calificacion.getCalificaciones(matriculaId);
        }

        [HttpPost("calificacion")]
        public bool agregarCalificacion([FromBody] Calificacion cal)
        {
            return calificacion.agregarCalificacion(cal);
        }

        [HttpDelete("calificacion")]
        public bool eliminarCalificacion(int id)
        {
            return calificacion.eliminarCalificacion(id);
        }
    }
}
