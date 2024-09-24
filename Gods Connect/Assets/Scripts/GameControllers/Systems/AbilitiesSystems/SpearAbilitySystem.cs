using GameControllers.Components.AbilitiesComponents;
using GameControllers.Ecs;
using GameControllers.MonoBehControllers;
using GameControllers.MonoBehControllers.UIControllers;
using Leopotam.Ecs;
using SpellItems;
using StoreControllers;
using UnityEngine;

namespace GameControllers.Systems.AbilitiesSystems
{
    public class SpearAbilitySystem : IEcsRunSystem
    {
        private EntityGoalReference _entityGoalReference;
        private SoundsContainer _soundsContainer;
        private EcsWorld _world;
        private UIContainer _uiContainer;
        private RunTimeDataContainer _runTimeDataContainer;
        private StoreItemData _characterData;
        private readonly EcsFilter<SpearAbilityComponent> _spearAbilityFilter = null;

        public void Run()
        {
            foreach (var i in _spearAbilityFilter)
            {
                ref var entity = ref _spearAbilityFilter.GetEntity(i);
                ref var spearAbilityComponent = ref _spearAbilityFilter.Get1(i);
                var spawnPosition = _runTimeDataContainer.SpawnPointSpear;

                var spear = SpawnerGameObjects.GetInstatinateObject(
                    _characterData.PrefabAbility,
                    spawnPosition,
                    spawnPosition
                );
                spear.GetComponent<Spear>().InitSpearData(
                    _world, 
                    _uiContainer.UIGameField, 
                    _soundsContainer.ShakeGameFieldSound,
                    _entityGoalReference);

                entity.Del<SpearAbilityComponent>();
            }
        }
    }
}

