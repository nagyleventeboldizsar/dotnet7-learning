namespace dotnet7_webapi.Services.SuperHeroService;
using dotnet7_webapi.Models;


public interface ISuperHeroService
{
    Task<List<SuperHero>> GetHeroes();
    Task<SuperHero> GetHero(int id);
    Task<List<SuperHero>> AddHero(SuperHero hero);
    Task<List<SuperHero>?> UpdateHero(int id, SuperHero hero);
    Task<List<SuperHero>?> DeleteHero(int id);
}
