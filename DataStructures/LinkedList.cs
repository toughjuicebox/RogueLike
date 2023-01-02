namespace ProcQuest
{
    public class LinkedList<T> where T : IComparable<T>
    {
        public int Size { get; set; }
        public Node<T> Head;
        public Node<T> Tail;
        
        public LinkedList()
        {
            Clear();
        }
        
        public bool IsEmpty() => Size == 0;
        
        public void Clear()
        {
            this.Size = 0;
            this.Head = null;
            this.Tail = null;
        }
        
        public T GetFirst()
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }
            return this.Head.Element;
        }

        public T GetLast()
        {
            if (this.Size == 0)
            {
                throw new ApplicationException();
            }
            return this.Tail.Element;
        }
        
        public void AddFirst(T element)
        {
            Node<T> newNode = new Node<T>(element, previousNode: null, nextNode: this.Head);

            if (IsEmpty())
            {
                this.Tail = newNode;
            }
            else
            {
                this.Head.Previous = newNode;
            }

            this.Head = newNode;
            this.Size++;
        }

        public void AddLast(T element)
        {
            Node<T> newNode = new Node<T>(element, previousNode: this.Tail, nextNode: null);

            if (IsEmpty())
            {
                this.Head = newNode;
            }
            else
            {
                this.Tail.Next = newNode;
            }

            this.Tail = newNode;
            this.Size++;
        }
        
        public T SetFirst(T element)
        {
            T oldElement = GetFirst();
            this.Head.Element = element;
            return oldElement;
        }

        public T SetLast(T element)
        {
            T oldElement = GetLast();
            this.Tail.Element = element;
            return oldElement;
        }
        
        public T RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }
            T oldElement = this.Head.Element;
            if (this.Size == 1)
            {
                Clear();
                return oldElement;
            }
            this.Head = this.Head.Next;
            this.Head.Previous = null;
            this.Size--;
            return oldElement;
        }

        public T RemoveLast()
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }
            T oldElement = this.Tail.Element;
            if (this.Size == 1)
            {
                Clear();
                return oldElement;
            }
            this.Tail = this.Tail.Previous;
            this.Tail.Next = null;
            this.Size--;
            return oldElement;
        }
        
        public T Get(int position)
        {
            return GetNodeByPosition(position).Element;
        }

        public T Remove(int position)
        {
            Node<T> currentNode = GetNodeByPosition(position);
            if (this.Size == 1)
            {
                Clear();
                return currentNode.Element;
            }
            if (currentNode == Head)
            {
                this.Head = currentNode.Next;
                currentNode.Next.Previous = currentNode.Previous;
            }
            else if (currentNode == Tail)
            {
                this.Tail = currentNode.Previous;
                currentNode.Previous.Next = currentNode.Next;
            }
            else
            {
                currentNode.Next.Previous = currentNode.Previous;
                currentNode.Previous.Next = currentNode.Next;
            }
            currentNode.Next = null;
            currentNode.Previous = null;
            this.Size--;
            return currentNode.Element;
        }

        public T Set(T element, int position)
        {
            T oldElement = GetNodeByPosition(position).Element;
            GetNodeByPosition(position).Element = element;
            return oldElement;
        }
        
        public void AddBefore(T element, int position)
        {
            Node<T> currentNode = GetNodeByPosition(position);
            if (position == 1)
            {
                AddFirst(element);
            }
            else
            {
                Node<T> newNode = new Node<T>(element, currentNode.Previous, currentNode);
                currentNode.Previous.Next = newNode;
                currentNode.Previous = newNode;
                this.Size++;
            }
        }

        public void AddAfter(T element, int position)
        {
            Node<T> currentNode = GetNodeByPosition(position);
            if (position == this.Size)
            {
                AddLast(element);
            }
            else
            {
                Node<T> newNode = new Node<T>(element, currentNode, currentNode.Next);
                currentNode.Next.Previous = newNode;
                currentNode.Next = newNode;
                this.Size++;
            }
        }

        public T Get(T element)
        {
            return GetNodeByElement(element).Element;
        }

        public void AddAfter(T element, T oldElement)
        {
            Node<T> currentNode = GetNodeByElement(oldElement);
            AddNode(element, currentNode, currentNode.Next);
        }

        private void AddNode(T element, Node<T> before, Node<T> after)
        {
            Node<T> newNode = new Node<T>(element, before, after);

            if (before == null) Head = newNode;
            else before.Next = newNode;

            if (after == null) Tail = newNode;
            else after.Previous = newNode;

            this.Size++;
        }

        public void AddBefore(T element, T oldElement)
        {
            Node<T> currentNode = GetNodeByElement(oldElement);
            if (currentNode.Previous == null)
            {
                AddFirst(element);
            }
            else
            {
                Node<T> newNode = new Node<T>(element, currentNode, currentNode.Next);
                currentNode.Previous.Next = newNode;
                currentNode.Previous = newNode;
                this.Size++;
            }
        }

        public T Remove(T element)
        {
            Node<T> currentNode = GetNodeByElement(element);
            return RemoveNode(currentNode);

        }

        private T RemoveNode(Node<T> currentNode)
        {
            Node<T> before = currentNode.Previous;
            Node<T> after = currentNode.Next;

            if (before == null) Head = after;
            else before.Next = after;

            if (after == null) Tail = before;
            else after.Previous = before;

            this.Size--;
            return currentNode.Element;
        }

        public T Set(T element, T oldElement)
        {
            Node<T> currentNode = GetNodeByElement(oldElement);
            T olderElement = currentNode.Element;
            currentNode.Element = element;
            return olderElement;
        }

        public void Insert(T element)
        {
            Node<T> currentNode = this.Head;
            int position = 1;
            for (int i = 0; i < this.Size; i++)
            {
                if (element.CompareTo(currentNode.Element) == -1 || element.CompareTo(currentNode.Element) == 0)
                {
                    break;
                }
                currentNode = currentNode.Next;
                position++;
            }
            if (currentNode == null)
            {
                AddLast(element);
            }
            else
            {
                AddNode(element, currentNode.Previous, currentNode);
            }
        }

        public void SortAscending()
        {
            Node<T> node = Head;
            Clear();

            while (node != null)
            {
                Insert(node.Element);
                node = node.Next;
            }
        }

        private Node<T> GetNodeByPosition(int position)
        {
            if (position <= 0 || position > this.Size)
            {
                throw new ApplicationException();
            }
            Node<T> currentNode = this.Head;
            for (int i = 1; i < this.Size; i++)
            {
                if (i == position)
                {
                    break;
                }
                currentNode = currentNode.Next;
            }
            return currentNode;
        }

        private Node<T> GetNodeByElement(T element)
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }
            if (element == null) throw new ArgumentNullException();

            Node<T> currentNode = this.Head;

            while (currentNode != null && currentNode.Element.CompareTo(element) != 0)
            {
             
                currentNode = currentNode.Next;
            }
            if (currentNode == null)
            {
                throw new ApplicationException();
            }
            return currentNode;
        }
    }
}
