using LevelControllers;
using StoreControllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class EndGameScreen : Screen
    {
        [SerializeField] private TMP_Text _currentScore;
        [SerializeField] private TMP_Text _currentCoins;
        [SerializeField] private Image _characterIcon;

        public bool GameIsEnd { get; private set; }

        public void UpdateEndScreenData(Sprite characterIcon, int indexLevel)
        {
            _characterIcon.sprite = characterIcon;
            GameIsEnd = true;
            _currentScore.text = $"{PlayerPrefs.GetInt($"{LevelProgressDataKeys.BestScoreLevelKey}{indexLevel}")}";
            _currentCoins.text = $"{PlayerPrefs.GetInt(StoreDataKeys.CoinsDataKey)}";
        }
    }
}

