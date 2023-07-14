using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationActions : MonoBehaviour
{
    protected Player player;

    protected virtual void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    protected virtual void AttackHit() { }
}
