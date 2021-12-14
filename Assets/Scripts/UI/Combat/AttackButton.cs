using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Combat
{
  public class AttackButton :  MonoBehaviour
  {
    [SerializeField] private Button _attackButton;

    private void Awake()
    {
      _attackButton = GetComponent<Button>();
      _attackButton.onClick.AddListener(OnAttackButtonClicked);
    }

    private void OnAttackButtonClicked()
    {
      CombatEvents.Instance.AttackButtonClicked();
    }
  }
}
