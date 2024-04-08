using Microsoft.AspNetCore.Mvc;
using SolestrideAPI.Model;

namespace SolestrideAPI.Controllers
{
    [ApiController]
    [Route("produto")]
    public class ProdutoController : Controller
    {

        List<Produto> produtos = new Produto().produtosList();

        [HttpGet]
        public IActionResult get()
        {
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var produto = produtos.ToList().FirstOrDefault(x => x.Id == id);

            if (produto == null)
                return BadRequest();

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult post([FromBody] Produto entity)
        {
            produtos.Add(entity);
            return Created("", produtos);
        }

        [HttpPut]
        public IActionResult put([FromBody] Produto entity)
        {
            getById(entity.Id);

            produtos.ToList().ForEach(x =>
            {
                if (entity.Id == x.Id)
                {
                    x.Nome = entity.Nome;
                    x.CodProduto = entity.CodProduto;
                    x.Descricao = entity.Descricao;
                    x.Modelo = entity.Modelo;
                    x.Fabricante = entity.Fabricante;
                    x.Fabricante = entity.Fabricante;
                }
            });
            return Ok(produtos);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            getById(id);

            produtos.ToList().ForEach(x =>
            {
                if (x.Id == id)
                {
                    produtos.Remove(x);
                }
            });

            return Ok(produtos);
        }
    }
}
