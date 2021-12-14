using TMPro;
using UnityEngine;

namespace Assets.Scripts.Components
{
  public class HeroCombatStats : MonoBehaviour
  {
    [SerializeField] TextMeshProUGUI _healthText;
    [SerializeField] TextMeshProUGUI _mpText;

    [Range(0, 2)]
    public int PlayerSlotID;

    private void Awake()
    {
      CombatEvents.Instance.EventSetActiveForSlotId += EventSetActiveForSlotId;
      CombatEvents.Instance.EventUpdateUnitStats += UpdateUnitStats;
    }

    private void OnDestroy()
    {
      CombatEvents.Instance.EventSetActiveForSlotId -= EventSetActiveForSlotId;
      CombatEvents.Instance.EventUpdateUnitStats -= UpdateUnitStats;
    }

    private void UpdateUnitStats(EventUpdateUnitStats args)
    {
      _healthText.SetText($"HP: {args.HP}/{args.MaxHP}");
      _mpText.SetText($"MP\r\n{args.MP}");
    }

    private void EventSetActiveForSlotId(SetActiveForSlotIdArgs args)
    {
      if (!args.IsPlayerUnit || args.PlayerSlotId != PlayerSlotID)
      {
        return;
      }

      gameObject.SetActive(args.IsActive);
    }
  }
}
