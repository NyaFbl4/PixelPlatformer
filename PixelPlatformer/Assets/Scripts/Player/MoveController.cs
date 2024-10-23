using UnityEngine;

namespace Player
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _dirX = 0f;
        [SerializeField] private float _moveSpeed = 2f;
        
        [SerializeField] private bool isWall = false;
        
        private void Move()
        {
            _dirX = Input.GetAxisRaw("Horizontal");
            
            if (isWall == false)
            { 
                _rigidbody.velocity = new Vector2(_dirX * _moveSpeed, _rigidbody.velocity.y);
            }
        }
    }
}