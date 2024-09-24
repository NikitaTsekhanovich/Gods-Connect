using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LevelControllers
{
    public class LevelItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _bestScore;
        [SerializeField] private Image[] _goalImages;
        [SerializeField] private TMP_Text[] _goalTexts;
        [SerializeField] private Image _goalCompleteImage;

        public void LoadLevelItemInfo(int levelIndex, int bestScore, List<GoalData> goalsData, TypeGoal typeGoal)
        {
            _levelText.text = $"Level {levelIndex + 1}";
            _bestScore.text = $"Best score: \n{bestScore}";

            var index = 0;
            foreach (var goalData in goalsData)
            {
                _goalImages[index].sprite = goalData.Icon;
                _goalTexts[index].text = $"{goalData.Amount}";

                index++;
            }

            if (typeGoal == TypeGoal.NotCompleted)
                _goalCompleteImage.color = new Color(1f, 1f, 1f, 0.2f);
            else 
                _goalCompleteImage.color = new Color(1f, 1f, 1f, 1f);
        }

        public float GetWidthLevelItem() => GetComponent<RectTransform>().rect.size.x;
    }
}

