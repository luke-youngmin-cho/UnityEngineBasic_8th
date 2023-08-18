using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.AISystems.BehaviourTree
{
    public abstract class Composite : Node, IParentOfChildren
    {
        protected Composite(BehaviourTreeBuilder tree, BlackBoard blackBoard) : base(tree, blackBoard)
        {
            children = new List<Node>();
        }

        public List<Node> children { get; set; }
    }
}