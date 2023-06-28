using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : Character
{
    private float _horizontal;
    public void OnHorizontal(InputValue value)
    {
        _horizontal = value.Get<float>();
    }

    public void OnAttack()
    {
        stateMachine.ChangeState(StateType.Attack);
    }

    private void Update()
    {
        movement.horizontal = _horizontal;
    }
}
