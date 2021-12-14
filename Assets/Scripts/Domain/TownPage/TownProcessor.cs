using MadDudeStudios.MobileDungeonCrawler.Core;

namespace MadDudeStudios.MobileDungeonCrawler.Domain.TownPage
{
  public class TownProcessor
  {
    private ILoadHeroes _loadHeroes;

    public TownProcessor()
    {
      _loadHeroes = new HeroRepository();
    }

    public Hero GetHero()
    {
      return _loadHeroes.LoadHero();
    }
  }
}