using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Controls_Player : ControlScheme
{
    public float runMultiplier = 2;
    private bool isRunning = false; 
    public override void AddInput()
    {

        controls.Player.Enable();


        controls.Player.Movement.started += OnMove;
        controls.Player.Movement.performed += OnMove;
        controls.Player.Movement.canceled += OnMove;

        controls.Player.Jump.started += OnJump;
        controls.Player.Jump.performed += OnJump;
        controls.Player.Jump.canceled += OnJump;

        controls.Player.Running.started += OnRun;
        controls.Player.Running.canceled += OnRun;
    }

    public void OnRun(InputAction.CallbackContext ctx)
    {
        isRunning = ctx.performed;
    }


    protected override Vector3 CalcDesiredVelocity()
    {
        // If using root motion and root motion is being applied (eg: grounded),
        // use animation velocity as animation takes full control

        if (useRootMotion && applyRootMotion)
            return rootMotionController.animVelocity;

        // else, convert input (moveDirection) to velocity vector
        float multiplier = isRunning ? runMultiplier : 1;
        return moveDirection * speed * multiplier;
    }

    protected override void Animate()
    {
        animator.SetFloat("Speed", movement.velocity.magnitude / speed);
        animator.SetBool("OnGround", movement.isGrounded);
    }
}
