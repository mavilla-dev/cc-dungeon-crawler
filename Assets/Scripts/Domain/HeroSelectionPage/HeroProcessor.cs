using MadDudeStudios.MobileDungeonCrawler.Core;
using System.Collections.Generic;

namespace MadDudeStudios.MobileDungeonCrawler.Domain.HeroSelection
{
  public class HeroProcessor : ICreateHeroes
  {
    private readonly ICreateAttributes _createAttributes;

    public HeroProcessor()
    {
      _createAttributes = new AttributesRepository();
    }

    public IEnumerable<HeroSelectionPageHero> GenerateHeroes(int heroesToGenerate)
    {
      var newHeroes = new List<HeroSelectionPageHero>();
      for (int index = 0; index < heroesToGenerate; index++)
      {
        newHeroes.Add(
          new HeroSelectionPageHero
          {
            HeroInfo = new Hero
            {
              Name = string.Empty,
              Attributes = _createAttributes.GeneratePlayer(),
            }
          });
      }

      return newHeroes;
    }
  }
}
