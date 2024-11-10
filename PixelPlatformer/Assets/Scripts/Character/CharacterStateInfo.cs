using System;
using UnityEngine;

namespace PixelPlatformer
{
    public class CharacterStateInfo : MonoBehaviour
    {
        public bool isJumping  { get; private set; }
        
        // Флаг, указывающий, находится ли персонаж на земле
        public bool isGrounded { get; private set; }
        
        // Флаг, указывающий, находится ли персонаж на стене
        public bool isWall     { get; private set; }

        private void Start()
        {
            isJumping  = false;
            isGrounded = false;
            isWall     = false;
        }

        private void Update()
        {
            throw new NotImplementedException();
        }

        public void SwtichState_isJumping()
        {
            if (isJumping)
            {
                isJumping = false;
            }
            else
            {
                isJumping = true;
            }
            
            Debug.Log("isJumping " + isJumping);
        }
        
        public void SwtichState_isGrounded()
        {
            if (isJumping)
            {
                isJumping = false;
            }
            else
            {
                isJumping = true;
            }
            
            Debug.Log("isGrounded " + isGrounded);
        }
        
        public void SwtichState_isWall()
        {
            if (isJumping)
            {
                isJumping = false;
            }
            else
            {
                isJumping = true;
            }
            
            Debug.Log("isWall " + isWall);
        }
    }
}