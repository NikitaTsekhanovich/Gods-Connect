using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LevelControllers
{
    public class LevelScrollController : MonoBehaviour
    {
        [SerializeField] private ScrollRect _contentRect; 
        [SerializeField] private Transform _contentTransform; 
        [SerializeField] private LevelItem _levelItem; 
        [SerializeField] private TMP_Text _currentLevelText; 
        [SerializeField] private Button _playButton; 

        private float _sizeWidthStoreItem;
        private int _currentLevelIndex;

        private void Update()
        {
            UpdateLevelText();
            AlignItems();
        }

        private void CheckStateLevels()
        {
            if (LevelDataContainer.LevelsData[_currentLevelIndex].LevelIsOpen == TypeLevel.IsOpen)
                _playButton.interactable = true;
            else
                _playButton.interactable = false;
        }

        private void UpdateLevelText()
        {
            _currentLevelIndex = (int)((Math.Abs(_contentRect.content.localPosition.x) + _sizeWidthStoreItem / 2) / _sizeWidthStoreItem);
            _currentLevelText.text = $"Level {_currentLevelIndex + 1}";
        }

        private void AlignItems()
        {
            if (Input.GetMouseButtonUp(0))
            {
                CheckStateLevels();
                var offset = 0 - _currentLevelIndex * _sizeWidthStoreItem;

                _contentRect.content.localPosition = new Vector3(
                    offset, 
                    _contentRect.content.localPosition.y, 
                    0);

                PlayerPrefs.SetInt(LevelProgressDataKeys.CurrentLevelKey, _currentLevelIndex);
            }
        }

        public void LoadLevelsItems()
        {
            foreach (var levelData in LevelDataContainer.LevelsData)
            {
                var newLevelItem = Instantiate(_levelItem, _contentTransform);
                newLevelItem.LoadLevelItemInfo(
                    levelData.Index, 
                    levelData.BestScore,
                    levelData.GoalsData,
                    levelData.GoalIsCompleted);

                _sizeWidthStoreItem = newLevelItem.GetWidthLevelItem();
            }
        }
    }
}

