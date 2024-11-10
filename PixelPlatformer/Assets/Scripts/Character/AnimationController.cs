using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        UpdateAnimationState();
    }

    private enum MovementState { idle, running, jumping, falling, WallJump, Die }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (_playerController._dirX != 0f)
        {
            state = MovementState.running;
            _playerController.FlipSprite();
        }
        else
        {
            state = MovementState.idle;
        }

        if (_playerController.rigidbody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (_playerController.rigidbody.velocity.y < -.1f && !_playerController.isWall)
        {
            state = MovementState.falling;
        }
        else if (_playerController.isWall)
        {
            state = MovementState.WallJump;
        }

        anim.SetInteger("state", (int)state);
    }
}
