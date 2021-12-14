namespace MadDudeStudios.MobileDungeonCrawler.Core
{
  public interface ISaveData
  {
    public T Save<T>(T data, string filePath);
  }
}
