using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine), typeof(EnemyMovement), typeof(CapsuleCollider2D))]
public class EnemyAI : MonoBehaviour
{
    public enum Step
    {
        Idle,
        Think,
        TakeARest,
        MoveLeft,
        MoveRight,
        StartFollow,
        Follow,
        StartAttack,
        Attack,
    }
    [SerializeField] private Step _step;
    [SerializeField] private bool _autoFollow;
    [SerializeField] private LayerMask _detectMask;
    [SerializeField] private float _detectRange = 1.5f;
    [SerializeField] private bool _attackEnable;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private float _thinkTimeMin = 0.1f;
    [SerializeField] private float _thinkTimeMax = 2.0f;
    [SerializeField] private float _thinkTimer;
    public GameObject target;
    private StateMachine _stateMachine;
    private EnemyMovement _movement;
    private CapsuleCollider2D _collider;

    private void Awake()
    {
        _stateMachine = GetComponent<StateMachine>();   
        _movement = GetComponent<EnemyMovement>();
        _collider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        Collider2D detected = Physics2D.OverlapCircle(transform.position, _detectRange, _detectMask);
        target = detected ? detected.gameObject : null;

        if (_autoFollow &&
            _step < Step.StartFollow &&
            target)
        {
            _step = Step.StartFollow;
        }


        switch (_step)
        {
            case Step.Idle:
                break;
            case Step.Think:
                {
                    _step = (Step)Random.Range((int)Step.TakeARest, (int)Step.MoveRight + 1);
                    _thinkTimer = Random.Range(_thinkTimeMin, _thinkTimeMax);

                     _stateMachine.ChangeState(_step == Step.TakeARest ? StateType.Idle : StateType.Move);
                }
                break;
            case Step.TakeARest:
                {
                    _movement.horizontal = 0.0f;
                    if (_thinkTimer > 0)
                        _thinkTimer -= Time.deltaTime;
                    else
                        _step = Step.Think;
                }
                break;
            case Step.MoveLeft:
                {
                    _movement.direction = Movement.DIRECTION_LEFT;
                    _movement.horizontal = -1.0f;
                    if (_thinkTimer > 0)
                        _thinkTimer -= Time.deltaTime;
                    else
                        _step = Step.Think;
                }
                break;
            case Step.MoveRight:
                {
                    _movement.direction = Movement.DIRECTION_RIGHT;
                    _movement.horizontal = +1.0f;
                    if (_thinkTimer > 0)
                        _thinkTimer -= Time.deltaTime;
                    else
                        _step = Step.Think;
                }
                break;
            case Step.StartFollow:
                {
                    _stateMachine.ChangeState(StateType.Move);
                    _step = Step.Follow;
                }
                break;
            case Step.Follow:
                {
                    if (target == null)
                    {
                        _step = Step.Think;
                        return;
                    }

                    if (transform.position.x < target.transform.position.x - _collider.size.x)
                    {
                        _movement.direction = Movement.DIRECTION_RIGHT;
                        _movement.horizontal = 1.0f;
                    }
                    else if (transform.position.x > target.transform.position.x + _collider.size.x)
                    {
                        _movement.direction = Movement.DIRECTION_LEFT;
                        _movement.horizontal = -1.0f;
                    }

                    if (_attackEnable &&
                        Vector2.Distance(transform.position, target.transform.position) < _attackRange)
                    {
                        _step = Step.StartAttack;
                    }
                }
                break;
            case Step.StartAttack:
                {
                    _stateMachine.ChangeState(StateType.Attack);
                    _step = Step.Attack;
                }
                break;
            case Step.Attack:
                {
                    if (_stateMachine.currentType != StateType.Attack)
                        _step = Step.Think;
                }
                break;
            default:
                break;
        }
    }

    private void OnDrawGizmos()
    {
        if (_autoFollow)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _detectRange);
        }

        if (_attackEnable)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackRange);
        }
    }
}
