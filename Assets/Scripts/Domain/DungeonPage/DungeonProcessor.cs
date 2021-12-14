using MadDudeStudios.MobileDungeonCrawler.Core;

namespace MadDudeStudios.MobileDungeonCrawler.Domain.DungeonPage
{
  public class DungeonProcessor
  {
    ILoadHeroes _loadHeroes;
    ILoadMonsters _loadMonsters;
    ILoadDungeonProgress _loadDungeonProgress;

    public DungeonProcessor()
    {
      _loadHeroes = new HeroRepository();
      _loadMonsters = new MonsterProcessor();
      _loadDungeonProgress = new DungeonProgressProcessor();
    }

    public DungeonPage GetDungeonPage()
    {
      var dungeonInfo = _loadDungeonProgress.GetCurrentDungeonInformation();
      var heroInfo = _loadHeroes.LoadHero();

      return new DungeonPage
      {
        Hero = heroInfo,
        DungeonInfo = dungeonInfo,
      };
    }
  }

  public class DungeonPage
  {
    public Hero Hero { get; set; }
    // public Monster Monster { get; set; }
    public DungeonInfo DungeonInfo { get; set; }
  }
}
