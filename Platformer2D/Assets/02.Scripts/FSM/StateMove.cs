public class StateMove : State
{
    public override bool canExecute => true;
    private GroundDetector _groundDetector;

    public StateMove(StateMachine machine) : base(machine)
    {
        _groundDetector = machine.GetComponent<GroundDetector>();
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
                    movement.isMovable = true;
                    movement.isDirectionChangeable = true;
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
                    if (_groundDetector.isDetected == false)
                    {
                        next = StateType.Fall;
                    }
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