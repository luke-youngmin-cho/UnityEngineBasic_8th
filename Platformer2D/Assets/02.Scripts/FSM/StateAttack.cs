using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttack : State
{
    public override bool canExecute => machine.currentType == StateType.Idle ||
                                       machine.currentType == StateType.Move;
                                       
    public StateAttack(StateMachine machine) : base(machine)
    {
    }

    public override StateType MoveNext()
    {
        StateType next = StateType.Attack;

        switch (currentStep)
        {
            case IStateEnumerator<StateType>.Step.None:
                {
                    currentStep++;
                }
                break;
            case IStateEnumerator<StateType>.Step.Start:
                {
                    movement.isMovable = false;
                    movement.isDirectionChangeable = false;
                    animator.Play("Attack");
                    currentStep++;
                }
                break;
            case IStateEnumerator<StateType>.Step.Casting:
                {
                    currentStep++;
                }
                break;
            case IStateEnumerator<StateType>.Step.DoAction:
                {
                    currentStep++;
                }
                break;
            case IStateEnumerator<StateType>.Step.WaitUntilActionFinished:
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                    {
                        currentStep++;
                    }
                }
                break;
            case IStateEnumerator<StateType>.Step.Finish:
                {
                    next = movement.horizontal == 0.0f ?  StateType.Idle : StateType.Move;
                }
                break;
            default:
                break;
        }

        return next;
    }
}
