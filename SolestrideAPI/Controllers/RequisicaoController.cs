using Microsoft.AspNetCore.Mvc;
using SolestrideAPI.Model;

namespace SolestrideAPI.Controllers
{
    [ApiController]
    [Route("requisicao")]
    public class RequisicaoController : Controller
    {
        List<Requisicao> requisicoes = new Requisicao().requisicaoesList();
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
                string result = await getMethod("http://localhost:8080/requisicao");

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