using GameControllers.Components;
using GameControllers.Components.AbilitiesComponents;
using GameControllers.MonoBehControllers;
using GameControllers.Properties;
using Leopotam.Ecs;
using StoreControllers;
using UnityEngine;

namespace GameControllers.Systems
{
    public class AbilitySystem : IEcsRunSystem
    {
        private SoundsContainer _soundsContainer;
        private EcsWorld _world;
        private StoreItemData _characterData;
        private readonly EcsFilter<AbilityComponent> _abilityFilter = null;

        public void Run()
        {
            foreach (var i in _abilityFilter)
            {
                ref var entity = ref _abilityFilter.GetEntity(i);
                ref var energyComponent = ref _abilityFilter.Get1(i);

                ChooseCharacterAbility(_characterData.ItemType);

                entity.Del<AbilityComponent>();
            }
        }

        private void ChooseCharacterAbility(ItemType itemType)
        {
            _soundsContainer.GranadeSpawnSound.Play();

            switch (itemType)
            {
                case ItemType.Orange:
                    _world.NewEntity().Get<TimerAbilityComponent>();
                    break;
                case ItemType.Blue:
                    _world.NewEntity().Get<ScoreAbilityComponent>();
                    break;
                case ItemType.Yellow:
                    _world.NewEntity().Get<CoinsAbilityComponent>();
                    break;
                case ItemType.White:
                    _world.NewEntity().Get<WhiteBombAbilityComponent>();
                    break;
                case ItemType.Purple:
                    _world.NewEntity().Get<TimerAbilityComponent>();
                    break;
                case ItemType.LightBlue:
                    _world.NewEntity().Get<ScoreAbilityComponent>();
                    break;
                case ItemType.DarkGreen:
                    _world.NewEntity().Get<WhiteBombAbilityComponent>();
                    break;
                case ItemType.Turquoise:
                    _world.NewEntity().Get<SpearAbilityComponent>();
                    break;
            }
        }
    }
}

