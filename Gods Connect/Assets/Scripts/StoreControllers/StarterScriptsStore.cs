using LevelControllers;
using UnityEngine;

namespace StoreControllers
{
    public class StarterScriptsStore : MonoBehaviour
    {
        [SerializeField] private LevelScrollController _levelScrollController;

        private void Awake()
        {
            LevelDataContainer.LoadLevelData();
            StoreDataContainer.LoadStoreItemsData();
        }

        private void Start()
        {
            _levelScrollController.LoadLevelsItems();
        }
    }
}

