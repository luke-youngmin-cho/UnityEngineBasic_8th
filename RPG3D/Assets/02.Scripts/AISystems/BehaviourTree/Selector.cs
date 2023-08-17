using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.AISystems.BehaviourTree
{
    public class Selector : Composite
    {
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