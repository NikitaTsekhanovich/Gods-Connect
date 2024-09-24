using GameControllers.MonoBehControllers.UIControllers;
using Leopotam.Ecs;
using StoreControllers;
using UnityEngine;

namespace GameControllers.Systems
{
    public class CharacterSystem : IEcsInitSystem
    {
        private UIContainer _uiContainer;
        private StoreItemData _characterData;

        public void Init()
        {
            _uiContainer.UICharacterIcon.LoadIcon(_characterData.CharacterSprite);
        }
    }
}

