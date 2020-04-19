using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures
{
    class LinkedList<T>
    {
        private class Node
        {
            private T _data;
            public T data => _data;
            private Node _next;
            public Node next
            {
                get => _next;
                set => _next = value;
            }
            public Node(T value)
            {
                next = null;
                _data = value;
            }
        }
        private Node head;
        public LinkedList()
        {
            head = null;
        }
        public void PushFront(T value)
        {
            Node n = new Node(value);
            n.next = head;
            head = n;
        }
        public T TopFront()
        {
            return head.data;
        }
        public T PopFront()
        {
            if (Empty()) throw new NullReferenceException("List is empty");
            T value = head.data;
            head = head.next;
            return value;
        }
        public bool Empty()
        {
            return head == null ? true : false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while(current!=null)
            {
                yield return current.data;
                current = current.next;
            }
        }


    }
    class Stack<T>
    {
        private LinkedList<T> list;

        public Stack()
        {
            list = new LinkedList<T>();
        }
        public void Push(T value)
        {
            list.PushFront(value);
        }
        public T Pop()
        {
            return list.PopFront();
        }

        public T Top()
        {
            return list.TopFront();
        }
        public bool Empty()
        {
            return list.Empty();
        }

    }

}
