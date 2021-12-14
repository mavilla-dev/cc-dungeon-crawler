using MadDudeStudios.MobileDungeonCrawler.Domain.HeroSelection;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MadDudeStudios.MobileDungeonCrawler.Core
{
  public class FileDataProcessor : ISaveData, ILoadData
  {
    public T Save<T>(T data, string filePath)
    {
      var bf = new BinaryFormatter();
      var file = File.OpenWrite(filePath);
      bf.Serialize(file, data);
      file.Close();
      return data;
    }

    public T Load<T>(string filePath)
    {
      if (!File.Exists(filePath))
      {
        return default;
      }

      var bf = new BinaryFormatter();
      var file = File.Open(filePath, FileMode.Open);
      var data = bf.Deserialize(file);
      file.Close();
      return (T)data;
    }

    public bool DoesFileExist(string filePath)
      => File.Exists(filePath);
  }
}
