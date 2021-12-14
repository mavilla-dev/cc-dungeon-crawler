using MadDudeStudios.MobileDungeonCrawler.Core;
using System;

namespace MadDudeStudios.MobileDungeonCrawler.Domain.DungeonPage
{
  public class DungeonProgressProcessor : ILoadDungeonProgress
  {
    ILoadData _loadData;
    ISaveData _saveData;

    public DungeonProgressProcessor()
    {
      _loadData = new FileDataProcessor();
      _saveData = new FileDataProcessor();
    }

    public DungeonInfo GetCurrentDungeonInformation()
    {
      var doesDataExist = _loadData.DoesFileExist(FilePaths.DungeonProgress);
      if (doesDataExist)
      {
        return _loadData.Load<DungeonInfo>(FilePaths.DungeonProgress);
      }

      return _saveData.Save(
        new DungeonInfo { CurrentArea = 1, DungeonDepth = 1, TotalAreas = 3 },
        FilePaths.DungeonProgress);
    }
  }

  [Serializable]
  public struct DungeonInfo
  {
    public int DungeonDepth { get; set; }
    public int CurrentArea { get; set; }
    public int TotalAreas { get; set; }
  }
}