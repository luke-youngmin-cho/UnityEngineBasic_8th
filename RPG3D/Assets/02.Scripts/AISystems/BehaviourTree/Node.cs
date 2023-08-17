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
        public abstract Result Invoke();
    }
}