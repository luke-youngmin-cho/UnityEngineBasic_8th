using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCrouch : State
{
    public override bool canExecute => machine.currentType == StateType.Idle ||
                                       machine.currentType == StateType.Move;


    public StateCrouch(StateMachine machine) : base(machine)
    {
    }


    public override StateType MoveNext()
    {
        StateType next = StateType.Crouch;

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
                    movement.isDirectionChangeable = true;
                    animator.Play("CrouchStart");
                    currentStep++;
                }
                break;
            case IStateEnumerator<StateType>.Step.Casting:
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                    {
                        currentStep++;
                    }
                }
                break;
            case IStateEnumerator<StateType>.Step.DoAction:
                {
                    animator.Play("CrouchIdle");
                    currentStep++;
                }
                break;
            case IStateEnumerator<StateType>.Step.WaitUntilActionFinished:
                {

                }
                break;
            case IStateEnumerator<StateType>.Step.Finish:
                break;
            default:
                break;
        }

        return next;
    }
}
