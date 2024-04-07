using Microsoft.AspNetCore.Mvc;
using SolestrideAPI.Model;

namespace SolestrideAPI.Controllers
{
    [ApiController]
    [Route("comprador")]
    public class CompradorController : Controller
    {
        [HttpGet]
        public IActionResult getCompradores()
        {
            List<Comprador> compradores = new Comprador().compradoresList();

            return Ok(compradores);
        }
    }
}
