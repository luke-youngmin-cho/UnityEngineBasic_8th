using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderDetector : MonoBehaviour
{
    public bool isGoUpPossible
    {
        get
        {
            Collider2D col =
            Physics2D.OverlapCircle((Vector2)transform.position + Vector2.up * _upLadderDetectOffset,
                                    _detectRadius,
                                    _ladderMask);
            upLadder = col ? col.GetComponent<Ladder>() : null;
            return upLadder;
        }
    }

    public bool isGoDownPossible
    {
        get
        {
            Collider2D col =
            Physics2D.OverlapCircle((Vector2)transform.position + Vector2.down * _downLadderDetectOffset,
                                    _detectRadius,
                                    _ladderMask);
            downLadder = col ? col.GetComponent<Ladder>() : null;
            return downLadder;
        }
    }

    public Ladder upLadder;
    public Ladder downLadder;    
    [SerializeField] private float _upLadderDetectOffset;
    [SerializeField] private float _downLadderDetectOffset;
    [SerializeField] private float _detectRadius;
    [SerializeField] private LayerMask _ladderMask;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * _upLadderDetectOffset,
                              _detectRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * _downLadderDetectOffset, 
                              _detectRadius); 
    }
}
