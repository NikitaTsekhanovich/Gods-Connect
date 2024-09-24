using GameControllers.Components;
using Leopotam.Ecs;
using LevelControllers;
using UnityEngine;

namespace GameControllers.Systems
{
    public class ScoreSystem : IEcsRunSystem
    {
        private LevelData _levelData;
        private readonly EcsFilter<ScoreComponent> _scoreFilter = null;
        private readonly EcsFilter<CoefficientComponent> _coefficientFilter = null;
        private int _amountScore;
        private int _coefficient = 1;
        private const float durationIncreasedCoefficient = 5f;
        private float _currentDuration = durationIncreasedCoefficient;

        public void Run()
        {
            foreach (var i in _coefficientFilter)
            {
                ref var entity = ref _coefficientFilter.GetEntity(i);
                ref var coefficientComponent = ref _coefficientFilter.Get1(i);

                _coefficient = coefficientComponent.Coefficient;

                _currentDuration -= Time.deltaTime;

                if (_currentDuration <= 0)
                {
                    _coefficient = 1;
                    _currentDuration = durationIncreasedCoefficient;
                    entity.Del<CoefficientComponent>();
                }
            }
            foreach (var i in _scoreFilter)
            {
                ref var entity = ref _scoreFilter.GetEntity(i);
                ref var scoreComponent = ref _scoreFilter.Get1(i);

                var enlargerScore = ScoreComponent.EnlargerScore;
                ref var destroyableItems = ref scoreComponent.DestroyableItems;

                IncreaseScore(enlargerScore, destroyableItems);

                entity.Del<ScoreComponent>();
            }
        }

        private void IncreaseScore(int enlargerScore, int destroyableItems)
        {
            var currentScore = destroyableItems;

            if (destroyableItems >= 20)
                currentScore *= 15;
            else if (destroyableItems >= 18)
                currentScore *= 13;
            else if (destroyableItems >= 16)
                currentScore *= 11;
            else if (destroyableItems >= 14)
                currentScore *= 10;
            else if (destroyableItems >= 12)
                currentScore *= 8;
            else if (destroyableItems >= 10)
                currentScore *= 7;
            else if (destroyableItems >= 7)
                currentScore *= 5;
            else if (destroyableItems >= 5)
                currentScore *= 3;
            else if (destroyableItems >= 3)
                currentScore *= 2;

            currentScore *= enlargerScore * _coefficient;

            _amountScore += currentScore;
            var currentBestScore = PlayerPrefs.GetInt($"{LevelProgressDataKeys.BestScoreLevelKey}{_levelData.Index}");

            if (_amountScore > currentBestScore)
            {
                PlayerPrefs.SetInt($"{LevelProgressDataKeys.BestScoreLevelKey}{_levelData.Index}", _amountScore);
            }
        }
    }
}
