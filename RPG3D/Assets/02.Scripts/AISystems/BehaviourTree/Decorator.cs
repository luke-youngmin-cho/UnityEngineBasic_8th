using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.AISystems.BehaviourTree
{
    public class Decorator : Node, IParentOfChild
    {
        public Node child { get; set; }
        private Func<Result, Result> _decorate;

        public Decorator(BehaviourTreeBuilder tree, BlackBoard blackBoard, Func<Result, Result> decorate) 
            : base(tree, blackBoard)
        {
            _decorate = decorate;
        }

        public override Result Invoke()
        {
            return _decorate.Invoke(child.Invoke());
        }
    }
}