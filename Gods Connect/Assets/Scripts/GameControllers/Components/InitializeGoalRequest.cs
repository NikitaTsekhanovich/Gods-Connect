using UnityEngine;
using System;
using GameControllers.Ecs;

namespace GameControllers.Components
{
    [Serializable]
    public struct InitializeGoalRequest
    {
        public EntityGoalReference EntityGoalReference;
    }
}

