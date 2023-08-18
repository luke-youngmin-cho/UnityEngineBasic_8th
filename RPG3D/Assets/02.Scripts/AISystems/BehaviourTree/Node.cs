using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.AISystems.BehaviourTree
{
    public enum Result
    {
        Success,
        Failure,
        Running
    }

    public abstract class Node
    {
        protected BehaviourTreeBuilder tree;
        protected BlackBoard blackBoard;

        public Node(BehaviourTreeBuilder tree, BlackBoard blackBoard)
        {
            this.tree = tree;
            this.blackBoard = blackBoard;
        }

        public abstract Result Invoke();
    }
}