using UnityEngine;
using UnityEngine.UI;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class UICharacterIcon : Screen
    {
        [SerializeField] private Image _iconCharacter;

        public void LoadIcon(Sprite icon)
        {
            _iconCharacter.sprite = icon;
        }
        
        public Transform GetIconCharacterTransform() => _iconCharacter.transform;
    }
}

