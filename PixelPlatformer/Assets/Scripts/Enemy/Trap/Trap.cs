using System;
using PixelPlatformer;
using UnityEngine;

namespace Enemy.Trap
{
    public class Trap : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            ITakeDamage health = other.gameObject.GetComponent<ITakeDamage>();

            if (health != null)
            {
                health.TakeDamage();
            }
        }
    }
}