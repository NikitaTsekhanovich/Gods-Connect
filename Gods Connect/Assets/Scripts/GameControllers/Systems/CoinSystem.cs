using GameControllers.Components;
using Leopotam.Ecs;
using StoreControllers;
using UnityEngine;

namespace GameControllers.Systems
{
    public class CoinSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CoinComponent> _coinFilter;

        public void Run()
        {
            foreach (var i in _coinFilter)
            {
                ref var entity = ref _coinFilter.GetEntity(i);
                ref var coinComponent = ref _coinFilter.Get1(i);

                ref var coins = ref coinComponent.DestroyableItems;

                IncreaseCoins(coins);

                entity.Del<CoinComponent>();
            }
        }

        private void IncreaseCoins(int coins)
        {
            var currentCoins = PlayerPrefs.GetInt(StoreDataKeys.CoinsDataKey);
            PlayerPrefs.SetInt(StoreDataKeys.CoinsDataKey, currentCoins + coins);
        }
    }
}

