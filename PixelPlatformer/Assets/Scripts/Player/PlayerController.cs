using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Animator anim;

    private bool isJumping = false;      // ����, �����������, ����������� �� ������
    private bool isGrounded = false;     // ����, �����������, ��������� �� �������� �� �����
    public bool isWall = false;

    private int jumpCount = 0;           // ���������� ����������� �������
    private int maxJumpCount = 2;         // ������������ ���������� �������
    private bool doubleJumpAllowed = true;// ���������� �� ������� ������

    [SerializeField] private LayerMask jumpableGround;

                     public float dirX = 0f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravitation = -2f;

    [SerializeField] private AudioSource jumpSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();

        if (isWall)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, gravitation, float.MaxValue));
        }                
    }

    private void Move()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (isWall == false)
        { 
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded || (doubleJumpAllowed && jumpCount < 2))
            {
                jumpCount++;
                if (!isWall)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    isJumping = true;
                                     
                }
                else if (isWall)
                {

                    if (sprite.flipX == false)
                    {
                        rb.velocity = new Vector2(-1, jumpForce);
                    }
                    else if (sprite.flipX == true) 
                    {
                        rb.velocity = new Vector2(1, jumpForce);
                    }
                }
            }
        }
    }

    public void Test()
    {
        Debug.Log("TEST");
    }

    public void FlipSprite()
    {
        if (dirX > 0f && isWall != true)
        {
            sprite.flipX = false;
        }
        else if (dirX < 0f && isWall != true)
        {
            sprite.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {       
        // ��������� ������� �����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isWall = false;
            jumpCount = 0;
            
            Debug.Log("�����");

        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            isWall = true;
            jumpCount = 1;

            Debug.Log("�������� �����");
        }
    }   

    private void OnCollisionExit2D(Collision2D collision)
    {
        // ��������� ���������� ������� �����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("������");
            jumpCount = 1;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            isWall = false;

            if (sprite.flipX == true)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
    }
}
