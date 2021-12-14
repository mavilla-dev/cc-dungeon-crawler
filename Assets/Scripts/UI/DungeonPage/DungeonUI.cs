using MadDudeStudios.MobileDungeonCrawler.Domain.DungeonPage;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DungeonUI : MonoBehaviour
{
  [SerializeField] Button _buttonPrefab;
  [SerializeField] TextMeshProUGUI _dungeonDepthText;
  [SerializeField] TextMeshProUGUI _dungeonAreaText;
  [SerializeField] TextMeshProUGUI _playerCharacterNameText;
  [SerializeField] TextMeshProUGUI _playerCharacterHpText;
  [SerializeField] TextMeshProUGUI _monsterNameText;
  [SerializeField] TextMeshProUGUI _monsterHPText;
  [SerializeField] Transform _actionTransform;

  DungeonProcessor _dungeonProcessor;

  private void Awake()
  {
    _dungeonProcessor = new DungeonProcessor();
  }

  private void OnEnable()
  {
    var page = _dungeonProcessor.GetDungeonPage();
    _dungeonDepthText.SetText($"Depth: {page.DungeonInfo.DungeonDepth}");
    _dungeonAreaText.SetText($"Area: {page.DungeonInfo.CurrentArea}/{page.DungeonInfo.TotalAreas}");
    _playerCharacterNameText.SetText("Name Goes Here");
    _playerCharacterHpText.SetText($"HP: {page.Hero.Attributes.MaxHp}");
  }

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
