using System.Collections.Generic;

public class Slug : Enemy
{
    override protected void Start()
    {
        base.Start();
        stateMachine.InitStates(new Dictionary<StateType, IStateEnumerator<StateType>>()
        {
            { StateType.Idle, new StateIdle(stateMachine) },
            { StateType.Move, new StateMove(stateMachine) }
        });
    }
}