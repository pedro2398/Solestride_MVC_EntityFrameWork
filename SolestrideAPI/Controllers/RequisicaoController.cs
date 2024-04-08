using Microsoft.AspNetCore.Mvc;
using SolestrideAPI.Model;

namespace SolestrideAPI.Controllers
{
    [ApiController]
    [Route("requisicao")]
    public class RequisicaoController : Controller
    {
        List<Requisicao> requisicoes = new Requisicao().requisicaoesList();

        [HttpGet]
        public IActionResult get()
        {
            return Ok(requisicoes);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var requisicao = requisicoes.ToList().FirstOrDefault(x => x.Id == id);

            if (requisicao == null)
                return BadRequest();

            return Ok(requisicao);
        }

        [HttpPost]
        public IActionResult post([FromBody] Requisicao entity)
        {
            requisicoes.Add(entity);
            return Created("", requisicoes);
        }

        [HttpPut]
        public IActionResult put([FromBody] Requisicao entity)
        {
            getById(entity.Id);

            requisicoes.ToList().ForEach(x =>
            {
                if (entity.Id == x.Id)
                {
                    x.CodRequisicao = entity.CodRequisicao;
                    x.Quantidade = entity.Quantidade;
                    x.TetoAutomatico = entity.TetoAutomatico;
                    x.Data = entity.Data;
                    x.Produto = entity.Produto;
                }
            });
            return Ok(requisicoes);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            getById(id);

            requisicoes.ToList().ForEach(x =>
            {
                if (x.Id == id)
                {
                    requisicoes.Remove(x);
                }
            });

            return Ok(requisicoes);
        }
    }
}