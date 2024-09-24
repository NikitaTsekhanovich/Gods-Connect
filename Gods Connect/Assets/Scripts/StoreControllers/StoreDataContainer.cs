using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StoreControllers
{
    public class StoreDataContainer 
    {
        public static List<StoreItemData> StoreItemsData { get; private set; }

        public static void LoadStoreItemsData()
        {
            StoreItemsData = Resources.LoadAll<StoreItemData>("ScriptableObjectStore/StoreItemData")
                .OrderBy(x => x.Index)
                .ToList();
        }
    }
}

