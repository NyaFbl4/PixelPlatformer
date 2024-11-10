using System;
using PixelPlatformer;
using UnityEngine;

namespace PixelPlatformer
{
    public class SpriteComponent : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;

        [SerializeField] private bool valueFlip;

        public bool ValueFlip 
        {
            get { return valueFlip; }
        }
        
        private void Start()
        {
            valueFlip = true;
        }

        public void UpdateSprite(float dirX)
        {
            if (dirX > 0f)
            {
                valueFlip = false;
            }
            else if (dirX < 0f)
            {
                valueFlip = true;
            }
            
            Flip();
        }
        
        public void FlipSprite()
        {
            if (valueFlip == true)
            {
                valueFlip = false;
            }
            else
            {
                valueFlip = true;
            }
            
            Debug.Log("flip");
        }

        private void Flip()
        {
            _sprite.flipX = valueFlip;
        }
    }
}