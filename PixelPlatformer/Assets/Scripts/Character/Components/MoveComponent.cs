using System;
using UnityEngine;
using Zenject;

namespace PixelPlatformer
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 2f;
        
        //[SerializeField] private bool isWall = false;

        public void Move(float dir, Rigidbody2D rigidbody2D)
        {
            rigidbody2D.velocity = new Vector2(dir * _moveSpeed, rigidbody2D.velocity.y);

            /*
            if (isWall == false)
            { 
                rigidbody2D.velocity = new Vector2(_dirX * _moveSpeed, rigidbody2D.velocity.y);
            }
            */
        }
    }
}