public class StateHurt : State
{
    public override bool canExecute => machine.currentType != StateType.Attack;
    public StateHurt(StateMachine machine) : base(machine)
    {
    }

    public override StateType MoveNext()
    {
        StateType next = StateType.Hurt;

        switch (currentStep)
        {
            case IStateEnumerator<StateType>.Step.None:
                {
                    movement.isMovable = false;
                    movement.isDirectionChangeable = false;
                    animator.Play("Hurt");
                    currentStep++;
                }
                break;
            case IStateEnumerator<StateType>.Step.Start:
                {
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
                    next = movement.horizontal == 0.0f ? StateType.Idle : StateType.Move;
                }
                break;
            default:
                break;
        }

        return next;
    }
}