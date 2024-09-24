using GameControllers.Components;
using GameControllers.Ecs;
using GameControllers.MonoBehControllers.UIControllers;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class InputSystem : IEcsRunSystem
    {
        private UIContainer _uiContainer;
        private readonly EcsFilter<CacherEntityReferenceComponent> _inputFilter = null;

        public void Run()
        {
            CheckClickOnItem();
        }

        private void CheckClickOnItem()
        {
            if (Input.GetMouseButtonDown(0) && 
                !_uiContainer.PauseController.GameIsPaused &&
                !_uiContainer.EndGameScreen.GameIsEnd)
            {
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                var hit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hit.collider != null && 
                    hit.collider.TryGetComponent<EntityGameItemReference>(out var entityReference))
                {
                    foreach (var i in _inputFilter)
                    {
                        ref var cacherEntityReferenceComponent = ref _inputFilter.Get1(i);
                        ref var entitySeekerReference = ref cacherEntityReferenceComponent.EntitySeekerReference;
                        ref var entityGoalReference = ref cacherEntityReferenceComponent.EntityGoalReference;

                        entitySeekerReference.Entity
                            .Replace(new SeekerNeighborsComponent() 
                            {
                                EntityGameItemReference = entityReference,
                                EntityGoalReference = entityGoalReference
                            });
                    }
                }
            }
        }
    }
}

