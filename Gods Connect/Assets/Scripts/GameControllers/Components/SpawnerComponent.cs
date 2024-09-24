using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameControllers.Components
{
    [Serializable]
    public struct SpawnerComponent
    {
        [HideInInspector] public const int MaxItemsAmount = 20;
        [HideInInspector] public int CurrentAmountItems;
        public List<Transform> SpawnPoints;
        public Transform ParentComponent;
    }
}

