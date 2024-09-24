using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LevelControllers
{
    public class LevelDataContainer
    {
        public static List<LevelData> LevelsData { get; private set; }

        public static void LoadLevelData()
        {
            LevelsData = Resources.LoadAll<LevelData>("ScriptableObjectLevel/LevelsData")
                .OrderBy(x => x.Index)
                .ToList();
        }
    }
}

