using Microsoft.AspNetCore.Mvc;
using SolestrideAPI.Model;

namespace SolestrideAPI.Controllers
{
    [ApiController]
    [Route("fornecedor")]
    public class FornecedorController : Controller
    {
        [HttpGet]
        public IActionResult getFornecedores()
        {
            List<Fornecedor> fornecedores = new Fornecedor().fornecedoresList();

            return Ok(fornecedores);
        }
    }
}
