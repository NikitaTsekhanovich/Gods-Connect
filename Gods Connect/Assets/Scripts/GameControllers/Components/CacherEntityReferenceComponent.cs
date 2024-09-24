using System;
using GameControllers.Ecs;
using UnityEngine;

namespace GameControllers.Components
{
    [Serializable]
    public struct CacherEntityReferenceComponent
    {
        public EntitySeekerReference EntitySeekerReference;
        public EntityGoalReference EntityGoalReference;
    }
}

