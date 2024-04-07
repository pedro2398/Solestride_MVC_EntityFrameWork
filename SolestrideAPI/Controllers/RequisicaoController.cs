using Microsoft.AspNetCore.Mvc;
using SolestrideAPI.Model;

namespace SolestrideAPI.Controllers
{
    [ApiController]
    [Route("requisicao")]
    public class RequisicaoController : Controller
    {
        [HttpGet]
        public IActionResult getRequisicao()
        {
            List<Requisicao> requisicoes = new Requisicao().requisicaoesList();

            return Ok(requisicoes);
        }
    }
}
