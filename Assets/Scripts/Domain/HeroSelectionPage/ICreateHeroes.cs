using System.Collections.Generic;

namespace MadDudeStudios.MobileDungeonCrawler.Domain.HeroSelection
{
  public interface ICreateHeroes
  {
    public IEnumerable<HeroSelectionPageHero> GenerateHeroes(int heroesToGenerate);
  }
}
