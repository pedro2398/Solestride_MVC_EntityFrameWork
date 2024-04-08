using Microsoft.AspNetCore.Mvc;
using SolestrideAPI.Model;

namespace SolestrideAPI.Controllers
{
    [ApiController]
    [Route("fornecedor")]
    public class FornecedorController : Controller
    {

        List<Fornecedor> fornecedores = new Fornecedor().fornecedoresList();

        [HttpGet]
        public IActionResult get()
        {
            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var fornecedor = fornecedores.ToList().FirstOrDefault(x => x.Id == id);

            if (fornecedor == null)
                return BadRequest();

            return Ok(fornecedor);
        }

        [HttpPost]
        public IActionResult post([FromBody] Fornecedor entity)
        {
            fornecedores.Add(entity);
            return Created("", fornecedores);
        }

        [HttpPut]
        public IActionResult put([FromBody] Fornecedor entity)
        {
            getById(entity.Id);

            fornecedores.ToList().ForEach(x =>
            {
                if (entity.Id == x.Id)
                {
                    x.Nome = entity.Nome;
                    x.Cnpj = entity.Cnpj;
                    x.Email = entity.Email;
                    x.Senha = entity.Senha;
                    x.ModTributario = entity.ModTributario;
                    x.Tipo = entity.Tipo;
                }
            });
            return Ok(fornecedores);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            getById(id);

            fornecedores.ToList().ForEach(x =>
            {
                if (x.Id == id)
                {
                    fornecedores.Remove(x);
                }
            });

            return Ok(fornecedores);
        }
    }
}
