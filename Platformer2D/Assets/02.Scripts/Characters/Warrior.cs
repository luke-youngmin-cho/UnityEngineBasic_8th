using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Player
{
    override protected void Start()
    {
        base.Start();
        stateMachine.InitStates(new Dictionary<StateType, IStateEnumerator<StateType>>()
        {
            { StateType.Idle, new StateIdle(stateMachine) },
            { StateType.Move, new StateMove(stateMachine) },
            { StateType.Jump, new StateJump(stateMachine) },
            { StateType.Fall, new StateFall(stateMachine) },
            { StateType.Land, new StateLand(stateMachine) },
            { StateType.Attack, new StateAttack(stateMachine) },
            { StateType.Hurt, new StateHurt(stateMachine) },
            { StateType.Die,  new StateDie(stateMachine) },
        });
    }
}
