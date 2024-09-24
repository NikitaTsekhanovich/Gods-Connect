using GameControllers.Components;
using GameControllers.MonoBehControllers;
using GameControllers.MonoBehControllers.UIControllers;
using Leopotam.Ecs;

namespace GameControllers.Systems
{
    public class EnergySystem : IEcsRunSystem
    {
        private SoundsContainer _soundsContainer;
        private EcsWorld _world;
        private UIContainer _uiContainer;
        private readonly EcsFilter<EnergyComponent> _energyFilter = null;

        private float _currentEnergy;
        private bool _isFull;

        public void Run()
        {
            foreach (var i in _energyFilter)
            {
                ref var entity = ref _energyFilter.GetEntity(i);
                ref var energyComponent = ref _energyFilter.Get1(i);

                var maximumEnergy = EnergyComponent.MaxEnergy;
                ref var amountDestroyItems = ref energyComponent.AmountDestroyItems;

                var energy = amountDestroyItems;

                if (amountDestroyItems >= 10)
                    energy *= 5f;
                else if (amountDestroyItems >= 7)
                    energy *= 4f;
                else if (amountDestroyItems >= 5)
                    energy *= 3f;
                else if (amountDestroyItems >= 3)
                    energy *= 2f;
                
                energy /= maximumEnergy;
                _currentEnergy += energy;

                _uiContainer.UIEnergy.UpdateEnergyImage(energy);

                if (_currentEnergy >= 1 && !_isFull)
                {
                    _soundsContainer.EnergyReadySound.Play();
                    _soundsContainer.FullEnergySound.Play();
                    _isFull = true;
                    _uiContainer.UIEnergy.OnFullEnergy();
                }

                entity.Del<EnergyComponent>();
            }

            CheckUseAbility();
        }

        private void CheckUseAbility()
        {
            if (_uiContainer.ClickAbility.IsClickOnAbility)
            {
                _uiContainer.ClickAbility.UsedAbility();

                if (_currentEnergy >= 1)
                {
                    _soundsContainer.EnergyReadySound.Stop();
                    _isFull = false;
                    _world.NewEntity().Get<AbilityComponent>();
                    _currentEnergy = 0f;
                    _uiContainer.UIEnergy.ResetEnergyImage(_currentEnergy);
                }
            }
        }
    }
}

