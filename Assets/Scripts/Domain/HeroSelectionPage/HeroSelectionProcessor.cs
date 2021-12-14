using MadDudeStudios.MobileDungeonCrawler.Core;
using System.Linq;

namespace MadDudeStudios.MobileDungeonCrawler.Domain.HeroSelection
{
  public class HeroSelectionProcessor
  {
    private readonly ICreateHeroes _createHeroes;
    private readonly ISaveHeroes _saveHeroes;

    public HeroSelectionProcessor()
    {
      _createHeroes = new HeroProcessor(); 
      _saveHeroes = new HeroRepository();
    }

    public HeroSelectionPage GetHeroSelectionPage()
    {
      var heroes = _createHeroes.GenerateHeroes(3);

      var page = new HeroSelectionPage
      {
        ActiveHero = heroes.First(),
        Heroes = heroes,
        PageNumber = 1,
      };

      return page;
    }

    public void SaveHero(HeroSelectionPageHero activeHero)
    {
      _saveHeroes.SaveHero(activeHero.HeroInfo);
    }
  }
}
