using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool isDetected => _isDetected;
    [SerializeField] private bool _isDetected;
    private Collider2D _detected;
    [SerializeField] private Vector2 _castOffset;
    [SerializeField] private Vector2 _castSize;
    [SerializeField] private LayerMask _groundMask;

    private void FixedUpdate()
    {
        _detected = Physics2D.OverlapBox((Vector2)transform.position + _castOffset,
                                         _castSize,
                                         0.0f,
                                         _groundMask);
        _isDetected = _detected;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + (Vector3)_castOffset, _castSize);
    }
}
