using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsHomework
{
    public class Node<T> : ICollection<T>
    {
        private T? _Data;

        public T Data
        {
            get
            {
                return _Data!;
            }
            private set
            {
                _Data = value ??
                    throw new ArgumentNullException(nameof(value));
            }
        }

        private Node<T>? _Next;

        public Node<T> Next
        {
            get
            {
                return _Next!;
            }
            private set
            {
                value._Next = this;
                _Next = value ??
                    throw new ArgumentNullException(nameof(value));
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

        public Node(T value)
        {
            Data = value;
            Next = this;
        }

        public override string ToString()
        {
            if (Data is null) 
                throw new ArgumentNullException(nameof(Data));

            return Data.ToString()!;
        }

        public void Insert(T value)
        {
            Node<T> newNode = new(value);
            Next = newNode;
        }

        public void Clear()
        {
            Next = this;
        }

        public void Add(T item)
        {
            Insert(item);
        }

        public bool Contains(T item)
        {
            if (Data is null && item is null || this.Data != null && this.Data.Equals(item))
                return true;
            else
            {
                Node<T> cur = Next;
                while (cur != this)
                {
                    if ((cur.Data is null && item is null) || (cur.Data is not null && cur.Data.Equals(item)))
                        return true;
                    cur = cur.Next;
                }
            }
            return false;
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
                array[arrayIndex] = cur.Data;
                cur = cur.Next;
                isHead = false;
                arrayIndex++;
            }
        }

        public bool Remove(T item)
        {
            Node<T> prev = this;
            Node<T> cur = Next;

            if (Data is null && item is null || Data is not null && Data.Equals(item))
                return true;

            while (cur != this)
            {
                if ((cur.Data is null && item is null) || (cur.Data is not null && cur.Data.Equals(item)))
                {
                    prev = cur.Next;
                    return true;
                }
                else
                {
                    prev = cur;
                    cur = cur.Next;
                }
            }
            return false;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> cur = this;

            yield return cur.Data;
            
            for (cur = this.Next; cur != this; cur = cur.Next)
                yield return cur.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
