using System;

namespace MadDudeStudios.MobileDungeonCrawler.Core
{
  [Serializable]
  public class Hero
  {
    public string Name { get; set; }
    public Attributes Attributes { get; set; }
  }
}