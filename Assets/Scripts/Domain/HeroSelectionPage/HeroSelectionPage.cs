using System.Collections.Generic;

namespace MadDudeStudios.MobileDungeonCrawler.Domain.HeroSelection
{
  public class HeroSelectionPage
  {
    public HeroSelectionPageHero ActiveHero{ get; set; }
    public int PageNumber { get; set; }
    public IEnumerable<HeroSelectionPageHero> Heroes { get; set; }
  }
}
