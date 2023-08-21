using UnityEngine;

namespace RPG.AISystems.BehaviourTree
{
    public class RandomSleep : Node
    {
        private float _minTime;
        private float _maxTime;
        public RandomSleep(float minTime, float maxTime, BehaviourTreeBuilder tree, BlackBoard blackBoard)
            : base(tree, blackBoard)
        {
            _minTime = minTime;
            _maxTime = maxTime;
        }

        public override Result Invoke()
        {
            tree.Sleep(Random.Range(_minTime, _maxTime));
            return Result.Running;
        }
    }
}