using System.Collections.Generic;

public class Enemy : Character
{
    private void Start()
    {
        stateMachine.InitStates(new Dictionary<StateType, IStateEnumerator<StateType>>()
        {
            { StateType.Idle, new StateIdle(stateMachine) },
            { StateType.Move, new StateMove(stateMachine) }
        });
    }
}