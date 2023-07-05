using System.Linq;
using UnityEngine;

public enum StateType
{
    Idle,
    Move,
    Jump,
    DownJump,
    Fall,
    Land,
    LadderUp,
    LadderDown,
    Crouch,
    StandUp,
    Attack,
    Hurt,
    Die
}

public abstract class State : IStateEnumerator<StateType>
{
    public abstract bool canExecute { get; }

    public IStateEnumerator<StateType>.Step current => currentStep;
    protected IStateEnumerator<StateType>.Step currentStep;
    protected StateMachine machine;
    protected Animator animator;
    protected Rigidbody2D rigidBody;
    protected CapsuleCollider2D trigger;
    protected CapsuleCollider2D collider;
    protected Transform transform;
    protected Movement movement;
    protected Character character;

    public State(StateMachine machine)
    {
        this.machine = machine;
        this.animator = machine.GetComponentInChildren<Animator>();
        this.rigidBody = machine.GetComponent<Rigidbody2D>();
        this.trigger = machine.GetComponentsInChildren<CapsuleCollider2D>().Where(c => c.isTrigger == true).First();
        this.collider = machine.GetComponentsInChildren<CapsuleCollider2D>().Where(c => c.isTrigger == false).First();
        this.transform = machine.GetComponent<Transform>();
        this.movement = machine.GetComponent<Movement>();
        this.character = machine.GetComponent<Character>();
    }

    public abstract StateType MoveNext();

    public virtual void Reset()
    {
        currentStep = IStateEnumerator<StateType>.Step.None;
    }
}