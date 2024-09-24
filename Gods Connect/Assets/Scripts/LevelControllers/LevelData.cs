using System.Collections.Generic;
using UnityEngine;

namespace LevelControllers
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Level data/ Level")]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private int _index;
        [SerializeField] private List<GameObject> _items = new();
        [SerializeField] private List<GoalData> _goalsData = new();

        public int Index => _index;
        public List<GameObject> Items => _items;
        public List<GoalData> GoalsData => _goalsData;
        public int BestScore 
        { 
            get 
            {
                return PlayerPrefs.GetInt($"{LevelProgressDataKeys.BestScoreLevelKey}{_index}");
            } 
        }
        public TypeLevel LevelIsOpen 
        { 
            get
            {
                var stateLevel = PlayerPrefs.GetInt($"{LevelProgressDataKeys.LevelIsOpenKey}{_index}");
                return stateLevel == 0 ? TypeLevel.IsClosed : TypeLevel.IsOpen;
            } 
        }
        public TypeGoal GoalIsCompleted 
        { 
            get
            {
                var stateLevel = PlayerPrefs.GetInt($"{LevelProgressDataKeys.GoalIsCompletedKey}{_index}");
                return stateLevel == 0 ? TypeGoal.NotCompleted : TypeGoal.Completed;
            } 
        }
    }
}

