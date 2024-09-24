using UnityEngine;
using System;
using GameControllers.Properties;
using System.Collections.Generic;

namespace GameControllers.Components
{
    [Serializable]
    public struct GoalComponent 
    {
        [HideInInspector] public List<ItemType> ItemTypes;
        [HideInInspector] public List<int> AmountsGoal;
        [HideInInspector] public List<bool> CompletedGoals;
    }
}

