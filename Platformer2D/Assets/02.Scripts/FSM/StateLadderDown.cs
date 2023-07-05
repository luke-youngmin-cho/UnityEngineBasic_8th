using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateLadderDown : State
{
    public override bool canExecute => (machine.currentType == StateType.Idle ||
                                        machine.currentType == StateType.Move ||
                                        machine.currentType == StateType.Jump ||
                                        machine.currentType == StateType.Fall) &&
                                        _ladderDetector.isGoDownPossible;

    private LadderDetector _ladderDetector;
    private GroundDetector _groundDetector;
    private Ladder _ladder;

    public StateLadderDown(StateMachine machine) : base(machine)
    {
        _ladderDetector = machine.GetComponent<LadderDetector>();
        _groundDetector = machine.GetComponent<GroundDetector>();
    }

    public override StateType MoveNext()
    {
        StateType next = StateType.LadderUp;

        switch (currentStep)
        {
            case IStateEnumerator<StateType>.Step.None:
                {
                    _ladder = _ladderDetector.downLadder;
                    movement.isMovable = false;
                    movement.isDirectionChangeable = false;
                    rigidBody.bodyType = RigidbodyType2D.Kinematic;
                    rigidBody.velocity = Vector2.zero;
                    animator.speed = 0.0f;
                    animator.Play("Ladder");
                    currentStep++;
                }
                break;
            case IStateEnumerator<StateType>.Step.Start:
                {
                    if (_groundDetector.isDetected)
                    {
                        transform.position = _ladder.ladderDownStartPos;
                    }
                    else
                    {
                        transform.position = new Vector2(_ladder.transform.position.x,
                                                         rigidBody.position.y);
                    }

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
                    if (_groundDetector.isDetected)
                    {
                        next = movement.horizontal == 0.0f ? StateType.Idle : StateType.Move;
                    }
                    else if (rigidBody.position.y < _ladder.ladderDownEndPos.y)
                    {
                        next = StateType.Idle;
                    }
                    else if (rigidBody.position.y > _ladder.ladderUpEndPos.y)
                    {
                        transform.position = _ladder.ladderTopPos;
                        next = movement.horizontal == 0.0f ? StateType.Idle : StateType.Move;
                    }
                    else
                    {
                        float vertical = Input.GetAxis("Vertical");
                        animator.speed = Mathf.Abs(vertical);
                        transform.position += Vector3.up * vertical * character.ladderMoveSpeed * Time.deltaTime;
                    }
                }
                break;
            case IStateEnumerator<StateType>.Step.Finish:
                {
                }
                break;
            default:
                break;
        }

        return next;
    }

    public override void Reset()
    {
        base.Reset();
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
        animator.speed = 1.0f;
    }
}
