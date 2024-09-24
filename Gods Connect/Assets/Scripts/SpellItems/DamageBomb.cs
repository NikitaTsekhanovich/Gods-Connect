using System.Collections.Generic;
using GameControllers.Components;
using GameControllers.Ecs;
using Leopotam.Ecs;
using UnityEngine;

namespace SpellItems
{
    public class DamageBomb : MonoBehaviour
    {
        [SerializeField] public ParticleSystem ExplosionParticle;

        [SerializeField] private CircleCollider2D _radiusCollider;
        [SerializeField] private bool _isVoidBomb;
        private HashSet<EntityGameItemReference> _neighboringItems = new();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<EntityGameItemReference>(out var entityReference))
                _neighboringItems.Add(entityReference);
        }

        public void DestroyItems(EcsWorld world)
        {
            var currentNeighbors = _neighboringItems.Count;

            foreach (var neighbor in _neighboringItems)
            {
                if (neighbor != null)
                    Destroy(neighbor.gameObject);
                else
                    currentNeighbors--;
            }

            if (!_isVoidBomb)
            {
                world.NewEntity().Get<EnergyComponent>().AmountDestroyItems = currentNeighbors;
                world.NewEntity().Get<ScoreComponent>().DestroyableItems = currentNeighbors;
                world.NewEntity().Get<CoinComponent>().DestroyableItems = currentNeighbors;
            }

            world.GetPool<SpawnerComponent>().GetItem(0).CurrentAmountItems -= currentNeighbors;
        }

        public void OnRadiusCollision()
        {
            _radiusCollider.enabled = true;
        }
    }
}

