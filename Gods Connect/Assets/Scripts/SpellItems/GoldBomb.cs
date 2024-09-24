using UnityEngine;

namespace SpellItems
{
    public class GoldBomb : MonoBehaviour
    {
        [field : SerializeField] public int AmountCoins { get; private set; }
        [SerializeField] public ParticleSystem ExplosionParticle;
    }
}

