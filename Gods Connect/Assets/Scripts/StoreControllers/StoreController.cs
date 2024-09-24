using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StoreControllers
{
    public class StoreController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameCharacterText;
        [SerializeField] private Image _characterStoreImage;
        [SerializeField] private TMP_Text _stateItemText;
        [SerializeField] private Image _abilityImage;
        [SerializeField] private TMP_Text _abilityName;
        [SerializeField] private TMP_Text _abilityDescription;
        [SerializeField] private List<StoreItemData> _storeItemsData = new();
        [SerializeField] private TMP_Text _currentCoinsText;
        [SerializeField] private AudioSource _purchaseSound;
        private StoreItemData _currentItemData;
        private int _currentCoins;

        private void Start()
        {
            UpdateCoinsText();
            SelectItem(0);
        }

        public void UpdateCoinsText()
        {
            _currentCoins = PlayerPrefs.GetInt(StoreDataKeys.CoinsDataKey);
            _currentCoinsText.text = $"{_currentCoins}";
        }

        public void SelectItem(int index)
        {
            _currentItemData = _storeItemsData[index];
            UpdateNameCharacter(_currentItemData.CharacterName);
            UpdateImageCharacter(_currentItemData.CharacterSprite);
            UpdateStateItem(_currentItemData.TypeItemStore, _currentItemData.Price, _currentItemData.NotReleased);
            UpdateAbilities(_currentItemData.AbilitiesData);
        }

        private void UpdateNameCharacter(string characterName)
        {
            _nameCharacterText.text = characterName;
        }

        private void UpdateImageCharacter(Sprite characterSprite)
        {
            _characterStoreImage.sprite = characterSprite;
        }

        private void UpdateStateItem(TypeItemStore typeItemStore, int price, bool notReleased)
        {
            switch (typeItemStore)
            {
                case TypeItemStore.Selected:
                    _stateItemText.text = "Selected";
                    break;
                case TypeItemStore.Bought:
                    _stateItemText.text = "Select";
                    break;
                case TypeItemStore.NotBought:
                    if (notReleased)
                        _stateItemText.text = "Coming soon";
                    else
                        _stateItemText.text = $"{price}";
                    break;
            }
        }

        private void UpdateAbilities(AbilityData abilitiesData)
        {
            _abilityImage.sprite = abilitiesData.AbilityIcon;
            _abilityName.text = abilitiesData.Name;
            _abilityDescription.text = abilitiesData.Description;
        }

        public void SelectOrBuyItem()
        {
            if (_currentItemData.NotReleased) return;

            switch (_currentItemData.TypeItemStore)
            {
                case TypeItemStore.Bought:
                    SelectItem();
                    break;
                case TypeItemStore.NotBought:
                    BuyItem();
                    break;
            }
        }

        private void SelectItem()
        {
            PlayerPrefs.SetInt(StoreDataKeys.IndexSelectedItemKey, _currentItemData.Index);
            _stateItemText.text = "Selected";
        }

        private void BuyItem()
        {
            if (_currentCoins - _currentItemData.Price >= 0)
            {
                _purchaseSound.Play();
                
                _currentCoins -= _currentItemData.Price;
                PlayerPrefs.SetInt(StoreDataKeys.CoinsDataKey, _currentCoins);
                UpdateCoinsText();

                PlayerPrefs.SetInt(StoreDataKeys.IndexSelectedItemKey, _currentItemData.Index);
                _stateItemText.text = "Selected";

                PlayerPrefs.SetInt(_currentItemData.IsBoughtStateKey, (int)TypeItemStore.Bought);
            }
        }
    }
}
