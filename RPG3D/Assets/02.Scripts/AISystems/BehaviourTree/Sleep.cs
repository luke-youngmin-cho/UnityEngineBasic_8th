using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.AISystems.BehaviourTree
{
    public class Sleep : Node
    {
        private float _time;
        public Sleep(float time, BehaviourTreeBuilder tree, BlackBoard blackBoard)
            : base(tree, blackBoard)
        {
            _time = time;
        }

        public override Result Invoke()
        {
            tree.Sleep(_time);
            return Result.Running;
        }
    }
}