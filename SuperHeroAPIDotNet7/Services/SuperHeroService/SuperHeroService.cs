using Microsoft.EntityFrameworkCore;
using SuperHeroAPIDotNet7.Data;
using SuperHeroAPIDotNet7.Models;

namespace SuperHeroAPIDotNet7.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _dataContext;

        public SuperHeroService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<SuperHero>> GetAllHeros()
        {
            return await _dataContext.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero = await _dataContext.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;

            return hero;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _dataContext.SuperHeroes.Add(hero);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
        {
            var hero = await _dataContext.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place; 

            await _dataContext.SaveChangesAsync();

            return await _dataContext.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var hero = await _dataContext.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;

            _dataContext.Remove(hero);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.SuperHeroes.ToListAsync();
        }
    }
}
