using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoolController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CoolController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("PokemonNames")]
        public async Task<ActionResult<string>> PokemonNames()
        {
            try
            {
                //var httpClient = new HttpClient();

                var httpClient = _httpClientFactory.CreateClient();

                var response = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=60");

                response.EnsureSuccessStatusCode();

                var pokemons = await response.Content.ReadAsStringAsync();

                return Ok(pokemons);
            }
            catch (HttpRequestException ex)
            {
                switch(ex.StatusCode)
                {
                    case System.Net.HttpStatusCode.InternalServerError: return StatusCode(502, "There was a problem on the Pokemon API");

                    case System.Net.HttpStatusCode.NotFound: return StatusCode(503, "The Pokemon API is currently unavailable");

                    default: return Problem("An unexpected error has occurred.");
                }
            }
            catch (Exception ex)
            {
                return Problem("An unexpected error has occurred.");
            }
        }
    }
}
