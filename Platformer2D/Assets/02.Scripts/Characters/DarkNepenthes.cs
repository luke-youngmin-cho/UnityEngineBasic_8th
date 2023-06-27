using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkNepenthes : Enemy
{
    [SerializeField] private float _damage = 20.0f;
    [SerializeField] private float _projectileDamage = 30.0f;
    [SerializeField] private float _projectileSpeed = 3.0f;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private DarkNepenthesProjectile _projectilePrefab;

    override protected void Start()
    {
        base.Start();
        stateMachine.InitStates(new Dictionary<StateType, IStateEnumerator<StateType>>()
        {
            { StateType.Idle, new StateIdle(stateMachine) },
            { StateType.Move, new StateMove(stateMachine) },
            { StateType.Attack, new StateAttack(stateMachine) },
            { StateType.Hurt, new StateHurt(stateMachine) },
            { StateType.Die,  new StateDie(stateMachine) },
        });
    }

    private void Hit()
    {
        Instantiate(_projectilePrefab,
                    transform.position + new Vector3(movement.direction * 0.1f, 0.2f, 0.0f),
                    Quaternion.identity)
            .SetUp(gameObject,
                   new Vector2(movement.direction * _projectileSpeed, 0.0f),
                   _projectileDamage,
                   _targetMask);
    }
}
