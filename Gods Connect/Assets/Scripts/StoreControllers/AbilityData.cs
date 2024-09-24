using UnityEngine;

namespace StoreControllers
{
    [CreateAssetMenu(fileName = "AbilityData", menuName = "Store ability data/ Store ability")]
    public class AbilityData : ScriptableObject
    {
        [SerializeField] private Sprite _abilityIcon;
        [SerializeField] private string _name;
        [SerializeField] private string _description;

        public Sprite AbilityIcon => _abilityIcon;
        public string Name => _name;
        public string Description => _description;
    }
}

