using Microsoft.AspNetCore.Mvc;
using SolestrideAPI.Model;

namespace SolestrideAPI.Controllers
{
    [ApiController]
    [Route("produto")]
    public class ProdutoController : Controller
    {

        List<Produto> produtos = new Produto().produtosList();

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
                string result = await getMethod("http://localhost:8080/produto");

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
