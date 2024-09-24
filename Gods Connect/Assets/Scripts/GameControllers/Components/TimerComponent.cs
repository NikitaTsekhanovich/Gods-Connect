using UnityEngine;
using System;

namespace GameControllers.Components
{
    [Serializable]
    public struct TimerComponent
    {
        [HideInInspector] public const float StartTimerValue = 60f;
        [HideInInspector] public float CurrentTimeValue;
    }
}

