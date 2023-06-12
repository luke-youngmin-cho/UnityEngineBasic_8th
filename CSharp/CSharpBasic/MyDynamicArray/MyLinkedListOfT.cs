using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Prev;
        public Node<T> Next;

        public Node(T value)
        {
            Value = value;
        }
    }

    public class MyLinkedList<T> : IEnumerable<T>
    {
        public Node<T> First => _first;
        private Node<T> _first;

        public Node<T> Last => _last;
        private Node<T> _last;

        private Node<T> _tmp;

        /// <summary>
        /// 삽입 알고리즘 (가장 앞에 삽입)
        /// O(1)
        /// </summary>
        public void AddFirst(T value)
        {
            _tmp = new Node<T>(value);

            // 노드가 만약 하나 이상 존재한다면
            if (_first != null)
            {
                _tmp.Next = _first;
                _first.Prev = _tmp;
            }
            else
            {
                _last = _tmp;
            }

            _first = _tmp;
        }

        /// <summary>
        /// 삽입 알고리즘 (가장 뒤에 삽입)
        /// O(1)
        /// </summary>
        public void AddLast(T value)
        {
            _tmp = new Node<T>(value);

            // 노드가 만약 하나 이상 존재한다면
            if (_last != null)
            {
                _tmp.Prev = _last;
                _last.Next = _tmp;
            }
            else
            {
                _first = _tmp;
            }

            _last = _tmp;
        }

        /// <summary>
        /// 삽입 알고리즘 (특정 노드 앞에 삽입)
        /// O(1)
        /// </summary>
        /// <param name="node"> 기준 노드 </param>
        /// <param name="value"> 삽입하려는 노드의 값 </param>
        public void AddBefore(Node<T> node, T value)
        {
            _tmp = new Node<T>(value);

            if (node.Prev != null)
            {
                node.Prev.Next = _tmp;
                _tmp.Prev = node.Prev;
            }
            else
            {
                _first = _tmp;
            }

            node.Prev = _tmp;
            _tmp.Next = node;
        }

        /// <summary>
        /// 삽입 알고리즘 (특정 노드 뒤에 삽입)
        /// O(1)
        /// </summary>
        /// <param name="node"> 기준 노드 </param>
        /// <param name="value"> 삽입하려는 노드의 값 </param>
        public void AddAfter(Node<T> node, T value)
        {
            _tmp = new Node<T>(value);

            if (node.Next != null)
            {
                node.Next.Prev = _tmp;
                _tmp.Next = node.Next;
            }
            else
            {
                _last = _tmp;
            }

            node.Next = _tmp;
            _tmp.Prev = node;
        }

        public Node<T> Find(T value)
        {
            _tmp = _first;
            while (_tmp != null)
            {
                if (Comparer<T>.Default.Compare(_tmp.Value, value) == 0)
                    return _tmp;

                _tmp = _tmp.Next;
            }
            return null;
        }

        public Node<T> FindLast(T value)
        {
            _tmp = _last;
            while (_tmp != null)
            {
                if (Comparer<T>.Default.Compare(_tmp.Value, value) == 0)
                    return _tmp;

                _tmp = _tmp.Prev;
            }
            return null;
        }

        public bool Remove(Node<T> node)
        {
            if (node == null)
            {
                return false;
            }
            else
            {
                if (node.Prev != null)
                    node.Prev.Next = node.Next;
                else
                    _first = node.Next;

                if (node.Next != null)
                    node.Next.Prev = node.Prev;
                else
                    _last = node.Prev;

                return true;
            }
        }

        public bool Remove(T value)
        {
            return Remove(Find(value));
        }

        public bool RemoveLast(T value)
        {
            return Remove(FindLast(value));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(_first);
        }

        public struct Enumerator : IEnumerator<T>
        {
            public T Current => _currentNode.Value;

            object IEnumerator.Current => _currentNode.Value;

            private Node<T> _currentNode;
            private Node<T> _first;

            public Enumerator(Node<T> first)
            {
                _first = first;
                _currentNode = null;
                _firstFlag = false;
            }

            public bool FirstFlag
            {
                get => _firstFlag;
                set
                {
                    if (value)
                        _currentNode = _first;

                    _firstFlag = value;
                }
            }
            private bool _firstFlag;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_firstFlag == false)
                    FirstFlag = true;
                else
                    _currentNode = _currentNode.Next;

                return _currentNode != null;
            }

            public void Reset()
            {
                _currentNode = null;
                FirstFlag = false;
            }
        }
    }
}
