using Assets.External;

namespace Assets.Scripts.Managers
{
  public class BootManager : Singleton<BootManager>
  {
    protected override void Awake()
    {
      base.Awake();
      gameObject.AddComponent<GameManager>();
    }

    private void Start()
    {
      SceneManagerEvents.Instance.InvokeOnLoadScene(GameScene.Combat);
    }
  }
}
