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

    }

    public virtual void AddInput()
    {

    }

    public virtual void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
        Orient();
    }

    //Orient makes your character move relative to where the camera is facing
    public void Orient()
    {

    }
}
