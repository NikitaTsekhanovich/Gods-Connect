using System.Collections.Generic;
using GameControllers.Components;
using GameControllers.MonoBehControllers;
using Leopotam.Ecs;
using LevelControllers;
using UnityEngine;

namespace GameControllers.Systems
{
    public class SpawnSystem : IEcsRunSystem
    {
        private LevelData _levelData;
        private readonly EcsFilter<SpawnerComponent> _spawnerFilter = null;

        public void Run()
        {
            foreach (var i in _spawnerFilter)
            {
                ref var spawnerComponent = ref _spawnerFilter.Get1(i);

                var maxItemsAmount = SpawnerComponent.MaxItemsAmount;
                ref var spawnPoints = ref spawnerComponent.SpawnPoints;
                ref var currentAmountItems = ref spawnerComponent.CurrentAmountItems;
                ref var parentComponent = ref spawnerComponent.ParentComponent;

                var prefabItems = new List<GameObject> (_levelData.Items);

                SpawnItems(spawnPoints, maxItemsAmount, prefabItems, parentComponent, ref currentAmountItems);
            }
        }
        
        private void SpawnItems(List<Transform> spawnPoints, int maxItemsAmount, List<GameObject> prefabItems, Transform parentComponent, ref int currentAmountItems)
        {
            if (currentAmountItems <= maxItemsAmount)
            {
                var randomIndexSpawn = Random.Range(0, spawnPoints.Count);
                var randomIndexPrefab = Random.Range(0, prefabItems.Count);

                SpawnerGameObjects.GetInstatinateObject(prefabItems[randomIndexPrefab], spawnPoints[randomIndexSpawn], parentComponent);
                currentAmountItems++;
            }
        }
    }
}

