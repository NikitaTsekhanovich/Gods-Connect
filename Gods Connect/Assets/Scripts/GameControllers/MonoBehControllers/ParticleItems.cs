using UnityEngine;

namespace GameControllers.MonoBehControllers
{
    public class ParticleItems : MonoBehaviour
    {
        [SerializeField] public ParticleSystem DestroyableParticle;

        public void StartDestryableParticle()
        {
            DestroyableParticle.Play();
        }
    }
}

