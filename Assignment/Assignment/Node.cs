using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    public class Node<T> : IEnumerable<T>
    {
        private Node<T> _Next;

        public Node(T value)
        {
            Value = value;
            _Next = this;
        }

        public T Value { get; private set; }

        public Node<T> Next
        {
            get
            {
                return _Next;
            }

            private set
            {
                _Next = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public int Count
        {
            get
            {
                return GetArrayLength();
            }
        }

        public int GetArrayLength()
        {
            Node<T> cur = Next;
            int count = 1;

            while (cur != this)
            {
                cur = cur.Next;
                count++;
            }
            return count;
        }

        public bool IsReadOnly
        {
            get;
        }

        public override string ToString()
        {
            if (Value is null)
                throw new ArgumentNullException(nameof(Value));

            return Value.ToString()!;
        }
        
        public void Insert(T value)
        {
            if (Next == this)
            {
                Next = new Node<T>(value)
                {
                    Next = this
                };
            }
            else
            {
                Node<T> temp = Next;
                while (temp.Next != this)
                {
                    temp = temp.Next.Next;
                }
                temp.Next = new Node<T>(value)
                {
                    Next = this
                };
            }
        }

        //No need to worry about garbage collection in the case of a circular list, garbage collector handles circular references
        public void Clear()
        {
            Next = this;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> cur = this;
            do
            {
                yield return cur.Value;
                cur = cur.Next;
            } while (cur != this);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            if (arrayIndex < 0 || arrayIndex > array.Length - 1)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            Node<T> cur = this;
            bool isHead = true;

            while (cur != this || isHead)
            {
                array[arrayIndex] = cur.Value;
                cur = cur.Next;
                isHead = false;
                arrayIndex++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> ChildItems(int maximum)
        {
            return this.AsEnumerable<T>().Take(maximum);
        }
    }
}
