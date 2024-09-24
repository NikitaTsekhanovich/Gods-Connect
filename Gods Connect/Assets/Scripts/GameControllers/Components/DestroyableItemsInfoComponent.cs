using UnityEngine;
using System;
using GameControllers.Properties;

namespace GameControllers.Components
{
    [Serializable]
    public struct DestroyableItemsInfoComponent
    {
        [HideInInspector] public ItemType CurrentItemType;
        [HideInInspector] public int CurrentAmountDestroyItems;
    }
}

