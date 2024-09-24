using UnityEngine;

namespace SpellItems
{
    public class ScoreBomb : MonoBehaviour
    {
        [field : SerializeField] public int Coefficient { get; private set; }
        [field : SerializeField] public int Duration { get; private set; }
    }
}

