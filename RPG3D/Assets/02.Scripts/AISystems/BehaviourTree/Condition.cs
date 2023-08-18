using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.AISystems.BehaviourTree
{
    public class Condition : Node, IParentOfChild
    {
        public Node child { get; set; }
        private Func<bool> _condition;

        public Condition(BehaviourTreeBuilder tree, BlackBoard blackBoard, Func<bool> condition) 
            : base(tree, blackBoard)
        {
            _condition = condition;
        }

        public override Result Invoke()
        {
            if (_condition.Invoke())
                return child.Invoke();

            return Result.Failure;
        }
    }
}