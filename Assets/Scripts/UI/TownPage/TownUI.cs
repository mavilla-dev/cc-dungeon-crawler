using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MadDudeStudios.MobileDungeonCrawler.Domain.TownPage
{
  public class TownUI : MonoBehaviour
  {
    [SerializeField] Button _diveButton;

    private void Awake()
    {
      _diveButton.onClick.AddListener(() => SceneManager.LoadScene("Combat"));
    }
  }
}