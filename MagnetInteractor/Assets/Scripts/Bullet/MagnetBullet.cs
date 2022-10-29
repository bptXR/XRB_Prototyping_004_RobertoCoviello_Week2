using UnityEngine;

namespace Bullet
{
    public class MagnetBullet : MonoBehaviour
    {
        [SerializeField] private float duration = 4;

        private void Awake()
        {
            Destroy(gameObject, duration);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(collision.gameObject);
        }
    }
}