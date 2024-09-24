using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using GameControllers.Systems;
using GameControllers.MonoBehControllers.UIControllers;
using LevelControllers;
using StoreControllers;
using GameControllers.Systems.AbilitiesSystems;
using GameControllers.MonoBehControllers;

namespace GameControllers.Ecs
{
    public class EcsGameStartup : MonoBehaviour
    {
        [SerializeField] private EntityGoalReference _entityGoalReference;
        [SerializeField] private UIContainer _uiContainer;
        [SerializeField] private RunTimeDataContainer _runTimeDataContainer;
        [SerializeField] private SoundsContainer _soundsContainer;

        private EcsWorld _world;
        private EcsSystems _systems;

        public static EcsGameStartup Instance;

        private void Awake() 
        {             
            if (Instance == null) 
                Instance = this; 
            else 
                Destroy(this);   
        }

        public void InitEcsWorld(LevelData levelData, StoreItemData characterData)
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.ConvertScene();

            AddInjections(levelData, characterData);
            AddOneFrames();
            AddSystems();

            _systems.Init();
        }

        private void AddInjections(LevelData levelData, StoreItemData characterData)
        {
            _systems
                .Inject(levelData)
                .Inject(characterData)
                .Inject(_uiContainer)
                .Inject(_runTimeDataContainer)
                .Inject(_soundsContainer)
                .Inject(_entityGoalReference);
        }

        private void AddSystems()
        {
            _systems
                .Add(new TimerSystem())
                .Add(new CharacterSystem())
                .Add(new SpawnSystem())
                .Add(new EntityInitializeSystem())
                .Add(new InputSystem())
                .Add(new AbilitySystem())
                .Add(new SeekNeighborsSystem())
                .Add(new DamageBombAbilitySystem())
                .Add(new DestroySystem())
                .Add(new EnergySystem())
                .Add(new GoalSystem())
                .Add(new TimerAbilitySystem())
                .Add(new ScoreAbilitySystem())
                .Add(new ScoreSystem())
                .Add(new CoinSystem())
                .Add(new CoinsAbilitySystem())
                .Add(new SpearAbilitySystem());
        }

        private void AddOneFrames()
        {

        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            if (_systems == null) return;

            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }
}

