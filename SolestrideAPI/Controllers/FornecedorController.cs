using Microsoft.AspNetCore.Mvc;
using SolestrideAPI.Model;

namespace SolestrideAPI.Controllers
{
    [ApiController]
    [Route("fornecedor")]
    public class FornecedorController : Controller
    {

        List<Fornecedor> fornecedores = new Fornecedor().fornecedoresList();

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
                string result = await getMethod("http://localhost:8080/fornecedor");

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
