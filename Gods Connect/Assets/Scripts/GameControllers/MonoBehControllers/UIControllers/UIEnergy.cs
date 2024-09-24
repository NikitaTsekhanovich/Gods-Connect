using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class UIEnergy : MonoBehaviour
    {
        [SerializeField] private Image _energyImage;
        [SerializeField] private ParticleSystem _fullEnergyParticle;

        private Sequence _animationEnergyImage;

        public void UpdateEnergyImage(float energy)
        {
            _energyImage.fillAmount += energy;
        }

        public void OnFullEnergy()
        {
            _fullEnergyParticle.Play();
            _animationEnergyImage = DOTween.Sequence()
                .Append(_energyImage.transform.DOScale(new Vector3(0.95f, 0.95f, 0.95f), 1f))
                .Append(_energyImage.transform.DOScale(new Vector3(1f, 1f, 1f), 1f))
                .Append(_energyImage.transform.DOScale(new Vector3(0.95f, 0.95f, 0.95f), 1f))
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void ResetEnergyImage(float energy)
        {
            _animationEnergyImage.Kill();
            _energyImage.fillAmount = energy;
            _fullEnergyParticle.Stop();
        }
    }
}
