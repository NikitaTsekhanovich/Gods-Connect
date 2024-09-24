using System;
using GameControllers.Ecs;
using UnityEngine;

namespace GameControllers.Components
{
    [Serializable]
    public struct SeekerNeighborsComponent
    {
        [HideInInspector] public EntityGameItemReference EntityGameItemReference;
        [HideInInspector] public EntityGoalReference EntityGoalReference;
    }
}

