using System.Collections.Generic;
using LevelControllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class UIGoal : Screen
    {
        [SerializeField] private Image[] _goalsIcons;
        [SerializeField] private TMP_Text[] _amountTexts;
        [SerializeField] private GameObject[] _comleteImages;

        public void LoadGoal(List<GoalData> goalsData)
        {
            var index = 0;

            foreach (var goalData in goalsData)
            {
                _goalsIcons[index].sprite = goalData.Icon;
                _amountTexts[index].text = $"{goalData.Amount}";

                index++;
            }
        }

        public void UpdateGoal(List<int> amountsGoal)
        {
            var index = 0;
            foreach (var amountText in _amountTexts)
            {
                amountText.text = $"{amountsGoal[index]}";

                if (amountsGoal[index] == 0)
                    _comleteImages[index].SetActive(true);
                    
                index++;
            }
        }
    }
}

