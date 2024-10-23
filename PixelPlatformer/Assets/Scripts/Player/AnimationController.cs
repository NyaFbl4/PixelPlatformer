using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private PlayerController PC;

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

        if (PC.dirX != 0f)
        {
            state = MovementState.running;
            PC.FlipSprite();
        }
        else
        {
            state = MovementState.idle;
        }

        if (PC.rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (PC.rb.velocity.y < -.1f && !PC.isWall)
        {
            state = MovementState.falling;
        }
        else if (PC.isWall)
        {
            state = MovementState.WallJump;
        }

        anim.SetInteger("state", (int)state);
    }
}
