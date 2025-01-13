using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        [HttpGet("prueba")]
        public string pruebaApi()
        {
            return "Probando la API...";
        }
    }
}
