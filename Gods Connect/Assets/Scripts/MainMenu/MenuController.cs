using LevelControllers;
using StoreControllers;
using UnityEngine;

namespace MainMenu
{
    public class MenuController : MonoBehaviour
    {
        public void LoadStore()
        {
            PlayerPrefs.SetInt($"{LevelProgressDataKeys.LevelIsOpenKey}{0}", (int)TypeLevel.IsOpen);
            PlayerPrefs.SetInt($"{StoreDataKeys.StoreItemIsBoughtKey}{0}", (int)TypeItemStore.Bought);
            LoadingScreenController.Instance.ChangeScene("Store");
        }
    }
}
