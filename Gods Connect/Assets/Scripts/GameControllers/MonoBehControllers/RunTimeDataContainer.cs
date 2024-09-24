using UnityEngine;

namespace GameControllers.MonoBehControllers
{
    public class RunTimeDataContainer : MonoBehaviour
    {
        [field : SerializeField] public Transform SpawnPointSpear { get; private set; }
    }
}

