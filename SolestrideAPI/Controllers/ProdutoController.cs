using Microsoft.AspNetCore.Mvc;
using SolestrideAPI.Model;

namespace SolestrideAPI.Controllers
{
    [ApiController]
    [Route("produto")]
    public class ProdutoController : Controller
    {
        public IActionResult getProduto()
        {
            List<Produto> produtos = new Produto().produtosList();

            return Ok(produtos);
        }
    }
}
