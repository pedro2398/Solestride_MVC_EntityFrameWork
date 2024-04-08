using Microsoft.AspNetCore.Mvc;
using SolestrideAPI.Model;

namespace SolestrideAPI.Controllers
{
    [ApiController]
    [Route("comprador")]
    public class CompradorController : Controller
    {

        List<Comprador> compradores = new Comprador().compradoresList();

        [HttpGet]
        public IActionResult get()
        {
            return Ok(compradores);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var comprador = compradores.ToList().FirstOrDefault(x => x.Id == id);

            if (comprador == null)
                return BadRequest();

            return Ok(comprador);
        }

        [HttpPost]
        public IActionResult post([FromBody] Comprador entity)
        {
            compradores.Add(entity);
            return Created("", compradores);
        }

        [HttpPut]
        public IActionResult put([FromBody] Comprador entity)
        {   
            getById(entity.Id);

           compradores.ToList().ForEach(x =>
           {
               if (entity.Id == x.Id) {
                    x.Nome = entity.Nome;
                    x.Cnpj = entity.Cnpj;
                    x.Email = entity.Email;
                    x.Senha = entity.Senha;
                    x.ModTributario = entity.ModTributario;
                    x.Tipo = entity.Tipo;
               }
           });
            return Ok(compradores);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            getById(id);

            compradores.ToList().ForEach(x =>
            {
                if (x.Id == id)
                {
                    compradores.Remove(x);
                }
            });

            return Ok(compradores);
        }
    }
}
