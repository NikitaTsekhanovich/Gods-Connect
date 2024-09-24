using UnityEngine;

namespace GameControllers.MonoBehControllers
{
    public class DestroyableWall : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(collision.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Destroy(col.gameObject);
        }
    }
}

