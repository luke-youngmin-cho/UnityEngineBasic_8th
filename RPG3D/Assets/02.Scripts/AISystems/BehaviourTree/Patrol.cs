using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace RPG.AISystems.BehaviourTree
{
    public class Patrol : Node
    {
        private float _range;
        private float _maxHeight = 5.0f;
        private float _tolerance = 1.0f;
        private LayerMask _groundMask = 1 << LayerMask.NameToLayer("Ground");

        public Patrol(float range, BehaviourTreeBuilder tree, BlackBoard blackBoard)
            : base(tree, blackBoard)
        {
            _range = range;
        }

        public override Result Invoke()
        {
            Debug.Log($"Patrol ...");
            float l = Random.Range(0, _range);
            float theta = Random.Range(0, 2.0f * Mathf.PI);
            Vector3 expected = blackBoard.transform.position + new Vector3(l * Mathf.Cos(theta),
                                                                           0.0f,
                                                                           l * Mathf.Sin(theta));
            if (Physics.SphereCast(expected + Vector3.up * _maxHeight, 
                                   _tolerance,
                                   Vector3.down,
                                   out RaycastHit hit,
                                   _maxHeight * 2.0f,
                                   _groundMask) == false)
            {
                return Result.Failure;
            }

            if (NavMesh.SamplePosition(hit.point,
                                           out NavMeshHit areaHit,
                                           _tolerance,
                                           NavMesh.AllAreas))
            {
                blackBoard.agent.destination = areaHit.position;
                return Result.Success;
            }

            return Result.Failure;
        }
    }
}