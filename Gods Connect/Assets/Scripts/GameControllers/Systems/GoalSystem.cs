using System.Collections.Generic;
using GameControllers.Components;
using GameControllers.MonoBehControllers;
using GameControllers.MonoBehControllers.UIControllers;
using GameControllers.Properties;
using Leopotam.Ecs;
using LevelControllers;
using UnityEngine;

namespace GameControllers.Systems
{
    public class GoalSystem : IEcsRunSystem, IEcsInitSystem
    {
        private SoundsContainer _soundsContainer;
        private readonly EcsFilter<GoalComponent> _goalFilter = null;
        private readonly EcsFilter<DestroyableItemsInfoComponent> _destroyableItemsInfoFilter = null;
        private UIContainer _uiContainer;
        private LevelData _levelData;

        public void Init()
        {
            _uiContainer.UIGoal.LoadGoal(_levelData.GoalsData);
            InitGoals(_levelData.GoalsData);
        }

        public void Run()
        {
            foreach (var i in _goalFilter)
            {
                ref var entity = ref _goalFilter.GetEntity(i);
                ref var goalComponent = ref _goalFilter.Get1(i);

                ref var itemTypes = ref goalComponent.ItemTypes;
                ref var amountsGoal = ref goalComponent.AmountsGoal;
                ref var completedGoals = ref goalComponent.CompletedGoals;

                foreach (var j in _destroyableItemsInfoFilter)
                {
                    ref var itemTypeComponent = ref _destroyableItemsInfoFilter.Get1(j);

                    ref var currentItemType = ref itemTypeComponent.CurrentItemType;
                    ref var currentAmountDestroyItems = ref itemTypeComponent.CurrentAmountDestroyItems;
                    
                    CheckItemType(
                        currentItemType, 
                        currentAmountDestroyItems, 
                        itemTypes, 
                        amountsGoal, 
                        completedGoals);

                    entity.Del<DestroyableItemsInfoComponent>();
                }
            }
        }

        private void UpdateUIGoal(List<int> amountsGoal)
        {
            _uiContainer.UIGoal.UpdateGoal(amountsGoal);
        }

        private void InitGoals(List<GoalData> goalsData)
        {
            foreach (var i in _goalFilter)
            {
                ref var goalComponent = ref _goalFilter.Get1(i);

                ref var itemTypes = ref goalComponent.ItemTypes;
                ref var amountsGoal = ref goalComponent.AmountsGoal;
                ref var completedGoals = ref goalComponent.CompletedGoals;

                foreach (var goalData in goalsData)
                {
                    itemTypes.Add(goalData.ItemType);
                    amountsGoal.Add(goalData.Amount);
                    completedGoals.Add(false);
                }
            }
        }

        private void CheckItemType(
            ItemType currentItemType, 
            int currentAmountDestroyItems, 
            List<ItemType> itemTypes, 
            List<int> amountsGoal, 
            List<bool> completedGoals)
        {
            if (currentAmountDestroyItems != 0)
            {
                var index = 0;
                foreach (var itemType in itemTypes)
                {
                    if (itemType == currentItemType && amountsGoal[index] > 0)
                    {
                        amountsGoal[index] -= currentAmountDestroyItems;

                        if (amountsGoal[index] <= 0)
                        {
                            _soundsContainer.GoalCompletedSound.Play();
                            completedGoals[index] = true;
                            amountsGoal[index] = 0;
                        }

                        UpdateUIGoal(amountsGoal);
                        break;
                    }
                    index++;
                }
            }

            CheckCompletedGoal(completedGoals);
        }

        private void CheckCompletedGoal(List<bool> completedGoals)
        {
            var isCompleted = true;

            foreach (var completedGoal in completedGoals)
                isCompleted &= completedGoal;

            if (isCompleted)
            {
                PlayerPrefs.SetInt($"{LevelProgressDataKeys.GoalIsCompletedKey}{_levelData.Index}", (int)TypeGoal.Completed);
                PlayerPrefs.SetInt($"{LevelProgressDataKeys.LevelIsOpenKey}{_levelData.Index + 1}", (int)TypeLevel.IsOpen);
            }
        }
    }
}

