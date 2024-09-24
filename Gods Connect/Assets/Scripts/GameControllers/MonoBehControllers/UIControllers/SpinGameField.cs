using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class SpinGameField : MonoBehaviour
    {
        [SerializeField] private Transform _tansformGameField;
        [SerializeField] private Transform _sword0;
        [SerializeField] private Transform _sword1;
        [SerializeField] private Transform _sword2;
        [SerializeField] private Transform _sword3;
        [SerializeField] private Button _spinButton;
        [SerializeField] private ParticleSystem _sandParticle;
        [SerializeField] private SoundsContainer _soundsContainer;

        public void UseSpinGameField()
        {
            _spinButton.interactable = false;
            StartAnimationSword();
            ShakeGameField();

            DOTween.Sequence()
                .AppendInterval(1.2f)
                .AppendCallback(StartAnimationSpin);
        }

        private void StartAnimationSword()
        {
            _sword0.DOLocalMove(new Vector3(-2f, 2.8f ,0), 1f);
            _sword1.DOLocalMove(new Vector3(2.25f, -2.6f ,0), 1f);
            _sword2.DOLocalMove(new Vector3(2.91f, 1.96f ,0), 1f);
            _sword3.DOLocalMove(new Vector3(-3.18f, -1.65f ,0), 1f);
        }

        private void ShakeGameField()
        {
            DOTween.Sequence()
                .AppendInterval(0.6f)
                .AppendCallback(StartSandParticles)
                .AppendCallback(_soundsContainer.ShakeGameFieldSound.Play)
                .Append(_tansformGameField.DOShakePosition(1.5f, new Vector3(0.2f, 0.2f, 0f)));
        }

        private void StartSandParticles()
        {
            _sandParticle.Play();
        }

        private void StartAnimationSpin()
        {
            DOTween.Sequence()
                .AppendCallback(_soundsContainer.RotateGameFieldSound.Play)
                .Append(_tansformGameField.DORotate(new Vector3(0f, 0f, -30f), 0.5f, RotateMode.Fast))
                .Append(_tansformGameField.DORotate(new Vector3(0f, 0f, 720f), 3f, RotateMode.FastBeyond360))
                .AppendCallback(EndAnimationSword);
        }

        private void EndAnimationSword()
        {
            _sword0.DOLocalMove(new Vector3(-7.1f, 4f ,0), 1f);
            _sword1.DOLocalMove(new Vector3(7.24f, -5f ,0), 1f);
            _sword2.DOLocalMove(new Vector3(7.13f, 3.1f ,0), 1f);
            _sword3.DOLocalMove(new Vector3(-7.21f, -3f ,0), 1f);

            DOTween.Sequence()
                .AppendInterval(1.2f)
                .AppendCallback(() => _spinButton.interactable = true);
        }
    }
}

