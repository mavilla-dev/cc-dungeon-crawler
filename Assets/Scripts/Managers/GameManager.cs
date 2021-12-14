using Assets.External;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
  public class GameManager : Singleton<GameManager>
  {
    private static readonly string SCENE_COMBAT_UI = "CombatUI";
    private static readonly string SCENE_COMBAT_WORLD = "CombatWorld";
    private static readonly string SCENE_TOWN_UI = "TownUI";
    private static readonly string SCENE_TOWN_WORLD = "TownWorld";

    private readonly string[] COMBAT_SCENES = new string[] { SCENE_COMBAT_UI, SCENE_COMBAT_WORLD };
    private readonly string[] TOWN_SCENES = new string[] { SCENE_TOWN_WORLD, SCENE_TOWN_UI };

    private GameScene _activeScene = GameScene.Boot;

    protected override void Awake()
    {
      base.Awake();
      SceneManagerEvents.Instance.OnLoadScene += OnLoadScene;
    }

    private void OnLoadScene(GameScene scene)
    {
      UnloadScene(_activeScene);
      LoadScene(scene);
    }

    private void LoadScene(GameScene scene)
      => ModifyGameSceneLoadState(scene, true);

    private void UnloadScene(GameScene scene)
      => ModifyGameSceneLoadState(scene, false);

    private void ModifyGameSceneLoadState(GameScene scene, bool shouldLoad)
    {
      switch (scene)
      {
        case GameScene.Boot:
          // Intenionally do nothing
          return;

        case GameScene.Town:
          LoadOrUnloadScene(TOWN_SCENES, shouldLoad);
          // StartCoroutine(NotifyTownManagerOfLoadComplete(operations));
          return;

        case GameScene.Combat:
          var combatOperations = LoadOrUnloadScene(COMBAT_SCENES, shouldLoad);
          StartCoroutine(NotifyCombatManagerOfLoadComplete(combatOperations));
          return;

        default:
          Debug.LogException(new NotImplementedException(nameof(scene)));
          break;
      }
    }

    private IEnumerator NotifyCombatManagerOfLoadComplete(IEnumerable<AsyncOperation> operations)
    {
      var continueLoop = true;
      while (continueLoop)
      {
        yield return new WaitForSeconds(1);
        var isLoadingDone = operations.All(x => x.isDone);
        continueLoop = !isLoadingDone;
      }

      CombatEvents.Instance.SceneLoadIsComplete();
    }

    private IEnumerable<AsyncOperation> LoadOrUnloadScene(string[] sceneNames, bool shouldLoad)
    {
      return sceneNames.Select(sceneName =>
      {
        return shouldLoad
          ? SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive)
          : SceneManager.UnloadSceneAsync(sceneName);
      }).ToArray();
    }
  }
}
