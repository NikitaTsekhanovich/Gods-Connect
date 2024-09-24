using GameControllers.Components;
using GameControllers.Components.AbilitiesComponents;
using GameControllers.MonoBehControllers.UIControllers;
using Leopotam.Ecs;
using SpellItems;
using StoreControllers;
using UnityEngine;

namespace GameControllers.Systems.AbilitiesSystems
{
    public class ScoreAbilitySystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private StoreItemData _characterData;
        private UIContainer _uiContainer;
        private readonly EcsFilter<ScoreAbilityComponent> _scoreAbilityFilter = null;

        public void Run()
        {
            foreach (var i in _scoreAbilityFilter)
            {
                var scoreBomb = _characterData.PrefabAbility.GetComponent<ScoreBomb>();

                ref var entity = ref _scoreAbilityFilter.GetEntity(i);

                var increasingCoefficientValue = scoreBomb.Coefficient;
                var duration = scoreBomb.Duration;
                _uiContainer.UIScore.StartAnimScoreText(increasingCoefficientValue, duration);

                _world.NewEntity().Get<CoefficientComponent>().Coefficient = increasingCoefficientValue;

                entity.Del<ScoreAbilityComponent>();
            }
        }
    }
}

