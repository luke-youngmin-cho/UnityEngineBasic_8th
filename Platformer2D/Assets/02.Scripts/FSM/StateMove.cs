public class StateMove : State
{
    public StateMove(StateMachine machine) : base(machine)
    {
    }

    public override StateType MoveNext()
    {
        StateType next = StateType.Move;

        switch (currentStep)
        {
            case IStateEnumerator<StateType>.Step.None:
                {
                    currentStep++;
                }
                break;
            case IStateEnumerator<StateType>.Step.Start:
                {
                    animator.Play("Move");
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
                    // looping...
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