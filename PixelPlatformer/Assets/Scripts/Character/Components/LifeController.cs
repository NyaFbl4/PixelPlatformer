using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private int _live;
    [SerializeField] private float _knockbackForce = 10f; // Сила отталкивания
    [SerializeField] private float _knockbackAngle = 45f; // Угол отталкивания

    private bool isDie = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(Vector3 damageSource)
    {
        Vector3 direction = (transform.position - damageSource).normalized;
        rb.AddForce(direction * _knockbackForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            Debug.Log("TRAP!");
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Opponent")) // Предположим, что "Enemy" - тег для врагов
        {
            TakeDamage(1);

            ContactPoint2D contact = collision.contacts[0];
            if (contact.normal.y > 0.5f) // Проверяем, что касание произошло сверху
            {
                Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
                Vector2 knockbackDirectionWithAngle = Quaternion.Euler(0, 0, _knockbackAngle) * knockbackDirection;
                rb.AddForce(knockbackDirectionWithAngle * _knockbackForce, ForceMode2D.Impulse);
            }
        }
    }

    private void TakeDamage(int damage)
    {
        Debug.Log(damage);
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Die");
    }
}
