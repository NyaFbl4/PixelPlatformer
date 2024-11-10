using System;
using PixelPlatformer;
using UnityEngine;

namespace PixelPlatformer
{
    public class JumpComponent : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 5f;
        //[SerializeField] private int _jumpCount = 0; // Количество выполненных прыжков
        //[SerializeField] private int _maxJumpCount = 2; // максимальное количество прыжков
        //[SerializeField] private bool _doubleJumpAllowed = true; // Разрешение на двойной прыжок

        //[SerializeField] private InputSystem _inputSystem;
        //[SerializeField] public Rigidbody2D _rigidbody2D { get; private set; }
        //[SerializeField] private CharacterStateInfo _characterStateInfo;

        private void OnEnable()
        {
            //_inputSystem.OnJump += Jump;
        }

        private void OnDisable()
        {
            //_inputSystem.OnJump -= Jump;
        }

        public void Jump(Rigidbody2D rigidbody2D)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, _jumpForce);

            //_characterStateInfo.SwtichState_isJumping();
        }

        /*
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _characterStateInfo.SwtichState_isGrounded();
                _characterStateInfo.SwtichState_isWall();
                _jumpCount = 0;
            }

            if (collision.gameObject.CompareTag("Wall"))
            {
                _characterStateInfo.SwtichState_isWall();
                _jumpCount = 1;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            {
                if (collision.gameObject.CompareTag("Ground"))
                {
                    _characterStateInfo.SwtichState_isGrounded();

                    _jumpCount = 1;
                }

                if (collision.gameObject.CompareTag("Wall"))
                {
                    _characterStateInfo.SwtichState_isWall();
                }
            }
        }
        */
    }
}