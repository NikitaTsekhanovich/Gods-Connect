using GameControllers.Components;
using GameControllers.Components.AbilitiesComponents;
using GameControllers.Ecs;
using GameControllers.MonoBehControllers;
using GameControllers.MonoBehControllers.UIControllers;
using Leopotam.Ecs;
using StoreControllers;
using UnityEngine;

namespace GameControllers.Systems.AbilitiesSystems
{
    public class DamageBombAbilitySystem : IEcsRunSystem
    {
        private EntityGoalReference _entityGoalReference;
        private SoundsContainer _soundsContainer;
        private EcsWorld _world;
        private UIContainer _uiContainer;
        private StoreItemData _characterData;
        private readonly EcsFilter<WhiteBombAbilityComponent> _damageBombAbilityFilter = null;

        public void Run()
        {
            foreach (var i in _damageBombAbilityFilter)
            {
                ref var entity = ref _damageBombAbilityFilter.GetEntity(i);

                _uiContainer.UIGameField.StartBombAnimation(
                    _characterData.PrefabAbility,
                    _uiContainer.UICharacterIcon.GetIconCharacterTransform(),
                    _world,
                    _soundsContainer.ExplosionSound,
                    _soundsContainer.ShakeGameFieldSound);

                entity.Del<WhiteBombAbilityComponent>();
            } 
        }
    }
}

