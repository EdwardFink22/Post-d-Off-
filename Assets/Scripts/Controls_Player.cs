using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls_Player : ControlScheme
{
    public override void AddInput()
    {
        controls.Player.Movement.started += OnMove;
        controls.Player.Movement.performed += OnMove;
        controls.Player.Movement.canceled += OnMove;

    }
}
