using FullStack.Models;
using FullStack.Operaciones;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    public class ProfesorController : Controller
    {
        // Instanciar las operaciones de profesor
        public ProfesorDAO profesorDAO = new ProfesorDAO();

        // Endpoint para autenticar el profesor
        [HttpPost("autenticacion")]
        public string login([FromBody] Profesor propsProfesor)
        {
            var profesor = profesorDAO.login(propsProfesor.Usuario, propsProfesor.Pass);

            if (profesor != null)
            {
                return profesor.Nombre;
            }
            else
            {
                return null;
            }
        }
    }
}
