using MadDudeStudios.MobileDungeonCrawler.Core;
using MadDudeStudios.MobileDungeonCrawler.UI.Prefabs;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MadDudeStudios.MobileDungeonCrawler.Domain
{

  public class CombatUI : MonoBehaviour
  {
    [SerializeField] TextMeshProUGUI _dungeonTitle;
    [SerializeField] Transform _enemyPanelContainer;
    [SerializeField] Transform _enemyTargetsContainer;
    [SerializeField] Transform _playerActionsContainer;
    [SerializeField] GameObject _prefab_enemyPanel;
    [SerializeField] TextMeshProUGUI _heroHpText;
    [SerializeField] TextMeshProUGUI _heroMpText;

    private ICreateAttributes _createAttributes;
    private ILoadHeroes _loadHeros;
    private Hero _activeHero;
    private int _mpCount = 0;
    private readonly IList<Monster> _monsters = new List<Monster>();

    private void Awake()
    {
      _createAttributes = new AttributesRepository();
      _loadHeros = new HeroRepository();
      _activeHero = _loadHeros.LoadHero();
    }

    private void OnEnable()
    {
      var floor = 1;
      var area = 1;
      var maxAreas = 3;
      _dungeonTitle.SetText("Floor: 1 - Area 1/3");
      ClearContainer(_enemyPanelContainer);
      ClearContainer(_enemyTargetsContainer);

      GenerateMonsters(floor, area, maxAreas);
      CreatePanelForMonsters();

      PopulateHeroStats();
      _enemyTargetsContainer.gameObject.SetActive(false);
      _playerActionsContainer.gameObject.SetActive(true);
    }

    void Start()
    {

    }

    void ClearContainer(Transform container)
    {
      foreach (Transform item in container)
      {
        Destroy(item.gameObject);
      }
    }

    void GenerateMonsters(int floor, int area, int maxArea)
    {
      _monsters.Add(new Monster
      {
        Name = "Monster 1",
        Attributes = _createAttributes.GeneratePlayer(),
      });
    }

    void CreatePanelForMonsters()
    {
      foreach (var item in _monsters)
      {
        var newEnemyPanel = Instantiate(_prefab_enemyPanel);
        newEnemyPanel.transform.SetParent(_enemyPanelContainer.transform);

        var monsterPanel = newEnemyPanel.GetComponent<MonsterPanel>();
        monsterPanel.SetMonster(item);
      }
    }

    void PopulateHeroStats()
    {
      _heroHpText.SetText($"HP: {_activeHero.Attributes.Hp}/{_activeHero.Attributes.MaxHp}");
      _heroMpText.SetText($"MP: {_mpCount}/8");
    }
  }

  public class Monster
  {
    public string Name { get; set; }
    public Attributes Attributes { get; set; }
  }
}