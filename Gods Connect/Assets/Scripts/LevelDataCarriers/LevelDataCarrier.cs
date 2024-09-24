using GameControllers.Ecs;
using LevelControllers;
using StoreControllers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelDataCarriers
{
    public class LevelDataCarrier : MonoBehaviour
    {
        private LevelData _currentLevel;
        private StoreItemData _currentCharacter;

        public static LevelDataCarrier Instance;

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            StoreMenuController.OnStashCurrentLevelData += StashCurrentLevelData;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            StoreMenuController.OnStashCurrentLevelData -= StashCurrentLevelData;
        }

        private void Start() 
        {             
            if (Instance == null) 
            { 
                Instance = this; 
                DontDestroyOnLoad(gameObject);
            } 
            else 
            { 
                Destroy(this);  
            } 
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.name == "Game")
            {
                EcsGameStartup.Instance.InitEcsWorld(_currentLevel, _currentCharacter);
            }
        }

        private void StashCurrentLevelData()
        {
            _currentLevel = LevelDataContainer.LevelsData[PlayerPrefs.GetInt(LevelProgressDataKeys.CurrentLevelKey)];
            _currentCharacter = StoreDataContainer.StoreItemsData[PlayerPrefs.GetInt(StoreDataKeys.IndexSelectedItemKey)];
        }
    }
}

