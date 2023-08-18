using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.AISystems.BehaviourTree
{
    public class Selector : Composite
    {
        public Selector(BehaviourTreeBuilder tree, BlackBoard blackBoard) : base(tree, blackBoard)
        {
        }

        public override Result Invoke()
        {
            Result result = Result.Failure;
            foreach (var child in children)
            {
                result = child.Invoke();
                if (result != Result.Failure)
                    break;
            }
            return result;
        }
    }
}