using TMPro;
using UnityEngine;
using DG.Tweening;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class UITimer : Screen
    {
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private Transform _timerTransform;

        public void UpdateScoreText(float currentTimeValue)
        {
            _timerText.text = $"{(int)currentTimeValue}c";
        }

        public void IncreaseTimerAnimation()
        {
            DOTween.Sequence()
                .Append(_timerText.DOColor(Color.green, 0.4f))
                .Append(_timerText.DOColor(new Color(0.4117647f, 0.2039216f, 0.1764706f), 0.4f));
        }

        public Transform GetTimerTextTransform() => _timerText.transform;
        public Transform GetTimerTransform() => _timerTransform;
    }
}

