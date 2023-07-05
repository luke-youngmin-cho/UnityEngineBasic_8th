using System;
using UnityEngine;


public abstract class Character : MonoBehaviour, IHp
{
    [Header("Stats")]
    public float jumpForce = 2.5f;
    public float downJumpForce = 1.0f;
    public float landDistance = 1.0f;
    public float ladderMoveSpeed = 1.0f;

    protected Movement movement;
    protected StateMachine stateMachine;

    public float hp
    {
        get => _hp;
        set
        {
            if (_hp == value)
                return;

            float prev = _hp;
            _hp = value;

            onHpChanged?.Invoke(value);
            if (prev > value)
            {
                onHpDecreased?.Invoke(prev - value);
                if (value <= _hpMin)
                {
                    onHpMin?.Invoke();
                    stateMachine.ChangeState(StateType.Die);
                }
                else
                {
                    stateMachine.ChangeState(StateType.Hurt);
                }
            }
            else
            {
                onHpIncreased?.Invoke(value - prev);
                if (value >= _hpMax)
                {
                    onHpMax?.Invoke();
                }
            }
        }
    }

    public float hpMin => _hpMin;

    public float hpMax => _hpMax;

    private float _hp;
    private float _hpMin;
    [SerializeField] private float _hpMax;

    public event Action<float> onHpChanged;
    public event Action<float> onHpDecreased;
    public event Action<float> onHpIncreased;
    public event Action onHpMin;
    public event Action onHpMax;

    protected virtual void Awake()
    {
        movement = GetComponent<Movement>();
        stateMachine = GetComponent<StateMachine>();

        movement.onHorizontalChanged += (value) =>
        {
            stateMachine.ChangeState(value == 0.0f ? StateType.Idle : StateType.Move);
        };
    }

    protected virtual void Start()
    {
        hp = hpMax;
    }

    public virtual void Damage(GameObject damager, float amout)
    {
        hp -= amout;
    }

    public virtual void Heal(GameObject healer, float amount)
    {
        hp += amount;
    }
}