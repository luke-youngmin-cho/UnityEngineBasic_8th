using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.AISystems.BehaviourTree
{
    public class Execution : Node
    {
        private Func<Result> _execute;

        public Execution(Func<Result> execute)
        {
            _execute = execute;
        }

        public override Result Invoke()
        {
            return _execute.Invoke();
        }
    }
}