using System;
using GameControllers.Ecs;

namespace GameControllers.Components
{
    [Serializable]
    public struct InitializeEntityGameItemRequest
    {
        public EntityGameItemReference EntityGameItemReference;
    }
}

