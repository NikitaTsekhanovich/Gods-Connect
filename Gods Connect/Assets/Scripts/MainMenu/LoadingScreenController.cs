using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

namespace MainMenu 
{
    public class LoadingScreenController : MonoBehaviour
    {
        [SerializeField] private GraphicRaycaster _loadingScreenBlockClick;
        [SerializeField] private Image _background;
        [SerializeField] private TMP_Text _loadingText;
        [SerializeField] private Image _logo;
        private Coroutine _loadingTextAnimation;
        private float _durationAnimationFade = 0.5f;

        public static LoadingScreenController Instance;

        private void Start() 
        {             
            if (Instance == null) 
            { 
                Instance = this; 
                DontDestroyOnLoad(gameObject);
            } 
            else 
            { 
                Destroy(this);  
            } 
        }
        
        public void ChangeScene(string nameScene)
        {
            _loadingScreenBlockClick.enabled = true;
           StartAnimationFade(nameScene);
        }

        private void StartAnimationFade(string nameScene)
        {
            _loadingTextAnimation = StartCoroutine(StartLoadingTextAnimation());
            _loadingText.DOFade(1f, _durationAnimationFade);
            _logo.DOFade(1f, _durationAnimationFade);

            DOTween.Sequence()
                .Append(_background.DOFade(1f, _durationAnimationFade))
                .AppendInterval(_durationAnimationFade)
                .AppendCallback(() => LoadScene(nameScene))
                .AppendInterval(1.2f)
                .OnComplete(() => EndAnimationFade());
        }

        private void LoadScene(string nameScene)
        {
            SceneManager.LoadSceneAsync(nameScene);
            Time.timeScale = 1f;
        }

        private void EndAnimationFade()
        {
            _logo.DOFade(0f, _durationAnimationFade);
            _loadingText.DOFade(0f, _durationAnimationFade);

            DOTween.Sequence()
                .Append(_background.DOFade(0f, _durationAnimationFade))
                .AppendCallback(() => StopCoroutine(_loadingTextAnimation))
                .AppendCallback(() => _loadingScreenBlockClick.enabled = false);
        }

        private IEnumerator StartLoadingTextAnimation()
        {
            while (true)
            {
                _loadingText.text = $"Loading.";
                yield return new WaitForSeconds(0.3f);

                _loadingText.text = $"Loading..";
                yield return new WaitForSeconds(0.3f);

                _loadingText.text = $"Loading...";
                yield return new WaitForSeconds(0.3f);
            }
        } 
    }
}