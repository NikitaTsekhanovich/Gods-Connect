using UnityEngine;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public abstract class Screen : MonoBehaviour
    {
        [SerializeField] private GameObject _screen;
        
        public virtual void Show(bool state = true)
        {
            _screen.SetActive(state);
        }
    }
}

