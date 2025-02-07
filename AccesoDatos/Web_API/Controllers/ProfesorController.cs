using FullStack.Models;
using FullStack.Operaciones;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProfesorController : Controller
    {
        // Instanciar las operaciones de profesor
        public ProfesorDAO profesorDAO = new ProfesorDAO();

        // Endpoint para autenticar el profesor
        [HttpPost("autenticacion")]
        public Profesor login([FromBody] Profesor propsProfesor)
        {
            var profesor = profesorDAO.login(propsProfesor.Usuario, propsProfesor.Pass);

            if (profesor != null)
            {
                return profesor;
            }
            else
            {
                return null;
            }
        }
    }
}
