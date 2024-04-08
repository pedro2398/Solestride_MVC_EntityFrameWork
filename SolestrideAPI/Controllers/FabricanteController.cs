using Microsoft.AspNetCore.Mvc;
using SolestrideAPI.Model;

namespace SolestrideAPI.Controllers
{
    [ApiController]
    [Route("fabricante")]
    public class FabricanteController : Controller
    {

        List<Fabricante> fabricantes = new Fabricante().fabricantesList();

        [HttpGet]
        public IActionResult get()
        {
            return Ok(fabricantes);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var fabricante = fabricantes.ToList().FirstOrDefault(x => x.Id == id);

            if (fabricante == null)
                return BadRequest();

            return Ok(fabricante);
        }

        [HttpPost]
        public IActionResult post([FromBody] Fabricante entity)
        {
            fabricantes.Add(entity);
            return Created("", fabricantes);
        }

        [HttpPut]
        public IActionResult put([FromBody] Fabricante entity)
        {
            getById(entity.Id);

            fabricantes.ToList().ForEach(x =>
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
            return Ok(fabricantes);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            getById(id);

            fabricantes.ToList().ForEach(x =>
            {
                if (x.Id == id) { 
                fabricantes.Remove(x);
                }
            });

            return Ok(fabricantes);
        }
    }
}
