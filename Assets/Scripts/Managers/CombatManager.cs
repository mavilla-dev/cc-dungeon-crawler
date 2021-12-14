using Assets.External;
using Assets.Scripts.Core;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Managers
{
  public class CombatManager : Singleton<CombatManager>
  {
    List<Creature> _playerCreatures = null;
    List<Creature> _enemyCreatures = null;
    int MAX_PLAYER_SLOTS = 3;
    int MAX_ENEMY_COUNT = 3;

    public new void Awake()
    {
      base.Awake();
      CombatEvents.Instance.EventAttackButtonClick += TriggerAttack;
      CombatEvents.Instance.EventSceneLoadComplete += OnSceneLoadComplete;
    }

    private void OnDestroy()
    {
      CombatEvents.Instance.EventAttackButtonClick -= TriggerAttack;
      CombatEvents.Instance.EventSceneLoadComplete -= OnSceneLoadComplete;
    }

    private void OnSceneLoadComplete()
    {
      _playerCreatures = GenerateCreatures(1);
      _enemyCreatures = GenerateCreatures(2);

      SendSetActiveEventForUnitSlots(_playerCreatures, MAX_PLAYER_SLOTS, true);
      SendSetActiveEventForUnitSlots(_enemyCreatures, MAX_ENEMY_COUNT, false);

      UpdateUnitStats(_playerCreatures, true);
      UpdateUnitStats(_enemyCreatures, false);
    }

    private void UpdateUnitStats(List<Creature> playerCreatures, bool isPlayer)
    {
      for (int index = 0; index < playerCreatures.Count; index++)
      {
        var creature = playerCreatures[index];
        CombatEvents.Instance.UpdateUnitStats(new EventUpdateUnitStats
        {
          HP = creature.Hp,
          IsPlayerUnit = isPlayer,
          MaxHP = creature.MaxHp,
          MP = 0,
          PlayerSlotId = index,
          UnitName = creature.Name,
        });
      }
    }

    private void SendSetActiveEventForUnitSlots(
      List<Creature> creatures,
      int maxSlots,
      bool isPlayer)
    {
      for (int index = 0; index < maxSlots; index++)
      {
        CombatEvents.Instance.SetActiveForSlotId(new SetActiveForSlotIdArgs
        {
          IsActive = creatures.ElementAtOrDefault(index) != null,
          IsPlayerUnit = isPlayer,
          PlayerSlotId = index,
        });
      }
    }

    private List<Creature> GenerateCreatures(int amount)
    {
      var creatureList = new List<Creature>();
      for (int index = 0; index < amount; index++)
      {
        var hp = UnityRandom.GetRange(40, 60);
        creatureList.Add(new Creature
        {
          Name = $"Unit: {index}",
          Hp = hp,
          MaxHp = hp,
          MaxMp = 8,
          Alignment = UnityRandom.GetRandomEnum<MagicType>(),
          Attack = UnityRandom.GetRange(40, 60),
          Defense = UnityRandom.GetRange(40, 60),
          SpecialAttack = UnityRandom.GetRange(40, 60),
          SpecialDefense = UnityRandom.GetRange(40, 60),
        });
      }

      return creatureList;
    }

    private void TriggerAttack()
    {
      Debug.Log("Attack button clicked");
    }
  }
}
