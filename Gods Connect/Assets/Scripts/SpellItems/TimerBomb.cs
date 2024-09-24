using UnityEngine;
using DG.Tweening;

namespace SpellItems
{
    public class TimerBomb : MonoBehaviour
    {
        [field : SerializeField] public int IncreasingTimeValue { get; private set; }
        [SerializeField] public ParticleSystem ExplosionParticle;

        public void SpawnSpell(
            Transform parentTransform, 
            Transform targetTextTransform, 
            Transform timerTransform,
            AudioSource explosion)
        {
            var timerBomb = Instantiate(gameObject, parentTransform).GetComponent<TimerBomb>();
            timerBomb.AnimationSpell(targetTextTransform, timerTransform, explosion);
        }

        public void AnimationSpell(Transform targetTransform, Transform timerTransform, AudioSource explosion)
        {
            DOTween.Sequence()
                .Append(transform.DOMove(targetTransform.position, 0.5f))
                .AppendCallback(() => ExplosionParticle.Play())
                .AppendCallback(() => explosion.Play())
                .Append(transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f))
                .AppendInterval(1f)
                .AppendCallback(() => DestroyImmediate(gameObject));

            DOTween.Sequence()
                .AppendInterval(0.5f)
                .Append(timerTransform.transform.DOShakePosition(1f, new Vector3(5f, 5f, 1f)));
        }
    }
}

