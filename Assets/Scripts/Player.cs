using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Components;
using ECM.Controllers;

public class Player : MonoBehaviour
{
    public ControlScheme controls;
    public Animator anim;

    private void Awake()
    {
        GameControls input = new GameControls();

        controls.SetInput(input);
        controls.SetCharacterMovement(GetComponent<CharacterMovement>());
        controls.animator = anim;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
