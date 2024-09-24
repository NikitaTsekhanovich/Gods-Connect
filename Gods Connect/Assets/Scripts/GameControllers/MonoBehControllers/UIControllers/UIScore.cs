using DG.Tweening;
using TMPro;
using UnityEngine;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class UIScore : Screen
    {
        [SerializeField] private TMP_Text _scoreText;

        public void StartAnimScoreText(int increasingCoefficientValue, int duration)
        {
            _scoreText.text = $"x{increasingCoefficientValue} score";

            DOTween.Sequence()
                .Append(_scoreText.transform.DOScale(Vector3.one, 0.5f))
                .AppendCallback(() => IdleAnimation(duration));
        }

        private void IdleAnimation(int duration)
        {
            DOTween.Sequence()
                .Append(_scoreText.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.5f))
                .Append(_scoreText.transform.DOScale(Vector3.one, 0.5f))
                .SetLoops(duration, LoopType.Yoyo);
            
            DOTween.Sequence()
                .AppendInterval(duration)
                .Append(_scoreText.transform.DOScale(Vector3.zero, 0.5f));
        }
    }
}
