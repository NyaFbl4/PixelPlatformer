using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Animator _anim;

    private bool _isJumping = false;      // Флаг, указывающий, выполняется ли прыжок
    private bool _isGrounded = false;     // Флаг, указывающий, находится ли персонаж на земле
    public bool isWall = false;

    private int _jumpCount = 0;            // Количество выполненных прыжков
    private int _maxJumpCount = 2;         // максимальное количество прыжков
    private bool _doubleJumpAllowed = true;// Разрешение на двойной прыжок

    [SerializeField] private LayerMask _jumpableGround;

                     public float _dirX = 0f;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _gravitation = -2f;

    [SerializeField] private AudioSource _jumpSoundEffect;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();

        if (isWall)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, Mathf.Clamp(rigidbody.velocity.y, _gravitation, float.MaxValue));
        }                
    }

    private void Move()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        if (isWall == false)
        { 
            rigidbody.velocity = new Vector2(_dirX * _moveSpeed, rigidbody.velocity.y);
        }
    }

    
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_isGrounded || (_doubleJumpAllowed && _jumpCount < 2))
            {
                _jumpCount++;
                if (!isWall)
                {
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, _jumpForce);
                    _isJumping = true;
                                     
                }
                else if (isWall)
                {

                    if (_sprite.flipX == false)
                    {
                        rigidbody.velocity = new Vector2(-1, _jumpForce);
                    }
                    else if (_sprite.flipX == true) 
                    {
                        rigidbody.velocity = new Vector2(1, _jumpForce);
                    }
                }
            }
        }
    }

    public void FlipSprite()
    {
        if (_dirX > 0f && isWall != true)
        {
            _sprite.flipX = false;
        }
        else if (_dirX < 0f && isWall != true)
        {
            _sprite.flipX = true;
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
