using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkNepenthesProjectile : MonoBehaviour
{
    private GameObject _owner;
    private Vector2 _velocity;
    private float _damage;
    private LayerMask _targetMask;

    public void SetUp(GameObject owner, Vector2 velocity, float damage, LayerMask targetMask)
    {
        _owner = owner;
        _velocity = velocity;
        _damage = damage;
        _targetMask = targetMask;
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)_velocity * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & _targetMask) > 0)
        {
            if (collision.TryGetComponent(out IHp ihp))
            {
                ihp.Damage(_owner, _damage);
                Destroy(gameObject);
            }
        }
    }
}
