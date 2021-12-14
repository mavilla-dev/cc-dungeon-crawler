using MadDudeStudios.MobileDungeonCrawler.Domain.HeroSelection;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MadDudeStudios.MobileDungeonCrawler.UI
{
  public class HeroSelectUI : MonoBehaviour
  {
    [SerializeField] Button _prevButton;
    [SerializeField] Button _nextButton;
    [SerializeField] Button _selectButton;
    [SerializeField] TextMeshProUGUI _textPage;
    [SerializeField] TextMeshProUGUI _textLv;
    [SerializeField] TextMeshProUGUI _textHp;
    [SerializeField] TextMeshProUGUI _textAlignment;
    [SerializeField] TextMeshProUGUI _textAtk;
    [SerializeField] TextMeshProUGUI _textDef;
    [SerializeField] TextMeshProUGUI _textSpAtk;
    [SerializeField] TextMeshProUGUI _textSpDef;

    HeroSelectionProcessor _processor;
    HeroSelectionPage _page;

    void Awake()
    {
      _processor = new HeroSelectionProcessor();
      _page = _processor.GetHeroSelectionPage();

      _nextButton.onClick.AddListener(() => UpdatePage(_page.PageNumber + 1));
      _prevButton.onClick.AddListener(() => UpdatePage(_page.PageNumber - 1));
      _selectButton.onClick.AddListener(OnSelectButtonClick);
    }

    void OnEnable()
    {
      UpdatePage(_page.PageNumber);
    }

    private void OnSelectButtonClick()
    {
      _processor.SaveHero(_page.ActiveHero);
      SceneManager.LoadSceneAsync("Town");
    }

    private void UpdatePage(int newPageNumber)
    {
      _page.PageNumber = newPageNumber;

      if (newPageNumber < 1)
      {
        _page.PageNumber = 1;
      }
      if (newPageNumber > _page.Heroes.Count())
      {
        _page.PageNumber = _page.Heroes.Count();
      }

      _page.ActiveHero = _page.Heroes.ElementAt(_page.PageNumber - 1);
      _prevButton.enabled = _page.PageNumber > 1;
      _nextButton.enabled = _page.PageNumber < _page.Heroes.Count();

      _textPage.text = $"Page: {_page.PageNumber}/{_page.Heroes.Count()}";
      _textLv.text = $"Lv: {_page.ActiveHero.HeroInfo.Attributes.Level}";
      _textHp.text = $"Hp: {_page.ActiveHero.HeroInfo.Attributes.Hp}";
      _textAlignment.text = $"Aligment: {_page.ActiveHero.HeroInfo.Attributes.Alignment}";
      _textAtk.text = $"Atk: {_page.ActiveHero.HeroInfo.Attributes.Attack}";
      _textDef.text = $"Def: {_page.ActiveHero.HeroInfo.Attributes.Defense}";
      _textSpAtk.text = $"SpAtk: {_page.ActiveHero.HeroInfo.Attributes.SpecialAttack}";
      _textSpDef.text = $"SpDef: {_page.ActiveHero.HeroInfo.Attributes.SpecialDefense}";
    }
  }
}
