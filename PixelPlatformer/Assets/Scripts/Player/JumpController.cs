using UnityEngine;

namespace Player
{
    public class JumpController : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private int   _jumpCount = 0;           // Количество выполненных прыжков
        [SerializeField] private int   _maxJumpCount = 2;         // максимальное количество прыжков
        [SerializeField] private bool  _doubleJumpAllowed = true;
        
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _sprite;
        
        private bool _isJumping  = false;      // Флаг, указывающий, выполняется ли прыжок
        private bool _isGrounded = false;     // Флаг, указывающий, находится ли персонаж на земле
        public bool isWall       = false;


        private void Jump()
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (_isGrounded || (_doubleJumpAllowed && _jumpCount < 2))
                {
                    _jumpCount++;
                    if (!isWall)
                    {
                        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
                        _isJumping = true;
                                     
                    }
                    else if (isWall)
                    {

                        if (_sprite.flipX == false)
                        {
                            _rigidbody.velocity = new Vector2(-1, _jumpForce);
                        }
                        else if (_sprite.flipX == true) 
                        {
                            _rigidbody.velocity = new Vector2(1, _jumpForce);
                        }
                    }
                }
            }
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {       
            // Обработка касания земли
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
                isWall = false;
                _jumpCount = 0;
            
                Debug.Log("земля");

            }
            if (collision.gameObject.CompareTag("Wall"))
            {
                isWall = true;
                _jumpCount = 1;

                Debug.Log("коснулся стены");
            }
        }   

        private void OnCollisionExit2D(Collision2D collision)
        {
            // Обработка отсутствия касания земли
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = false;
                Debug.Log("воздух");
                _jumpCount = 1;
            }
            if (collision.gameObject.CompareTag("Wall"))
            {
                isWall = false;

                if (_sprite.flipX == true)
                {
                    _sprite.flipX = false;
                }
                else
                {
                    _sprite.flipX = true;
                }
            }
        }
    }
}