namespace MadDudeStudios.MobileDungeonCrawler.Core
{
  public interface ILoadData
  {
    T Load<T>(string filePath);
    bool DoesFileExist(string filePath);
  }
}