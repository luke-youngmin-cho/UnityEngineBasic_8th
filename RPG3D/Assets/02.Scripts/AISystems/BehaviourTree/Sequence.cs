using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.AISystems.BehaviourTree
{
    public class Sequence : Composite
    {
        public override Result Invoke()
        {
            Result result = Result.Success;
            foreach (var child in children)
            {
                result = child.Invoke();
                if (result != Result.Success)
                    break;
            }
            return result;
        }
    }
}