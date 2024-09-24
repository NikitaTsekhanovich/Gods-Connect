using UnityEngine;

namespace GameControllers.MonoBehControllers
{
    public class SoundsContainer : MonoBehaviour
    {
        [SerializeField] public AudioSource EndGameSound;
        [SerializeField] public AudioSource EnergyReadySound;
        [SerializeField] public AudioSource FullEnergySound;
        [SerializeField] public AudioSource GranadeSpawnSound;
        [SerializeField] public AudioSource RotateGameFieldSound;
        [SerializeField] public AudioSource ShakeGameFieldSound;
        [SerializeField] public AudioSource GoalCompletedSound;
        [SerializeField] public AudioSource DestroyItemSound;
        [SerializeField] public AudioSource ExplosionSound;
    }
}

