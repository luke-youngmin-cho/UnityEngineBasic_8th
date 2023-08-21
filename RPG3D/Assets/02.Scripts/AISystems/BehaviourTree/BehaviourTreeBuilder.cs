using RPG.FSM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.AISystems.BehaviourTree
{
    public class BlackBoard
    {
        // owner
        public GameObject owner;
        public Transform transform;
        public NavMeshAgent agent;
        public MachineManager machineManager;

        // target
        public Transform target;

        public BlackBoard(GameObject owner)
        {
            this.owner = owner;
            transform = owner.transform;
            agent = owner.GetComponent<NavMeshAgent>();
            machineManager = owner.GetComponent<MachineManager>();
        }
    }


    public class BehaviourTreeBuilder
    {
        public BlackBoard blackBoard;
        public Root root;
        private Node _current;
        private Stack<Composite> _compositeStack = new Stack<Composite>();
        private bool paused;

        public Result Tick()
        {
            return paused ? Result.Running : root.Invoke();
        }

        public void Sleep(float seconds)
        {
            paused = true;
            blackBoard.machineManager.StartCoroutine(C_Sleep(seconds));
        }

        IEnumerator C_Sleep(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            paused = false;
        }


        public BehaviourTreeBuilder StartBuild(GameObject owner)
        {
            blackBoard = new BlackBoard(owner);
            root = new Root(this, blackBoard);
            Node node = root;
            _current = node;
            return this;
        }

        public BehaviourTreeBuilder ExitCurrentComposite()
        {
            if (_compositeStack.Count > 1)
            {
                _compositeStack.Pop();
                _current = _compositeStack.Peek();
            }
            else if (_compositeStack.Count == 0)
            {
                _compositeStack.Pop();
                _current = null;
            }
            else
            {
                throw new Exception($"[BehaviourTreeBuilder] : Cannot exit composite. Stack is empty.");
            }

            return this;
        }

        public BehaviourTreeBuilder Condition(Func<bool> condition)
        {
            Node node = new Condition(this, blackBoard, condition);
            AttachAsChild(_current, node);
            _current = node;
            return this;
        }

        public BehaviourTreeBuilder Execution(Func<Result> execute)
        {
            Node node = new Execution(this, blackBoard, execute);
            AttachAsChild(_current, node);

            if (_compositeStack.Count > 0)
                _current = _compositeStack.Peek();
            else
                _current = null;

            return this;
        }

        public BehaviourTreeBuilder Patrol(float range)
        {
            Node node = new Patrol(range, this, blackBoard);
            AttachAsChild(_current, node);

            if (_compositeStack.Count > 0)
                _current = _compositeStack.Peek();
            else
                _current = null;

            return this;
        }
        public BehaviourTreeBuilder RandomSleep(float minTime, float maxTime)
        {
            Node node = new RandomSleep(minTime, maxTime, this, blackBoard);
            AttachAsChild(_current, node);

            if (_compositeStack.Count > 0)
                _current = _compositeStack.Peek();
            else
                _current = null;

            return this;
        }

        public BehaviourTreeBuilder Seek(float radius, float angle, float deltaAngle, LayerMask targetMask, Vector3 offset)
        {
            Node node = new Seek(this, blackBoard, radius, angle, deltaAngle, targetMask, offset);
            AttachAsChild(_current, node);

            if (_compositeStack.Count > 0)
                _current = _compositeStack.Peek();
            else
                _current = null;

            return this;
        }

        public BehaviourTreeBuilder Sequence()
        {
            Composite composite = new Sequence(this, blackBoard);
            AttachAsChild(_current, composite);
            _compositeStack.Push(composite);
            _current = composite;
            return this;
        }

        public BehaviourTreeBuilder Selector()
        {
            Composite composite = new Selector(this, blackBoard);
            AttachAsChild(_current, composite);
            _compositeStack.Push(composite);
            _current = composite;
            return this;
        }

        public BehaviourTreeBuilder Parallel(Parallel.Policy successPolicy)
        {
            Composite composite = new Parallel(this, blackBoard, successPolicy);
            AttachAsChild(_current, composite);
            _compositeStack.Push(composite);
            _current = composite;
            return this;
        }

        private void AttachAsChild(Node parent, Node child)
        {
            if (parent is IParentOfChild)
            {
                ((IParentOfChild)parent).child = child;
            }
            else if (parent is IParentOfChildren)
            {
                ((IParentOfChildren)parent).children.Add(child);
            }
            else
            {
                throw new Exception($"[BehaviourTreeBuilder] : You cannot attach child to {parent.GetType()}");
            }
        }
    }
}