using GameControllers.Properties;
using UnityEngine;

namespace LevelControllers
{
    [CreateAssetMenu(fileName = "GoalData", menuName = "Goal data/ Goal")]
    public class GoalData : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private int _amount;

        public Sprite Icon => _icon;
        public ItemType ItemType => _itemType;
        public int Amount => _amount;
    }
}

