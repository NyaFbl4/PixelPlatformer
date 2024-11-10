using System;
using Unity.VisualScripting;
using UnityEngine;

namespace PixelPlatformer
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        [SerializeField] private InputSystem         _inputSystem;
        [SerializeField] private MoveComponent       _moveComponent;
        [SerializeField] private JumpComponent       _jumpComponent;
        [SerializeField] private SpriteComponent     _spriteComponent;
        [SerializeField] private AnimationController _animationController;

        [SerializeField] private bool _isMoving;
        [SerializeField] private bool _isJumping;
        [SerializeField] private bool _isGrounded;
        [SerializeField] private bool _isWall;
        
        [SerializeField] private int _maxJumpCount = 2; // максимальное количество прыжков
        [SerializeField] private bool _doubleJumpAllowed = true; // Разрешение на двойной прыжок
        [SerializeField] private int _jumpCount = 0;
        
        [SerializeField] private float _gravitation = -2f;

        [SerializeField] private float _dirX;

        private void OnEnable()
        {
            _inputSystem.OnMove += Move;
            _inputSystem.OnJump += Jump;
        }

        private void OnDisable()
        {
            _inputSystem.OnMove -= Move;
            _inputSystem.OnJump -= Jump;
        }

        private void Update()
        {
            if (_isMoving)
            {
                _spriteComponent.UpdateSprite(_dirX);
            }
            
            if (_isWall)
            {
                Debug.Log("isWall");
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 
                    Mathf.Clamp(_rigidbody2D.velocity.y, _gravitation, float.MaxValue));
            }
        }

        private void Move(float dirX)
        {
            _isMoving = true;
            
            _dirX = dirX;

            _moveComponent.Move(_dirX, _rigidbody2D);
        }
        

        private void Jump()
        {
            if (_isGrounded || (_doubleJumpAllowed && _jumpCount < 2))
            {
                _jumpCount++;

                if (!_isWall)
                {
                    _jumpComponent.Jump(_rigidbody2D);
                }
                else if (_isWall)
                {
                    /*
                    if (_spriteComponent.ValueFlip == false)
                    {
                        _rigidbody2D.velocity = new Vector2(-1, jumpForce);
                    }
                    else if (_spriteComponent.ValueFlip.flipX == true) 
                    {
                        rb.velocity = new Vector2(1, jumpForce);
                    }
                    */
                }
            }
            
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
                _isWall = false;
                _jumpCount = 0;
            }
            
            if (collision.gameObject.CompareTag("Wall"))
            {
                _isWall = true;
                _jumpCount = 1;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = false;

                _jumpCount = 1;
            }
        }
    }
}