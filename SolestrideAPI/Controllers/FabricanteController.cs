using Microsoft.AspNetCore.Mvc;
using SolestrideAPI.Model;

namespace SolestrideAPI.Controllers
{
    [ApiController]
    [Route("fabricante")]
    public class FabricanteController : Controller
    {

        List<Fabricante> fabricantes = new Fabricante().fabricantesList();

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
                        return responseBody;
                    }
                    else
                    {
                        return $"Erro ao fazer a requisição: {response.StatusCode} - {response.ReasonPhrase}";
                    }
                }
                catch (HttpRequestException e)
                {
                    return $"Erro de requisição HTTP: {e.Message}";
                }
                catch (Exception e)
                {
                    return $"Erro: {e.Message}";
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            try
            {
                string result = await getMethod("http://localhost:8080/fabricante");

                if (result.StartsWith("Erro"))
                {
                    return StatusCode(500, result);
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro ao processar a requisição: {e.Message}");
            }
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
