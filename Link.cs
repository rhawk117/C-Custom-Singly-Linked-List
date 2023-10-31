using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anotherlinkedlist
{
    class Link<T>
    {
        private class Node
        {
            public T data { get; set; }
            public Node next { get; set; }
            public Node(T data, Node next)
            {
                this.data = data;
                this.next = next;
            }
        }
        private Node first;
        // Methods 
        // Constructor
        // +AddFirst, +AddLast, TryAddAt
        // Clear, Contains, IndexOf, LastIndexOf, GetLength
        // +RemoveFirst, RemoveLast, TryRemoveAt
        public Link()
        {
            this.first = null;
        }
        public bool isEmpty
        {
            get => this.first == null;
        }
        public void Clear()
        { 
            this.first = null; 
        }
        public void Display()
        {
            Node current = this.first;
            int indexer = 0;
            while(current != null)
            {
                Console.Write("| {0} | {1} |->", indexer, current.data);
                indexer++;
                current = current.next;
            }
            Console.Write("(null) |\n");
        }
        public T AddFirst(T data)
        {
            this.first = new Node(data, this.first);
            return data;
        }
        public T AddLast(T data)
        {
            if(isEmpty)
            {
                AddFirst(data);
                return data;
            }
            Node current = this.first;
            while(current.next != null)
                current = current.next;
            current.next = new Node(data, null);
            return data;
        }

        public T RemoveFirst()
        {
            if (!isEmpty)
            {
                T del_node = first.data;
                first = first.next;
                return del_node;
            }
            else
                throw new Exception("ERROR -> List is Empty try adding a node before removing");
        }
        public T RemoveLast()
        {
            if(isEmpty)
                throw new Exception("ERROR -> List is Empty try adding a node before removing");
            else if(first.next == null)
            {
                T node_data = first.data;
                RemoveFirst();
                return node_data;
            }
            else
            {
                Node current = first;
                while(current != null && current.next.next != null)
                    current = current.next;
                T data = current.next.data;
                current.next = null;
                return data;
            }
        }
        public bool TryAddAt(int pos,T data)
        {
            if(isEmpty || pos < 0)
            {
                return false;
            }
            else if(pos.Equals(0))
            {
                AddFirst(data); 
                return true;
            }
            else
            {
                Node current = this.first;
                int indexer = 1;
                while (current != null && indexer < pos)
                {
                    indexer++;
                    current = current.next;
                }
                if (current != null)
                {
                    current.next = new Node(data, current.next);
                    return true;
                }
                else
                    return false;
            }
        }
        public bool TryRemoveAt(int pos)
        {
            if (isEmpty || pos < 0)
                return false;
            else if (pos.Equals(0))
            {
                if (this.first.next != null)
                {
                    RemoveFirst();
                    return true;
                }
                else
                {
                    Clear();
                    return false;
                }
            }
            else
            {
                Node current = this.first;
                int indexer = 0;
                while (indexer < pos - 1 && current.next != null)
                {
                    indexer++;
                    current = current.next;
                }
                if (current.next != null)
                {
                    current.next = current.next.next;
                    return true;
                }
                else
                    return false;
            }
        }
        public bool Contains(T match)
        {
            if(isEmpty)
                return false;
            else
            {
                Node current = this.first;
                while(current != null)
                {
                    if(current.data.Equals(match))
                        return true;
                    current = current.next;
                }
                return false;
            }
        }
        public int LastIndexOf(T match)
        {
            int lastIndex = -1;
            if (isEmpty)
                return lastIndex;
            else
            {
                Node current = this.first;
                int indexer = 0;
                while(current != null )
                {
                    if (current.data.Equals(match))
                    {
                        lastIndex = indexer;
                    }
                    indexer++;
                    current= current.next;
                }
                return lastIndex;
            }
        }
        public int IndexOf(T match)
        {
            if(isEmpty)
                return -1;
            else
            {
                Node current = this.first;
                int indexer = 0;    
                while(current != null)
                {
                    if(current.data.Equals(match))
                        return indexer;
                    indexer++;
                    current= current.next;
                }
                return -1;
            }
        }
        public void Reverse()
        {
            Node prev = null;
            Node cur = this.first;
            Node next;
            while( cur != null )
            {
                next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
            }
            this.first = prev;
            Display();
        }
        // 1->2->3->1
        public int Distance(T match)
        {
            if(first == null)
                return -1;
            else
            {
                Node cur = this.first;
                while(cur != null && cur.next != null)

                {
                    int distance = 1;
                    Node pTmp = cur.next;
                    if(cur.data.Equals(match))
                    {
                        while(pTmp != null)
                        {
                            if (pTmp.data.Equals(match))
                                return distance;
                            distance++;
                            pTmp = pTmp.next;
                        }
                    }
                    cur = cur.next;
                }
                return -1;
            }
        }
    }
}
