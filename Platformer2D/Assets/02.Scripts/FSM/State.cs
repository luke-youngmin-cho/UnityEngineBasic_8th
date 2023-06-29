using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum StateType
{
    Idle,
    Move,
    Jump,
    Fall,
    Land,
    Crouch,
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
    protected CapsuleCollider2D collider;
    protected Transform transform;
    protected Movement movement;
    protected Character character;

    public State(StateMachine machine)
    {
        this.machine = machine;
        this.animator = machine.GetComponentInChildren<Animator>();
        this.rigidBody = machine.GetComponent<Rigidbody2D>();
        this.collider = machine.GetComponent<CapsuleCollider2D>();
        this.transform = machine.GetComponent<Transform>();
        this.movement = machine.GetComponent<Movement>();
        this.character = machine.GetComponent<Character>();
    }

    public abstract StateType MoveNext();

    public void Reset()
    {
        currentStep = IStateEnumerator<StateType>.Step.None;
    }
}