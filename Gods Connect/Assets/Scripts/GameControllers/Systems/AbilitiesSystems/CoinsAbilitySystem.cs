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
    public class CoinsAbilitySystem : IEcsRunSystem
    {
        private SoundsContainer _soundsContainer;
        private EcsWorld _world;
        private StoreItemData _characterData;
        private UIContainer _uiContainer;
        private readonly EcsFilter<CoinsAbilityComponent> _coinsAbilityFilter = null;

        public void Run()
        {
            foreach (var i in _coinsAbilityFilter)
            {
                ref var entity = ref _coinsAbilityFilter.GetEntity(i);

                var amountCoins = _characterData.PrefabAbility.GetComponent<GoldBomb>().AmountCoins;
                _world.NewEntity().Get<CoinComponent>().DestroyableItems = amountCoins;
                _uiContainer.UICoins.StartAnimationCoins(
                    amountCoins, 
                    _characterData.PrefabAbility,
                    _uiContainer.UICharacterIcon.GetIconCharacterTransform(),
                    _soundsContainer.ExplosionSound);

                entity.Del<CoinsAbilityComponent>();
            }
        }
    }
}

