using System;
using UnityEngine;

namespace Object
{
    public class CollisionSounds : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip fallLow;
        [SerializeField] private AudioClip fallMedium;
        [SerializeField] private AudioClip fallHigh;
        [SerializeField] private AudioClip magnetHitSound;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                audioSource.PlayOneShot(magnetHitSound);
            }
            else
            {
                switch (collision.relativeVelocity.magnitude)
                {
                    case >= 1 and < 6:
                        audioSource.PlayOneShot(fallLow);
                        break;
                    case >= 6 and < 12:
                        audioSource.PlayOneShot(fallMedium);
                        break;
                    case >= 12:
                        audioSource.PlayOneShot(fallHigh);
                        break;
                }
            }
        }
    }
}