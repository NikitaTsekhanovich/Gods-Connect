using System;
using UnityEngine;

namespace GameControllers.Components
{
    [Serializable]
    public struct EnergyComponent
    {
        [HideInInspector] public const float MaxEnergy = 150f;
        [HideInInspector] public float AmountDestroyItems;
    }
}

