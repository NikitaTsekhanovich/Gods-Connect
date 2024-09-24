using GameControllers.Components;
using GameControllers.Components.AbilitiesComponents;
using GameControllers.MonoBehControllers;
using GameControllers.MonoBehControllers.UIControllers;
using Leopotam.Ecs;
using SpellItems;
using StoreControllers;
using UnityEngine;

namespace GameControllers.Systems.AbilitiesSystems
{
    public class TimerAbilitySystem : IEcsRunSystem
    {
        private SoundsContainer _soundsContainer;
        private StoreItemData _characterData;
        private EcsWorld _world;
        private readonly EcsFilter<TimerAbilityComponent> _timerAbilityFilter = null;
        private UIContainer _uiContainer;

        public void Run()
        {
            foreach (var i in _timerAbilityFilter)
            {
                var timerBomb = _characterData.PrefabAbility.GetComponent<TimerBomb>();

                ref var entity = ref _timerAbilityFilter.GetEntity(i);

                var increasingTimeValue = timerBomb.IncreasingTimeValue;
                timerBomb.SpawnSpell(
                    _uiContainer.UICharacterIcon.GetIconCharacterTransform(), 
                    _uiContainer.UITimer.GetTimerTextTransform(),
                    _uiContainer.UITimer.GetTimerTransform(),
                    _soundsContainer.ExplosionSound);

                _world.GetPool<TimerComponent>().GetItem(0).CurrentTimeValue += increasingTimeValue;

                _uiContainer.UITimer.IncreaseTimerAnimation();

                entity.Del<TimerAbilityComponent>();
            }
        }
    }
}

