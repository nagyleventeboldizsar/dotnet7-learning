using dotnet7_webapi.Data;
using dotnet7_webapi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace dotnet7_webapi.Services.SuperHeroService;


public class SuperHeroService : ISuperHeroService
{
    private readonly DataContext _context;
    public SuperHeroService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<SuperHero>> AddHero(SuperHero request)
    {
        var hero = await _context.SuperHeroes.AddAsync(request);
        await _context.SaveChangesAsync();
        return await _context.SuperHeroes.ToListAsync();
    }

    public async Task<List<SuperHero>?> DeleteHero(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero == null)
            return null;

        _context.SuperHeroes.Remove(hero);
        await _context.SaveChangesAsync();

        return await _context.SuperHeroes.ToListAsync();
    }

    public async Task<SuperHero> GetHero(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero == null)
            return null;
        return hero;
    }

    public async Task<List<SuperHero>> GetHeroes()
    {
        var heroes = await _context.SuperHeroes.ToListAsync();
        return heroes;
    }

    public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero == null)
            return null;

        hero.Name = request.Name;
        hero.FirstName = request.FirstName;
        hero.LastName = request.LastName;
        hero.Place = request.Place;

        await _context.SaveChangesAsync();

        return await _context.SuperHeroes.ToListAsync();
    }
}
