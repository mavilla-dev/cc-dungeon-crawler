using UnityEngine;

namespace MadDudeStudios.MobileDungeonCrawler.Core
{
  public class FilePaths
  {
    public static string DungeonProgress => Application.persistentDataPath + "/dungeonProgress.dat";
    public static string Hero => Application.persistentDataPath + "/HeroSaveData.dat";
  }
}
