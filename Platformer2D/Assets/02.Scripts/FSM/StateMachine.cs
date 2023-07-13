using UnityEngine;
using System.Collections.Generic;

public class StateMachine : MonoBehaviour
{
    public StateType currentType;
    public IStateEnumerator<StateType> current;
    public Dictionary<StateType, IStateEnumerator<StateType>> states;

    public bool ChangeState(StateType newType)
    {
        if (currentType == newType)
            return false;

        if (states[newType].canExecute == false)
            return false;

        states[currentType].Reset();
        current = states[newType];
        currentType = newType;
        current.MoveNext();
        return true;
    }

    private void Update()
    {
        ChangeState(current.MoveNext());
    }

    public void InitStates(Dictionary<StateType, IStateEnumerator<StateType>> states)
    {
        this.states = states;
        current = states[currentType];
    }
}