using GameControllers.Components;
using GameControllers.MonoBehControllers;
using GameControllers.MonoBehControllers.UIControllers;
using Leopotam.Ecs;
using LevelControllers;
using StoreControllers;
using UnityEngine;

namespace GameControllers.Systems
{
    public class TimerSystem : IEcsRunSystem, IEcsInitSystem
    {
        private SoundsContainer _soundsContainer;
        private UIContainer _uiContainer;
        private StoreItemData _characterData;
        private LevelData _levelData;
        private readonly EcsFilter<TimerComponent> _timerFilter = null;

        public void Init()
        {
            foreach (var i in _timerFilter)
            {
                ref var timerComponent = ref _timerFilter.Get1(i);

                ref var currentTimeValue = ref timerComponent.CurrentTimeValue;
                currentTimeValue = TimerComponent.StartTimerValue;
            }
        }

        public void Run()
        {
            foreach (var i in _timerFilter)
            {
                ref var entity = ref _timerFilter.GetEntity(i);
                ref var timerComponent = ref _timerFilter.Get1(i);

                ref var currentTimeValue = ref timerComponent.CurrentTimeValue;

                StartTimer(ref currentTimeValue, entity);
            }
        }

        private void StartTimer(ref float currentTimeValue, EcsEntity entity)
        {
            currentTimeValue -= Time.deltaTime;
            _uiContainer.UITimer.UpdateScoreText(currentTimeValue);

            if (currentTimeValue <= 0)
            {
                _soundsContainer.EndGameSound.Play();
                _uiContainer.EndGameScreen.UpdateEndScreenData(_characterData.CharacterSprite, _levelData.Index);
                _uiContainer.EndGameScreen.Show();
                entity.Del<TimerComponent>();
            }
        }
    }
}

