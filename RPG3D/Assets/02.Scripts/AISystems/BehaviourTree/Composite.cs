using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.AISystems.BehaviourTree
{
    public abstract class Composite : Node, IParentOfChildren
    {
        public List<Node> children { get; set; }
    }
}