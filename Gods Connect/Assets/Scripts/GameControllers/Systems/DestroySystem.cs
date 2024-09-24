using GameControllers.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class DestroySystem : IEcsRunSystem
    {
        private readonly EcsFilter<InitializeEntityGameItemRequest, DestroyableComponent> _destroyFilter = null;
        private readonly EcsFilter<SpawnerComponent> _spawnerFilter = null;

        public void Run()
        {
            foreach (var i in _spawnerFilter)
            {
                ref var spawnerComponent = ref _spawnerFilter.Get1(i);
                ref var currentAmountItems = ref spawnerComponent.CurrentAmountItems;

                foreach (var j in _destroyFilter)
                {
                    ref var entity = ref _destroyFilter.GetEntity(j);
                    ref var initializeEntity = ref _destroyFilter.Get1(j);

                    if (initializeEntity.EntityGameItemReference != null)
                    {
                        currentAmountItems--;
                        UnityEngine.Object.Destroy(initializeEntity.EntityGameItemReference.gameObject);
                    }
                    entity.Destroy();
                }
            }
        }
    }
}
