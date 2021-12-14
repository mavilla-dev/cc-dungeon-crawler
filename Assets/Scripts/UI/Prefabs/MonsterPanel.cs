using MadDudeStudios.MobileDungeonCrawler.Core;
using MadDudeStudios.MobileDungeonCrawler.Domain;
using TMPro;
using UnityEngine;

namespace MadDudeStudios.MobileDungeonCrawler.UI.Prefabs
{
  public class MonsterPanel : MonoBehaviour
  {
    [SerializeField] TextMeshProUGUI _textName;
    [SerializeField] TextMeshProUGUI _textHp;

    Monster _monster;
    Attributes _activeStats;

    public void SetMonster(Monster monster)
    {
      _monster = monster;
      _activeStats = monster.Attributes;
      _textName.text = $"Name: {monster.Name}";
      _textHp.text = $"HP: {monster.Attributes.Hp}/{monster.Attributes.Hp}";
    }
  }
}
