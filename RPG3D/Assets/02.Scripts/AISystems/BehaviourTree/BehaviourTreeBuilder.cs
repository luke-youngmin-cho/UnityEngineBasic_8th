using System;
using System.Collections.Generic;

namespace RPG.AISystems.BehaviourTree
{
    public class EnemySample
    {
        private void Start()
        {
            BehaviourTreeBuilder builder = new BehaviourTreeBuilder();
            builder.StartBuild()
                .Condition(() => true)
                    .Selector()
                        .Execution(() => Result.Success)
                        .Condition(() => true)
                            .Execution(() => Result.Success)
                        .Sequence()
                            .Condition(() => true)
                                .Execution(() => Result.Success)
                            .Execution(() => Result.Success)
                        .ExitCurrentComposite()
                        .Execution(() => Result.Success);
        }
    }


    public class BehaviourTreeBuilder
    {
        private Node _current;
        private Stack<Composite> _compositeStack = new Stack<Composite>();

        public BehaviourTreeBuilder StartBuild()
        {
            Node node = new Root();
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
            Node node = new Condition(condition);
            AttachAsChild(_current, node);
            _current = node;
            return this;
        }

        public BehaviourTreeBuilder Execution(Func<Result> execute)
        {
            Node node = new Execution(execute);
            AttachAsChild(_current, node);

            if (_compositeStack.Count > 0)
                _current = _compositeStack.Peek();
            else
                _current = null;

            return this;
        }

        public BehaviourTreeBuilder Sequence()
        {
            Composite composite = new Sequence();
            AttachAsChild(_current, composite);
            _compositeStack.Push(composite);
            _current = composite;
            return this;
        }

        public BehaviourTreeBuilder Selector()
        {
            Composite composite = new Selector();
            AttachAsChild(_current, composite);
            _compositeStack.Push(composite);
            _current = composite;
            return this;
        }

        public BehaviourTreeBuilder Parallel(Parallel.Policy successPolicy)
        {
            Composite composite = new Parallel(successPolicy);
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