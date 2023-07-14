using System.Linq.Expressions;
using UnityEngine;

public class WarriorAnimationActions : PlayerAnimationActions
{
    [SerializeField] private Vector2 _attackCastOffset;    
    [SerializeField] private Vector2 _attackCastSize;
    [SerializeField] private LayerMask _attackTargetMask;
    private Movement _movement;

    protected override void Awake()
    {
        base.Awake();
        _movement = GetComponentInParent<Movement>();
    }

    protected override void AttackHit()
    {
        base.AttackHit();
        Collider2D col =
        Physics2D.OverlapBox((Vector2)player.transform.position + new Vector2(_attackCastOffset.x * _movement.direction,
                                                                              _attackCastOffset.y),
                             _attackCastSize,
                             0.0f,
                             _attackTargetMask);

        if (col &&
            col.TryGetComponent(out IHp ihp))
        {
            ihp.Damage(player.gameObject, player.attackForce);
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 playerPos = GetComponentInParent<Player>().transform.position;
        int direction = 1;
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(playerPos + new Vector3(_attackCastOffset.x * direction,
                                                    _attackCastOffset.y,
                                                    0.0f),
                             _attackCastSize);
    }
}