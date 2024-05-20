using Microsoft.AspNetCore.Mvc;
using SolestrideAPI.Model;

namespace SolestrideAPI.Controllers
{
    [ApiController]
    [Route("comprador")]
    public class CompradorController : Controller
    {

        List<Comprador> compradores = new Comprador().compradoresList();

        public async Task<string> getMethod(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        return (responseBody.ToString());
                    }
                    else
                    {
                       return "Erro ao fazer a requisição";
                    }
                }
                catch (Exception e)
                {
                    return "erro" + e;
                }
            }
        }

        [HttpGet]
        public IActionResult get()
        {
            return Ok(getMethod("https://servicodados.ibge.gov.br/api/v1/localidades/distritos/520005005"));
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
