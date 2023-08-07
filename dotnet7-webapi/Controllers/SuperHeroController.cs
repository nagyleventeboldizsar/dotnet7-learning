using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotnet7_webapi.Models;
using dotnet7_webapi.Services.SuperHeroService;

namespace dotnet7_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetHeroes()
        {
            return await _superHeroService.GetHeroes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHero(int id)
        {
            var result = await _superHeroService.GetHero(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero) 
        {
            var result = await _superHeroService.AddHero(hero);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>?>> UpdateHero(int id,SuperHero request)
        {
            var result = await _superHeroService.UpdateHero(id, request);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>?>> DeleteHero(int id)
        {
            var result = await _superHeroService.DeleteHero(id);
            if(result == null) return NotFound();
            return Ok(result);
        }
    }
}
