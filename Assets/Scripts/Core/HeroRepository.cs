using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace MadDudeStudios.MobileDungeonCrawler.Core
{
  public class HeroRepository : ILoadHeroes, ISaveHeroes
  {
    private readonly string HeroSaveDataFileName = Application.persistentDataPath + "/HeroSaveData.dat";

    public void SaveHero(Hero heroInfo)
    {
      var bf = new BinaryFormatter();
      var file = File.OpenWrite(HeroSaveDataFileName);
      bf.Serialize(file, heroInfo);
      file.Close();
    }

    public Hero LoadHero()
    {
      if (!File.Exists(HeroSaveDataFileName))
      {
        return null;
      }

      var bf = new BinaryFormatter();
      var file = File.Open(HeroSaveDataFileName, FileMode.Open);
      Hero hero = bf.Deserialize(file) as Hero;
      file.Close();
      return hero;
    }
  }
}
