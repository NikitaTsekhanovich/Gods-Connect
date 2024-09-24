using UnityEngine;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class ClickAbility : MonoBehaviour
    {
        public bool IsClickOnAbility { get; private set; }

        public void ClickOnAbility()
        {
            IsClickOnAbility = true;
        }

        public void UsedAbility()
        {
            IsClickOnAbility = false;
        }
    }
}

