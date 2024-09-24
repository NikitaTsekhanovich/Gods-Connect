using UnityEngine;

namespace GameControllers.MonoBehControllers
{
    public class SpawnerGameObjects : MonoBehaviour
    {
        public static GameObject GetInstatinateObject(
            GameObject gameObject, 
            Transform spawnPosition, 
            Transform parentComponent)
        {
            var newGameObject = Instantiate(gameObject, spawnPosition.position, parentComponent.rotation, parentComponent);

            return newGameObject;
        }
    }
}

