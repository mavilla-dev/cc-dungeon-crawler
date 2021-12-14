using Assets.External;
using System;

namespace Assets.Scripts
{
  public class SceneManagerEvents : Singleton<SceneManagerEvents>
  {
    public Action<GameScene> OnLoadScene { get; set; }
    public void InvokeOnLoadScene(GameScene scene)
    {
      OnLoadScene?.Invoke(scene);
    }
  }
}
