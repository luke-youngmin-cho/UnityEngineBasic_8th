public class StateHurt : State
{
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
                    currentStep++;
                }
                break;
            case IStateEnumerator<StateType>.Step.Start:
                {
                    animator.Play("Hurt");
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
                    next = StateType.Idle;
                }
                break;
            default:
                break;
        }

        return next;
    }
}