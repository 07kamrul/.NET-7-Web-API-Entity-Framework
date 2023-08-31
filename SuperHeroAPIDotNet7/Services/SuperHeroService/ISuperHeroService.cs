using SuperHeroAPIDotNet7.Models;

namespace SuperHeroAPIDotNet7.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> GetAllHeros();
        SuperHero? GetSingleHero(int id);
        List<SuperHero> AddHero(SuperHero hero);
        List<SuperHero>? UpdateHero(int id, SuperHero request);
        List<SuperHero>? DeleteHero(int id);
    }
}
