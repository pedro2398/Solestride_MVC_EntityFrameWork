using Microsoft.AspNetCore.Mvc;
using SolestrideAPI.Model;

namespace SolestrideAPI.Controllers
{
    [ApiController]
    [Route("fabricante")]
    public class FabricanteController : Controller
    {
        [HttpGet]
        public IActionResult getFabricantes()
        {
            List<Fabricante> fabricantes = new Fabricante().fabricantesList();

            return Ok(fabricantes);
            }
        }
    }
