using System.Collections.Generic;
using GameControllers.Components;
using GameControllers.Ecs;
using GameControllers.MonoBehControllers.UIControllers;
using Leopotam.Ecs;
using UnityEngine;

namespace SpellItems
{
    public class Spear : MonoBehaviour
    {
        private EntityGoalReference _entityGoalReference;
        private EcsWorld _world;
        private UIGameField _uiGameField;
        private AudioSource _shakeGameFieldSound;
        private bool isFirstDestroy = true;
        private HashSet<EntityGameItemReference> _neighboringItems = new();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<EntityGameItemReference>(out var entityReference) &&
                !_neighboringItems.Contains(entityReference))
            {
                if (isFirstDestroy)
                {
                    _uiGameField.ShakeGameField(_shakeGameFieldSound);
                    isFirstDestroy = false;
                }
                _neighboringItems.Add(entityReference);
                _entityGoalReference.Entity
                    .Replace(new DestroyableItemsInfoComponent() 
                    {
                        CurrentItemType = entityReference.ItemType,
                        CurrentAmountDestroyItems = 1
                    });
                Destroy(entityReference.gameObject);
                _world.NewEntity().Get<EnergyComponent>().AmountDestroyItems = 1;
                _world.NewEntity().Get<ScoreComponent>().DestroyableItems = 1;
                _world.NewEntity().Get<CoinComponent>().DestroyableItems = 1;
                _world.GetPool<SpawnerComponent>().GetItem(0).CurrentAmountItems -= 1;
            }
        }

        public void InitSpearData(
            EcsWorld world, 
            UIGameField uiGameField, 
            AudioSource shakeGameFieldSound,
            EntityGoalReference entityGoalReference)
        {
            _world = world;
            _uiGameField = uiGameField;
            _shakeGameFieldSound = shakeGameFieldSound;
            _entityGoalReference = entityGoalReference;
        }
    }
}

