using System;
using MainMenu;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StoreControllers
{
    public class StoreMenuController : MonoBehaviour
    {
        [SerializeField] private Image _characterMainImage;
        [SerializeField] private TMP_Text _nameCharacter;
        [SerializeField] private TMP_Text _currentCoins;

        public static Action OnStashCurrentLevelData;

        private void Start()
        {   
            UpdateInfoMainScreen();
        }
        
        public void UpdateInfoMainScreen()
        {
            var currentCharacter = StoreDataContainer.StoreItemsData[PlayerPrefs.GetInt(StoreDataKeys.IndexSelectedItemKey)];

            _characterMainImage.sprite = currentCharacter.CharacterSprite;
            _nameCharacter.text = currentCharacter.CharacterName;
            _currentCoins.text = $"{PlayerPrefs.GetInt(StoreDataKeys.CoinsDataKey)}";
        }

        public void StartGame()
        {
            OnStashCurrentLevelData?.Invoke();
            LoadingScreenController.Instance.ChangeScene("Game");
        }

        public void BackToMenu()
        {
            LoadingScreenController.Instance.ChangeScene("Menu");
        }
    }
}
