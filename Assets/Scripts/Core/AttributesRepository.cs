using Assets.Scripts.Core;

namespace MadDudeStudios.MobileDungeonCrawler.Core
{
  public class AttributesRepository : ICreateAttributes
  {
    public Attributes GeneratePlayer()
    {
      var hp = UnityRandom.GetRange(40, 60);
      return new Attributes
      {
        Level = 1,
        Hp = hp,
        MaxHp = hp,
        Alignment = UnityRandom.GetRandomEnum<MagicType>(),
        Attack = UnityRandom.GetRange(40, 60),
        Defense = UnityRandom.GetRange(40, 60),
        SpecialAttack = UnityRandom.GetRange(40, 60),
        SpecialDefense = UnityRandom.GetRange(40, 60),
      };
    }
  }
}
