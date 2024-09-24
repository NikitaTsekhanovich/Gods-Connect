using GameControllers.Properties;
using UnityEngine;

namespace StoreControllers
{
    [CreateAssetMenu(fileName = "StoreItemData", menuName = "Store item data/ Store item")]
    public class StoreItemData : ScriptableObject
    {
        [SerializeField] private int _index;
        [SerializeField] private Sprite _characterSprite;
        [SerializeField] private string _characterName;
        [SerializeField] private int _price;
        [SerializeField] private AbilityData _abilityData;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private GameObject _prefabAbility;

        [field : SerializeField] public bool NotReleased { get; private set; }
        public int Index => _index;
        public Sprite CharacterSprite => _characterSprite;
        public string CharacterName => _characterName;
        public int Price => _price;
        public AbilityData AbilitiesData => _abilityData; 
        public ItemType ItemType => _itemType;
        public GameObject PrefabAbility => _prefabAbility;
        public string IsBoughtStateKey => $"{StoreDataKeys.StoreItemIsBoughtKey}{_index}";
        public TypeItemStore TypeItemStore 
        { 
            get 
            {
                if (PlayerPrefs.GetInt(IsBoughtStateKey) == (int)TypeItemStore.NotBought)
                    return TypeItemStore.NotBought;

                return PlayerPrefs.GetInt(StoreDataKeys.IndexSelectedItemKey) == _index ? 
                    TypeItemStore.Selected : TypeItemStore.Bought;
            }
        }
    }
}

