using DG.Tweening;
using SpellItems;
using TMPro;
using UnityEngine;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class UICoins : Screen
    {
        [SerializeField] private TMP_Text _coinsText;
        [SerializeField] private ParticleSystem _coinsParticle;

        public void StartAnimationCoins(
            int amountCoins, 
            GameObject prefabGoldBomb, 
            Transform spawnTransform,
            AudioSource explosion)
        {
            var goldBomb = Instantiate(prefabGoldBomb, spawnTransform).GetComponent<GoldBomb>();

            _coinsText.text = $"{amountCoins} coins";

            DOTween.Sequence()
                .Append(goldBomb.transform.DOMove(_coinsText.transform.position, 1f))
                .Append(goldBomb.transform.DOScale(Vector3.zero, 0.2f))
                .AppendCallback(() => goldBomb.ExplosionParticle.Play())
                .AppendCallback(() => explosion.Play())
                .AppendCallback(() => _coinsParticle.Play())
                .Append(_coinsText.transform.DOScale(Vector3.one, 0.5f))
                .AppendInterval(1f)
                .AppendCallback(() => Destroy(goldBomb))
                .Append(_coinsText.transform.DOScale(Vector3.zero, 0.5f));
        }
    }
}

