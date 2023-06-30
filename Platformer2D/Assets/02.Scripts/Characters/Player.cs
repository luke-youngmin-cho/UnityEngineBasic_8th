using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : Character
{
    private PlayerInput playerInput;
    private float _horizontal;
    private float _vertical;
    public void OnHorizontal(InputValue value)
    {
        _horizontal = value.Get<float>();
    }

    public void OnVertical(InputValue value)
    {
        _vertical = value.Get<float>();
    }

    public void OnAttack()
    {
        stateMachine.ChangeState(StateType.Attack);
    }

    public void OnJump()
    {
        stateMachine.ChangeState(StateType.Jump);
    }

    protected override void Awake()
    {
        base.Awake();
        playerInput = GetComponent<PlayerInput>();
        InputAction crouchAction = playerInput.currentActionMap.FindAction("Crouch");
        crouchAction.performed += ctx => stateMachine.ChangeState(StateType.Crouch);
        crouchAction.canceled  += ctx => stateMachine.ChangeState(StateType.StandUp);
    }

    private void Update()
    {
        movement.horizontal = _horizontal;
        if (_horizontal > 0)
            movement.direction = Movement.DIRECTION_RIGHT;
        else if (_horizontal < 0)
            movement.direction = Movement.DIRECTION_LEFT;
    }
}
