using GameControllers.MonoBehControllers;
using GameControllers.Properties;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Ecs
{
    public class EntityGameItemReference : MonoBehaviour
    {
        public EcsEntity Entity;
        public ItemType ItemType;
        public CollisionItems CollisionItems;
        public ParticleItems ParticleItems;
    }
}

