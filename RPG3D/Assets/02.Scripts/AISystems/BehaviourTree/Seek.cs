using UnityEditor.AnimatedValues;
using UnityEngine;

namespace RPG.AISystems.BehaviourTree
{
    public class Seek : Node
    {
        private float _radius;
        private float _angle;
        private float _deltaAngle;
        private LayerMask _targetMask;
        private Vector3 _offset;


        public Seek(BehaviourTreeBuilder tree, BlackBoard blackBaord, float radius, float angle, float deltaAngle, LayerMask targetMask, Vector3 offset)
            : base(tree, blackBaord)
        {
            _radius = radius;
            _angle = angle;
            _deltaAngle = deltaAngle;
            _targetMask = targetMask;
            _offset = offset;
        }


        public override Result Invoke()
        {
            bool result = false;
            Ray ray;
            RaycastHit hit;
            blackBoard.target = null;

            for (float theta = 0; theta < _angle / 2.0f; theta += _deltaAngle)
            {
                ray = new Ray(blackBoard.transform.position + _offset,
                              Quaternion.Euler(Vector3.up * theta) * blackBoard.transform.forward * _radius);

                if (Physics.Raycast(ray, out hit, _radius, _targetMask))
                {
                    Debug.DrawRay(ray.origin, ray.direction * _radius, Color.red);
                    blackBoard.target = hit.transform;
                    result = true;
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * _radius, Color.green);
                }

                ray = new Ray(blackBoard.transform.position + _offset,
                              Quaternion.Euler(Vector3.up * -theta) * blackBoard.transform.forward * _radius);

                if (Physics.Raycast(ray, out hit, _radius, _targetMask))
                {
                    Debug.DrawRay(ray.origin, ray.direction * _radius, Color.red);
                    blackBoard.target = hit.transform;
                    result = true;
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * _radius, Color.green);
                }
            }

            if (result)
            {
                blackBoard.agent.destination = blackBoard.target.position;
            }

            return result ? Result.Success : Result.Failure;
        }
    }
}