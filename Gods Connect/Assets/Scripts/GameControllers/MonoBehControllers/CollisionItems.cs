using System.Collections.Generic;
using GameControllers.Ecs;
using UnityEngine;

namespace GameControllers.MonoBehControllers
{
    public class CollisionItems : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _collider;
        private HashSet<EntityGameItemReference> _neighboringItems = new();
        private string _gameFieldTag = "GameField";

        public HashSet<EntityGameItemReference> NeighboringItems { get => _neighboringItems; }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<EntityGameItemReference>(out var entityReference))
                _neighboringItems.Add(entityReference);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<EntityGameItemReference>(out var entityReference))
                _neighboringItems.Remove(entityReference);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(_gameFieldTag))
                _collider.enabled = true;
        }
    }
}

