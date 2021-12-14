using Assets.External;
using System;

namespace Assets.Scripts
{
  public class CombatEvents : Singleton<CombatEvents>
  {
    public Action EventAttackButtonClick { get; set; }
    public void AttackButtonClicked()
    {
      EventAttackButtonClick?.Invoke();
    }

    public Action EventSceneLoadComplete { get; set; }
    public void SceneLoadIsComplete()
    {
      EventSceneLoadComplete?.Invoke();
    }

    public Action<SetActiveForSlotIdArgs> EventSetActiveForSlotId { get; set; }
    public void SetActiveForSlotId(SetActiveForSlotIdArgs args)
    {
      EventSetActiveForSlotId?.Invoke(args);
    }

    public Action<EventUpdateUnitStats> EventUpdateUnitStats { get; set; }
    public void UpdateUnitStats(EventUpdateUnitStats args)
    {
      EventUpdateUnitStats?.Invoke(args);
    }
  }
}
