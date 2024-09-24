using GameControllers.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class EntityInitializeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InitializeEntityGameItemRequest> _initEntityGameItemFilter = null;
        private readonly EcsFilter<InitializeSeekerRequest> _initSeekerFilter = null;
        private readonly EcsFilter<InitializeGoalRequest> _initGoalFilter = null;

        public void Run()
        {
            foreach (var i in _initEntityGameItemFilter)
            {
                ref var entity = ref _initEntityGameItemFilter.GetEntity(i);
                ref var request = ref _initEntityGameItemFilter.Get1(i);

                request.EntityGameItemReference.Entity = entity;
                // entity.Del<InitializeEntityRequest>();
            }
            foreach (var i in _initSeekerFilter)
            {
                ref var entity = ref _initSeekerFilter.GetEntity(i);
                ref var request = ref _initSeekerFilter.Get1(i);

                request.EntitySeekerReference.Entity = entity;
                // entity.Del<InitializeEntityRequest>();
            }
            foreach (var i in _initGoalFilter)
            {
                ref var entity = ref _initGoalFilter.GetEntity(i);
                ref var request = ref _initGoalFilter.Get1(i);

                request.EntityGoalReference.Entity = entity;
                // entity.Del<InitializeEntityRequest>();
            }
        }
    }
}

