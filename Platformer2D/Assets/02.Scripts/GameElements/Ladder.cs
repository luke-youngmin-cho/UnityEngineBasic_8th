using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Vector2 ladderTopPos => (Vector2)transform.position +
                                   Vector2.up * _bound.size.y / 2.0f;

    public Vector2 ladderUpStartPos => (Vector2)transform.position +
                                        Vector2.down * _bound.size.y / 2.0f +
                                        Vector2.up * _ladderUpStartOffsetY;
    public Vector2 ladderUpEndPos => (Vector2)transform.position +
                                      Vector2.up * _bound.size.y / 2.0f +
                                      Vector2.down * _ladderUpEndOffsetY;

    public Vector2 ladderDownStartPos => (Vector2)transform.position +
                                          Vector2.up * _bound.size.y / 2.0f +
                                          Vector2.down * _ladderDownStartOffsetY;

    public Vector2 ladderDownEndPos => (Vector2)transform.position +
                                        Vector2.down * _bound.size.y / 2.0f +
                                        Vector2.down * _ladderDownEndOffsetY;

    [SerializeField] private float _ladderUpStartOffsetY = 0.05f;
    [SerializeField] private float _ladderUpEndOffsetY = 0.05f;
    [SerializeField] private float _ladderDownStartOffsetY = 0.1f;
    [SerializeField] private float _ladderDownEndOffsetY = 0.1f;
    private BoxCollider2D _bound;

    private void Awake()
    {
        _bound = GetComponent<BoxCollider2D>();
    }

    private void OnDrawGizmos()
    {
        if (_bound == null)
            _bound = GetComponent<BoxCollider2D>();

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.left  * 0.1f + (Vector3)ladderUpStartPos,
                        Vector3.right * 0.1f + (Vector3)ladderUpStartPos);
        Gizmos.DrawLine(Vector3.left  * 0.1f + (Vector3)ladderUpEndPos,
                        Vector3.right * 0.1f + (Vector3)ladderUpEndPos);

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(Vector3.left  * 0.1f + (Vector3)ladderDownStartPos,
                        Vector3.right * 0.1f + (Vector3)ladderDownStartPos);
        Gizmos.DrawLine(Vector3.left  * 0.1f + (Vector3)ladderDownEndPos,
                        Vector3.right * 0.1f + (Vector3)ladderDownEndPos);
    }
}
