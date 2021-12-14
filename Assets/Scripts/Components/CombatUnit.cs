using TMPro;
using UnityEngine;

namespace Assets.Scripts.Components
{
  public class CombatUnit : MonoBehaviour
  {
    [SerializeField] TextMeshProUGUI _unitName;

    [Range(0, 2)]
    public int UnitSlotId;
    public bool IsPlayerUnit;

    private void Awake()
    {
      CombatEvents.Instance.EventSetActiveForSlotId += EventSetActiveForSlotId;
      CombatEvents.Instance.EventUpdateUnitStats += UpdateUnitStats;
    }

    private void UpdateUnitStats(EventUpdateUnitStats args)
    {
      if (IsPlayerUnit != args.IsPlayerUnit || UnitSlotId != args.PlayerSlotId)
      {
        return;
      }

      _unitName.SetText(args.UnitName);
    }

    private void EventSetActiveForSlotId(SetActiveForSlotIdArgs args)
    {
      if (IsPlayerUnit != args.IsPlayerUnit || UnitSlotId != args.PlayerSlotId)
      {
        return;
      }

      gameObject.SetActive(args.IsActive);
    }
  }
}
