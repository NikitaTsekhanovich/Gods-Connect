using System.Collections.Generic;
using DG.Tweening;
using GameControllers.Components;
using GameControllers.Ecs;
using GameControllers.MonoBehControllers;
using GameControllers.Properties;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class SeekNeighborsSystem : IEcsRunSystem
    {
        private SoundsContainer _soundsContainer;
        private EcsWorld _world;
        private readonly EcsFilter<SeekerNeighborsComponent> _seekerNeighborsFilter = null;

        public void Run()
        {
            foreach (var i in _seekerNeighborsFilter)
            {
                ref var entity = ref _seekerNeighborsFilter.GetEntity(i);
                ref var seekerNeighborsComponent = ref _seekerNeighborsFilter.Get1(i);
                ref var entityReference = ref seekerNeighborsComponent;
                ref var entityGameItemReference = ref seekerNeighborsComponent.EntityGameItemReference;
                ref var entityGoalReference = ref seekerNeighborsComponent.EntityGoalReference;

                if (entityGameItemReference != null &&
                    entityGameItemReference.Entity != EcsEntity.Null)
                    CheckNearbyItems(entityGameItemReference, entityGoalReference);

                entity.Del<SeekerNeighborsComponent>();
            }
        }

        private void CheckNearbyItems(
            EntityGameItemReference targetEntity, 
            EntityGoalReference entityGoalReference)
        {
            var destroyableItems = new HashSet<EntityGameItemReference>{ targetEntity };

            DFS(destroyableItems, targetEntity.ItemType, targetEntity.CollisionItems.NeighboringItems);

            if (destroyableItems.Count > 1)
            {
                entityGoalReference.Entity
                    .Replace(new DestroyableItemsInfoComponent() 
                    {
                        CurrentItemType = targetEntity.ItemType,
                        CurrentAmountDestroyItems = destroyableItems.Count
                    });
                
                _world.NewEntity().Get<EnergyComponent>().AmountDestroyItems = destroyableItems.Count;
                _world.NewEntity().Get<ScoreComponent>().DestroyableItems = destroyableItems.Count;
                _world.NewEntity().Get<CoinComponent>().DestroyableItems = destroyableItems.Count;
                DestroyItems(destroyableItems);
            }
        }

        private void DFS(HashSet<EntityGameItemReference> destroyableItems, ItemType targetEntityType, HashSet<EntityGameItemReference> neighboringItems)
        {
            foreach (var neighbour in neighboringItems)
            {
                if (targetEntityType == neighbour.ItemType && !destroyableItems.Contains(neighbour))
                {
                    destroyableItems.Add(neighbour);
                    DFS(destroyableItems, targetEntityType, neighbour.CollisionItems.NeighboringItems);
                }
            }
        }

        private void DestroyItems(HashSet<EntityGameItemReference> destroyableItems)
        {
            foreach (var destroyableItem in destroyableItems)
            {
                // зависает и вылетает unity
                // destroyableItem.ParticleItems.StartDestryableParticle();
                var transformItem = destroyableItem.gameObject.transform;
                _soundsContainer.DestroyItemSound.Play();

                DOTween.Sequence()
                    .Append(transformItem.DOScale(Vector3.zero, 0.5f))
                    .AppendCallback(() => destroyableItem.Entity.Get<DestroyableComponent>());
            }
        }
    }
}

