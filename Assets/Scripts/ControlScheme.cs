using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ECM.Common;
using ECM.Controllers;
public class ControlScheme : BaseCharacterController
{
    //Controller Input
    protected GameControls controls;
    //Saves the last input we received from the controller
    protected Vector2 moveInput;

    //Called by the PlayerScript. Gives it access to the input
    public virtual void SetInput(GameControls c)
    {
        controls = c;
        AddInput();

    }

    public virtual void AddInput() {}

    public virtual void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();   //setting the move input
        Orient();   
    }

    protected virtual void OnJump(InputAction.CallbackContext ctx)
    {
        jump = ctx.performed;
    }

    protected override void HandleInput() {    }

    //Orient makes your character move relative to where the camera is facing
    //Orient means to make something face the right direction
    public void Orient()
    {
        moveDirection = new Vector3()
        {
            x = moveInput.x,
            y = 0,
            z = moveInput.y
        };
        moveDirection = moveDirection.relativeTo(Camera.main.transform);
    }

}
