using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nepenthes : Enemy
{
    [SerializeField] private Vector2 _attackBoxCenter;
    [SerializeField] private Vector2 _attackBoxSize;
    [SerializeField] private LayerMask _attackTargetMask;
    [SerializeField] private float _attackDamage = 10.0f;

    override protected void Start()
    {
        base.Start();
        stateMachine.InitStates(new Dictionary<StateType, IStateEnumerator<StateType>>()
        {
            { StateType.Idle, new StateIdle(stateMachine) },
            { StateType.Move, new StateMove(stateMachine) },
            { StateType.Attack, new StateAttack(stateMachine) },
        });

    }
    private void Hit()
    {
        Debug.Log($"Hit!");
        Collider2D target =
        Physics2D.OverlapBox((Vector2)transform.position + new Vector2(_attackBoxCenter.x * movement.direction, _attackBoxCenter.y),
                             _attackBoxSize,
                             0.0f,
                             _attackTargetMask);

        if (target &&
            target.TryGetComponent(out IHp iHp))
        {
            iHp.hp -= _attackDamage;
        }
    }

    private void OnDrawGizmos()
    {
        int direction = movement ? movement.direction : 1;
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position + new Vector3(_attackBoxCenter.x * direction, _attackBoxCenter.y, 0.0f),
                            _attackBoxSize);
    }
}
