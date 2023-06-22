using UnityEngine;


public abstract class Character : MonoBehaviour
{
    protected Movement movement;
    protected StateMachine stateMachine;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        stateMachine = GetComponent<StateMachine>();

        movement.onHorizontalChanged += (value) =>
        {
            stateMachine.ChangeState(value == 0.0f ? StateType.Idle : StateType.Move);
        };
    }
}